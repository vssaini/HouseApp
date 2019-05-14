//using System.Web.UI.DataVisualization.Charting;
//using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using HouseApp.Code;

namespace HouseApp.UserControls
{
    public partial class UserIncome : UserControl
    {
        public UserIncome()
        {
            InitializeComponent();
        }

        private void UserIncome_Load(object sender, EventArgs e)
        {
            loadGraph();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView5.AutoGenerateColumns = false;
            dataGridView6.AutoGenerateColumns = false;
            GetData1();
            Utility.GetAllTablesData();
            lblnote.Text =
                "במסך זה מוסיפים הכנסה לטובת פרויקט בבניין ולא תשלומי דיירים.\n הכנסות תשלומי דיירים מחושבים אוטומטית ולא נדרש להוסיפם שוב במסך זה";
            lblnote3.Text = "במסך זה ניתן להוסיף הוצאה כללית חדשה אשר אין לה קטגוריה מתאימה בלשוניות";
            lblnote4.Text = "במסך זה ניתן לנהל את הוצאות חשבון החשמל";
            lblnote5.Text = "במסך זה ניתן לנהל את הוצאות חשבון הגינון";
            lblnote6.Text = "במסך זה ניתן לנהל את הוצאות חשבון הניקיון";
            lblnote7.Text = "במסך זה ניתן לנהל את הוצאות חשבון המעלית";
        }

        /// <summary>
        ///     Bind data from database to Grid
        /// </summary>
        private void GetData1()
        {
            //you see here i call data from database
            Cleardata();
            Utility.GetAllTablesData();
            dataGridView1.DataSource = Utility.Income;
            dataGridView2.DataSource = Utility.Expence;
            dataGridView3.DataSource = Utility.ExpenceElec;
            dataGridView4.DataSource = Utility.ExpenceGarden;
            dataGridView5.DataSource = Utility.ExpenceClean;
            dataGridView6.DataSource = Utility.ExpenceAlavator;
        }

        private void Cleardata()
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
            dataGridView5.ClearSelection();
            dataGridView6.ClearSelection();
            txtAmount.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
            txtAmount2.Text = "";
            txtName2.Text = "";
            txtDetails2.Text = "";
            txtamountELC.Text = "";
            txtnameELC.Text = "";
            txtdetailsELC.Text = "";
        }

        /// <summary>
        ///     Save user Income to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// save user income data to db
        private void button1_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(txtAmount.Text) ||
                string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDetails.Text))
            {
                errorProvider1.SetError(dateTimePicker1, msgStr);
                errorProvider1.SetError(txtAmount, msgStr);
                errorProvider1.SetError(txtName, msgStr);
                errorProvider1.SetError(txtDetails, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO Income_TBL (BuildingId,dateIncome,amountIncome,nameIncome,detailsIncome) VALUES (@BuildingId,@dateIncome,@amountIncome,@nameIncome,@detailsIncome)",
                        con);

                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@dateIncome", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@amountIncome", txtAmount.Text);
                cmd.Parameters.AddWithValue("@nameIncome", txtName.Text);
                cmd.Parameters.AddWithValue("@detailsIncome", txtDetails.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        /// <summary>
        ///     EXPENCE GENERAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker2.Text) || string.IsNullOrEmpty(txtAmount2.Text) ||
                string.IsNullOrEmpty(txtName2.Text) || string.IsNullOrEmpty(txtDetails2.Text))
            {
                errorProvider1.SetError(dateTimePicker2, msgStr);
                errorProvider1.SetError(txtAmount2, msgStr);
                errorProvider1.SetError(txtName2, msgStr);
                errorProvider1.SetError(txtDetails2, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO Expence_TBL (BuildingId, dateExpence,amountExpence,nameExpence,detailsExpence) VALUES (@BuildingId, @dateExpence,@amountExpence,@nameExpence,@detailsExpence)",
                        con);

                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@dateExpence", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@amountExpence", txtAmount2.Text);
                cmd.Parameters.AddWithValue("@nameExpence", txtName2.Text);
                cmd.Parameters.AddWithValue("@detailsExpence", txtDetails2.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        /// <summary>
        ///     Load Graph ON app start, for income and expence
        /// </summary>
        private void loadGraph()
        {
            int buildingId = Utility.BuildingId;

            string query1 = string.Format("SELECT SUM(amountIncome) FROM Income_TBL WHERE BuildingId={0}", buildingId);
            DataTable dataTable1 = DataAccess.GetDataTable(query1);

            string query2 = string.Format("SELECT SUM(amountExpence) FROM Expence_TBL WHERE BuildingId={0}", buildingId);
            DataTable dataTable2 = DataAccess.GetDataTable(query2);

            string query3 = string.Format("SELECT SUM(expenceAmount) FROM ExpenceGarden WHERE BuildingId={0}",
                buildingId);
            DataTable dataTable3 = DataAccess.GetDataTable(query3);

            string query4 = string.Format("SELECT SUM(expenceAmount) FROM ExpenceAlavator WHERE BuildingId={0}",
                buildingId);
            DataTable dataTable4 = DataAccess.GetDataTable(query4);

            string query5 = string.Format("SELECT SUM(expenceAmount) FROM ExpenceElec WHERE BuildingId={0}", buildingId);
            DataTable dataTable5 = DataAccess.GetDataTable(query5);

            string query6 = string.Format("SELECT SUM(expenceAmount) FROM EpenceClean WHERE BuildingId={0}", buildingId);
            DataTable dataTable6 = DataAccess.GetDataTable(query6);

            string query7 = string.Format("SELECT SUM(AmountPaid) FROM Payment WHERE BuildingId={0}", buildingId);
            DataTable dataTable7 = DataAccess.GetDataTable(query7);


            //Clean old items from series
            chart1.Series[0].Points.Clear();

            chart1.Series[1].Points.Clear();

            chart1.Series[2].Points.Clear();

            chart1.Series[3].Points.Clear();

            chart1.Series[4].Points.Clear();

            chart1.Series[5].Points.Clear();

            chart1.Series[6].Points.Clear();


            //INCOME TABLE
            object dataExist1 = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM Income_TBL WHERE BuildingId={0}", buildingId));

            if (dataExist1 != null)
            {
                foreach (DataRow dr in dataTable1.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[1].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[1].LabelToolTip = dr[0].ToString();
                    chart1.Series[1].LegendToolTip = dr[0].ToString();
                    chart1.Series[1].ToolTip = dr[0].ToString();
                    chart1.Series[1].Label = dr[0].ToString();
                }
            }

            //EXPENCE TABLLE
            object dataExist2 = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM Expence_TBL WHERE BuildingId={0}", buildingId));

            if (dataExist2 != null)
            {
                foreach (DataRow dr in dataTable2.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[2].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[2].LabelToolTip = dr[0].ToString();
                    chart1.Series[2].LegendToolTip = dr[0].ToString();
                    chart1.Series[2].ToolTip = dr[0].ToString();
                    chart1.Series[2].Label = dr[0].ToString();
                }
            }
            //GARDEN table
            object dataExistGarden = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM ExpenceGarden WHERE BuildingId={0}", buildingId));

            if (dataExistGarden != null)
            {
                foreach (DataRow dr in dataTable3.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[3].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[3].LabelToolTip = dr[0].ToString();
                    chart1.Series[3].LegendToolTip = dr[0].ToString();
                    chart1.Series[3].ToolTip = dr[0].ToString();
                    chart1.Series[3].Label = dr[0].ToString();
                }
            }


            //ELECTRICK  table
            object dataExistELK = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM ExpenceAlavator WHERE BuildingId={0}", buildingId));

            if (dataExistELK != null)
            {
                foreach (DataRow dr in dataTable4.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[6].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[6].LabelToolTip = dr[0].ToString();
                    chart1.Series[6].LegendToolTip = dr[0].ToString();
                    chart1.Series[6].ToolTip = dr[0].ToString();
                    chart1.Series[6].Label = dr[0].ToString();
                }
            }

            //ALAVATOR  table
            object dataExistALV = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM ExpenceElec WHERE BuildingId={0}", buildingId));

            if (dataExistALV != null)
            {
                foreach (DataRow dr in dataTable5.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[4].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[4].LabelToolTip = dr[0].ToString();
                    chart1.Series[4].LegendToolTip = dr[0].ToString();
                    chart1.Series[4].ToolTip = dr[0].ToString();
                    chart1.Series[4].Label = dr[0].ToString();
                }
            }

            //CLEAN  table
            object dataExistCLN = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM EpenceClean WHERE BuildingId={0}", buildingId));

            if (dataExistCLN != null)
            {
                foreach (DataRow dr in dataTable6.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[5].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[5].LabelToolTip = dr[0].ToString();
                    chart1.Series[5].LegendToolTip = dr[0].ToString();
                    chart1.Series[5].ToolTip = dr[0].ToString();
                    chart1.Series[5].Label = dr[0].ToString();
                }
            }

            //payments monthly table
            object dataExistPayment = DataAccess.ExecuteScalar(Utility.ConnectionString,
                string.Format("SELECT * FROM Payment WHERE BuildingId={0}", buildingId));

            if (dataExistPayment != null)
            {
                foreach (DataRow dr in dataTable7.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                        dr[0] = "0";
                    chart1.Series[0].Points.Add(new[] {Convert.ToDouble(dr[0].ToString())});
                    chart1.Series[0].LabelToolTip = dr[0].ToString();
                    chart1.Series[0].LegendToolTip = dr[0].ToString();
                    chart1.Series[0].ToolTip = dr[0].ToString();
                    chart1.Series[0].Label = dr[0].ToString();
                }
            }
        }

        //SAVE EXPENCE ELC
        private void button3_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker3.Text) || string.IsNullOrEmpty(txtamountELC.Text) ||
                string.IsNullOrEmpty(txtnameELC.Text) || string.IsNullOrEmpty(txtdetailsELC.Text))
            {
                errorProvider1.SetError(dateTimePicker3, msgStr);
                errorProvider1.SetError(txtamountELC, msgStr);
                errorProvider1.SetError(txtnameELC, msgStr);
                errorProvider1.SetError(txtdetailsELC, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO ExpenceElec (BuildingId, expenceDate,expenceAmount,expenceName,expenceDetails) VALUES (@BuildingId, @expenceDate,@expenceAmount,@expenceName,@expenceDetails)",
                        con);
                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@expenceDate", dateTimePicker3.Text);
                cmd.Parameters.AddWithValue("@expenceAmount", txtamountELC.Text);
                cmd.Parameters.AddWithValue("@expenceName", txtnameELC.Text);
                cmd.Parameters.AddWithValue("@expenceDetails", txtdetailsELC.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        //SAVE EXPENCE GARDEN
        private void button4_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker4.Text) || string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(dateTimePicker4, msgStr);
                errorProvider1.SetError(textBox4, msgStr);
                errorProvider1.SetError(textBox6, msgStr);
                errorProvider1.SetError(textBox5, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO ExpenceGarden (buildingId,expenceDate,expenceName,expenceDetails,expenceAmount) VALUES (@BuildingId,@expenceDate,@expenceName,@expenceDetails,@expenceAmount)",
                        con);

                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@expenceDate", dateTimePicker4.Text);
                cmd.Parameters.AddWithValue("@expenceAmount", textBox4.Text);
                cmd.Parameters.AddWithValue("@expenceName", textBox6.Text);
                cmd.Parameters.AddWithValue("@expenceDetails", textBox5.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        //SAVE EXPENCE CLEAN
        private void button5_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker5.Text) || string.IsNullOrEmpty(txtamountCLN.Text) ||
                string.IsNullOrEmpty(txtnameCLN.Text) || string.IsNullOrEmpty(txtdetailsCLN.Text))
            {
                errorProvider1.SetError(dateTimePicker5, msgStr);
                errorProvider1.SetError(txtamountCLN, msgStr);
                errorProvider1.SetError(txtnameCLN, msgStr);
                errorProvider1.SetError(txtdetailsCLN, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO EpenceClean (BuildingId,expenceDate,expenceName,expenceDetails,expenceAmount) VALUES (@BuildingId,@expenceDate,@expenceName,@expenceDetails,@expenceAmount)",
                        con);

                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@expenceDate", dateTimePicker5.Text);
                cmd.Parameters.AddWithValue("@expenceAmount", txtamountCLN.Text);
                cmd.Parameters.AddWithValue("@expenceName", txtnameCLN.Text);
                cmd.Parameters.AddWithValue("@expenceDetails", txtdetailsCLN.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        //SAVE EXPENCE ALAVATOR
        private void button6_Click(object sender, EventArgs e)
        {
            const string msgStr = "missing data";
            if (string.IsNullOrEmpty(dateTimePicker6.Text) || string.IsNullOrEmpty(txtamountALV.Text) ||
                string.IsNullOrEmpty(txtnameALV.Text) || string.IsNullOrEmpty(txtdetailsALV.Text))
            {
                errorProvider1.SetError(dateTimePicker6, msgStr);
                errorProvider1.SetError(txtamountALV, msgStr);
                errorProvider1.SetError(txtnameALV, msgStr);
                errorProvider1.SetError(txtdetailsALV, msgStr);
            }
            else
            {
                var con = new SqlCeConnection(Utility.ConnectionString);
                con.Open();
                var cmd =
                    new SqlCeCommand(
                        "INSERT INTO ExpenceAlavator (BuildingId,expenceDate,expenceName,expenceDetails,expenceAmount) VALUES (@BuildingId,@expenceDate,@expenceName,@expenceDetails,@expenceAmount)",
                        con);

                cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                cmd.Parameters.AddWithValue("@expenceDate", dateTimePicker6.Text);
                cmd.Parameters.AddWithValue("@expenceName", txtnameALV.Text);
                cmd.Parameters.AddWithValue("@expenceDetails", txtdetailsALV.Text);
                cmd.Parameters.AddWithValue("@expenceAmount", txtamountALV.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!", "Data Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetData1();
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get primary key value (from hidden column 'Id' at zero index)
            if (e.RowIndex < 0) return;
            var id = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            switch (dataGridView1.Columns[e.ColumnIndex].HeaderText)
            {
                case "מחיקת הוצאה":
                    DeleteRecord(id);
                    break;
            }
        }

        private void DeleteRecord(string id)
        {
            // 1. Show dialog box for asking record deletion
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 2. If user clicked 'No' return back
            if (dialogResult != DialogResult.Yes) return;

            // 3. If 'Yes' clicked, prepare delete query
            string deleteQuery = string.Format("DELETE FROM Income_TBL WHERE Id={0} AND BuildingId={1}",
                Convert.ToInt32(id), Utility.BuildingId);

            // 4. Execute the delete query
            using (var con = new SqlCeConnection(Utility.ConnectionString))
            {
                con.Open();

                var cmd = new SqlCeCommand(deleteQuery, con);
                int cmdResult = cmd.ExecuteNonQuery();

                // Show message accordingly
                if (cmdResult > 0)
                    MessageBox.Show("Record deleted successfully!", "Delete Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    MessageBox.Show("Deleting record failed.", "Delete Status", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                // Refresh grid data after delete
                GetData();
            }
        }

        private void GetData()
        {
            //code here is retieve dayarimTBL data
            Utility.GetAllTablesData();
            dataGridView1.DataSource = Utility.Income;
        }
    }
}