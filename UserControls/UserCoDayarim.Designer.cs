namespace HouseApp.UserControls
{
    partial class UserCoDayarim
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
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdyrapt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmlname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmjoinmeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayarLastPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Save = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.AllowUserToAddRows = false;
            this.dataGridViewRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.clmdyrapt,
            this.clnname,
            this.clmlname,
            this.clmstatus,
            this.clmjoinmeeting,
            this.clmphone,
            this.clmmobile,
            this.clmemail,
            this.Payment,
            this.DayarLastPay,
            this.Edit,
            this.Save,
            this.Delete});
            this.dataGridViewRecords.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridViewRecords.Location = new System.Drawing.Point(0, 44);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewRecords.RowHeadersVisible = false;
            this.dataGridViewRecords.Size = new System.Drawing.Size(1077, 503);
            this.dataGridViewRecords.StandardTab = true;
            this.dataGridViewRecords.TabIndex = 1;
            this.dataGridViewRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecords_CellClick);
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
            this.label2.Text = "רשימת דיירים";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // clmdyrapt
            // 
            this.clmdyrapt.DataPropertyName = "dayarapartmentnum";
            this.clmdyrapt.FillWeight = 86.24661F;
            this.clmdyrapt.HeaderText = "דירה";
            this.clmdyrapt.Name = "clmdyrapt";
            this.clmdyrapt.ReadOnly = true;
            this.clmdyrapt.ToolTipText = "דירה";
            // 
            // clnname
            // 
            this.clnname.DataPropertyName = "dayarname";
            this.clnname.FillWeight = 118.6863F;
            this.clnname.HeaderText = "שם פרטי";
            this.clnname.Name = "clnname";
            this.clnname.ReadOnly = true;
            // 
            // clmlname
            // 
            this.clmlname.DataPropertyName = "dayarlastname";
            this.clmlname.FillWeight = 118.6863F;
            this.clmlname.HeaderText = "שם משפחה";
            this.clmlname.Name = "clmlname";
            this.clmlname.ReadOnly = true;
            // 
            // clmstatus
            // 
            this.clmstatus.DataPropertyName = "dayarstatus";
            this.clmstatus.FillWeight = 118.6863F;
            this.clmstatus.HeaderText = "סטטוס";
            this.clmstatus.Name = "clmstatus";
            this.clmstatus.ReadOnly = true;
            // 
            // clmjoinmeeting
            // 
            this.clmjoinmeeting.DataPropertyName = "dayarjoinmeeting";
            this.clmjoinmeeting.FillWeight = 78.74828F;
            this.clmjoinmeeting.HeaderText = "פגישות";
            this.clmjoinmeeting.Name = "clmjoinmeeting";
            this.clmjoinmeeting.ReadOnly = true;
            // 
            // clmphone
            // 
            this.clmphone.DataPropertyName = "dayarphone";
            this.clmphone.FillWeight = 118.6863F;
            this.clmphone.HeaderText = "טלפון";
            this.clmphone.Name = "clmphone";
            this.clmphone.ReadOnly = true;
            // 
            // clmmobile
            // 
            this.clmmobile.DataPropertyName = "dayarmobil";
            this.clmmobile.FillWeight = 118.6863F;
            this.clmmobile.HeaderText = "נייד";
            this.clmmobile.Name = "clmmobile";
            this.clmmobile.ReadOnly = true;
            // 
            // clmemail
            // 
            this.clmemail.DataPropertyName = "dayaremail";
            this.clmemail.FillWeight = 118.6863F;
            this.clmemail.HeaderText = "אימייל";
            this.clmemail.Name = "clmemail";
            this.clmemail.ReadOnly = true;
            // 
            // Payment
            // 
            this.Payment.DataPropertyName = "Dayarpay";
            this.Payment.FillWeight = 94.0207F;
            this.Payment.HeaderText = "תשלום חודשי";
            this.Payment.Name = "Payment";
            // 
            // DayarLastPay
            // 
            this.DayarLastPay.DataPropertyName = "DayarLastPay";
            this.DayarLastPay.FillWeight = 94.39214F;
            this.DayarLastPay.HeaderText = "יתרה קודמת";
            this.DayarLastPay.Name = "DayarLastPay";
            // 
            // Edit
            // 
            this.Edit.FillWeight = 55.88988F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "ערוך";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Save
            // 
            this.Save.FillWeight = 46.60445F;
            this.Save.HeaderText = "Save";
            this.Save.Name = "Save";
            this.Save.Text = "שמור";
            this.Save.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 131.9797F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "שמור להיסטוריה";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // UserCoDayarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewRecords);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserCoDayarim";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.UserCoDayarim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdyrapt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmlname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmjoinmeeting;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayarLastPay;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Save;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;


    }
}
