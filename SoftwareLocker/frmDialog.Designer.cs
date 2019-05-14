namespace SoftwareLocker
{
    partial class frmDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTrial = new System.Windows.Forms.Button();
            this.grbRegister = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCallPhone = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.sebBaseString = new SoftwareLocker.Controls.SerialBox();
            this.sebPassword = new SoftwareLocker.Controls.SerialBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblmsg2 = new System.Windows.Forms.Label();
            this.lblmsg1 = new System.Windows.Forms.Label();
            this.lblmsg3 = new System.Windows.Forms.Label();
            this.grbRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(97, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "הפעל רישיון";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTrial
            // 
            this.btnTrial.BackColor = System.Drawing.Color.Chocolate;
            this.btnTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrial.Location = new System.Drawing.Point(6, 358);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(323, 66);
            this.btnTrial.TabIndex = 2;
            this.btnTrial.Text = "כניסה לתוכנה";
            this.btnTrial.UseVisualStyleBackColor = false;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // grbRegister
            // 
            this.grbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRegister.Controls.Add(this.lblmsg3);
            this.grbRegister.Controls.Add(this.lblmsg2);
            this.grbRegister.Controls.Add(this.lblmsg1);
            this.grbRegister.Controls.Add(this.lblSerial);
            this.grbRegister.Controls.Add(this.lblID);
            this.grbRegister.Controls.Add(this.lblCallPhone);
            this.grbRegister.Controls.Add(this.sebBaseString);
            this.grbRegister.Controls.Add(this.btnOK);
            this.grbRegister.Controls.Add(this.sebPassword);
            this.grbRegister.Location = new System.Drawing.Point(9, 71);
            this.grbRegister.Name = "grbRegister";
            this.grbRegister.Size = new System.Drawing.Size(327, 281);
            this.grbRegister.TabIndex = 1;
            this.grbRegister.TabStop = false;
            this.grbRegister.Text = "חלונית הפעלת רישיון תוכנה";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(9, 101);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(36, 13);
            this.lblSerial.TabIndex = 3;
            this.lblSerial.Text = "Serial:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 58);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID:";
            // 
            // lblCallPhone
            // 
            this.lblCallPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallPhone.Location = new System.Drawing.Point(6, 21);
            this.lblCallPhone.Name = "lblCallPhone";
            this.lblCallPhone.Size = new System.Drawing.Size(314, 29);
            this.lblCallPhone.TabIndex = 0;
            this.lblCallPhone.Text = "על מנת להפעיל את הרישיון , שלח למנהל התוכנה את הקוד המוצג וקבל קוד הפעלה";
            this.lblCallPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(647, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "התוכנה תפעל כגירסת דמו למשך 30 ימים. לאחר מכן חובה לרכוש אותה עם רישיון שימוש לשנ" +
    "ה. לפני ביצוע הרכישה באפשרותך להנות מהתוכנה על כל תכונותיה שזמינות באופן מלא בגי" +
    "רסת הדמו.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HouseApp.Properties.Resources.pic1;
            this.pictureBox1.Location = new System.Drawing.Point(339, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 26);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(314, 66);
            this.label5.TabIndex = 0;
            this.label5.Text = "תוכנה פעילה כגירסת דמו. לחץ על כניסה לתוכנה על מנת לעבוד איתה באופן מלא בגירסת הד" +
    "מו.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDays
            // 
            this.lblDays.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.ForeColor = System.Drawing.Color.Red;
            this.lblDays.Location = new System.Drawing.Point(9, 122);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(313, 40);
            this.lblDays.TabIndex = 8;
            this.lblDays.Text = "[Days]";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimes
            // 
            this.lblTimes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimes.ForeColor = System.Drawing.Color.Red;
            this.lblTimes.Location = new System.Drawing.Point(8, 191);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(314, 40);
            this.lblTimes.TabIndex = 10;
            this.lblTimes.Text = "[Times]";
            this.lblTimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sebBaseString
            // 
            this.sebBaseString.CaptleLettersOnly = true;
            this.sebBaseString.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.sebBaseString.Location = new System.Drawing.Point(12, 74);
            this.sebBaseString.Name = "sebBaseString";
            this.sebBaseString.ReadOnly = true;
            this.sebBaseString.Size = new System.Drawing.Size(293, 18);
            this.sebBaseString.TabIndex = 2;
            // 
            // sebPassword
            // 
            this.sebPassword.CaptleLettersOnly = true;
            this.sebPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.sebPassword.Location = new System.Drawing.Point(12, 117);
            this.sebPassword.Name = "sebPassword";
            this.sebPassword.Size = new System.Drawing.Size(293, 18);
            this.sebPassword.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblTimes);
            this.groupBox2.Controls.Add(this.lblDays);
            this.groupBox2.Location = new System.Drawing.Point(3, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(330, 292);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // lblmsg2
            // 
            this.lblmsg2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblmsg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg2.ForeColor = System.Drawing.Color.Red;
            this.lblmsg2.Location = new System.Drawing.Point(7, 221);
            this.lblmsg2.Name = "lblmsg2";
            this.lblmsg2.Size = new System.Drawing.Size(314, 25);
            this.lblmsg2.TabIndex = 12;
            this.lblmsg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmsg1
            // 
            this.lblmsg1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblmsg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg1.ForeColor = System.Drawing.Color.Red;
            this.lblmsg1.Location = new System.Drawing.Point(8, 188);
            this.lblmsg1.Name = "lblmsg1";
            this.lblmsg1.Size = new System.Drawing.Size(313, 25);
            this.lblmsg1.TabIndex = 11;
            this.lblmsg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmsg3
            // 
            this.lblmsg3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblmsg3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg3.ForeColor = System.Drawing.Color.Black;
            this.lblmsg3.Location = new System.Drawing.Point(8, 253);
            this.lblmsg3.Name = "lblmsg3";
            this.lblmsg3.Size = new System.Drawing.Size(314, 25);
            this.lblmsg3.TabIndex = 13;
            this.lblmsg3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Activation";
            this.grbRegister.ResumeLayout(false);
            this.grbRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SerialBox sebBaseString;
        private Controls.SerialBox sebPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.GroupBox grbRegister;
        private System.Windows.Forms.Label lblCallPhone;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblmsg2;
        private System.Windows.Forms.Label lblmsg1;
        private System.Windows.Forms.Label lblmsg3;

    }
}