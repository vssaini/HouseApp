namespace HouseApp.Forms
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlCommon = new System.Windows.Forms.Panel();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.bgWorkerEmail = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerStartup = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAppHome = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUsersList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGraphs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripReports = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNearSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLogout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCopyright.Location = new System.Drawing.Point(0, 582);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(1084, 34);
            this.lblCopyright.TabIndex = 23;
            this.lblCopyright.Text = "תוכנה לניהול קופת ועד הבית  |  כל הזכויות שמורות  |  2014";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlCommon
            // 
            this.pnlCommon.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCommon.Location = new System.Drawing.Point(4, 27);
            this.pnlCommon.Name = "pnlCommon";
            this.pnlCommon.Size = new System.Drawing.Size(1080, 550);
            this.pnlCommon.TabIndex = 45;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(4, 584);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(66, 25);
            this.btnShowLog.TabIndex = 8;
            this.btnShowLog.Text = "LOG FILE";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // bgWorkerEmail
            // 
            this.bgWorkerEmail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerEmail_DoWork);
            this.bgWorkerEmail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerEmail_RunWorkerCompleted);
            // 
            // bgWorkerStartup
            // 
            this.bgWorkerStartup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerStartup_DoWork);
            this.bgWorkerStartup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerStartup_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBuilding,
            this.toolStripAppHome,
            this.toolStripAddUser,
            this.toolStripUsersList,
            this.toolStripPayments,
            this.toolStripGraphs,
            this.toolStripReports,
            this.toolStripNearSetting,
            this.toolStripSetting,
            this.toolStripHistory,
            this.toolStripAbout,
            this.toolStripSupport,
            this.toolStripLogout});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripBuilding
            // 
            this.toolStripBuilding.Name = "toolStripBuilding";
            this.toolStripBuilding.Size = new System.Drawing.Size(71, 20);
            this.toolStripBuilding.Text = "BUILDING";
            this.toolStripBuilding.Visible = false;
            this.toolStripBuilding.Click += new System.EventHandler(this.Home_Click);
            // 
            // toolStripAppHome
            // 
            this.toolStripAppHome.Name = "toolStripAppHome";
            this.toolStripAppHome.Size = new System.Drawing.Size(74, 20);
            this.toolStripAppHome.Text = "AppHome";
            this.toolStripAppHome.Visible = false;
            this.toolStripAppHome.Click += new System.EventHandler(this.ביתToolStripMenuItem_Click);
            // 
            // toolStripAddUser
            // 
            this.toolStripAddUser.Name = "toolStripAddUser";
            this.toolStripAddUser.Size = new System.Drawing.Size(73, 20);
            this.toolStripAddUser.Text = "ADD USER";
            this.toolStripAddUser.Visible = false;
            this.toolStripAddUser.Click += new System.EventHandler(this.הוספתדיירToolStripMenuItem_Click);
            // 
            // toolStripUsersList
            // 
            this.toolStripUsersList.Name = "toolStripUsersList";
            this.toolStripUsersList.Size = new System.Drawing.Size(77, 20);
            this.toolStripUsersList.Text = "USERS LIST";
            this.toolStripUsersList.Visible = false;
            this.toolStripUsersList.Click += new System.EventHandler(this.רשימתדייריםToolStripMenuItem_Click);
            // 
            // toolStripPayments
            // 
            this.toolStripPayments.Name = "toolStripPayments";
            this.toolStripPayments.Size = new System.Drawing.Size(80, 20);
            this.toolStripPayments.Text = "PAYMENTS";
            this.toolStripPayments.Visible = false;
            this.toolStripPayments.Click += new System.EventHandler(this.תשלומיםToolStripMenuItem_Click);
            // 
            // toolStripGraphs
            // 
            this.toolStripGraphs.Name = "toolStripGraphs";
            this.toolStripGraphs.Size = new System.Drawing.Size(64, 20);
            this.toolStripGraphs.Text = "GRAPHS";
            this.toolStripGraphs.Visible = false;
            this.toolStripGraphs.Click += new System.EventHandler(this.הכנסותהוצאותToolStripMenuItem_Click);
            // 
            // toolStripReports
            // 
            this.toolStripReports.Name = "toolStripReports";
            this.toolStripReports.Size = new System.Drawing.Size(68, 20);
            this.toolStripReports.Text = "REPORTS";
            this.toolStripReports.Visible = false;
            this.toolStripReports.Click += new System.EventHandler(this.דוחחודשישנתיToolStripMenuItem_Click);
            // 
            // toolStripNearSetting
            // 
            this.toolStripNearSetting.Name = "toolStripNearSetting";
            this.toolStripNearSetting.Size = new System.Drawing.Size(53, 20);
            this.toolStripNearSetting.Text = "קבלות";
            this.toolStripNearSetting.Visible = false;
            this.toolStripNearSetting.Click += new System.EventHandler(this.קבלותToolStripMenuItem_Click);
            // 
            // toolStripSetting
            // 
            this.toolStripSetting.Name = "toolStripSetting";
            this.toolStripSetting.Size = new System.Drawing.Size(65, 20);
            this.toolStripSetting.Text = "SETTING";
            this.toolStripSetting.Visible = false;
            this.toolStripSetting.Click += new System.EventHandler(this.הגדרותToolStripMenuItem_Click);
            // 
            // toolStripHistory
            // 
            this.toolStripHistory.Name = "toolStripHistory";
            this.toolStripHistory.Size = new System.Drawing.Size(67, 20);
            this.toolStripHistory.Text = "HISTORY";
            this.toolStripHistory.Visible = false;
            this.toolStripHistory.Click += new System.EventHandler(this.toolStripHistory_Click);
            // 
            // toolStripAbout
            // 
            this.toolStripAbout.Name = "toolStripAbout";
            this.toolStripAbout.Size = new System.Drawing.Size(58, 20);
            this.toolStripAbout.Text = "ABOUT";
            this.toolStripAbout.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSupport
            // 
            this.toolStripSupport.Name = "toolStripSupport";
            this.toolStripSupport.Size = new System.Drawing.Size(70, 20);
            this.toolStripSupport.Text = "SUPPORT";
            this.toolStripSupport.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripLogout
            // 
            this.toolStripLogout.Name = "toolStripLogout";
            this.toolStripLogout.Size = new System.Drawing.Size(66, 20);
            this.toolStripLogout.Text = "LOGOUT";
            this.toolStripLogout.Click += new System.EventHandler(this.ExittoolStripMenuItem1_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1084, 612);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.pnlCommon);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "תוכנה לניהול קופת ועד הבית - Ihome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHome_FormClosing);
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.Shown += new System.EventHandler(this.FrmHome_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnShowLog;
        private System.ComponentModel.BackgroundWorker bgWorkerEmail;
        private System.ComponentModel.BackgroundWorker bgWorkerStartup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem toolStripAppHome;
        public System.Windows.Forms.ToolStripMenuItem toolStripAddUser;
        public System.Windows.Forms.ToolStripMenuItem toolStripUsersList;
        public System.Windows.Forms.ToolStripMenuItem toolStripPayments;
        public System.Windows.Forms.ToolStripMenuItem toolStripGraphs;
        public System.Windows.Forms.ToolStripMenuItem toolStripReports;
        public System.Windows.Forms.ToolStripMenuItem toolStripNearSetting;
        public System.Windows.Forms.ToolStripMenuItem toolStripSetting;
        public System.Windows.Forms.ToolStripMenuItem toolStripAbout;
        public System.Windows.Forms.ToolStripMenuItem toolStripSupport;
        private System.Windows.Forms.ToolStripMenuItem toolStripLogout;
        public System.Windows.Forms.ToolStripMenuItem toolStripHistory;
        public System.Windows.Forms.ToolStripMenuItem toolStripBuilding;
        public System.Windows.Forms.Panel pnlCommon;
    }
}