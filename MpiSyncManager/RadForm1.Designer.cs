namespace MpiSyncManager
{
    partial class RadForm1
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm1));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.lblTimer = new Telerik.WinControls.UI.RadLabel();
            this.cmdLogPrint = new Telerik.WinControls.UI.RadButton();
            this.cmdPreview = new Telerik.WinControls.UI.RadButton();
            this.cmdPause = new Telerik.WinControls.UI.RadButton();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.gridListMpiSync = new Telerik.WinControls.UI.RadGridView();
            this.tmrPrint = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLogPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListMpiSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListMpiSync.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.EnableAnalytics = false;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(792, 570);
            this.radSplitContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            this.radSplitContainer1.ThemeName = "Windows8";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.lblTimer);
            this.splitPanel1.Controls.Add(this.cmdLogPrint);
            this.splitPanel1.Controls.Add(this.cmdPreview);
            this.splitPanel1.Controls.Add(this.cmdPause);
            this.splitPanel1.EnableAnalytics = false;
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MaxSize = new System.Drawing.Size(2400, 46);
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(800, 46);
            this.splitPanel1.Size = new System.Drawing.Size(800, 46);
            this.splitPanel1.SizeInfo.AbsoluteSize = new System.Drawing.Size(800, 46);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.4134276F);
            this.splitPanel1.SizeInfo.MaximumSize = new System.Drawing.Size(2400, 46);
            this.splitPanel1.SizeInfo.MinimumSize = new System.Drawing.Size(800, 46);
            this.splitPanel1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Windows8";
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimer.Location = new System.Drawing.Point(13, 17);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(2, 2);
            this.lblTimer.TabIndex = 3;
            // 
            // cmdLogPrint
            // 
            this.cmdLogPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLogPrint.Location = new System.Drawing.Point(670, 12);
            this.cmdLogPrint.Name = "cmdLogPrint";
            this.cmdLogPrint.Size = new System.Drawing.Size(110, 24);
            this.cmdLogPrint.TabIndex = 2;
            this.cmdLogPrint.Text = "Log Print";
            this.cmdLogPrint.ThemeName = "Windows8";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPreview.Location = new System.Drawing.Point(554, 12);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(110, 24);
            this.cmdPreview.TabIndex = 1;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.ThemeName = "Windows8";
            // 
            // cmdPause
            // 
            this.cmdPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPause.Location = new System.Drawing.Point(438, 12);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(110, 24);
            this.cmdPause.TabIndex = 0;
            this.cmdPause.Text = "Pause";
            this.cmdPause.ThemeName = "Windows8";
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.gridListMpiSync);
            this.splitPanel2.Location = new System.Drawing.Point(0, 50);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitPanel2.Size = new System.Drawing.Size(792, 520);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.4054054F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 388);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Windows8";
            // 
            // gridListMpiSync
            // 
            this.gridListMpiSync.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListMpiSync.Location = new System.Drawing.Point(0, 0);
            // 
            // gridListMpiSync
            // 
            this.gridListMpiSync.MasterTemplate.AllowAddNewRow = false;
            this.gridListMpiSync.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.FieldName = "RegistrationNo";
            gridViewTextBoxColumn1.HeaderText = "Registration Number";
            gridViewTextBoxColumn1.MaxLength = 500;
            gridViewTextBoxColumn1.Name = "RegistrationNo";
            gridViewTextBoxColumn1.Width = 113;
            gridViewTextBoxColumn2.FieldName = "MedicalNo";
            gridViewTextBoxColumn2.HeaderText = "Medical Number";
            gridViewTextBoxColumn2.MaxLength = 500;
            gridViewTextBoxColumn2.Name = "MedicalNo";
            gridViewTextBoxColumn2.Width = 92;
            gridViewTextBoxColumn3.FieldName = "PatientID";
            gridViewTextBoxColumn3.HeaderText = "Patient ID";
            gridViewTextBoxColumn3.MaxLength = 500;
            gridViewTextBoxColumn3.Name = "PatientID";
            gridViewTextBoxColumn3.Width = 57;
            gridViewDateTimeColumn1.Expression = "";
            gridViewDateTimeColumn1.FieldName = "CreatedDateTime";
            gridViewDateTimeColumn1.HeaderText = "Created Date Time";
            gridViewDateTimeColumn1.Name = "CreatedDateTime";
            gridViewDateTimeColumn1.Width = 74;
            gridViewTextBoxColumn4.FieldName = "CreatedByUser";
            gridViewTextBoxColumn4.HeaderText = "Created By User ID";
            gridViewTextBoxColumn4.Name = "CreatedByUser";
            gridViewCheckBoxColumn1.FieldName = "IsClosed";
            gridViewCheckBoxColumn1.HeaderText = "Is Closed";
            gridViewCheckBoxColumn1.Name = "IsClosed";
            gridViewCheckBoxColumn2.FieldName = "IsDischarged";
            gridViewCheckBoxColumn2.HeaderText = "Is Discharged";
            gridViewCheckBoxColumn2.Name = "IsDischarged";
            gridViewCheckBoxColumn3.FieldName = "IsEditedKunjungan";
            gridViewCheckBoxColumn3.HeaderText = "Is Edited Kunjungan";
            gridViewCheckBoxColumn3.Name = "IsEditedKunjungan";
            gridViewCheckBoxColumn4.FieldName = "IsNewKunjungan";
            gridViewCheckBoxColumn4.HeaderText = "Is New Kunjungan";
            gridViewCheckBoxColumn4.Name = "IsNewKunjungan";
            this.gridListMpiSync.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3,
            gridViewCheckBoxColumn4});
            this.gridListMpiSync.Name = "gridListMpiSync";
            this.gridListMpiSync.ReadOnly = true;
            this.gridListMpiSync.ShowGroupPanel = false;
            this.gridListMpiSync.Size = new System.Drawing.Size(792, 520);
            this.gridListMpiSync.TabIndex = 0;
            this.gridListMpiSync.Text = "List UnSynced MPI";
            this.gridListMpiSync.ThemeName = "Windows8";
            // 
            // tmrPrint
            // 
            this.tmrPrint.Tick += new System.EventHandler(this.tmrPrint_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "Mpi Sync Manager";
            this.notifyIcon.Visible = true;
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.radSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPI Sync Manager";
            this.ThemeName = "Windows8";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            this.splitPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdLogPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListMpiSync.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListMpiSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadButton cmdLogPrint;
        private Telerik.WinControls.UI.RadButton cmdPreview;
        private Telerik.WinControls.UI.RadButton cmdPause;
        private Telerik.WinControls.UI.RadGridView gridListMpiSync;
        private System.Windows.Forms.Timer tmrPrint;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private Telerik.WinControls.UI.RadLabel lblTimer;
    }
}