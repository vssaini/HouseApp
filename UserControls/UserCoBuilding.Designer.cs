namespace HouseApp.UserControls
{
    partial class UserCoBuilding
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoToHome = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gvBuildings = new System.Windows.Forms.DataGridView();
            this.colBuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuildingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCitry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBuildingStatus = new System.Windows.Forms.GroupBox();
            this.pnlBuildingMgr = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApartNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlBuildingImg = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pbBuilding = new System.Windows.Forms.PictureBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlBuildingDetails = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStartPayment = new System.Windows.Forms.Label();
            this.txtStartPayment = new System.Windows.Forms.TextBox();
            this.txtBuildingNumber = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveBuilding = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSetting = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuildings)).BeginInit();
            this.gbBuildingStatus.SuspendLayout();
            this.pnlBuildingMgr.SuspendLayout();
            this.pnlBuildingImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuilding)).BeginInit();
            this.pnlBuildingDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1080, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGoToHome);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.gvBuildings);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(620, 354);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Existing building(s)";
            // 
            // btnGoToHome
            // 
            this.btnGoToHome.Enabled = false;
            this.btnGoToHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGoToHome.Image = global::HouseApp.Properties.Resources.IconGo;
            this.btnGoToHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoToHome.Location = new System.Drawing.Point(522, 316);
            this.btnGoToHome.Name = "btnGoToHome";
            this.btnGoToHome.Size = new System.Drawing.Size(92, 26);
            this.btnGoToHome.TabIndex = 5;
            this.btnGoToHome.Text = "&Go to Home";
            this.btnGoToHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoToHome.UseVisualStyleBackColor = true;
            this.btnGoToHome.Click += new System.EventHandler(this.btnGoToHome_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(357, 17);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(244, 15);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Double click arrow to update respective home";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gvBuildings
            // 
            this.gvBuildings.AllowUserToAddRows = false;
            this.gvBuildings.AllowUserToDeleteRows = false;
            this.gvBuildings.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.gvBuildings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gvBuildings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvBuildings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBuildings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBuildingId,
            this.colBuildingNumber,
            this.colStreet,
            this.colCitry,
            this.colStartPayment,
            this.colFirstName,
            this.colLastName});
            this.gvBuildings.Enabled = false;
            this.gvBuildings.Location = new System.Drawing.Point(6, 35);
            this.gvBuildings.Name = "gvBuildings";
            this.gvBuildings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gvBuildings.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gvBuildings.Size = new System.Drawing.Size(608, 275);
            this.gvBuildings.TabIndex = 2;
            this.gvBuildings.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvBuildings_RowHeaderMouseDoubleClick);
            // 
            // colBuildingId
            // 
            this.colBuildingId.DataPropertyName = "BuildingId";
            this.colBuildingId.FillWeight = 53.29949F;
            this.colBuildingId.HeaderText = "Id";
            this.colBuildingId.Name = "colBuildingId";
            // 
            // colBuildingNumber
            // 
            this.colBuildingNumber.DataPropertyName = "BuildingNumber";
            this.colBuildingNumber.FillWeight = 107.7834F;
            this.colBuildingNumber.HeaderText = "Building Number";
            this.colBuildingNumber.Name = "colBuildingNumber";
            // 
            // colStreet
            // 
            this.colStreet.DataPropertyName = "Street";
            this.colStreet.FillWeight = 107.7834F;
            this.colStreet.HeaderText = "Street";
            this.colStreet.Name = "colStreet";
            // 
            // colCitry
            // 
            this.colCitry.DataPropertyName = "City";
            this.colCitry.FillWeight = 107.7834F;
            this.colCitry.HeaderText = "City";
            this.colCitry.Name = "colCitry";
            // 
            // colStartPayment
            // 
            this.colStartPayment.DataPropertyName = "StartPayment";
            this.colStartPayment.FillWeight = 107.7834F;
            this.colStartPayment.HeaderText = "Start Payment";
            this.colStartPayment.Name = "colStartPayment";
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "firstName";
            this.colFirstName.FillWeight = 107.7834F;
            this.colFirstName.HeaderText = "Name";
            this.colFirstName.Name = "colFirstName";
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "lastName";
            this.colLastName.FillWeight = 107.7834F;
            this.colLastName.HeaderText = "Last Name";
            this.colLastName.Name = "colLastName";
            // 
            // gbBuildingStatus
            // 
            this.gbBuildingStatus.Controls.Add(this.pnlBuildingMgr);
            this.gbBuildingStatus.Controls.Add(this.pnlBuildingImg);
            this.gbBuildingStatus.Controls.Add(this.btnUpdate);
            this.gbBuildingStatus.Controls.Add(this.btnDelete);
            this.gbBuildingStatus.Controls.Add(this.pnlBuildingDetails);
            this.gbBuildingStatus.Controls.Add(this.btnSaveBuilding);
            this.gbBuildingStatus.ForeColor = System.Drawing.Color.Navy;
            this.gbBuildingStatus.Location = new System.Drawing.Point(664, 3);
            this.gbBuildingStatus.Name = "gbBuildingStatus";
            this.gbBuildingStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbBuildingStatus.Size = new System.Drawing.Size(413, 522);
            this.gbBuildingStatus.TabIndex = 6;
            this.gbBuildingStatus.TabStop = false;
            this.gbBuildingStatus.Text = "Add new building";
            // 
            // pnlBuildingMgr
            // 
            this.pnlBuildingMgr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBuildingMgr.Controls.Add(this.label6);
            this.pnlBuildingMgr.Controls.Add(this.txtApartNum);
            this.pnlBuildingMgr.Controls.Add(this.label3);
            this.pnlBuildingMgr.Controls.Add(this.txtEmail);
            this.pnlBuildingMgr.Controls.Add(this.txtLastName);
            this.pnlBuildingMgr.Controls.Add(this.txtFirstName);
            this.pnlBuildingMgr.Controls.Add(this.label14);
            this.pnlBuildingMgr.Controls.Add(this.label15);
            this.pnlBuildingMgr.Controls.Add(this.label17);
            this.pnlBuildingMgr.Location = new System.Drawing.Point(19, 191);
            this.pnlBuildingMgr.Name = "pnlBuildingMgr";
            this.pnlBuildingMgr.Size = new System.Drawing.Size(379, 160);
            this.pnlBuildingMgr.TabIndex = 130;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(3, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "BUILDING MANAGER";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtApartNum
            // 
            this.txtApartNum.BackColor = System.Drawing.Color.DarkRed;
            this.txtApartNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApartNum.ForeColor = System.Drawing.SystemColors.Info;
            this.txtApartNum.Location = new System.Drawing.Point(3, 122);
            this.txtApartNum.Name = "txtApartNum";
            this.txtApartNum.Size = new System.Drawing.Size(245, 26);
            this.txtApartNum.TabIndex = 24;
            this.txtApartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApartNum.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(254, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "APART NUMBER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.DarkRed;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.Info;
            this.txtEmail.Location = new System.Drawing.Point(3, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 26);
            this.txtEmail.TabIndex = 22;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.DarkRed;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtLastName.Location = new System.Drawing.Point(3, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(245, 26);
            this.txtLastName.TabIndex = 21;
            this.txtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.DarkRed;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtFirstName.Location = new System.Drawing.Point(3, 26);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(245, 26);
            this.txtFirstName.TabIndex = 20;
            this.txtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(254, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 23);
            this.label14.TabIndex = 7;
            this.label14.Text = "NAME";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(254, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 23);
            this.label15.TabIndex = 8;
            this.label15.Text = "LAST NAME";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(254, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 23);
            this.label17.TabIndex = 10;
            this.label17.Text = "EMAIL";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBuildingImg
            // 
            this.pnlBuildingImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBuildingImg.Controls.Add(this.label11);
            this.pnlBuildingImg.Controls.Add(this.pbBuilding);
            this.pnlBuildingImg.Controls.Add(this.txtImagePath);
            this.pnlBuildingImg.Controls.Add(this.btnBrowseImg);
            this.pnlBuildingImg.Controls.Add(this.label2);
            this.pnlBuildingImg.Location = new System.Drawing.Point(18, 361);
            this.pnlBuildingImg.Name = "pnlBuildingImg";
            this.pnlBuildingImg.Size = new System.Drawing.Size(382, 123);
            this.pnlBuildingImg.TabIndex = 129;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(108, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(260, 45);
            this.label11.TabIndex = 31;
            this.label11.Text = "if not load image so defalt image will be auto show";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbBuilding
            // 
            this.pbBuilding.BackColor = System.Drawing.Color.DarkGray;
            this.pbBuilding.Location = new System.Drawing.Point(3, 26);
            this.pbBuilding.Name = "pbBuilding";
            this.pbBuilding.Size = new System.Drawing.Size(99, 87);
            this.pbBuilding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBuilding.TabIndex = 30;
            this.pbBuilding.TabStop = false;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(108, 38);
            this.txtImagePath.Multiline = true;
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(114, 23);
            this.txtImagePath.TabIndex = 29;
            // 
            // btnBrowseImg
            // 
            this.btnBrowseImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImg.Location = new System.Drawing.Point(228, 26);
            this.btnBrowseImg.Name = "btnBrowseImg";
            this.btnBrowseImg.Size = new System.Drawing.Size(140, 39);
            this.btnBrowseImg.TabIndex = 26;
            this.btnBrowseImg.Text = "Load img";
            this.btnBrowseImg.UseVisualStyleBackColor = true;
            this.btnBrowseImg.Click += new System.EventHandler(this.btnBrowseImg_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "main image of building";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Image = global::HouseApp.Properties.Resources.IconUpdate;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Location = new System.Drawing.Point(244, 490);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Image = global::HouseApp.Properties.Resources.IconDelete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(325, 490);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlBuildingDetails
            // 
            this.pnlBuildingDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBuildingDetails.Controls.Add(this.label7);
            this.pnlBuildingDetails.Controls.Add(this.lblStartPayment);
            this.pnlBuildingDetails.Controls.Add(this.txtStartPayment);
            this.pnlBuildingDetails.Controls.Add(this.txtBuildingNumber);
            this.pnlBuildingDetails.Controls.Add(this.txtStreet);
            this.pnlBuildingDetails.Controls.Add(this.txtCity);
            this.pnlBuildingDetails.Controls.Add(this.label5);
            this.pnlBuildingDetails.Controls.Add(this.label8);
            this.pnlBuildingDetails.Controls.Add(this.label9);
            this.pnlBuildingDetails.Location = new System.Drawing.Point(18, 19);
            this.pnlBuildingDetails.Name = "pnlBuildingDetails";
            this.pnlBuildingDetails.Size = new System.Drawing.Size(380, 166);
            this.pnlBuildingDetails.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(5, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "BUILDING DETAILS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartPayment
            // 
            this.lblStartPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStartPayment.Location = new System.Drawing.Point(254, 127);
            this.lblStartPayment.Name = "lblStartPayment";
            this.lblStartPayment.Size = new System.Drawing.Size(119, 25);
            this.lblStartPayment.TabIndex = 29;
            this.lblStartPayment.Text = "Start Payment";
            this.lblStartPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStartPayment
            // 
            this.txtStartPayment.BackColor = System.Drawing.Color.DarkRed;
            this.txtStartPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartPayment.ForeColor = System.Drawing.SystemColors.Info;
            this.txtStartPayment.Location = new System.Drawing.Point(5, 126);
            this.txtStartPayment.Name = "txtStartPayment";
            this.txtStartPayment.Size = new System.Drawing.Size(245, 26);
            this.txtStartPayment.TabIndex = 8;
            this.txtStartPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartPayment.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtStartPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartPayment_KeyPress);
            // 
            // txtBuildingNumber
            // 
            this.txtBuildingNumber.BackColor = System.Drawing.Color.DarkRed;
            this.txtBuildingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildingNumber.ForeColor = System.Drawing.SystemColors.Info;
            this.txtBuildingNumber.Location = new System.Drawing.Point(3, 95);
            this.txtBuildingNumber.Name = "txtBuildingNumber";
            this.txtBuildingNumber.Size = new System.Drawing.Size(245, 26);
            this.txtBuildingNumber.TabIndex = 7;
            this.txtBuildingNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuildingNumber.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtBuildingNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuildingNumber_KeyPress);
            // 
            // txtStreet
            // 
            this.txtStreet.BackColor = System.Drawing.Color.DarkRed;
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.ForeColor = System.Drawing.SystemColors.Info;
            this.txtStreet.Location = new System.Drawing.Point(3, 63);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(245, 26);
            this.txtStreet.TabIndex = 6;
            this.txtStreet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.DarkRed;
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCity.Location = new System.Drawing.Point(3, 28);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(245, 26);
            this.txtCity.TabIndex = 5;
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCity.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(254, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "city";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(254, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "street name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(254, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "building number";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveBuilding
            // 
            this.btnSaveBuilding.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveBuilding.Image = global::HouseApp.Properties.Resources.IconBuildingPlus;
            this.btnSaveBuilding.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveBuilding.Location = new System.Drawing.Point(17, 490);
            this.btnSaveBuilding.Name = "btnSaveBuilding";
            this.btnSaveBuilding.Size = new System.Drawing.Size(103, 26);
            this.btnSaveBuilding.TabIndex = 3;
            this.btnSaveBuilding.Text = "Save Building";
            this.btnSaveBuilding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBuilding.UseVisualStyleBackColor = true;
            this.btnSaveBuilding.Click += new System.EventHandler(this.btnSaveBuilding_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(22, 487);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(67, 32);
            this.btnSetting.TabIndex = 10;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // UserCoBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbBuildingStatus);
            this.Name = "UserCoBuilding";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.UserCoBuilding_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuildings)).EndInit();
            this.gbBuildingStatus.ResumeLayout(false);
            this.pnlBuildingMgr.ResumeLayout(false);
            this.pnlBuildingMgr.PerformLayout();
            this.pnlBuildingImg.ResumeLayout(false);
            this.pnlBuildingImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuilding)).EndInit();
            this.pnlBuildingDetails.ResumeLayout(false);
            this.pnlBuildingDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView gvBuildings;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbBuildingStatus;
        private System.Windows.Forms.Panel pnlBuildingImg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbBuilding;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBuildingDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStartPayment;
        public System.Windows.Forms.TextBox txtStartPayment;
        public System.Windows.Forms.TextBox txtBuildingNumber;
        public System.Windows.Forms.TextBox txtStreet;
        public System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveBuilding;
        private System.Windows.Forms.Panel pnlBuildingMgr;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtApartNum;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCitry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.Button btnGoToHome;
        private System.Windows.Forms.Button btnSetting;
    }
}
