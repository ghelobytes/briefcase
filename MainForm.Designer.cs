namespace Briefcase
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPull = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lnkDataDir = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnDownload = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbODKDrive = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.cmbTabletID = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tabExport = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.optControl = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.optNonControl = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnExportExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPull)).BeginInit();
            this.tabPull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTabletID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabExport)).BeginInit();
            this.tabExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Padding = new System.Windows.Forms.Padding(20);
            this.kryptonPanel.Size = new System.Drawing.Size(358, 281);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.RoundedOutsizeLarge;
            this.kryptonNavigator1.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.StandardProfile;
            this.kryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(20, 20);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPull,
            this.tabExport});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(318, 241);
            this.kryptonNavigator1.TabIndex = 7;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // tabPull
            // 
            this.tabPull.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPull.Controls.Add(this.kryptonPanel1);
            this.tabPull.Flags = 65534;
            this.tabPull.LastVisibleSet = true;
            this.tabPull.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPull.Name = "tabPull";
            this.tabPull.Size = new System.Drawing.Size(316, 214);
            this.tabPull.Text = "Download";
            this.tabPull.ToolTipTitle = "Page ToolTip";
            this.tabPull.UniqueName = "FB3974C810E3473408AF9858CB2C18E3";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lnkDataDir);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.btnDownload);
            this.kryptonPanel1.Controls.Add(this.cmbODKDrive);
            this.kryptonPanel1.Controls.Add(this.cmbTabletID);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(316, 214);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lnkDataDir
            // 
            this.lnkDataDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDataDir.Location = new System.Drawing.Point(163, 191);
            this.lnkDataDir.Name = "lnkDataDir";
            this.lnkDataDir.Size = new System.Drawing.Size(150, 20);
            this.lnkDataDir.TabIndex = 7;
            this.lnkDataDir.Values.Text = "Show download directory";
            this.lnkDataDir.LinkClicked += new System.EventHandler(this.lnkDataDir_LinkClicked);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(35, 27);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Tablet ID";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(36, 58);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Source drive";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(133, 123);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(93, 29);
            this.btnDownload.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDownload.StateCommon.Border.Rounding = 5;
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Values.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // cmbODKDrive
            // 
            this.cmbODKDrive.Location = new System.Drawing.Point(120, 58);
            this.cmbODKDrive.Name = "cmbODKDrive";
            this.cmbODKDrive.Size = new System.Drawing.Size(120, 54);
            this.cmbODKDrive.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbODKDrive.StateCommon.Border.Rounding = 5;
            this.cmbODKDrive.TabIndex = 6;
            // 
            // cmbTabletID
            // 
            this.cmbTabletID.DropDownHeight = 100;
            this.cmbTabletID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabletID.DropDownWidth = 121;
            this.cmbTabletID.Items.AddRange(new object[] {
            "Tablet01",
            "Tablet02",
            "Tablet03",
            "Tablet04",
            "Tablet05",
            "Tablet06",
            "Tablet07",
            "Tablet08",
            "Tablet09",
            "Tablet10",
            "Tablet11",
            "Tablet12",
            "Tablet13",
            "Tablet14",
            "Tablet15",
            "Tablet16",
            "Tablet17",
            "Tablet18",
            "Tablet19",
            "Tablet20",
            "Tablet21",
            "Tablet22",
            "Tablet23",
            "Tablet24",
            "Tablet25",
            "Tablet26",
            "Tablet27",
            "Tablet28",
            "Tablet29",
            "Tablet30"});
            this.cmbTabletID.Location = new System.Drawing.Point(119, 27);
            this.cmbTabletID.Name = "cmbTabletID";
            this.cmbTabletID.Size = new System.Drawing.Size(121, 25);
            this.cmbTabletID.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbTabletID.StateCommon.ComboBox.Border.Rounding = 5;
            this.cmbTabletID.TabIndex = 1;
            this.cmbTabletID.TabStop = false;
            // 
            // tabExport
            // 
            this.tabExport.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabExport.Controls.Add(this.kryptonPanel2);
            this.tabExport.Flags = 65534;
            this.tabExport.LastVisibleSet = true;
            this.tabExport.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(316, 214);
            this.tabExport.Text = "Export";
            this.tabExport.ToolTipTitle = "Page ToolTip";
            this.tabExport.UniqueName = "31FCF77C5B6A4720AEBC4791A12E81DB";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.optControl);
            this.kryptonPanel2.Controls.Add(this.optNonControl);
            this.kryptonPanel2.Controls.Add(this.btnExportExcel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(316, 214);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // optControl
            // 
            this.optControl.Location = new System.Drawing.Point(76, 53);
            this.optControl.Name = "optControl";
            this.optControl.Size = new System.Drawing.Size(127, 20);
            this.optControl.TabIndex = 3;
            this.optControl.Values.Text = "Export control data";
            // 
            // optNonControl
            // 
            this.optNonControl.Checked = true;
            this.optNonControl.Location = new System.Drawing.Point(75, 79);
            this.optNonControl.Name = "optNonControl";
            this.optNonControl.Size = new System.Drawing.Size(153, 20);
            this.optNonControl.TabIndex = 2;
            this.optNonControl.Values.Text = "Export non-control data";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(112, 138);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(93, 29);
            this.btnExportExcel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportExcel.StateCommon.Border.Rounding = 5;
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Values.Text = "Export as XLS";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 281);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Briefcase";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPull)).EndInit();
            this.tabPull.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTabletID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabExport)).EndInit();
            this.tabExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDownload;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbTabletID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox cmbODKDrive;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPull;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabExport;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lnkDataDir;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExportExcel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton optControl;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton optNonControl;

    }
}

