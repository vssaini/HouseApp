using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using HouseApp.Code;
using System;
using HouseApp.Properties;

namespace HouseApp.Forms
{
    public partial class FrmBackup : Form
    {
        // Global variables
        private readonly DataTable _dataTable;
        private readonly FrmHome _frmHome;

        // Customize constructor for Backup class
        public FrmBackup(DataTable dataTable, FrmHome formHome)
        {
            InitializeComponent();

            _dataTable = dataTable;
            _frmHome = formHome;
        }

        // This event is fired after Form had shown
        private void Backup_Shown(object sender, EventArgs e)
        {
            // Show them here
            lblStatus.Text = "Please wait! We are taking backup...";
            lblStatus.Image = Resources.ImgLoading;
            // Trying to fix to show loader text and image properly
            Application.DoEvents();

            // Run the task of taking backup
            bgWorker.RunWorkerAsync();
        }

        // The event handler when you call 'bgWorker.RunWorkerAsync();' in above form
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var zipFileName = string.Format("{0}.{1}", _dataTable.Rows[0]["MgrName"], "zip");
            var zipFilePath = Path.Combine(Application.StartupPath, zipFileName);

            // 1. Create user.txt file
            var progStatus = "Creating user file";
            bgWorker.ReportProgress(20, progStatus);
            Utility.CreateUserFile(_dataTable);

            // 2. Create backup file
            progStatus = "Creating backup file";
            bgWorker.ReportProgress(40, progStatus);
            Utility.CreateBackup(zipFileName);

            // 3. Upload it on server
            //Utility.Upload(zipFilePath, zipFileName);

            // 4. Email to admin
            progStatus = "Emailing backup to Admin";
            bgWorker.ReportProgress(60, progStatus);
            var adminEmail = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"];
            Utility.SendEmail(adminEmail, "info@all4business.co.il", "HouseApp Backup", "Backup of HouseApp data.", zipFilePath);


            // 5. Send email to client
            progStatus = "Emailing backup to User";
            bgWorker.ReportProgress(80, progStatus);
            Utility.SendEmail(_dataTable.Rows[0]["Email"].ToString(), "info@all4business.co.il", "HouseApp Backup", "Backup of HouseApp data.", zipFilePath);

            // 6. Delete zip file
            progStatus = "Cleaning temporary files";
            bgWorker.ReportProgress(95, progStatus);
            if (File.Exists(zipFilePath))
                File.Delete(zipFilePath);

        }

        // The event handler when the 'bgWorker.RunWorkerAsync();' tasks get completed
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DialogResult = MessageBox.Show("Error occured during backup.\r\n" + e.Error.Message);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Dispose();
                _frmHome.Dispose();
            }
        }

        // Fire whenever the progress changes for 'bgWorker.RunWorkerAsync();'
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progStatus = e.UserState.ToString();
            lblStatus.Text = string.Format("{0} ({1}% completed)", progStatus, e.ProgressPercentage);
            progBar.Value = e.ProgressPercentage;
        }
    }
}
