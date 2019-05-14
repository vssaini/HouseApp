using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;

namespace SoftwareLocker
{
    public partial class frmDialog : Form
    {
        private string _Pass;

        public frmDialog(string BaseString, string Password, int DaysToEnd, int Runed, string info)
        {
            InitializeComponent();
            sebBaseString.Text = BaseString;
            _Pass = Password;
            lblDays.Text = DaysToEnd.ToString() + " : ימים לסיום הדמו";
            lblTimes.Text = Runed.ToString() + " : הפעלות לסיום הדמו";
            //lblText.Text = info;

            if (DaysToEnd<=30||Runed<=150)
            {
                grbRegister.Visible = false;
                groupBox2.Visible = true;

            }

            if (DaysToEnd <= 0 || Runed <= 0)
            {
                grbRegister.Visible = true;
                groupBox2.Visible = false;
                lblmsg1.Text = "גירסת הדמו הסתיימה";
                lblmsg2.Text = "צור קשר עם התמיכה לחידוש רישיון";
                lblmsg3.Text = "ihomesystem2014@gmail.com";
                btnTrial.Enabled = false;
            }
            
            sebPassword.Select();
        }

       

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_Pass == sebPassword.Text)
            {
                MessageBox.Show("Serial Accepted", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var licx = new LicenceExpiry();
                licx.Serial = sebPassword.Text;
                licx.ExpiryDate = DateTime.Now.AddYears(1);
                LicenceExpiry.Write(licx);

                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("The Serial Number is Incorrect", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}