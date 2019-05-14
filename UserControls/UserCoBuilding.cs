using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HouseApp.Code;
using HouseApp.Forms;
using HouseApp.Properties;

namespace HouseApp.UserControls
{
    public partial class UserCoBuilding : UserControl
    {
        private bool _isValid;

        public UserCoBuilding()
        {
            InitializeComponent();
        }

        private void UserCoBuilding_Load(object sender, EventArgs e)
        {
            // Run backgroundworker to collect buildings from database
            bgWorker.RunWorkerAsync("Refresh");
        }

        #region Button Clicks

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
                                 {
                                     Title = "Select building image",
                                     Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
                                 };

            var dr = ofd.ShowDialog();
            if (!dr.Equals(DialogResult.OK)) return;

            pbBuilding.Image = Image.FromFile(ofd.FileName);
            txtImagePath.Text = ofd.FileName;
        }

        private void btnSaveBuilding_Click(object sender, EventArgs e)
        {
            // 1. Validate textboxes
            foreach (var textBox in pnlBuildingDetails.Controls.OfType<TextBox>().Select(control => control))
            {
                Utility.ValidateTextBox(textBox, errorProvider, out _isValid);
            }

            foreach (var textBox in pnlBuildingMgr.Controls.OfType<TextBox>().Select(control => control))
            {
                Utility.ValidateTextBox(textBox, errorProvider, out _isValid);
            }

            // 2. If all valid, then save records
            if (!_isValid) return;
            btnSaveBuilding.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnBrowseImg.Enabled = false;
            InitiateActions(sender);

            RefreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            InitiateActions(sender);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult.Equals(DialogResult.OK))
                InitiateActions(sender);
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            // 1. Set building id
            var rowIndex = gvBuildings.SelectedCells[0].RowIndex;
            var selectedRow = gvBuildings.Rows[rowIndex];
            Utility.BuildingId = (int)selectedRow.Cells[0].Value; // BuildingId

            // 2. Get this usercontrol parent form
            var frmHome = (FrmHome)ParentForm;
            if (frmHome == null) return;

            // 3. Make all menu items visible
            frmHome.ShowMenuItems(true);

            // 4. Redirect to UserCoMainApp
            frmHome.pnlCommon.Controls.Clear();
            var userCoMain = new UserCoMainApp();

            frmHome.pnlCommon.Controls.Add(userCoMain);
            //userCoMain.Dock = DockStyle.Fill;

            RefreshGrid();

            // Run backgroundworker to collect buildings from database
            bgWorker.RunWorkerAsync("Refresh");

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // 2. Get this usercontrol parent form
            var frmHome = (FrmHome)ParentForm;
            if (frmHome == null) return;

            // 3. Make all menu items visible
            frmHome.ShowMenuItems(true);

            // 4. Redirect to UserCoMainApp
            frmHome.pnlCommon.Controls.Clear();
            var userCoHome = new UserCoHome();

            frmHome.pnlCommon.Controls.Add(userCoHome);
            userCoHome.Dock = DockStyle.Fill;
        }

        #endregion

        #region Textbox Handlers

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
                btnSaveBuilding.Enabled = btnUpdate.Enabled = !string.IsNullOrEmpty(textBox.Text.Trim());
        }

        private void txtStartPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                errorProvider.SetError(txtStartPayment, "Only digits are allowed.Letters are not permitted for 'Start Payment'.");
            }
            else
                errorProvider.SetError(txtStartPayment, null);

        }

        private void txtBuildingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                errorProvider.SetError(txtBuildingNumber, "Only digits are allowed.Letters are not permitted for 'Building Number'.");
            }
            else
                errorProvider.SetError(txtBuildingNumber, null);
        }

        #endregion

        #region Threading

        // Load buildings from database to GridView
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get data from database
            if (!IsHandleCreated && !IsDisposed) return;

            var method = Convert.ToString(e.Argument);
            RunFuncInThread(method);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Text = "Error";
                MessageBox.Show("Error: " + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (gvBuildings.Rows.Count > 0)
                {
                    gvBuildings.Enabled = true;
                    if (gvBuildings.CurrentCell.RowIndex > -1)
                        btnGoToHome.Enabled = true;
                }

                btnSaveBuilding.Enabled = btnBrowseImg.Enabled = true;

            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Intitiate buttons click.
        /// </summary>
        /// <param name="sender"></param>
        public void InitiateActions(object sender)
        {
            if (!bgWorker.IsBusy)
            {
                var button = sender as Button;
                if (button != null)
                    bgWorker.RunWorkerAsync(button.Text);
            }
            else
            {
                MessageBox.Show("Please wait! Some other process is executing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Run function in thread as per request.
        /// </summary>
        /// <param name="method">Name of method.</param>
        public void RunFuncInThread(string method)
        {
            switch (method)
            {
                case "Refresh":
                    Invoke((MethodInvoker)RefreshGrid);
                    break;

                case "Save Building":
                    Invoke((MethodInvoker)SaveRecord);
                    break;

                case "Update":
                    Invoke((MethodInvoker)UpdateRecord);
                    break;

                case "Delete":
                    Invoke((MethodInvoker)DeleteRecord);
                    break;
            }
        }

        /// <summary>
        /// Refresh the grid.
        /// </summary>
        public void RefreshGrid()
        {
            // Refresh records
            Utility.GetAllTablesData();

            // Filtered retrieved data
            var dataView = Utility.BuildingData.DefaultView;
            var filteredTable = dataView.ToTable("Buildings", false, "BuildingId", "BuildingNumber", "Street", "City", "StartPayment", "firstName", "lastName");

            if (filteredTable.Rows.Count <= 0) return;
            gvBuildings.DataSource = filteredTable;
        }

        /// <summary>
        /// Save new record from grid.
        /// </summary>
        public void SaveRecord()
        {
            // Let user know what is happening
            lblStatus.Text = "Please wait! Saving data...";

            #region 1. Set building image and path

            byte[] buildingPicBytes;
            string imgPath;

            GetImageData(out buildingPicBytes, out imgPath);

            #endregion

            using (var con = new SqlCeConnection(Utility.ConnectionString))
            {
                // 2. Prepare query for saving records into 'Buildings' table
                var cmd = new SqlCeCommand("INSERT INTO Buildings(Street,City,StartPayment,BuildingNumber,firstName,lastName,email,apartNum,DayarImagePath,DayarImg) VALUES(@street,@city,@startPayment,@buildingNumber,@firstName,@lastName,@email ,@apartNum,@dayarImgPath,@dayarImg)",
                           con) { CommandType = CommandType.Text };

                con.Open();
                cmd.Parameters.AddWithValue("@street", txtStreet.Text.Trim());
                cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@startPayment", txtStartPayment.Text.Trim());
                cmd.Parameters.AddWithValue("@buildingNumber", txtBuildingNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@apartNum", txtApartNum.Text.Trim());
                cmd.Parameters.AddWithValue("@dayarImgPath", imgPath);

                if (buildingPicBytes != null)
                    cmd.Parameters.AddWithValue("@dayarImg", buildingPicBytes);
                else
                    cmd.Parameters.AddWithValue("@dayarImg", DBNull.Value);

                // 3. Execute query
                var rowsAffected = cmd.ExecuteNonQuery();

                // 4. Show message to user
                if (rowsAffected > 0)
                {
                    RefreshGrid();
                    ResetAll();
                    lblStatus.Text = "Building Manager and Building Details data saved successfully!";
                }
                else
                {
                    lblStatus.Text = "Building Manager and Building Details data saving failed.";
                }
            }
        }

        /// <summary>
        /// Delete selected record from grid.
        /// </summary>
        public void DeleteRecord()
        {
            lblStatus.Text = "Deleting current selected record.";

            // Get id of selected row
            var rowIndex = gvBuildings.SelectedCells[0].RowIndex;
            var selectedRow = gvBuildings.Rows[rowIndex];
            var buildingId = selectedRow.Cells[0].Value;
            var buildingNumber = selectedRow.Cells[1].Value;

            var query = new StringBuilder("DELETE FROM Buildings").Append(" WHERE BuildingId=").Append(buildingId);

            if (DataAccess.ExecuteNonQuery(Utility.ConnectionString, query.ToString()))
            {
                RefreshGrid();
                ResetAll();
                lblStatus.Text = string.Format("Building with number '{0}' deleted successfully!", buildingNumber);
            }
            else
            {
                lblStatus.Text = string.Format("Deleting building with number '{0}' failed.", buildingNumber);
            }
        }

        /// <summary>
        /// Update any type of changes back to database.
        /// </summary>
        public void UpdateRecord()
        {
            bool updated;

            // 1. Get id of selected row
            var rowIndex = gvBuildings.SelectedCells[0].RowIndex;
            var selectedRow = gvBuildings.Rows[rowIndex];
            var buildingId = selectedRow.Cells[0].Value;

            // 2. Get image data
            byte[] buildingPicBytes;
            string imgPath;
            GetImageData(out buildingPicBytes, out imgPath);

            // 3. Prepare query for updating
            var query =
                string.Format(
                    "UPDATE Buildings SET City=@city, Street=@street, BuildingNumber=@bNumber,StartPayment=@sPayment,firstName=@firstName,lastName=@lastName,apartNum=@apartNum,email=@email,DayarImagePath=@DayarImagePath,DayarImg=@DayarImg WHERE BuildingId={0}",
                    Utility.BuildingId);

            using (var con = new SqlCeConnection(Utility.ConnectionString))
            {
                var cmd = new SqlCeCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@bNumber", txtBuildingNumber.Text);
                cmd.Parameters.AddWithValue("@sPayment", txtStartPayment.Text);
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@apartNum", txtApartNum.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.Add(@"DayarImagePath", imgPath);

                if (buildingPicBytes != null)
                    cmd.Parameters.AddWithValue("@dayarImg", buildingPicBytes);
                else
                    cmd.Parameters.AddWithValue("@dayarImg", DBNull.Value);

                updated = cmd.ExecuteNonQuery() > 0;
            }

            // 4. Execute queries
            if (updated)
            {
                RefreshGrid();
                lblStatus.Text = string.Format("Name of building with BuildingId '{0}' updated successfully!", buildingId);
            }
            else
            {
                lblStatus.Text = string.Format("Updating building with BuildingId '{0}' failed.", buildingId);
            }
        }

        /// <summary>
        /// Reset all textboxes and image control
        /// </summary>
        private void ResetAll()
        {
            foreach (var textBox in pnlBuildingDetails.Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }

            foreach (var textBox in pnlBuildingMgr.Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }

            txtImagePath.Text = string.Empty;
            pbBuilding.Image = null;
        }

        /// <summary>
        /// Get image path and bytes for saving to database
        /// </summary>
        /// <param name="buildingBytes"></param>
        /// <param name="imagePath"></param>
        private void GetImageData(out byte[] buildingBytes, out string imagePath)
        {
            byte[] imgBytes = null;

            // Set image path //Resources.newpic
            imagePath = string.IsNullOrEmpty(txtImagePath.Text.Trim()) ? @"Resources\newpic.jpg" : txtImagePath.Text.Trim();

            // Paths
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var appResPath = string.Format(@"{0}\{1}\Resources", appDataPath, Application.ProductName);
            var convImgPath = string.Format(@"{0}\ConvertedPic.jpg", appResPath);

            // Create folder if not exists
            if (!Directory.Exists(appResPath))
                Directory.CreateDirectory(appResPath);

            // Set building image
            if (!imagePath.Equals(@"Resources\newpic.jpg",StringComparison.OrdinalIgnoreCase) && File.Exists(imagePath) && pbBuilding.Image != null)
            {
                pbBuilding.Image = Utility.SaveImgToJpg(new Bitmap(pbBuilding.Image), 300, 300, 300, convImgPath);

                byte[] buildingPicBytes;
                using (var ms = new MemoryStream())
                {
                    pbBuilding.Image.Save(ms, ImageFormat.Png);
                    buildingPicBytes = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(buildingPicBytes, 0, buildingPicBytes.Length);
                }

                imgBytes = buildingPicBytes;
            }

            buildingBytes = imgBytes;
        }

        #endregion

        private void gvBuildings_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get id of selected row
            var rowIndex = gvBuildings.SelectedCells[0].RowIndex;
            var selectedRow = gvBuildings.Rows[rowIndex];
            var buildingId = (int)selectedRow.Cells[0].Value; // BuildingId

            // Set building id for using later
            Utility.BuildingId = buildingId;

            // Filter data
            var filter = string.Format("BuildingId={0}", buildingId);
            var dataRows = Utility.BuildingData.Select(filter);

            foreach (var row in dataRows)
            {
                // Building details
                txtCity.Text = Convert.ToString(row["City"]);
                txtStreet.Text = Convert.ToString(row["Street"]);
                txtBuildingNumber.Text = Convert.ToString(row["BuildingNumber"]);
                txtStartPayment.Text = Convert.ToString(row["StartPayment"]);

                // Building manager
                txtFirstName.Text = Convert.ToString(row["firstName"]);
                txtLastName.Text = Convert.ToString(row["lastName"]);
                txtEmail.Text = Convert.ToString(row["email"]);
                txtApartNum.Text = Convert.ToString(row["apartNum"]);

                // Image data
                txtImagePath.Text = Convert.ToString(row["DayarImagePath"]);
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

            // If any record, enable update and delete buttons
            if (dataRows.Any())
                btnUpdate.Enabled = btnDelete.Enabled = true;
        }
    }
}
