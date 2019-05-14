using System;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserCoDayarim : UserControl
    {
        public UserCoDayarim()
        {
            InitializeComponent();
        }

        private void UserCoDayarim_Load(object sender, EventArgs e)
        {
            dataGridViewRecords.AutoGenerateColumns = false;
            GetData();
        }

        /// <summary>
        /// Bind data from database to Grid
        /// </summary>
        private void GetData()
        {
            Utility.GetAllTablesData();
            dataGridViewRecords.DataSource = Utility.DayarimData;
        }

        private void dataGridViewRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get primary key value (from column 'Dayarapartmentnum' at first index)
            if (e.RowIndex < 0) return;
            var apartmentNum = dataGridViewRecords.Rows[e.RowIndex].Cells[1].Value.ToString();

            try
            {
                switch (dataGridViewRecords.Columns[e.ColumnIndex].HeaderText)
                {
                    case "Edit":
                        SetEditableRow(e.RowIndex);
                        break;

                    case "Save":
                        UpdateRecord(e.RowIndex, apartmentNum);
                        break;

                    case "Delete":
                        DeleteRecord(apartmentNum);
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured - \r\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Helpers

        private void SetEditableRow(int rowIndex)
        {
            var currentRow = dataGridViewRecords.Rows[rowIndex];

            // 1. Prepare style for cells
            var style = new DataGridViewCellStyle {BackColor = System.Drawing.Color.Aqua};

            var padding = new Padding(1, 1, 1, 1);
            style.Padding = padding;
            style.ForeColor = System.Drawing.Color.DarkBlue;

            // 2. If index of current cell of current row matches with row index, allow it to be editable
            foreach (DataGridViewRow row in dataGridViewRecords.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (row.Index != rowIndex)
                    {
                        cell.ReadOnly = true;
                        cell.Style = null;
                    }
                    else
                    {
                        cell.ReadOnly = false;
                        cell.Style = style;
                    }
                }
            }

            // 3. Activate the first cell of current row as editable with cursor
            dataGridViewRecords.CurrentCell = currentRow.Cells[1];
            dataGridViewRecords.BeginEdit(true);
        }

        /// <summary>
        /// Update the current row clicked record.
        /// </summary>
        /// <param name="rowIndex">Current row index</param>
        /// <param name="aptNum">Primary key in current row</param>
        private void UpdateRecord(int rowIndex, string aptNum)
        {
            var row = dataGridViewRecords.Rows[rowIndex];

            //Get respective column values for current row
            var name = row.Cells[2].Value.ToString();
            var lastName = row.Cells[3].Value.ToString();
            var status = row.Cells[4].Value.ToString();
            var meeting = row.Cells[5].Value.ToString();
            var phone = row.Cells[6].Value.ToString();
            var mobile = row.Cells[7].Value.ToString();
            var email = row.Cells[8].Value.ToString();
            var payment = row.Cells[9].Value.ToString();
            var lastpayment = row.Cells[10].Value.ToString();

            // Build update query
            var queryBuilder = new StringBuilder("UPDATE Dayarim_TBL SET Dayarname='").Append(name).Append("',");
            queryBuilder.Append("Dayarlastname='").Append(lastName).Append("',");
            queryBuilder.Append("Dayarstatus='").Append(status).Append("',");
            queryBuilder.Append("Dayarjoinmeeting='").Append(meeting).Append("',");
            queryBuilder.Append("Dayarphone='").Append(phone).Append("',");
            queryBuilder.Append("Dayarmobil='").Append(mobile).Append("',");
            queryBuilder.Append("Dayaremail='").Append(email).Append("',");
            queryBuilder.Append("Dayarpay='").Append(payment).Append("',");
            queryBuilder.Append("DayarLastPay='").Append(lastpayment).Append("'");
            queryBuilder.Append("WHERE Dayarapartmentnum=").Append(Convert.ToInt32(aptNum));
            queryBuilder.Append(" AND BuildingId=").Append(Utility.BuildingId);
            var updateQuery = queryBuilder.ToString();

            // Execute query and show message
            var result = DataAccess.ExecuteNonQuery(Utility.ConnectionString, updateQuery);

            if (result)
                MessageBox.Show("Record updated successfully!", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Updating record failed.", "Update Status", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            // Refresh grid data after update
            GetData();
        }

        /// <summary>
        /// Delete the current row clicked record.
        /// </summary>
        /// <param name="aptNum">Primary key in current row</param>
        private void DeleteRecord(string aptNum)
        {
            // 1. Show dialog box for asking record deletion
            var dialogResult = MessageBox.Show("Are you sure you want to delete this record?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 2. If user clicked 'No' return back
            if (dialogResult != DialogResult.Yes) return;

            // 3. If 'Yes' clicked, prepare delete queries
            var dayarimDeleteQuery = string.Format("DELETE FROM Dayarim_TBL WHERE Dayarapartmentnum={0} AND BuildingId={1}", Convert.ToInt32(aptNum),Utility.BuildingId);
            var paymentDeleteQuery = string.Format("DELETE FROM Payment WHERE Dayarapartmentnum={0} AND BuildingId={1}", Convert.ToInt32(aptNum), Utility.BuildingId);

            // 4. Save records to 'DayarimHistory' and 'PaymentHistory'
            var recordSaved = SaveRecordToHistory(Convert.ToInt32(aptNum));

            if (recordSaved)
            {
                // 5. Execute respective delete queries
                var dCmdResult = DataAccess.ExecuteNonQuery(Utility.ConnectionString, dayarimDeleteQuery);
                var pCmdResult = DataAccess.ExecuteNonQuery(Utility.ConnectionString, paymentDeleteQuery);

                // 6. Show message accordingly (Because sometime there might not be any record in payment)
                if (dCmdResult || pCmdResult)
                    MessageBox.Show("Record deleted successfully!", "Delete Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    MessageBox.Show("Deleting record failed.", "Delete Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                // 7. Refresh grid data after delete
                GetData();
            }
            else
            {
                MessageBox.Show("Saving data to history tables failed.", "Saving Status", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save records that are about to delete to respective History tables.
        /// </summary>
        /// <param name="aptNum">Apartment number as primary key</param>
        /// <returns>Return true if all records got saved successfully</returns>
        private static bool SaveRecordToHistory(int aptNum)
        {
            // Delete records, if found, with same aptNum already in respective history tables
            var dayarimHistoryQuery = string.Format("DELETE FROM DayarimHistory WHERE Dayarapartmentnum={0} AND BuildingId={1}", aptNum, Utility.BuildingId);
            var paymentHistoryQuery = string.Format("DELETE FROM PaymentHistory WHERE Dayarapartmentnum={0} AND BuildingId={1}", aptNum, Utility.BuildingId);
            DataAccess.ExecuteNonQuery(Utility.ConnectionString, dayarimHistoryQuery);
            DataAccess.ExecuteNonQuery(Utility.ConnectionString, paymentHistoryQuery);

            // 1. Get table 'Dayarim_TBL'
            var queryForDayarim = string.Format("SELECT * FROM Dayarim_TBL WHERE Dayarapartmentnum={0} AND BuildingId={1}", aptNum, Utility.BuildingId);
            var dayarimTbl = DataAccess.GetDataTable(queryForDayarim);

            if (dayarimTbl == null || dayarimTbl.Rows.Count <= 0) return false;

            // 2. Get each entry from table 'Dayarim_TBL'
            var dayarimRow = dayarimTbl.Rows[0];
            var apartmentNum = Convert.ToString(dayarimRow["Dayarapartmentnum"]);
            var name = Convert.ToString(dayarimRow["Dayarname"]);
            var lastName = Convert.ToString(dayarimRow["Dayarlastname"]);
            var status = Convert.ToString(dayarimRow["Dayarstatus"]);
            var meeting = Convert.ToString(dayarimRow["Dayarjoinmeeting"]);
            var phone = Convert.ToString(dayarimRow["Dayarphone"]);
            var mobile = Convert.ToString(dayarimRow["Dayarmobil"]);
            var email = Convert.ToString(dayarimRow["Dayaremail"]);
            var pay = Convert.ToString(dayarimRow["Dayarpay"]);
            var lastPay = Convert.ToString(dayarimRow["DayarLastPay"]);

            // 3. Get table 'Payment'
            var queryForPaytm = string.Format("SELECT * FROM Payment WHERE Dayarapartmentnum={0} AND BuildingId={1}", aptNum, Utility.BuildingId);
            var paymentTbl = DataAccess.GetDataTable(queryForPaytm);

            if (paymentTbl != null && paymentTbl.Rows.Count > 0)
            {
                // 4. Get each entry from table 'Payment'
                var paymentRow = paymentTbl.Rows[0];
                var pName = Convert.ToString(paymentRow["Dayarname"]);
                var pLastName = Convert.ToString(paymentRow["Dayarlastname"]);
                var payType = Convert.ToString(paymentRow["PayType"]);
                var month = Convert.ToString(paymentRow["Month"]);
                var year = Convert.ToString(paymentRow["Year"]);
                var idNotification = Convert.ToString(paymentRow["IdNotification"]);
                var pPay = Convert.ToString(paymentRow["Dayarpay"]);
                var amountPaid = Convert.ToString(paymentRow["AmountPaid"]);
                var amountLeft = Convert.ToString(paymentRow["AmountLeft"]);

                // 5. Save record to 'DayarimHistory'
                DataAccess.SaveToDayarim("DayarimHistory", apartmentNum, name, lastName, status, meeting, phone, mobile, email, pay, lastPay);

                // 6. Save record to 'PaymentHistory'
                return DataAccess.SaveToPayment("PaymentHistory", apartmentNum, pName, pLastName, payType, month, year, idNotification, pPay, amountPaid, amountLeft);
            }

            // 4. Save record to 'DayarimHistory'
            return DataAccess.SaveToDayarim("DayarimHistory", apartmentNum, name, lastName, status, meeting, phone, mobile, email, pay, lastPay);
        }

        #endregion
    }
}
