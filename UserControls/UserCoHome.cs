using System;
using System.Data.SqlServerCe;
using System.Text;
using System.Windows.Forms;
using HouseApp.Code;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using HouseApp.Forms;
using Encoder = System.Drawing.Imaging.Encoder;
using System.Data;

namespace HouseApp.UserControls
{
    public partial class UserCoHome : UserControl
    {
        // Global variable
        private readonly bool _isTrial;
        private bool _isValid;
        DataTable _dataTable;

        public UserCoHome()
        {
            InitializeComponent();
        }

        public UserCoHome(bool isTrial)
        {
            _isTrial = isTrial;
            InitializeComponent();
        }

        private void User_Home_Load(object sender, EventArgs e)
        {
            LoadSoftMgrData();
            GetLeftDays();
            lblSerial.Text = Program.Licence.Serial;
        }

        /// <summary>
        /// Load data from SoftwareManager table and fill form fields.
        /// </summary>
        public void LoadSoftMgrData()
        {
            _dataTable = Utility.SoftMgrData;
            if (_dataTable == null || _dataTable.Rows.Count <= 0) return;

            // Get values if not null and if rows are there
            txtManagerName.Text = _dataTable.Rows[0]["MgrName"].ToString();
            txtCity.Text = _dataTable.Rows[0]["City"].ToString();
            txtStreetName.Text = _dataTable.Rows[0]["StreetName"].ToString();
            txtStreetNumber.Text = _dataTable.Rows[0]["StreetNumber"].ToString();
            txtPhone.Text = _dataTable.Rows[0]["Phone"].ToString();
            txtMobile.Text = _dataTable.Rows[0]["Mobile"].ToString();
            txtEmail.Text = _dataTable.Rows[0]["Email"].ToString();
            txtBackupPath.Text = _dataTable.Rows[0]["BackupPath"].ToString();
        }

        #region Button clicks

        // Browse backup directory path
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var result = folderBrowser.ShowDialog();
            if (result != DialogResult.OK) return;

            txtBackupPath.Text = folderBrowser.SelectedPath;
            Utility.BackupPath = folderBrowser.SelectedPath;
        }

        //save setup first data
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            foreach (var control in panel2.Controls)
            {
                if (!(control is TextBox)) continue;

                var textBox = control as TextBox;
                Utility.ValidateTextBox(textBox, errorProvider, out _isValid);
            }

            // Separately check for Backup path
            Utility.ValidateTextBox(txtBackupPath, errorProvider, out _isValid);

            if (_isValid)
                SaveOrUpdateData();
        }

        // Browse backup file
        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            txtRestorePath.Text = openFileDialog.FileName;
        }

        // Restore the license file and database for user
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRestorePath.Text))
            {
                // Get boolean value
                var isRestored = Utility.Restore(txtRestorePath.Text);

                // Refresh records and enable buttons
                if (isRestored)
                {
                    Utility.GetAllTablesData(); // Refresh records
                    LoadSoftMgrData(); // Load data in form

                    // Enable specific menu items
                    if (Utility.SoftMgrData.Rows.Count > 0)
                    {
                        var frmHome = (FrmHome)ParentForm;

                        if (frmHome != null)
                        {
                            frmHome.toolStripBuilding.Visible = frmHome.toolStripAppHome.Visible = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please browse backup file before restoring.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = string.Format("DELETE FROM Payment WHERE BuildingId={0}", Utility.BuildingId);
            SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("DATA WAS DELETED");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Dayarim_TBL", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("DATA WAS DELETED");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(string.Format("DELETE FROM Expence_TBL WHERE BuildingId={0}", Utility.BuildingId), con);
            SqlCeCommand cmd1 = new SqlCeCommand(string.Format("DELETE FROM ExpenceElec WHERE BuildingId={0}", Utility.BuildingId), con);
            SqlCeCommand cmd2 = new SqlCeCommand(string.Format("DELETE FROM ExpenceAlavator WHERE BuildingId={0}", Utility.BuildingId), con);
            SqlCeCommand cmd3 = new SqlCeCommand(string.Format("DELETE FROM ExpenceGarden WHERE BuildingId={0}", Utility.BuildingId), con);
            SqlCeCommand cmd4 = new SqlCeCommand(string.Format("DELETE FROM EpenceClean WHERE BuildingId={0}", Utility.BuildingId), con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            MessageBox.Show("DATA WAS DELETED");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(string.Format("DELETE FROM Income_TBL WHERE BuildingId={0}", Utility.BuildingId), con);
            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("DATA WAS DELETED");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCeConnection con = new SqlCeConnection(Utility.ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(string.Format("DELETE FROM DayarimHistory WHERE BuildingId={0}", Utility.BuildingId), con);
            SqlCeCommand cmd1 = new SqlCeCommand(string.Format("DELETE FROM PaymentHistory WHERE BuildingId={0}", Utility.BuildingId), con);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();

            MessageBox.Show("HISTORY DATA WAS DELETED");
        }

        #endregion

        /// <summary>
        /// Common event handler for all textboxes
        /// </summary>
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            Utility.ValidateTextBox(textBox, errorProvider, out _isValid);
        }

        #region Helpers

        /// <summary>
        /// Get number of trial days left
        /// </summary>
        private void GetLeftDays()
        {
            if (_isTrial)
            {
                DateTime dt = Convert.ToDateTime(Properties.Settings.Default.DemoDate);
                if (dt.AddDays(30) < DateTime.Today)
                {
                    //expair demo
                    MessageBox.Show("פג רישיון דמו, פנה לספק לרכישה"); //Expair demo
                }
                else
                {
                    TimeSpan i = DateTime.Today - dt;
                    lblday.Text = (30 - i.Days) + " ימים נותרו"; //Days Left

                }
            }
            else
            {
                if (Program.Licence == null) return;
                lblVersion.Text = @"גירסת דמו"; //Full Version
                lblday.Text = Program.Licence.DaysTillExpiry + @" :ימים שנותרו"; //Days Left
            }
        }

        public Bitmap Save(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = maxWidth / (float)originalWidth;
            float ratioY = maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            Encoder encoder = Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            newImage.Save(filePath, imageCodecInfo, encoderParameters);
            return newImage;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        private void SaveOrUpdateData()
        {
            // Get fields information
            var mgrName = txtManagerName.Text.Trim();
            var city = txtCity.Text.Trim();
            var streetName = txtStreetName.Text.Trim();
            var streetNumber = txtStreetNumber.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var mobile = txtMobile.Text.Trim();
            var email = txtEmail.Text.Trim();
            var backupPath = txtBackupPath.Text.Trim();

            if (Utility.SoftMgrData.Rows.Count <= 0)
            {
                // SAVE DATA
                var sq = new StringBuilder("INSERT INTO SoftwareManager (MgrName, City, StreetName, StreetNumber, Phone, Mobile, Email, BackupPath) VALUES('");

                sq.Append(mgrName).Append("','");
                sq.Append(city).Append("','");
                sq.Append(streetName).Append("','");
                sq.Append(streetNumber).Append("','");
                sq.Append(phone).Append("','");
                sq.Append(mobile).Append("','");
                sq.Append(email).Append("','");
                sq.Append(backupPath).Append("')");

                if (DataAccess.ExecuteNonQuery(Utility.ConnectionString, sq.ToString()))
                {
                    MessageBox.Show("Data was saved successfully!", "Saving succeeded", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh table data
                    Utility.GetAllTablesData();

                    // Visible Home and Building toolStrip Menus
                    var frmHome = (FrmHome)ParentForm;
                    if (frmHome != null)
                        frmHome.toolStripBuilding.Visible = frmHome.toolStripAppHome.Visible = true;
                }
                else
                    MessageBox.Show("Saving data failed!", "Saving failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                // UPDATE DATA
                var uq = new StringBuilder("UPDATE SoftwareManager SET MgrName='").Append(mgrName);
                uq.Append("',City='").Append(city);
                uq.Append("', StreetName='").Append(streetName);
                uq.Append("', StreetNumber='").Append(streetNumber);
                uq.Append("', Phone='").Append(phone);
                uq.Append("', Mobile='").Append(mobile);
                uq.Append("', Email='").Append(email);
                uq.Append("', BackupPath='").Append(backupPath).Append("' WHERE id=1");

                if (DataAccess.ExecuteNonQuery(Utility.ConnectionString, uq.ToString()))
                {
                    MessageBox.Show("Data was updated successfully!", "Update succeeded", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Updating data failed!", "Update failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}

