namespace HouseApp.Forms
{
    partial class FrmSentEmail
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
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.lblSendToEmail = new System.Windows.Forms.Label();
            this.lblFromEmail = new System.Windows.Forms.Label();
            this.lblEmailSubject = new System.Windows.Forms.Label();
            this.lblEmailBody = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.txtSenderEmail = new System.Windows.Forms.TextBox();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(98, 319);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSendEmail.TabIndex = 0;
            this.btnSendEmail.Text = "שלח טופס";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // lblSendToEmail
            // 
            this.lblSendToEmail.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSendToEmail.Location = new System.Drawing.Point(275, 26);
            this.lblSendToEmail.Name = "lblSendToEmail";
            this.lblSendToEmail.Size = new System.Drawing.Size(100, 23);
            this.lblSendToEmail.TabIndex = 1;
            this.lblSendToEmail.Text = "send to";
            this.lblSendToEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSendToEmail.Visible = false;
            // 
            // lblFromEmail
            // 
            this.lblFromEmail.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblFromEmail.Location = new System.Drawing.Point(275, 65);
            this.lblFromEmail.Name = "lblFromEmail";
            this.lblFromEmail.Size = new System.Drawing.Size(100, 23);
            this.lblFromEmail.TabIndex = 2;
            this.lblFromEmail.Text = "דואר אלקטרוני";
            this.lblFromEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblEmailSubject.Location = new System.Drawing.Point(275, 107);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(100, 23);
            this.lblEmailSubject.TabIndex = 3;
            this.lblEmailSubject.Text = "נושא ההודעה";
            this.lblEmailSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmailBody
            // 
            this.lblEmailBody.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblEmailBody.Location = new System.Drawing.Point(275, 148);
            this.lblEmailBody.Name = "lblEmailBody";
            this.lblEmailBody.Size = new System.Drawing.Size(100, 23);
            this.lblEmailBody.TabIndex = 5;
            this.lblEmailBody.Text = "ההודעה";
            this.lblEmailBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEmailBody);
            this.panel1.Controls.Add(this.txtEmailSubject);
            this.panel1.Controls.Add(this.txtSenderEmail);
            this.panel1.Controls.Add(this.txtRecipient);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblSendToEmail);
            this.panel1.Controls.Add(this.btnSendEmail);
            this.panel1.Controls.Add(this.lblEmailBody);
            this.panel1.Controls.Add(this.lblFromEmail);
            this.panel1.Controls.Add(this.lblEmailSubject);
            this.panel1.Location = new System.Drawing.Point(1, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 356);
            this.panel1.TabIndex = 6;
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Location = new System.Drawing.Point(3, 148);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.Size = new System.Drawing.Size(253, 165);
            this.txtEmailBody.TabIndex = 16;
            this.txtEmailBody.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Location = new System.Drawing.Point(98, 107);
            this.txtEmailSubject.Multiline = true;
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(158, 23);
            this.txtEmailSubject.TabIndex = 15;
            this.txtEmailSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSenderEmail
            // 
            this.txtSenderEmail.Location = new System.Drawing.Point(98, 65);
            this.txtSenderEmail.Multiline = true;
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Size = new System.Drawing.Size(158, 23);
            this.txtSenderEmail.TabIndex = 14;
            this.txtSenderEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(98, 26);
            this.txtRecipient.Multiline = true;
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(158, 23);
            this.txtRecipient.TabIndex = 13;
            this.txtRecipient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecipient.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(267, 319);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "סגור וחזור";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "נקה טופס";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(0, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 46);
            this.label4.TabIndex = 55;
            this.label4.Text = "כל הזכויות שמורות @ 2012 / נתן מזרחי - 0544-966595";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(1, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(383, 52);
            this.label6.TabIndex = 56;
            this.label6.Text = "טופס דיווח על תקלה לתמיכה הטכנית";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSentEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 460);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSentEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SentEmail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label lblSendToEmail;
        private System.Windows.Forms.Label lblFromEmail;
        private System.Windows.Forms.Label lblEmailSubject;
        private System.Windows.Forms.Label lblEmailBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtEmailBody;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.TextBox txtSenderEmail;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}