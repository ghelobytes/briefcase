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
        public const string VERSION = "1.21 (10-17-2014)";


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
                File.Copy(dialog.FileName, Environment.CurrentDirectory + @"\data\export\" + f.Name);
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

            // prepare structure of tables
            ds.ReadXmlSchema(Environment.CurrentDirectory + @"\data\shared\schema.xsd");

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
          
                        if(f.FullName.Contains("uct_form_control") && control)
                            ds.ReadXml(f.FullName);
                        if (!f.FullName.Contains("uct_form_control") && !control)
                            ds.ReadXml(f.FullName);
                    }
                }

            }
            return ds;
        }

        private void CreateWorkbook(String filePath, DataSet dataset)
        {
            if (dataset.Tables.Count == 0)
                throw new ArgumentException("DataSet needs to have at least one DataTable", "dataset");

            Workbook workbook = new Workbook();
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

    }
}
