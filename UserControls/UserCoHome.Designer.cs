namespace HouseApp.UserControls
{
    partial class UserCoHome
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtStreetNumber = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtManagerName = new System.Windows.Forms.TextBox();
            this.lblManagerName = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.btnSaveMgrData = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblday = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.lblBackup = new System.Windows.Forms.Label();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblMobile);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtMobile);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.txtStreetNumber);
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Controls.Add(this.lblPhone);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtStreetName);
            this.panel2.Controls.Add(this.txtCity);
            this.panel2.Controls.Add(this.txtManagerName);
            this.panel2.Controls.Add(this.lblManagerName);
            this.panel2.Controls.Add(this.lblCity);
            this.panel2.Controls.Add(this.lblStreetName);
            this.panel2.Location = new System.Drawing.Point(235, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 178);
            this.panel2.TabIndex = 52;
            // 
            // lblMobile
            // 
            this.lblMobile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMobile.Location = new System.Drawing.Point(255, 68);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(119, 23);
            this.lblMobile.TabIndex = 36;
            this.lblMobile.Text = "mobile";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.DarkRed;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.Info;
            this.txtEmail.Location = new System.Drawing.Point(5, 99);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 26);
            this.txtEmail.TabIndex = 35;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.DarkRed;
            this.txtMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMobile.Location = new System.Drawing.Point(5, 65);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(245, 26);
            this.txtMobile.TabIndex = 34;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobile.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.DarkRed;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPhone.Location = new System.Drawing.Point(5, 35);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(245, 26);
            this.txtPhone.TabIndex = 33;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtStreetNumber
            // 
            this.txtStreetNumber.BackColor = System.Drawing.Color.DarkRed;
            this.txtStreetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetNumber.ForeColor = System.Drawing.SystemColors.Info;
            this.txtStreetNumber.Location = new System.Drawing.Point(458, 134);
            this.txtStreetNumber.Name = "txtStreetNumber";
            this.txtStreetNumber.Size = new System.Drawing.Size(245, 26);
            this.txtStreetNumber.TabIndex = 32;
            this.txtStreetNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStreetNumber.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEmail.Location = new System.Drawing.Point(255, 102);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(119, 23);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhone
            // 
            this.lblPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPhone.Location = new System.Drawing.Point(255, 35);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(119, 23);
            this.lblPhone.TabIndex = 28;
            this.lblPhone.Text = "phone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(709, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "street number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(5, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(823, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "SOFTWARE MANAGER DETAILS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.DarkRed;
            this.txtStreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtStreetName.Location = new System.Drawing.Point(458, 102);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(245, 26);
            this.txtStreetName.TabIndex = 22;
            this.txtStreetName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStreetName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.DarkRed;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCity.Location = new System.Drawing.Point(458, 70);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(245, 26);
            this.txtCity.TabIndex = 21;
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCity.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtManagerName
            // 
            this.txtManagerName.BackColor = System.Drawing.Color.DarkRed;
            this.txtManagerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManagerName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtManagerName.Location = new System.Drawing.Point(458, 35);
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.Size = new System.Drawing.Size(245, 26);
            this.txtManagerName.TabIndex = 20;
            this.txtManagerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtManagerName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // lblManagerName
            // 
            this.lblManagerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblManagerName.Location = new System.Drawing.Point(709, 35);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(119, 23);
            this.lblManagerName.TabIndex = 7;
            this.lblManagerName.Text = "super manager name";
            this.lblManagerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCity
            // 
            this.lblCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCity.Location = new System.Drawing.Point(709, 70);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(119, 23);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "city";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStreetName
            // 
            this.lblStreetName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStreetName.Location = new System.Drawing.Point(709, 102);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(119, 23);
            this.lblStreetName.TabIndex = 10;
            this.lblStreetName.Text = "street name";
            this.lblStreetName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveMgrData
            // 
            this.btnSaveMgrData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSaveMgrData.Location = new System.Drawing.Point(235, 361);
            this.btnSaveMgrData.Name = "btnSaveMgrData";
            this.btnSaveMgrData.Size = new System.Drawing.Size(233, 69);
            this.btnSaveMgrData.TabIndex = 51;
            this.btnSaveMgrData.Text = "SAVE DATA";
            this.btnSaveMgrData.UseVisualStyleBackColor = true;
            this.btnSaveMgrData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.BackColor = System.Drawing.Color.Maroon;
            this.lblSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSerial.Location = new System.Drawing.Point(695, 407);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(245, 23);
            this.lblSerial.TabIndex = 19;
            this.lblSerial.Text = "lblSerial";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(946, 407);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 23);
            this.label16.TabIndex = 9;
            this.label16.Text = "מספר רשיון תוכנה";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVersion.Location = new System.Drawing.Point(819, 436);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(121, 23);
            this.lblVersion.TabIndex = 55;
            this.lblVersion.Text = "Licens Type";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblday
            // 
            this.lblday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblday.Location = new System.Drawing.Point(695, 436);
            this.lblday.Name = "lblday";
            this.lblday.Size = new System.Drawing.Size(121, 23);
            this.lblday.TabIndex = 54;
            this.lblday.Text = "Dayes Remain";
            this.lblday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.txtRestorePath);
            this.panel3.Controls.Add(this.lblBackup);
            this.panel3.Controls.Add(this.btnBrowseBackup);
            this.panel3.Controls.Add(this.btnRestore);
            this.panel3.Controls.Add(this.txtBackupPath);
            this.panel3.Location = new System.Drawing.Point(695, 276);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 115);
            this.panel3.TabIndex = 56;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Yellow;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(362, 21);
            this.label22.TabIndex = 117;
            this.label22.Text = "טען את קובץ הגיבוי ולחץ על שחזור נתונים";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "BACKUP/RESTOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(3, 28);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 26);
            this.btnBrowse.TabIndex = 75;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Enabled = false;
            this.txtRestorePath.Location = new System.Drawing.Point(84, 60);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(164, 20);
            this.txtRestorePath.TabIndex = 75;
            // 
            // lblBackup
            // 
            this.lblBackup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackup.Location = new System.Drawing.Point(254, 29);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(114, 25);
            this.lblBackup.TabIndex = 8;
            this.lblBackup.Text = "BACKUP";
            this.lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Location = new System.Drawing.Point(3, 57);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBackup.TabIndex = 74;
            this.btnBrowseBackup.Text = "Browse...";
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(254, 60);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(114, 20);
            this.btnRestore.TabIndex = 73;
            this.btnRestore.Text = "RESTOR";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(84, 28);
            this.txtBackupPath.Multiline = true;
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(164, 26);
            this.txtBackupPath.TabIndex = 74;
            this.txtBackupPath.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(15, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 118;
            this.button4.Text = "איפוס הכנסות";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(15, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 78;
            this.button3.Text = "איפוס הוצאות";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(15, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 77;
            this.button2.Text = "איפוס דיירים";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(15, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 76;
            this.button1.Text = "איפוס תשלומים";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "zip";
            this.openFileDialog.FileName = "Backup";
            this.openFileDialog.Filter = "Zip fles (*.zip|*.zip";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Browse backup file";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Maroon;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1074, 44);
            this.label13.TabIndex = 73;
            this.label13.Text = "SETTING";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(149, 292);
            this.groupBox1.TabIndex = 119;
            this.groupBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Maroon;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(15, 238);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 23);
            this.button5.TabIndex = 119;
            this.button5.Text = "מחיקת הסטוריה";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Maroon;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "איפוס נתונים";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserCoHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSaveMgrData);
            this.Controls.Add(this.lblday);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.label16);
            this.Name = "UserCoHome";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.User_Home_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCity;
        public System.Windows.Forms.TextBox txtManagerName;
        private System.Windows.Forms.Label lblManagerName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Button btnSaveMgrData;
        public System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblday;
        private System.Windows.Forms.ErrorProvider errorProvider;
        public System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtMobile;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtStreetNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label lblMobile;
    }
}
