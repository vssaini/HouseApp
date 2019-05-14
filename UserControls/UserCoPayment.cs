using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserCoPayment : UserControl
    {
        // Global variables
        private string _dayarPay;
        private int _currentYear = DateTime.Now.Year;
        private bool _showMessage;

        public UserCoPayment()
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

            lblnote.Visible = true;
            btnSavePayment.Visible = true;
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

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            // 1. Prepare values to be saved in database
            if (IsNotEmpty())
            {
                decimal amountLeft = 0;
                var totalToPay = Convert.ToDecimal(_dayarPay);
                var amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                if (amountPaid < totalToPay)
                    amountLeft = totalToPay - amountPaid;

                var month = cboMonthOfPay.SelectedIndex + 1;
                int year = Convert.ToInt32(cboYearOfPay.Text);
                if (cboYearOfPay.Items.Count > 0)
                    year = Convert.ToInt32(cboYearOfPay.SelectedValue.ToString());

                // 1.A. Check if record not exists already
                var existQuery = string.Format("SELECT Dayarname FROM Payment WHERE Dayarapartmentnum='{0}' AND BuildingId={1} AND Month={2} AND Year={3}", cboApartment.SelectedValue, Utility.BuildingId, month, year);

                var dataTable = DataAccess.GetDataTable(existQuery);

                if (dataTable.Rows.Count.Equals(0))
                {
                    // 2. Create insert query using values
                    var query = @"INSERT INTO Payment(Dayarapartmentnum, BuildingId, Dayarname, Dayarlastname,PayType,Month, Year, IdNotification,Dayarpay,AmountPaid,AmountLeft) VALUES ('" + lblApartmentNum.Text + "','" + Utility.BuildingId + "','" + lblFirstName.Text + "','" + lblLastName.Text + "','" + cboPaymentType.SelectedItem + "'," + month + "," + year + ",'" + txtIdNotification.Text + "'," + totalToPay + "," + amountPaid + "," + amountLeft + ")";

                    // 3. Execute query to save payment record
                    var result = DataAccess.ExecuteNonQuery(Utility.ConnectionString, query);



                    // 4. Show message accordingly
                    if (result)
                    {
                        MessageBox.Show("פעולת תשלום נשמרה בהצלחה!", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopulateMonthCubes();
                        PopulateForm();
                        populateTotalPaid();
                    }


                    else
                    {
                        MessageBox.Show("שמירה נכשלה,נסה שוב.", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("קיים תשלום לחודש זה, השתמש בכפתור עדכון ולא בכפתור שמירה.", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("נתונים חסרים,בדוק ולחץ עדכן שנית.", "Updating Failed", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

            }

        }

        private void btnCube_Click(object sender, EventArgs e)
        {
            // Enable or disable button update
            ToggleUpdateEnable(null);

            // Cast sender as button
            var btn = sender as Button;
            if (btn == null) return;
            var cubeName = btn.Name;

            // Prepare query half part
            var query = new StringBuilder("SELECT PayType,AmountPaid,IdNotification,Month,Year FROM Payment WHERE Dayarapartmentnum='").Append(cboApartment.SelectedValue).Append(" AND BuildingId=").Append(Utility.BuildingId).Append("' AND Month=");

            // Complete query part and bind to card textboxes
            switch (cubeName)
            {
                case "btnJanuaryPaid":
                    query.Append(1).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnFebruaryPaid":
                    query.Append(2).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnMarchPaid":
                    query.Append(3).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnAprilPaid":
                    query.Append(4).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnMayPaid":
                    query.Append(5).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnJunePaid":
                    query.Append(6).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnJulyPaid":
                    query.Append(7).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnAugustPaid":
                    query.Append(8).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnSeptemberPaid":
                    query.Append(9).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnOctoberPaid":
                    query.Append(10).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnNovemberPaid":
                    query.Append(11).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;

                case "btnDecemberPaid":
                    query.Append(12).Append(" AND YEAR=").Append(_currentYear);
                    BindDataToControls(query.ToString());
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsNotEmpty())
            {
                // 1. Set values to be updated
                decimal amountLeft = 0;
                var dayarPay = Convert.ToInt32(_dayarPay);
                var amountPaid = Convert.ToInt32(txtAmountPaid.Text);
                if (amountPaid < dayarPay)
                    amountLeft = dayarPay - amountPaid;

                var month = cboMonthOfPay.SelectedIndex + 1;

                // when manager update user payment's so it is need to folow year of payment
                var year = DateTime.Now.Year;
                if (cboYearOfPay.Items.Count > 0)
                    year = Convert.ToInt32(cboYearOfPay.SelectedValue.ToString());

                // 2. Prepare update query
                var query =
                    string.Format(
                        "UPDATE Payment SET PayType='{0}',AmountPaid={1},AmountLeft={2},IdNotification='{3}',Month='{4}',Year='{5}' WHERE Dayarapartmentnum='{6}' AND Month={7} AND BuildingId={8}",
                        cboPaymentType.SelectedItem, amountPaid, amountLeft, txtIdNotification.Text, month, year,
                        cboApartment.SelectedValue, month, Utility.BuildingId);

                // 3. Executeq uery
                var result = DataAccess.ExecuteNonQuery(Utility.ConnectionString, query);

                // 4. Show message
                if (result)
                {
                    PopulateMonthCubes();
                    MessageBox.Show("Record updated successfully!", "Update Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnSavePayment.Enabled = true;
                }
                else
                    MessageBox.Show("Updating record failed.", "Update Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Some of fields are still blank.", "Updating Failed", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }

        }

        // Handle textAmount keypress event.
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if e.KeyChar is less than 48 (number zero) OR greater than 57 (number 9) AND not equal to 8(BACKSPACE)
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                toolTip1.OwnerDraw = false;
                toolTip1.Show("ניתן להקיש ספרות בלבד.", txtAmountPaid, 4000);
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }
        }

        private void txtAmountPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmountPaid.Text)) return;

            var dayarpay = Convert.ToInt32(_dayarPay);
            var amountpaid = Convert.ToInt32(txtAmountPaid.Text);

            // Show tooltip if amount more than dayarpay
            if (amountpaid > dayarpay)
            {
                toolTip1.Show("לידיעה, אתה מזין סכום שיותר גדול מהתשלום החודשי ללקוח.", txtAmountPaid, 4000);
            }
        }

        private void cboYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentYear = Convert.ToInt32(cboYearOfPay.SelectedValue.ToString());
            bgWorker.RunWorkerAsync();
        }

        #region TextChanged Events

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            // if not blank, set amount
            if (!string.IsNullOrEmpty(txtAmountPaid.Text))
            {
                btnUpdate.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
                errorProvider1.SetError(txtAmountPaid, "Amount can't be left blank.");
            }
        }

        private void cboPaymentType_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPaymentType.Text))
            {
                btnUpdate.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
                errorProvider1.SetError(cboPaymentType, "Payment Type can't be left blank.");
            }
        }

        private void txtIdNotification_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdNotification.Text))
            {
                btnUpdate.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
                errorProvider1.SetError(txtIdNotification, "Notification can't be left blank.");
            }
        }

        private void cboMonthOfPay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboMonthOfPay.Text))
            {
                btnUpdate.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
                errorProvider1.SetError(cboMonthOfPay, "Month can't be left blank.");
            }
        }

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
            lblnote.Visible = false;
            cboApartment.Text = ("בחר בבקשה....");
        }

        /// <summary>
        /// Fill combobox by data from database to show apartment.
        /// </summary>
        public void PopulateCombobox()
        {
            // Bind apartment
            string query = string.Format("SELECT Dayarapartmentnum FROM Dayarim_TBL WHERE BuildingId={0} ORDER BY Dayarapartmentnum", Utility.BuildingId);
            var dataTable = DataAccess.GetDataTable(query);
            cboApartment.DataSource = dataTable;
            cboApartment.DisplayMember = "Dayarapartmentnum";
            cboApartment.ValueMember = "Dayarapartmentnum";

            // Bind years
            string yearQuery = string.Format("SELECT DISTINCT Year FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
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
            var queryBuilder = new StringBuilder("SELECT * FROM Dayarim_TBL WHERE Dayarapartmentnum='");
            queryBuilder.Append(cboApartment.SelectedValue).Append("' AND BuildingId=").Append(Utility.BuildingId);

            // Get all data into table
            var table = DataAccess.GetDataTable(queryBuilder.ToString());

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
            var query1 = new StringBuilder("SELECT SUM (DayarLastPay) FROM Dayarim_TBL d WHERE d.Dayarapartmentnum=");
            query1.Append(cboApartment.SelectedValue).Append(" AND BuildingId=").Append(Utility.BuildingId);

            // Execute query and get result
            var total1 = DataAccess.ExecuteScalar(Utility.ConnectionString, query1.ToString());
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
            string queryForPayment = string.Format("SELECT * FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
            var cmdResult = DataAccess.ExecuteScalar(Utility.ConnectionString, queryForPayment);

            if (cmdResult != null)
            {
                _showMessage = false;

                // Sum AmountPaid from 'Payment' table (AND) Sum DayarPay from 'Dayarim_TBL' table
                //part 1 of Amountpaid
                var query = new StringBuilder("SELECT SUM (AmountPaid) FROM Payment p  WHERE p.Dayarapartmentnum=");
                query.Append(cboApartment.SelectedValue).Append(" AND BuildingId=").Append(Utility.BuildingId);

                // Execute query and get result
                var totalSum = DataAccess.ExecuteScalar(Utility.ConnectionString, query.ToString());
                if (string.IsNullOrEmpty(totalSum.ToString()))
                {
                    totalSum = 0;
                }


                //part 2 of DayarLastPay
                query = new StringBuilder("SELECT SUM (DayarLastPay) FROM Dayarim_TBL d WHERE d.Dayarapartmentnum=");
                query.Append(cboApartment.SelectedValue).Append(" AND BuildingId=").Append(Utility.BuildingId);

                // Execute query and get result
                var total = DataAccess.ExecuteScalar(Utility.ConnectionString, query.ToString());
                //if (total != DBNull.Value)
                if (Convert.ToDecimal(total) > 0)
                {
                    totalSum = Convert.ToDecimal(totalSum) + Convert.ToDecimal(total);
                    btnUserMony.Text = totalSum.ToString();
                    btnUserMony.BackColor = Color.Green;
                }

                if (Convert.ToDecimal(total) < 0)
                {
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
            var query = new StringBuilder("SELECT Month,Dayarpay,AmountPaid,AmountLeft FROM Payment WHERE Dayarapartmentnum='");
            query.Append(cboApartment.SelectedValue).Append("' AND BuildingId=").Append(Utility.BuildingId).Append(" AND Year=").Append(_currentYear);

            #region Reset Controls & Prevent event firing

            // Remove event handlers
            txtIdNotification.TextChanged -= txtIdNotification_TextChanged;
            cboMonthOfPay.TextChanged -= cboMonthOfPay_TextChanged;
            cboPaymentType.TextChanged -= cboPaymentType_TextChanged;
            txtAmountPaid.TextChanged -= txtAmountPaid_TextChanged;

            // Reset controls text
            lblYearOfPay.Text = string.Format("שנת הכרטיס: {0}", _currentYear);
            txtAmountPaid.Text = string.Empty;
            txtIdNotification.Text = string.Empty;
            cboMonthOfPay.Text = string.Empty;
            cboPaymentType.Text = string.Empty;

            // Add event handlers
            txtIdNotification.TextChanged += txtIdNotification_TextChanged;
            cboMonthOfPay.TextChanged += cboMonthOfPay_TextChanged;
            cboPaymentType.TextChanged += cboPaymentType_TextChanged;
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;

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
                        MarkPaymentStatus(row, btnJanuaryPaid, btnJanuaryLeft);
                        break;
                    case 2:
                        MarkPaymentStatus(row, btnFebruaryPaid, btnFebruaryLeft);
                        break;
                    case 3:
                        MarkPaymentStatus(row, btnMarchPaid, btnMarchLeft);
                        break;
                    case 4:
                        MarkPaymentStatus(row, btnAprilPaid, btnAprilLeft);
                        break;
                    case 5:
                        MarkPaymentStatus(row, btnMayPaid, btnMayLeft);
                        break;
                    case 6:
                        MarkPaymentStatus(row, btnJunePaid, btnJuneLeft);
                        break;
                    case 7:
                        MarkPaymentStatus(row, btnJulyPaid, btnJulyLeft);
                        break;
                    case 8:
                        MarkPaymentStatus(row, btnAugustPaid, btnAugustLeft);
                        break;
                    case 9:
                        MarkPaymentStatus(row, btnSeptemberPaid, btnSeptemberLeft);
                        break;
                    case 10:
                        MarkPaymentStatus(row, btnOctoberPaid, btnOctoberLeft);
                        break;
                    case 11:
                        MarkPaymentStatus(row, btnNovemberPaid, btnNovemberLeft);
                        break;
                    case 12:
                        MarkPaymentStatus(row, btnDecemberPaid, btnDecemberLeft);
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
        private static void MarkPaymentStatus(DataRow row, Control btnPaid, Control btnLeft)
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

        /// <summary>
        /// Fill card textboxes and comboboxes on click of cube
        /// </summary>
        /// <param name="query"></param>
        private void BindDataToControls(string query)
        {
            var dataTable = DataAccess.GetDataTable(query);

            if (dataTable.Rows.Count > 0)
            {
                // Remove event handler it was causing issue while updating from cube
                txtAmountPaid.TextChanged -= txtAmountPaid_TextChanged;

                cboPaymentType.Text = dataTable.Rows[0]["PayType"].ToString();
                txtAmountPaid.Text = dataTable.Rows[0]["AmountPaid"].ToString();
                txtIdNotification.Text = dataTable.Rows[0]["IdNotification"].ToString();

                cboMonthOfPay.SelectedIndex = Convert.ToInt32(dataTable.Rows[0]["Month"].ToString()) - 1;

                lblYearOfPay.Text = string.Format("Year of Pay: {0}", dataTable.Rows[0]["Year"]);

                txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;
                btnSavePayment.Enabled = false;
            }
            else
                btnSavePayment.Enabled = true;
        }

        /// <summary>
        /// Enable or disable update button. And also set error on thsee controls 
        /// </summary>
        private void ToggleUpdateEnable(Control control)
        {
            // Enable Update button
            if (IsNotEmpty())
            {
                btnUpdate.Enabled = true;
                errorProvider1.Clear();
            }
            else
            {
                btnUpdate.Enabled = false;
                if (control != null)
                    errorProvider1.SetError(control, "Value can't be left blank.");
            }
        }

        /// <summary>
        /// Check if respective controls are not empty
        /// </summary>
        /// <returns></returns>
        private bool IsNotEmpty()
        {
            return !string.IsNullOrEmpty(cboMonthOfPay.Text) && !string.IsNullOrEmpty(cboYearOfPay.Text) &&
                   !string.IsNullOrEmpty(txtAmountPaid.Text) && !string.IsNullOrEmpty(txtIdNotification.Text) &&
                   !string.IsNullOrEmpty(cboPaymentType.Text);
        }

        #endregion

        //Delete user monthly payment
        private void btnDeletePay_Click(object sender, EventArgs e)
        {
            if (!btnUpdate.CanSelect)
            {
                MessageBox.Show("לביצוע מחיקת או עדכון תשלום חובה לבחור חודש בשורת הקוביות");
            }
            else
            {
                // 2. Prepare update query
                //var query =
                //    string.Format(
                //        "UPDATE Payment SET PayType='{0}',AmountPaid={1},AmountLeft={2},IdNotification='{3}',Month='{4}',Year='{5}' WHERE Dayarapartmentnum='{6}' AND Month={7}",
                //        cboPaymentType.SelectedItem, amountPaid, amountLeft, txtIdNotification.Text, month, year,
                //        cboApartment.SelectedValue, month);

                SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();

                SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Payment WHERE Dayarapartmentnum=@Dayarapartmentnum AND BuildingId=@BuildingId AND Month = @Month ", con);

                cmd.Parameters.AddWithValue("@Dayarapartmentnum", cboApartment.SelectedText);
                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@Month", cboMonthOfPay.SelectedIndex + 1);

                cmd.ExecuteNonQuery();
                PopulateForm();
                bgWorker.RunWorkerAsync();
                MessageBox.Show("תשלום חודש זה נמחק בהצלחה");
            }

        }
    }
}

