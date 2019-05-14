using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SoftwareLocker
{
    [Serializable]
    public class LicenceExpiry
    {
        private const int LICENCE_VALID_FOR = 365;

        public int DaysTillExpiry
        {
            get
            {
                return (int)(ExpiryDate - DateTime.Now).TotalDays;
            }
        }

        public DateTime ExpiryDate { get; set; }
        public string Serial { get; set; }

        public static LicenceExpiry Read()
        {
            var fname = string.Format("{0}\\{1}", Application.StartupPath, "SERIAL.DAT");
            if (File.Exists(fname))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LicenceExpiry));
                using (var stream = File.Open(fname, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (LicenceExpiry)serializer.Deserialize(stream);
                }
            }
            return null;
        }

        public static void Write(LicenceExpiry obj)
        {
            var fname = string.Format("{0}\\{1}", Application.StartupPath, "SERIAL.DAT");
            XmlSerializer serializer = new XmlSerializer(typeof(LicenceExpiry));
            using (TextWriter writer = new StreamWriter(fname))
            {
                serializer.Serialize(writer, obj);
            }
        }
      
    }
}
