using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HouseApp.UserControls
{
    public partial class UserCoLogs : UserControl
    {
        private string _logFilePath;
        public UserCoLogs()
        {
            InitializeComponent();
        }

        private void UserCoLogs_Load(object sender, System.EventArgs e)
        {
            _logFilePath = Path.Combine(Application.StartupPath, @"Logs\HouseApp-log.txt");

            if (File.Exists(_logFilePath))
            {
                // Handle these events
                listLog.DrawMode = DrawMode.OwnerDrawVariable;
                listLog.MeasureItem += listLog_MeasureItem;
                listLog.DrawItem += listLog_DrawItem;

                // Run reading of log file in background thread
                bgWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Log file at '" + _logFilePath + "' not exist", "File not found", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }

        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)ReadLogFile);
        }

        #region Event handlers for making listbox size adjust as per content

        private void listLog_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listLog.Items[e.Index].ToString(), listLog.Font, listLog.Width).Height;
        }

        private void listLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // If the item state is selected, then change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          Color.Black,
                                          Color.LightGreen);

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            // Draw the current item text
            e.Graphics.DrawString(listLog.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        #endregion

        private void ReadLogFile()
        {
            // Open, read lines and close file
            var lines = File.ReadAllLines(_logFilePath);
            foreach (var line in lines)
            {
                listLog.Items.Add(line);
            }
        }
    }
}
