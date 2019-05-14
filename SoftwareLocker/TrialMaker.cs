using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace SoftwareLocker
{
    // Activate Property
    public class TrialMaker
    {
        #region -> Private Variables 

        private string _BaseString;
        private string _Password;
        private string _SoftName;
        private string _RegFilePath;
        private string _HideFilePath;
        private int _DefDays;
        private int _Runed;
        private string _Text;
        private string _Identifier;

        #endregion

        #region -> Constructor 

        /// <summary>
        /// Make new TrialMaker class to make software trial
        /// </summary>
        /// <param name="softwareName">Name of software to make trial</param>
        /// <param name="regFilePath">File path to save password(enrypted)</param>
        /// <param name="hideFilePath">file path for saving hidden information</param>
        /// <param name="text">A text for contacting to you</param>
        /// <param name="trialDays">Default period days</param>
        /// <param name="trialRunTimes">How many times user can run as trial</param>
        /// <param name="identifier">3 Digit string as your identifier to make password</param>
        public TrialMaker(string softwareName,
            string regFilePath, string hideFilePath,
            string text, int trialDays, int trialRunTimes,
            string identifier)
        {
            _SoftName = softwareName;
            _Identifier = identifier;

            SetDefaults();

            _DefDays = trialDays;
            _Runed = trialRunTimes;

            _RegFilePath = regFilePath;
            _HideFilePath = hideFilePath;
            _Text = text;
        }

        private void SetDefaults()
        {
            SystemInfo.UseBaseBoardManufacturer = false;
            SystemInfo.UseBaseBoardProduct = true;
            SystemInfo.UseBiosManufacturer = false;
            SystemInfo.UseBiosVersion = true;
            SystemInfo.UseDiskDriveSignature = true;
            SystemInfo.UsePhysicalMediaSerialNumber = false;
            SystemInfo.UseProcessorID = true;
            SystemInfo.UseVideoControllerCaption = false;
            SystemInfo.UseWindowsSerialNumber = false;

            MakeBaseString();
            MakePassword();
        }

        #endregion

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public string EncyptBasic(string data)
        {
            var arr = GetBytes(data);
            return Convert.ToBase64String(arr);
        }

        public string DecyptBasic(string data)
        {
            var arr = Convert.FromBase64String(data);
            return GetString(arr);
        }

        // Make base string (Computer ID)
        private void MakeBaseString()
        {
            _BaseString = Encryption.Boring(Encryption.InverseByBase(SystemInfo.GetSystemInfo(_SoftName), 10));
        }

        private void MakePassword()
        {
            _Password = Encryption.MakePassword(_BaseString, _Identifier);
        }

        /// <summary>
        /// Show registering dialog to user
        /// </summary>
        /// <returns>Type of running</returns>
        public RunTypes ShowDialog()
        {
            // check if registered before
            if (CheckRegister() == true)
                return RunTypes.Full;

            frmDialog PassDialog = new frmDialog(_BaseString, _Password, DaysToEnd(), _Runed, _Text);
            
            MakeHideFile();

            DialogResult DR = PassDialog.ShowDialog();

            if (DR == DialogResult.OK)
            {
                MakeRegFile();
                return RunTypes.Full;
            }
            else if (DR == DialogResult.Retry)
            {  return RunTypes.Trial;}
            else
            {   return RunTypes.Expired;}
        }

        // save password to Registration file for next time usage
        private void MakeRegFile()
        {
            FileReadWrite.WriteFile(_RegFilePath, _Password);
        }

        // Control Registeration file for password
        // if password saved correctly return true else false
        private bool CheckRegister()
        { 
            string password = FileReadWrite.ReadFile(_RegFilePath);

            if (_Password == password)
                return true;
            else
                return false;
        }

        // from hidden file
        // indicate how many days can user use program
        // if the file does not exists, make it
        private int DaysToEnd()
        {
            FileInfo hf = new FileInfo(_HideFilePath);
            if (hf.Exists == false)
            {
                MakeHideFile();
                return _DefDays;
            }
            return CheckHideFile();
        }

        // store hidden information to hidden file
        // Date,DaysToEnd,HowManyTimesRuned,BaseString(ComputerID)
        private void MakeHideFile()
        {
            string HideInfo;
            HideInfo = DateTime.Now.Ticks + ";";
            HideInfo += _DefDays + ";" + _Runed + ";" + _BaseString;
            FileReadWrite.WriteFile(_HideFilePath, HideInfo);
        }

        // Get Data from hidden file if exists
        private int CheckHideFile()
        {
            string[] hideInfo;
            hideInfo = FileReadWrite.ReadFile(_HideFilePath).Split(';');
            long DiffDays;
            int DaysToEnd;

            if (_BaseString == hideInfo[3])
            {
                DaysToEnd = Convert.ToInt32(hideInfo[1]);
                if (DaysToEnd <= 0)
                {
                    _Runed = 0;
                    _DefDays = 0;
                    return 0;
                }
                var dt = new DateTime(Convert.ToInt64(hideInfo[0]));
                DiffDays = DateAndTime.DateDiff(DateInterval.Day,
                    dt.Date, DateTime.Now.Date,
                    FirstDayOfWeek.Saturday,
                    FirstWeekOfYear.FirstFullWeek);
                
                DaysToEnd = Convert.ToInt32(hideInfo[1]);
                _Runed = Convert.ToInt32(hideInfo[2]);
                _Runed -= 1;

                DiffDays = Math.Abs(DiffDays);

                _DefDays = DaysToEnd - Convert.ToInt32(DiffDays);
            }
            return _DefDays;
        }

        public enum RunTypes
        { 
            Trial = 0,
            Full,
            Expired,
            UnKnown
        }

        #region -> Properties 

        /// <summary>
        /// Indicate File path for storing password
        /// </summary>
        public string RegFilePath
        {
            get
            {
                return _RegFilePath;
            }
            set
            {
                _RegFilePath = value;
            }
        }

        /// <summary>
        /// Indicate file path for storing hidden information
        /// </summary>
        public string HideFilePath
        {
            get
            {
                return _HideFilePath;
            }
            set
            {
                _HideFilePath = value;
            }
        }

        /// <summary>
        /// Get default number of days for trial period
        /// </summary>
        public int TrialPeriodDays
        {
            get
            {
                return _DefDays;
            }
        }

        /// <summary>
        /// Get or Set TripleDES key for encrypting files to save
        /// </summary>
        public byte[] TripleDESKey
        {
            get
            {
                return FileReadWrite.key;
            }
            set
            {
                FileReadWrite.key = value;
            }
        }

        #endregion

        #region -> Usage Properties 

        public bool UseProcessorID
        {
            get
            {
                return SystemInfo.UseProcessorID;
            }
            set
            {
                SystemInfo.UseProcessorID = value;
            }
        }

        public bool UseBaseBoardProduct
        {
            get
            {
                return SystemInfo.UseBaseBoardProduct;
            }
            set
            {
                SystemInfo.UseBaseBoardProduct = value;
            }
        }

        public bool UseBaseBoardManufacturer
        {
            get
            {
                return SystemInfo.UseBiosManufacturer;
            }
            set
            {
                SystemInfo.UseBiosManufacturer = value;
            }
        }

        public bool UseDiskDriveSignature
        {
            get
            {
                return SystemInfo.UseDiskDriveSignature;
            }
            set
            {
                SystemInfo.UseDiskDriveSignature = value;
            }
        }

        public bool UseVideoControllerCaption
        {
            get
            {
                return SystemInfo.UseVideoControllerCaption;
            }
            set
            {
                SystemInfo.UseVideoControllerCaption = value;
            }
        }

        public bool UsePhysicalMediaSerialNumber
        {
            get
            {
                return SystemInfo.UsePhysicalMediaSerialNumber;
            }
            set
            {
                SystemInfo.UsePhysicalMediaSerialNumber = value;
            }
        }

        public bool UseBiosVersion
        {
            get
            {
                return SystemInfo.UseBiosVersion;
            }
            set
            {
                SystemInfo.UseBiosVersion = value;
            }
        }

        public bool UseBiosManufacturer
        {
            get
            {
                return SystemInfo.UseBiosManufacturer;
            }
            set
            {
                SystemInfo.UseBiosManufacturer = value;
            }
        }

        public bool UseWindowsSerialNumber
        {
            get
            {
                return SystemInfo.UseWindowsSerialNumber;
            }
            set
            {
                SystemInfo.UseWindowsSerialNumber = value;
            }
        }

        #endregion
    }
}