using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Diagnostics;
using System.Xml;
using ExcelLibrary.SpreadSheet;

namespace Briefcase
{

    public partial class MainForm : KryptonForm
    {
        // Added exporting to XLS
        //public const string VERSION = "1.20";

        // Added conversion of PSGC to NAME
        //public const string VERSION = "1.21 (10-17-2014)";

        // Added hh_id and uct_form_id to every worksheet
        public const string VERSION = "1.22 (10-23-2014)";


        protected const string ODK_SETTINGS_FILE = @"\odk\settings\collect.settings";
        protected string ODK_DESTINATION;
        protected string ODK_SOURCE;


        private DataSet dsPSGC = new DataSet();

        public MainForm()
        {
            InitializeComponent();
            Init();
        }




        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportXLS();
        }


        private void lnkDataDir_LinkClicked(object sender, EventArgs e)
        {
            Process.Start(ODK_DESTINATION);
        }


        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Download();
        }





        private void Init()
        {
            this.Text = this.Text + " - v" + VERSION;
            ODK_DESTINATION = Environment.CurrentDirectory + @"\data\download\" ;
            
            WatchODK();

            dsPSGC.ReadXml(Environment.CurrentDirectory + @"\data\shared\psgc.xml");

        }


        private void Download()
        {
            if (cmbODKDrive.SelectedItem == null || cmbTabletID.SelectedItem == null)
                return;

            string from = cmbODKDrive.SelectedItem + @"\odk";
            string to = ODK_DESTINATION + cmbTabletID.Text;

            DirectoryInfo fromDir = new DirectoryInfo(from);
            DirectoryInfo toDir = new DirectoryInfo(to);

            CopyAll(fromDir, toDir);

            MessageBox.Show("Data from " + cmbTabletID.Text + " was downloaded successfully", "Done");

        }


        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void WatchODK()
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += delegate
            {
                FindODKFolders();
            };
            t.Start();
        }

        private void FindODKFolders()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string file = drive.Name + ODK_SETTINGS_FILE;
                System.Diagnostics.Debug.WriteLine(file + " - " + System.IO.File.Exists(file));
                if (System.IO.File.Exists(file))
                {
                    // add drive
                    if (cmbODKDrive.Items.IndexOf(drive.Name) == -1)
                        cmbODKDrive.Items.Add(drive.Name);
                }
                else
                {
                    if (cmbODKDrive.Items.IndexOf(drive.Name) > -1)
                        cmbODKDrive.Items.Remove(drive.Name);
                }
            }
        }

        private void ExportXLS()
        {
            DataSet ds;
            if (optControl.Checked)
                ds = GetControlForm();
            else
                ds = GetDefaultForm();

            SaveFileDialog dialog = new SaveFileDialog();
            
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.FileName = String.Format("export{6}_{0}-{1}-{2}_{3}-{4}-{5}.xls", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second,(optControl.Checked?"_control":""));
            dialog.FileOk += delegate
            {
                CreateWorkbook(dialog.FileName, ds);
                FileInfo f = new FileInfo(dialog.FileName);
                File.Copy(dialog.FileName, Environment.CurrentDirectory + @"\data\export\" + f.Name, true);
            };
            dialog.ShowDialog();
        }

        private DataSet GetControlForm()
        {
            return XMLtoDS(true);
        }

        private DataSet GetDefaultForm()
        {
            return XMLtoDS(false);
        }

        private DataSet XMLtoDS(bool control = false)
        {
            DataSet ds = new DataSet("DataSet");
            ds.EnforceConstraints = false;

            int uct_form_id = 0;

            // prepare structure of tables
            ds.ReadXmlSchema(Environment.CurrentDirectory + String.Format(@"\data\shared\{0}", (control ? "schema_control.xsd" : "schema.xsd")));

            // get all xml files
            DirectoryInfo destinationDir = new DirectoryInfo(ODK_DESTINATION);

            DirectoryInfo[] tabletDirs = destinationDir.GetDirectories();

            foreach (DirectoryInfo tabletDir in tabletDirs)
            {
                foreach (DirectoryInfo instancesDir in tabletDir.GetDirectories("instances"))
                {
                    FileInfo[] xmlFiles = instancesDir.GetFiles(@"uct_form*.xml", SearchOption.AllDirectories);
 
                    foreach (FileInfo f in xmlFiles)
                    {

                        DataSet dsTemp = new DataSet();
                        dsTemp.ReadXmlSchema(Environment.CurrentDirectory + String.Format(@"\data\shared\{0}", (control ? "schema_control.xsd" : "schema.xsd")));

                        if (f.FullName.Contains("uct_form_control") && !control)
                            continue;
                        if (!f.FullName.Contains("uct_form_control") && control)
                            continue;

                        dsTemp.ReadXml(f.FullName, XmlReadMode.InferSchema);
                        
                        
                        // do any necessary transformations
                        string uct_form_id_name = (control ? "uct_form_control_id" : "uct_form_id");
                        object hh_id = "";
                        if (dsTemp.Tables["S1.2"].Rows.Count > 0)
                            hh_id = dsTemp.Tables["S1.2"].Rows[0]["hh_id"];
                        uct_form_id++;

                        AddAdditionalData(dsTemp, hh_id, uct_form_id, uct_form_id_name, f.DirectoryName);
                        

                        // merge to main DS
                        ds.Merge(dsTemp,false, MissingSchemaAction.Ignore);


                        /*
                        if(f.FullName.Contains("uct_form_control") && control)
                            ds.ReadXml(f.FullName);
                        if (!f.FullName.Contains("uct_form_control") && !control)
                            ds.ReadXml(f.FullName);
                        */

                    }
                }

            }
            return ds;
        }

        private void AddAdditionalData(DataSet ds, object hh_id, int uct_form_id, string uct_form_id_name, string dir)
        {
            foreach (DataTable dt in ds.Tables)
            {
                if (!dt.Columns.Contains("hh_id"))
                    dt.Columns.Add("hh_id");
                if (!dt.Columns.Contains(uct_form_id_name))
                    dt.Columns.Add(new DataColumn(uct_form_id_name, typeof(int)));

                foreach (DataRow dr in dt.Rows)
                {
                    dr["hh_id"] = hh_id;
                    dr[uct_form_id_name] = uct_form_id;

                    if (dt.TableName == "meta")
                        dr["directory"] = dir;

                    if (dt.TableName == "S1.2")
                    {
                        dr["photo"] = @"file:///" + dir + @"\" + dr["Q2.5"];
                    }

                }

                

            }
        }


        private void CreateWorkbook(String filePath, DataSet dataset)
        {
            if (dataset.Tables.Count == 0)
                throw new ArgumentException("DataSet needs to have at least one DataTable", "dataset");

            Workbook workbook = new Workbook();
            int lastRow = 0;

            foreach (DataTable dt in dataset.Tables)
            {
                Worksheet worksheet = new Worksheet(dt.TableName);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    // Add column header
                    worksheet.Cells[0, i] = new Cell(dt.Columns[i].ColumnName);

                    // Populate row data
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        //object value = dt.Rows[j][i];
                        object value = ProcessData(dt.Columns[i].ColumnName, dt.Rows[j][i]);

                        worksheet.Cells[j + 1, i] = new Cell(dt.Rows[j][i] == DBNull.Value ? "" : value);
                    }
                }
                workbook.Worksheets.Add(worksheet);
            }
            // fix bug as described here: https://code.google.com/p/excellibrary/issues/detail?id=60
            for (int i = 0; i < 150; i++)
            {
                workbook.Worksheets[0].Cells[workbook.Worksheets[0].Cells.LastRowIndex + 1, 0] = new Cell("");
            }
            workbook.Save(filePath);
        }


        private object ProcessData(string columnName, object value)
        {
            if (columnName == "Q1.1" || columnName == "Q1.2" || columnName == "Q26" || columnName == "Q29" || columnName == "Q35" || columnName == "Q36.2")
            {
                DataRow[] drRows = dsPSGC.Tables[0].Select("PSGC='" + value + "'");
                if(drRows.Length ==0)
                    return "Did not find " + value + " in PSGC";
                return drRows[0]["NAME"];
            }

            return value;
        }



        private void GeneratePhotoIndex()
        {

        }


        // from: http://www.codeproject.com/Articles/15460/C-Image-to-Byte-Array-and-Byte-Array-to-Image-Conv
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        // from: http://stackoverflow.com/questions/6826390/how-to-convert-image-to-data-uri-for-html-with-c
        public static string GetDataURL(string imgFile)
        {
            return "<img src=\"data:image/"
                        + Path.GetExtension(imgFile).Replace(".", "")
                        + ";base64,"
                        + Convert.ToBase64String(File.ReadAllBytes(imgFile)) + "\" />";
        }

    }
}
