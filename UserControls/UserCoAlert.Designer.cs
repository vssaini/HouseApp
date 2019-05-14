namespace HouseApp.UserControls
{
    partial class UserCoAlert
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.groupControls = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowAllUsers = new System.Windows.Forms.CheckBox();
            this.cboYears = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.groupControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMonth
            // 
            this.cboMonth.Enabled = false;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(630, 34);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(127, 23);
            this.cboMonth.TabIndex = 0;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(15, 144);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1062, 325);
            this.dataGridViewUsers.TabIndex = 3;
            // 
            // groupControls
            // 
            this.groupControls.Controls.Add(this.label1);
            this.groupControls.Controls.Add(this.chkShowAllUsers);
            this.groupControls.Controls.Add(this.cboYears);
            this.groupControls.Controls.Add(this.lblYear);
            this.groupControls.Controls.Add(this.cboMonth);
            this.groupControls.Controls.Add(this.btnLoad);
            this.groupControls.Location = new System.Drawing.Point(15, 56);
            this.groupControls.Name = "groupControls";
            this.groupControls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControls.Size = new System.Drawing.Size(1062, 82);
            this.groupControls.TabIndex = 4;
            this.groupControls.TabStop = false;
            this.groupControls.Text = "הצג דוחות לפי בחירתך";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(763, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "בחר חודש:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowAllUsers
            // 
            this.chkShowAllUsers.AutoSize = true;
            this.chkShowAllUsers.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAllUsers.Location = new System.Drawing.Point(278, 37);
            this.chkShowAllUsers.Name = "chkShowAllUsers";
            this.chkShowAllUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowAllUsers.Size = new System.Drawing.Size(191, 19);
            this.chkShowAllUsers.TabIndex = 5;
            this.chkShowAllUsers.Text = "לקבלת ריכוז שנתי סמן כאן";
            this.chkShowAllUsers.UseVisualStyleBackColor = true;
            // 
            // cboYears
            // 
            this.cboYears.Enabled = false;
            this.cboYears.FormattingEnabled = true;
            this.cboYears.Location = new System.Drawing.Point(886, 33);
            this.cboYears.Name = "cboYears";
            this.cboYears.Size = new System.Drawing.Size(85, 23);
            this.cboYears.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.Maroon;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblYear.Location = new System.Drawing.Point(977, 33);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(79, 22);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "בחר שנה:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = global::HouseApp.Properties.Resources.IconLoader;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(512, 34);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "הצג דוח";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1077, 44);
            this.label2.TabIndex = 72;
            this.label2.Text = "הצגת דוחות תשלומים";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserCoAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupControls);
            this.Controls.Add(this.dataGridViewUsers);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserCoAlert";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.UserCoAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.groupControls.ResumeLayout(false);
            this.groupControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.GroupBox groupControls;
        private System.Windows.Forms.ComboBox cboYears;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.CheckBox chkShowAllUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
