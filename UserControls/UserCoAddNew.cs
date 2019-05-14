using System;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserCoAddNew : UserControl
    {
        public UserCoAddNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayarapartmentnum.Text != "")
            {
                if (DataAccess.IsRecordExistInDayarim("Dayarim_TBL", txtDayarapartmentnum.Text.Trim()))
                {
                    const string msgStr = "Apartment already exists.";
                    errorProvider1.SetError(txtDayarapartmentnum, msgStr);
                    MessageBox.Show(msgStr, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                errorProvider1.SetError(txtDayarapartmentnum, lbl7.Text = "Input apartment number");
                return;
            }

            if (txtDayarname.Text == "")
            {
                errorProvider1.SetError(txtDayarname, lbl1.Text = "הזן שם פרטי בבקשה");
                return;
            }
            if (txtDayarlastname.Text == "")
            {
                errorProvider1.SetError(txtDayarlastname, lbl2.Text = "הזן שם משפחה בבקשה");
                return;
            }

            if (comboDayarstatus.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboDayarstatus, "בחר סטטוס בבקשה");
                return;
            }
            if ((radioButton1.Text == "") && (radioButton2.Text == ""))
            {
                errorProvider1.SetError(radioButton1, "בחר אופצייה בבקשה");
                errorProvider1.SetError(radioButton2, "בחר אופצייה בבקשה");
                return;
            }
            if (txtDayarphone.Text == "")
            {
                errorProvider1.SetError(txtDayarphone, lbl3.Text = "הזן מספר טלפון בבקשה");
                return;
            }
            if (txtDayarmobil.Text == "")
            {
                errorProvider1.SetError(txtDayarmobil, lbl4.Text = "הזן טלפון נייד בבקשה");
                return;
            }

            if (txtDayaremail.Text == "")
            {
                errorProvider1.SetError(txtDayaremail, lbl5.Text = "הזן דואר אלקטרוני בבקשה");
                return;
            }

            if (txtpay.Text == "")
            {
                errorProvider1.SetError(txtpay, lbl6.Text = "ספרות בלבד וללא תווים");
            }

            if (txtlastPay.Text == "")
            {
                txtlastPay.Text = "0";
                errorProvider1.SetError(txtlastPay, lblerror7.Text = "ספרות בלבד וללא תווים");
            }
            else
            {
                //this is save part code
                SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
                SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Dayarim_TBL(Dayarapartmentnum, BuildingId, Dayarname, Dayarlastname,Dayarstatus,Dayarjoinmeeting,Dayarphone,Dayarmobil,Dayaremail,Dayarpay,DayarLastPay) values (@Dayarapartmentnum,@BuildingId, @Dayarname,@Dayarlastname,@Dayarstatus,@Dayarjoinmeeting,@Dayarphone,@Dayarmobil,@Dayaremail,@Dayarpay,@DayarLastPay)", con);
                con.Open();

                cmd.Parameters.AddWithValue("@Dayarapartmentnum", Convert.ToInt32(txtDayarapartmentnum.Text));
                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@Dayarname", txtDayarname.Text);
                cmd.Parameters.AddWithValue("@Dayarlastname", txtDayarlastname.Text);
                cmd.Parameters.AddWithValue("@Dayarstatus", comboDayarstatus.Text);
                cmd.Parameters.AddWithValue("@Dayarjoinmeeting", radioButton2.Checked ? radioButton2.Text : radioButton1.Text);
                cmd.Parameters.AddWithValue("@Dayarphone", txtDayarphone.Text);
                cmd.Parameters.AddWithValue("@Dayarmobil", txtDayarmobil.Text);
                cmd.Parameters.AddWithValue("@Dayaremail", txtDayaremail.Text);
                cmd.Parameters.AddWithValue("@Dayarpay", txtpay.Text);
                cmd.Parameters.AddWithValue("@DayarLastPay", txtlastPay.Text);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }

        private void UserCoAddNew_Load(object sender, EventArgs e)
        {
            txtlastPay.Text = "0";
        }
    }
}

