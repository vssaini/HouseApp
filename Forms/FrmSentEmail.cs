using System;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.Forms
{
    public partial class FrmSentEmail : Form
    {
        public FrmSentEmail()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenderEmail.Text))
            {
                errorProvider1.SetError(txtSenderEmail, "חובה להזין אימייל");
            }

            else if (string.IsNullOrEmpty(txtEmailSubject.Text))
            {
                errorProvider1.SetError(txtEmailSubject, "חובה להזין אימייל");
            }

            else if (string.IsNullOrEmpty(txtEmailBody.Text))
            {
                errorProvider1.SetError(txtEmailBody, "חובה להזין אימייל");
            }
            else
            {
                Utility.SendEmail("ihomesystem2014@gmail.com", txtSenderEmail.Text, txtEmailSubject.Text, txtEmailBody.Text, null);
                MessageBox.Show("הודעתך נשלחה בהצלחה לצוות התמיכה, נשיב בהקדם האפשרי,תודה!");

                clearfileds();
            }
        }

        public void clearfileds()
        {
            txtSenderEmail.Text = "";
            txtEmailSubject.Text = "";
            txtEmailBody.Text = "";
        }
    }
}

