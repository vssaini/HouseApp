using System;
using System.Text;
using System.Windows.Forms;
using HouseApp.Properties;
using HouseApp.UserControls;
using HouseApp.Code;
using System.Configuration;
using System.ComponentModel;

namespace HouseApp.Forms
{
    public partial class FrmHome : Form
    {
        // Variable to store reference of main user control
        UserControl _userControl;

        public FrmHome()
        {
            InitializeComponent();
        }

        #region Form Events

        private void FrmHome_Load(object sender, EventArgs e)
        {
            if (Settings.Default.EnableMenuItems)
                ShowMenuItems(true);
        }

        // After form shown
        private void FrmHome_Shown(object sender, EventArgs e)
        {
            Application.DoEvents(); // For fixing loading freezing issue
            bgWorkerStartup.RunWorkerAsync();
        }

        // Do something when form closes
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Get refreshed record
            var dataTable = Utility.SoftMgrData;

            // If data create backup
            if (dataTable.Rows.Count > 0)
            {
                using (var backup = new FrmBackup(dataTable, this))
                {
                    backup.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Backup failed because no user details were found in database.", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region  ToolStrip Menu clicks

        private void ביתToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoMainApp();
            pnlCommon.Controls.Add(_userControl);
        }

        private void הוספתדיירToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoAddNew();

            pnlCommon.Controls.Add(_userControl);
            _userControl.Dock = DockStyle.Fill;
        }

        private void רשימתדייריםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoDayarim();
            pnlCommon.Controls.Add(_userControl);
            _userControl.Dock = DockStyle.Fill;
        }

        private void תשלומיםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoPayment();
            pnlCommon.Controls.Add(_userControl);
        }

        private void הכנסותהוצאותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserIncome();
            pnlCommon.Controls.Add(_userControl);
        }

        private void דוחחודשישנתיToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoAlert();
            pnlCommon.Controls.Add(_userControl);
            _userControl.Dock = DockStyle.Fill;
        }

        private void קבלותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserInvoice();
            pnlCommon.Controls.Add(_userControl);
        }

        private void הגדרותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();

            // Pass this form object to constructor so that it ca be used later
            _userControl = new UserCoHome();

            pnlCommon.Controls.Add(_userControl); // Add it to the panel
            _userControl.Dock = DockStyle.Fill;

            //lblHeader.Text = "הגדרות מערכת";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmAbout = new FrmAbout();
            frmAbout.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Declare SentEmail Form
            FrmSentEmail frmSentEmail = new FrmSentEmail();

            //Show SentEmail Form
            frmSentEmail.Show();
        }

        private void ExittoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripHistory_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoHistory();

            pnlCommon.Controls.Add(_userControl);
            _userControl.Dock = DockStyle.Fill;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();
            _userControl = new UserCoBuilding();

            pnlCommon.Controls.Add(_userControl);
            _userControl.Dock = DockStyle.Fill;
        }

        #endregion

        #region Threading

        private void bgWorkerStartup_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)StartupTasks);
        }

        private void bgWorkerStartup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occured while executing startup tasks.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                // Send email to Admin after application started
                bgWorkerEmail.RunWorkerAsync();
            }
        }

        private void bgWorkerEmail_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)MiscellaneousTasks);
        }

        private void bgWorkerEmail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occured while executing Email takss.", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            pnlCommon.Controls.Clear();

            // Add user control to show logs
            var ucLog = new UserCoLogs();
            pnlCommon.Controls.Add(ucLog);
            ucLog.Dock = DockStyle.Fill;
        }

        #region Helpers

        /// <summary>
        /// Tasks that are executed when Form loads.
        /// </summary>
        private void StartupTasks()
        {
            // 1. Get all tables data here
            Utility.GetAllTablesData();

            if (Utility.SoftMgrData.Rows.Count > 0)
            {
                toolStripBuilding.Visible = toolStripAppHome.Visible = true;

                pnlCommon.Controls.Clear();
                _userControl = new UserCoBuilding();

                pnlCommon.Controls.Add(_userControl);
                _userControl.Dock = DockStyle.Fill;
            }
            else
            {
                pnlCommon.Controls.Clear();
                _userControl = new UserCoHome();

                pnlCommon.Controls.Add(_userControl);
                _userControl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Delete existing zip file, Send Email and Set backup path from database.
        /// </summary>
        private static void MiscellaneousTasks()
        {
            var softMgrDt = Utility.SoftMgrData;
            if (softMgrDt.Rows.Count <= 0) return;

            var mgrName = softMgrDt.Rows[0]["MgrName"].ToString();

            // Setting backup path from database here. So that it can be used later
            Utility.BackupPath = softMgrDt.Rows[0]["BackupPath"].ToString();

            // Prepare for sending email
            var body = new StringBuilder("House App was started by '").Append(mgrName).Append("' at")
                .Append(DateTime.Now.ToShortDateString());

            var subject = string.Format("HouseApp started by {0}", mgrName);

            // First email address to Admin user
            var adminEmail = ConfigurationManager.AppSettings["AdminEmail"];

            // Let's ask .Net to process all messages in queue together
            Application.DoEvents();
            Utility.SendEmail(adminEmail, "ihomesystem2014@gmail.com", subject, body.ToString(), null);
        }

        /// <summary>
        /// Show or hide menu items
        ///</summary>
        public void ShowMenuItems(bool enable)
        {
            toolStripAppHome.Visible =
                toolStripAddUser.Visible =
                    toolStripUsersList.Visible =
                        toolStripPayments.Visible =
                            toolStripReports.Visible =
                                toolStripGraphs.Visible =
                                            toolStripHistory.Visible =
                                                toolStripNearSetting.Visible = enable;
        }

        #endregion
    }
}
