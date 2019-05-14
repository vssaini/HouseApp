using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserCoHistory : UserControl
    {
        // Global variables
        private string _dayarPay;
        private int _currentYear = DateTime.Now.Year;
        private bool _showMessage;

        public UserCoHistory()
        {
            InitializeComponent();
        }

        private void UserData_Load(object sender, EventArgs e)
        {
            DisableControls();
            bgWorker2.RunWorkerAsync();
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            PopulateForm();
            populateTotalPaid();

            if (_showMessage) // There is no records
            {
                MessageBox.Show("No records found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else // If records, show other controls
            {
                groupBox1.Visible = true;
                groupBox3.Visible = true;
            }

            bgWorker.RunWorkerAsync();
        }

        private void cboYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentYear = Convert.ToInt32(cboYearOfPay.SelectedValue.ToString());
            bgWorker.RunWorkerAsync();
        }

        #region TextChanged Events



        #endregion

        /// <summary>
        /// This is a function that is executed on another thread. It is done to reduce loading main thread. This function call method PopulateMonthButtons so as to set 12 cubes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)PopulateMonthCubes);
        }

        private void bgWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)PopulateCombobox);
        }

        #region Helpers

        /// <summary>
        /// Disable specific cotnrols on this user contorl
        /// </summary>
        public void DisableControls()
        {
            groupBox1.Visible = false;

            groupBox3.Visible = false;
            cboApartment.Text = ("בחר בבקשה....");
        }

        /// <summary>
        /// Fill combobox by data from database to show apartment.
        /// </summary>
        public void PopulateCombobox()
        {
            // Bind apartment
            var query = string.Format("SELECT Dayarapartmentnum FROM DayarimHistory WHERE BuildingId={0} ORDER BY Dayarapartmentnum", Utility.BuildingId);
            var dataTable = DataAccess.GetDataTable(query);
            cboApartment.DataSource = dataTable;
            cboApartment.DisplayMember = "Dayarapartmentnum";
            cboApartment.ValueMember = "Dayarapartmentnum";

            // Bind years
            var yearQuery = string.Format("SELECT DISTINCT Year FROM PaymentHistory WHERE BuildingId={0}", Utility.BuildingId);
            var yearData = DataAccess.GetDataTable(yearQuery);

            if (yearData.Rows.Count > 0)
            {
                cboYearOfPay.DataSource = yearData;
                cboYearOfPay.DisplayMember = "Year";
                cboYearOfPay.ValueMember = "Year";

                _currentYear = Convert.ToInt32(cboYearOfPay.SelectedValue.ToString());
            }
            else
            {
                var currentYear = DateTime.Now.Year;
                cboYearOfPay.SelectedText = currentYear.ToString(CultureInfo.InvariantCulture);
            }

            cboYearOfPay.SelectedIndexChanged += cboYears_SelectedIndexChanged;
        }

        /// <summary>
        /// Fill respective fields on user control as per value selected in Apartment combobox.
        /// </summary>
        public void PopulateForm()
        {
            var query = string.Format("SELECT * FROM DayarimHistory WHERE Dayarapartmentnum={0} AND BuildingId={1}",
                 cboApartment.SelectedValue, Utility.BuildingId);

            // Get all data into table
            var table = DataAccess.GetDataTable(query);

            if (table.Rows.Count > 0)
            {
                // Now get row and column values to set controls text
                lblApartmentNum.Text = Convert.ToString(table.Rows[0]["Dayarapartmentnum"]);
                lblFirstName.Text = "שם פרטי: " + table.Rows[0]["Dayarname"];
                lblLastName.Text = "שם משפחה: " + table.Rows[0]["Dayarlastname"];
                lblDayarPhone.Text = "טלפון בית: " + table.Rows[0]["Dayarphone"];
                lblDayarMobile.Text = "נייד: " + table.Rows[0]["Dayarmobil"];
                lblDayarEmail.Text = "אימייל: " + table.Rows[0]["Dayaremail"];
                _dayarPay = Convert.ToString(table.Rows[0]["Dayarpay"]);
                lbllastpayResult.Text = "" + table.Rows[0]["DayarLastPay"];
                lblDayarPay.Text = "תשלום חודשי: ";
                lblpayAmount.Text = _dayarPay + "₪";

                _showMessage = false;
            }
            else
            {
                _showMessage = true;
            }

        }

        //here i calculate the AmountPaid from "payment" table + DayarLastPay from "Dayarim_TBL"
        //and show tham in btnUserMony button, when load apartment number in combobox
        private void populateTotalPaid()
        {
            //part 2 of DayarLastPay
            var query =
                string.Format(
                    "SELECT SUM (DayarLastPay) FROM DayarimHistory d WHERE d.Dayarapartmentnum={0} AND BuildingId={1}",
                    cboApartment.SelectedValue, Utility.BuildingId);

            // Execute query and get result
            var total1 = DataAccess.ExecuteScalar(Utility.ConnectionString, query);
            //if (total1 != DBNull.Value)
            if (Convert.ToDecimal(total1) > 0)
            {
                btnUserMony.Text = total1.ToString();
                btnUserMony.BackColor = Color.Green;
            }

            if (Convert.ToDecimal(total1) < 0)
            {
                // If less from 0 so show red color
                btnUserMony.Text = total1.ToString();
                btnUserMony.BackColor = Color.Red;
            }
            else
            {
                // If less from 0 so show red color
                btnUserMony.Text = total1.ToString();
                btnUserMony.BackColor = Color.Green;
            }


            // TODO: Execute query to check if PaymentHistory is having records or not
            var queryForPayment = string.Format("SELECT * FROM PaymentHistory WHERE BuildingId={0}", Utility.BuildingId);
            var cmdResult = DataAccess.ExecuteScalar(Utility.ConnectionString, queryForPayment);

            if (cmdResult != null)
            {
                _showMessage = false;

                // Sum AmountPaid from 'Payment' table (AND) Sum DayarPay from 'Dayarim_TBL' table
                //part 1 of Amountpaid
                var query1 = string.Format("SELECT SUM (AmountPaid) FROM PaymentHistory p  WHERE p.Dayarapartmentnum={0} AND BuildingId={1}", cboApartment.SelectedValue, Utility.BuildingId);

                // Execute query and get result
                var totalSum = DataAccess.ExecuteScalar(Utility.ConnectionString, query1);
                if (string.IsNullOrEmpty(totalSum.ToString()))
                {
                    totalSum = 0;
                }

                //part 2 of DayarLastPay
                // Execute query and get result
                var total = DataAccess.ExecuteScalar(Utility.ConnectionString, query1);
                //if (total != DBNull.Value)
                if (Convert.ToDecimal(total1) > 0)
                {
                    totalSum = Convert.ToDecimal(totalSum) + Convert.ToDecimal(total);
                    btnUserMony.Text = totalSum.ToString();
                    btnUserMony.BackColor = Color.Green;
                }

                if (Convert.ToDecimal(total1) < 0)
                {
                    // If more big from 0 so show green color
                    totalSum = Convert.ToDecimal(totalSum) + Convert.ToDecimal(total);
                    btnUserMony.Text = totalSum.ToString();
                    btnUserMony.BackColor = Color.Red;
                }


                else
                {
                    // If less from 0 so show red color
                    btnUserMony.Text = totalSum.ToString();
                    btnUserMony.BackColor = Color.Green;
                }
            }
        }



        /// <summary>
        /// Populate month cubes value and color
        /// </summary>
        private void PopulateMonthCubes()
        {
            // 1. Get data from database
            var query = new StringBuilder("SELECT Month,Dayarpay,AmountPaid,AmountLeft FROM PaymentHistory WHERE Dayarapartmentnum=");
            query.Append(cboApartment.SelectedValue).Append(" AND BuildingId=").Append(Utility.BuildingId).Append(" AND Year=").Append(_currentYear);

            #region Reset Controls & Prevent event firing



            // Reset controls text
            lblYearOfPay.Text = string.Format("שנת הכרטיס: {0}", _currentYear);



            #endregion

            var dt = DataAccess.GetDataTable(query.ToString());

            // 2. Reset buttons style and text as it was earlier
            Control[] controls = { btnJanuaryPaid, btnFebruaryPaid, btnMarchPaid, btnAprilPaid, btnMayPaid, btnJunePaid, btnJulyPaid, btnAugustPaid, btnSeptemberPaid, btnOctoberPaid, btnNovemberPaid, btnDecemberPaid, btnJanuaryLeft, btnFebruaryLeft, btnMarchLeft, btnAprilLeft, btnMayLeft, btnJuneLeft, btnJulyLeft, btnAugustLeft, btnSeptemberLeft, btnOctoberLeft, btnNovemberLeft, btnDecemberLeft };
            foreach (Button button in controls)
            {
                button.UseVisualStyleBackColor = true;
                button.Text = string.Empty;
            }

            // 3. Retrieve month value from Rows and set text on cubes
            foreach (DataRow row in dt.Rows)
            {
                var month = Convert.ToInt32(row["Month"]);

                switch (month)
                {
                    case 1:
                        MarkPaymentHistoryStatus(row, btnJanuaryPaid, btnJanuaryLeft);
                        break;
                    case 2:
                        MarkPaymentHistoryStatus(row, btnFebruaryPaid, btnFebruaryLeft);
                        break;
                    case 3:
                        MarkPaymentHistoryStatus(row, btnMarchPaid, btnMarchLeft);
                        break;
                    case 4:
                        MarkPaymentHistoryStatus(row, btnAprilPaid, btnAprilLeft);
                        break;
                    case 5:
                        MarkPaymentHistoryStatus(row, btnMayPaid, btnMayLeft);
                        break;
                    case 6:
                        MarkPaymentHistoryStatus(row, btnJunePaid, btnJuneLeft);
                        break;
                    case 7:
                        MarkPaymentHistoryStatus(row, btnJulyPaid, btnJulyLeft);
                        break;
                    case 8:
                        MarkPaymentHistoryStatus(row, btnAugustPaid, btnAugustLeft);
                        break;
                    case 9:
                        MarkPaymentHistoryStatus(row, btnSeptemberPaid, btnSeptemberLeft);
                        break;
                    case 10:
                        MarkPaymentHistoryStatus(row, btnOctoberPaid, btnOctoberLeft);
                        break;
                    case 11:
                        MarkPaymentHistoryStatus(row, btnNovemberPaid, btnNovemberLeft);
                        break;
                    case 12:
                        MarkPaymentHistoryStatus(row, btnDecemberPaid, btnDecemberLeft);
                        break;
                }

            }
        }

        /// <summary>
        /// Set cube color and  text on basis of amount paid or left values
        /// </summary>
        /// <param name="row">Current row</param>
        /// <param name="btnPaid">Paid button</param>
        /// <param name="btnLeft">Left button</param>
        private static void MarkPaymentHistoryStatus(DataRow row, Control btnPaid, Control btnLeft)
        {
            var amountPaid = Convert.ToInt32(row["AmountPaid"]);
            var amountLeft = Convert.ToInt32(row["AmountLeft"]);

            // Paid button settings
            btnPaid.Text = amountPaid.ToString(CultureInfo.InvariantCulture);
            btnPaid.BackColor = Color.LightGreen;

            // Left button settings
            if (amountLeft == 0) return;
            btnLeft.Text = string.Format("-{0}", amountLeft.ToString(CultureInfo.InvariantCulture));
            btnLeft.BackColor = Color.LightCoral;
        }

        #endregion

        //Delete user monthly PaymentHistory
        private void btnDeletePay_Click(object sender, EventArgs e)
        {
            //if (!btnUpdate.CanSelect)
            //{
            //    MessageBox.Show("לביצוע מחיקת או עדכון תשלום חובה לבחור חודש בשורת הקוביות");
            //}
            //else
            //{
            //    // 2. Prepare update query
            //    //var query =
            //    //    string.Format(
            //    //        "UPDATE PaymentHistory SET PayType='{0}',AmountPaid={1},AmountLeft={2},IdNotification='{3}',Month='{4}',Year='{5}' WHERE Dayarapartmentnum='{6}' AND Month={7}",
            //    //        cboPaymentHistoryType.SelectedItem, amountPaid, amountLeft, txtIdNotification.Text, month, year,
            //    //        cboApartment.SelectedValue, month);

            //    SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            //    con.Open();
            //    SqlCeCommand cmd = new SqlCeCommand("DELETE FROM PaymentHistory WHERE Month = @Month ", con);
            //    cmd.Parameters.AddWithValue("@Month", cboMonthOfPay.SelectedIndex + 1);

            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        PopulateForm();
            //        bgWorker.RunWorkerAsync();
            //        MessageBox.Show("תשלום חודש זה נמחק בהצלחה");

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}

        }
    }
}

