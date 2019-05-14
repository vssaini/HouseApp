using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserCoAlert : UserControl
    {
        // Global variables
        private int _currentYear, _currentMonth;

        public UserCoAlert()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 1. Set current month value            
            dataGridViewUsers.AutoGenerateColumns = true;

            // PREVIOUS QUERY
            // var query = new StringBuilder("SELECT Dayarapartmentnum,Dayarname,Dayarlastname,Dayarpay,AmountPaid,AmountLeft FROM Payment WHERE Year="); 
            // query.Append(_currentYear).Append(" AND Month=").Append(_currentMonth);

            // 2. Prepare query for retireivng values
            var query = new StringBuilder("SELECT Dayarapartmentnum AS Apartment,Dayarname AS FirstName,Dayarlastname AS LastName,SUM(Dayarpay) AS Payment,SUM(AmountPaid) AS TotalPaid,SUM(AmountLeft) AS TotalLeft FROM Payment WHERE");

            query.Append(" BuildingId=").Append(Utility.BuildingId).Append("AND Year=");

            if (chkShowAllUsers.Checked)
                query.Append(_currentYear).Append(" GROUP BY Dayarapartmentnum,Dayarname,Dayarlastname");
            else
                query.Append(_currentYear).Append(" AND Month=").Append(_currentMonth).Append(" GROUP BY Dayarapartmentnum,Dayarname,Dayarlastname");

            // 3.  Retrieve data from database into datatable
            var dataTable = DataAccess.GetDataTable(query.ToString());
            dataGridViewUsers.DataSource = dataTable;

            // 4. Customize column names
            dataGridViewUsers.Columns[0].HeaderText = "Apartment";
            dataGridViewUsers.Columns[1].HeaderText = "First Name";
            dataGridViewUsers.Columns[2].HeaderText = "Last Name";
            dataGridViewUsers.Columns[3].HeaderText = "Total Payment";
            dataGridViewUsers.Columns[4].HeaderText = "Total Paid";
            dataGridViewUsers.Columns[5].HeaderText = "Total Left";

            // 5. If value of DayarPay equals to value of AmountPaid, set color green else red(light coral)
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                //row.DefaultCellStyle.BackColor = row.Cells["Payment"].Value.Equals(row.Cells["TotalPaid"].Value) ? Color.LightGreen : Color.LightCoral;

                var payment = Convert.ToInt32(row.Cells["Payment"].Value.ToString());
                var totalPaid = Convert.ToInt32(row.Cells["TotalPaid"].Value.ToString());
                var totalleft = Convert.ToInt16(row.Cells["TotalLeft"].Value.ToString());

                // Check if else and set color
                if (payment.Equals(totalPaid) || payment < totalPaid || totalleft == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }

                // If show all is checked, then set red color for row for if  else
                if (chkShowAllUsers.Checked)
                {
                    var totalLeft = Convert.ToInt32(row.Cells["TotalLeft"].Value.ToString());

                    if (totalLeft > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        private void UserCoAlert_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }

        private void cboYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            var year = cboYears.SelectedValue.ToString();
            _currentYear = Convert.ToInt32(year);
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentMonth = cboMonth.SelectedIndex + 1;
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)InitializeControls);
        }

        /// <summary>
        /// Initialize combo values
        /// </summary>
        private void InitializeControls()
        {
            // Fill year comboboxes with  values from database          
            var query = string.Format("SELECT DISTINCT Year FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
            var dataTable = DataAccess.GetDataTable(query);

            if (dataTable.Rows.Count > 0)
            {
                cboYears.DataSource = dataTable;
                cboYears.DisplayMember = "Year";
                cboYears.ValueMember = "Year";

                // Fill month combobox with months values
                Utility.FillMonths(cboMonth);

                // Enable controls
                btnLoad.Enabled = true;
                cboYears.Enabled = true;
                cboMonth.Enabled = true;

                // Set selected index
                cboYears.SelectedIndex = 0;
                cboMonth.SelectedIndex = 0;

                var firstIndex = Convert.ToInt32(cboMonth.SelectedIndex) + 1;

                // Set default year and month valeus
                _currentYear = Convert.ToInt32(cboYears.SelectedValue.ToString());
                _currentMonth = firstIndex;

                // Bind Event Handlers
                cboYears.SelectedIndexChanged += cboYears_SelectedIndexChanged;
                cboMonth.SelectedIndexChanged += cboMonth_SelectedIndexChanged;
            }
            else
            {
                btnLoad.Enabled = false;
                cboYears.Enabled = false;
                cboMonth.Enabled = false;
            }
        }

    }
}
