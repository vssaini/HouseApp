using System;
using System.Windows.Forms;
using HouseApp.Code;
using System.Drawing;
using System.IO;
using HouseApp.Properties;

namespace HouseApp.UserControls
{
    public partial class UserCoMainApp : UserControl
    {
        public UserCoMainApp()
        {
            InitializeComponent();
        }

        public UserCoMainApp(bool isTrial)
        {
            _isTrial = isTrial;
            InitializeComponent();
        }

        private void UserCoMainApp_Load(object sender, EventArgs e)
        {
            SumMainBuildingMony();
            LoadBuildingData();
            MarkReadOnly();
            GetLeftDays();
            LoadImg();
            lblSerial.Text = Program.Licence.Serial;
            bgWorker.RunWorkerAsync();

        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)SetButtonsText);
        }

        #region Helpers

        /// <summary>
        /// Get number of trial days left
        /// </summary>
        private void GetLeftDays()
        {
            if (_isTrial)
            {
                DateTime dt = Convert.ToDateTime(Settings.Default.DemoDate);
                if (dt.AddDays(30) < DateTime.Today)
                {
                    //expair demo
                    MessageBox.Show("פג רישיון דמו,פנה לתמיכה לרכישת רישיון");
                }
                else
                {
                    TimeSpan i = DateTime.Today - dt;
                    lblday.Text = (30 - i.Days) + " :ימים שנותרו"; //Days Left
                    lblVersion.Text = @"גירסת דמו";
                }
            }
            else
            {
                if (Program.Licence == null) return;
                lblVersion.Text = @"Full Version";
                lblday.Text = Program.Licence.DaysTillExpiry + @" :ימים שנותרו"; //Days Left
            }
        }

        /// <summary>
        /// Load building data
        /// </summary>
        public void LoadBuildingData()//maby the problom is here? becous how load function know what row user choos ?
        {
            // Filter the respective dataTable            
            var filter = string.Format("BuildingId={0}", Utility.BuildingId);
            var dataRows = Utility.BuildingData.Select(filter);

            foreach (var row in dataRows)
            {
                // Building manager
                txtfirstName.Text = Convert.ToString(row["firstName"]);
                txtlastName.Text = Convert.ToString(row["lastName"]);
                txtemail.Text = Convert.ToString(row["email"]);
                txtapartNum.Text = Convert.ToString(row["apartNum"]);

                // Image data
                if (row["DayarImg"] != DBNull.Value)
                {
                    using (var ms = new MemoryStream((byte[])row["DayarImg"]))
                    {
                        pbBuilding.Image = Image.FromStream(ms);
                    }
                }
                else
                    pbBuilding.Image = Resources.newpic;
            }
        }

        public void SumMainBuildingMony()
        {
            int a = 0;
            int b = 0;
            decimal c = 0;
            decimal d = 0;

            //this is a = start payment
            string query1 = string.Format("SELECT SUM(startPayment) FROM Buildings WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable1 = DataAccess.GetDataTable(query1);

            //this is b = payments from users
            string query2 = string.Format("SELECT SUM(AmountPaid) FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable2 = DataAccess.GetDataTable(query2);


            //this is c = payments from projects
            string query3 = string.Format("SELECT SUM(amountIncome) FROM Income_TBL WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable3 = DataAccess.GetDataTable(query3);


            //this is d = startPaymentUser from projects
            string query4 = string.Format("SELECT SUM(DayarLastPay) FROM Dayarim_TBL WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable4 = DataAccess.GetDataTable(query4);



            if (dataTable1 != null && dataTable1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataTable1.Rows[0][0].ToString()))
                    a = Convert.ToInt32(dataTable1.Rows[0][0].ToString());
            }
            if (dataTable2 != null && dataTable2.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataTable2.Rows[0][0].ToString()))
                    b = Convert.ToInt32(dataTable2.Rows[0][0].ToString());

            }

            if (dataTable3 != null && dataTable3.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataTable3.Rows[0][0].ToString()))
                    c = Convert.ToDecimal(dataTable3.Rows[0][0].ToString());
            }

            if (dataTable4 != null && dataTable4.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataTable4.Rows[0][0].ToString()))
                    d = Convert.ToDecimal(dataTable4.Rows[0][0].ToString());
            }

            decimal sum = a + b + c + d;
            lblMainBank.Text = "₪" + sum;
        }

        public void LoadImg()
        {
            // If building id not set, return back
            if (Utility.BuildingId <= 0) return;

            var query = string.Format("SELECT DayarImg FROM Buildings WHERE BuildingId={0}", Utility.BuildingId);
            var imgColData = DataAccess.ExecuteScalar(Utility.ConnectionString, query);            

            // If imgColData not null
            if (imgColData == DBNull.Value) return;
            var byteData = (Byte[])imgColData;

            // Create memory stream from bytes
            using (var ms = new MemoryStream(byteData))
            {
                // Get image from stream
                pbBuilding.Image = Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Mark all textboxes as read only.
        /// </summary>
        private void MarkReadOnly()
        {
            txtfirstName.ReadOnly = true;
            txtlastName.ReadOnly = true;
            txtemail.ReadOnly = true;
            txtapartNum.ReadOnly = true;
        }

        /// <summary>
        /// Set buttons text
        /// </summary>
        private void SetButtonsText()
        {
            //const string query1 = "SELECT COUNT(*) FROM Dayarim_TBL";
            //var dataTable1 = DataAccess.GetDataTable(query1);

            //const string query2 = "SELECT SUM(AmountPaid) FROM Payment";
            //var dataTable2 = DataAccess.GetDataTable(query2);

            //const string query3 = "SELECT SUM(amountExpence) FROM Expence_TBL";
            //var dataTable3 = DataAccess.GetDataTable(query3);

            //const string query4 = "SELECT SUM(expenceAmount) FROM ExpenceGarden";
            //var dataTable4 = DataAccess.GetDataTable(query4);

            //const string query5 = "SELECT SUM(expenceAmount) FROM ExpenceAlavator";
            //var dataTable5 = DataAccess.GetDataTable(query5);

            //const string query6 = "SELECT SUM(expenceAmount) FROM ExpenceElec";
            //var dataTable6 = DataAccess.GetDataTable(query6);

            //const string query7 = "SELECT SUM(expenceAmount) FROM EpenceClean";
            //var dataTable7 = DataAccess.GetDataTable(query7);

            //const string query8 = "SELECT SUM(AmountPaid), SUM(AmountLeft) FROM Payment";
            //var dataTable8 = DataAccess.GetDataTable(query8);

            //const string query9 = "SELECT SUM(startPayment), SUM(startPayment) FROM vaadSet_TBL";
            //var dataTable9 = DataAccess.GetDataTable(query9);


            string query = string.Format("SELECT SUM(AmountPaid), SUM(AmountLeft) FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable = DataAccess.GetDataTable(query);

            string userQuery = string.Format("SELECT COUNT(*) FROM Dayarim_TBL WHERE BuildingId={0}", Utility.BuildingId);
            var rowCount = DataAccess.ExecuteScalar(Utility.ConnectionString, userQuery);


            if (dataTable.Rows.Count > 0)
            {

                lblZhut.Text = "₪" + dataTable.Rows[0][0];
                lblHova.Text = "₪" + dataTable.Rows[0][1];
            }
            else
            {
                lblZhut.Text = "אין נתונים";
                lblHova.Text = "אין נתונים";
            }

            lblcountDayarim.Text = rowCount != null ? rowCount.ToString() : "אין דיירים";
        }

        #endregion

    }
}
