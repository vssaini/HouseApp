/****************************** Module Utility ******************************\
* Module Name:  Utility.cs
* Project:      HouseApp
* Date:         28th July, 2014
* 
* Provide properties & functions for creating database, connection string and log information.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ErikEJ.SqlCeScripting;
using HouseApp.Properties;
using Ionic.Zip;
using log4net.Config;
using SoftwareLocker;
using System.Net.Mime;
using System.ComponentModel;

namespace HouseApp.Code
{
    class Utility
    {
        #region Properties

        /// <summary>
        /// Get application database name
        /// </summary>
        public static string AppDbName
        {
            get
            {
                return ConfigurationManager.AppSettings["SqlCeDbName"];
            }
        }

        /// <summary>
        /// Get Sql connection string
        /// </summary>
        public static string AppConString
        {
            get
            {
                return ConfigurationManager.AppSettings["SqlConString"];
            }
        }

        /// <summary>
        /// Get path to folder in 'Application Data' directory
        /// </summary>
        public static string AppDataPath
        {
            get
            {
                var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                var userAppDataPath = Path.Combine(localAppData, Application.ProductName);

                if (!Directory.Exists(userAppDataPath))
                    Directory.CreateDirectory(userAppDataPath);

                return userAppDataPath;
            }
        }

        /// <summary>
        /// Get connection string by reading app.config values.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                //var sqlDbPath = Path.Combine(Application.StartupPath, "DBL\\" + appDbName);
                var sqlDbAppDataPath = Path.Combine(AppDataPath, "DBL\\" + AppDbName);

                var dayarimConnectionString = String.Format(AppConString, sqlDbAppDataPath);
                return dayarimConnectionString;
            }
        }

        /// <summary>
        /// Get or set Backup path
        /// </summary>
        public static string BackupPath { get; set; }

        /// <summary>
        /// Get or set current building id
        /// </summary>
        public static int BuildingId { get; set; }

        #endregion

        #region DB Properties

        /// <summary>
        /// Get or set fresh records from SoftwareManager table
        /// </summary>
        public static DataTable SoftMgrData { get; set; }

        /// <summary>
        /// Get or set fresh records from Building table
        /// </summary>
        public static DataTable BuildingData { get; set; }

        /// <summary>
        /// Get or set fresh records from Dayarim_TBL
        /// </summary>
        public static DataTable DayarimData { get; set; }

        /// <summary>
        /// Get or set fresh records from Payment
        /// </summary>
        public static DataTable PaymentData { get; set; }

        /// <summary>
        /// Get or set fresh records from Income_TBL
        /// </summary>
        public static DataTable Income { get; set; }

        /// <summary>
        /// Get or set fresh records from Expence_TBL
        /// </summary>
        public static DataTable Expence { get; set; }

        /// <summary>
        /// Get or set fresh records from Expence_TBL
        /// </summary>
        public static DataTable ExpenceElec { get; set; }

        /// <summary>
        /// Get or set fresh records from Expence_TBL
        /// </summary>
        public static DataTable ExpenceGarden { get; set; }

        /// <summary>
        /// Get or set fresh records from Expence_TBL
        /// </summary>
        public static DataTable ExpenceClean { get; set; }

        /// <summary>
        /// Get or set fresh records from Expence_TBL
        /// </summary>
        public static DataTable ExpenceAlavator { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Log current software details on starting of software.
        /// </summary>
        public static void LogOnStart()
        {
            // Get current executing .exe location
            var currentAssembly = Assembly.GetExecutingAssembly();
            var execDirPath = Path.GetDirectoryName(currentAssembly.Location);

            // Set log path
            //  @"\Inetpub\Logs\log4net.config"
            var logpath = ConfigurationManager.AppSettings["LogConfigPath"];

            if (execDirPath != null)
            {
                var fullLogpath = Path.Combine(execDirPath, logpath);
                var fInfo = new FileInfo(fullLogpath);
                XmlConfigurator.ConfigureAndWatch(fInfo);
            }

            var appinfo = String.Format("{0} [v{1}.{2:00}.{3:0000}.{4:0000}]",
                Application.ProductName, currentAssembly.GetName().Version.Major, currentAssembly.GetName().Version.Minor,
                    currentAssembly.GetName().Version.Build, currentAssembly.GetName().Version.Revision);

            Logger.FileLogger.Info(String.Format("STARTING: {0}", appinfo));
        }

        /// <summary>
        /// Create and initialize the database.
        /// </summary>
        public static void CreateInitialDatabase()
        {
            Logger.FileLogger.Info("BEGIN: Create & Initialize Database");

            // Copy default database
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // Application.StartupPath
            var appDbPath = Path.Combine(AppDataPath, "DBL");

            var appDbFilePath = Path.Combine(appDbPath, AppDbName);
            var appOldDbConnStr = string.Format(AppConString, appDbFilePath);


            // if main datebase path doesn't exist create it.
            if (!Directory.Exists(appDbPath))
            {
                Directory.CreateDirectory(appDbPath);
                Logger.FileLogger.Info(string.Format("Main database path doesn't exist. Creating it now: {0}", appDbPath));
            }

            // Make sure database path has been created, and or exist.
            if (Directory.Exists(appDbPath))
            {
                Logger.FileLogger.Info(string.Format("Main database path exist or has already been created: {0}", appDbPath));

                // this 'data' folder creation is kind of problem when installing from published 
                // the data folder is created somewhere else than program's location
                if (appPath != null)
                {
                    var appCurrentDbPath = Path.Combine(appPath, "SQLCEDB");
                    var appCurrentDbFilePath = Path.Combine(appCurrentDbPath, AppDbName);
                    var appCurrentDbConnStr = string.Format(AppConString, appCurrentDbFilePath);

                    // if main database doesn't exist, copy it from the default location.
                    if (!File.Exists(appDbFilePath))
                    {
                        File.Copy(appCurrentDbFilePath, appDbFilePath);


                        Logger.FileLogger.Info(string.Format(
                            "An existing database did not exist copied newest database to Location: {0}", appDbPath));
                        Logger.FileLogger.Info(string.Format(
                            "Master Database Location: {0}", appCurrentDbFilePath));
                        Logger.FileLogger.Info(string.Format(
                            "Copied to New Database Location: {0}", appDbFilePath));
                    }
                    else
                    {
                        Logger.FileLogger.Info(
                            "An existing database was found checking to make sure it is up to date.");

                        var sql = new StringBuilder();

                        // bool result=false;
                        //result = Utils.Data.DataAccess.ExecuteNonQuery(appDbConnStr, "DROP TABLE [SchemaVersions_TBL];");

                        // We need to make sure the old database is up to date.
                        // First make sure it has the new schema version table.
                        if (DataAccess.ExistSchemaVersion(appOldDbConnStr))
                        {
                            Logger.FileLogger.Info(
                                "Old Database contained [SchemaVersions_TBL] Table, Proceeding with database schema check.");

                            sql.Append("SELECT [SchemaVersion] FROM [SchemaVersions_TBL] WHERE [Feature] = 'Default'");

                            var oldVersion = Convert.ToInt32(DataAccess.ExecuteScalar(appOldDbConnStr, sql.ToString()));

                            sql.Clear();

                            sql.Append("SELECT [SchemaVersion] FROM [SchemaVersions_TBL] WHERE [Feature] = 'Default'");

                            var currentVersion = Convert.ToInt32(DataAccess.ExecuteScalar(appCurrentDbConnStr, sql.ToString()));

                            // If both versions are same, log this message
                            if (oldVersion.Equals(currentVersion))
                            {
                                Logger.FileLogger.Info(string.Format(
                                    "The Old, & New Database contain the same schema version. Current Schema Version: {0}",
                                    currentVersion));
                            }
                            else // Otherwise update database
                            {
                                // We are trying to get version number of both old and new file. So as to check in log why issue. Done.
                                Logger.FileLogger.Info(string.Format(
                                   "Old Database schema version is {0}. It is different from new one. Current Schema Version: {1}.",
                                   oldVersion, currentVersion));

                                // The old database isn't the current one, update it with new tables, and or columns
                                CheckUpdateDbSchema(appOldDbConnStr, appCurrentDbConnStr);
                            }

                            sql.Clear();

                            sql.Append("UPDATE [SchemaVersions_TBL] SET ");
                            sql.AppendFormat("[SchemaVersion] = {0} ", currentVersion);
                            sql.Append("WHERE [Feature] = 'Default'");

                            DataAccess.ExecuteNonQuery(appOldDbConnStr, sql.ToString());

                            Logger.FileLogger.Info(string.Format(
                                "Update Old Database schema version to reflect the newer Version: {0}",
                                currentVersion));

                        }
                        else
                        {
                            Logger.FileLogger.Info(
                                "Old Database did not contained [SchemaVersions_TBL] Table. Adding [SchemaVersions_TBL] Table then proceeding with database schema check.");

                            // the old database doesn't have the new SchemaVersions_TBL table
                            // need to create this table, and update others most likely they
                            // are not up to date either.
                            sql.Append("CREATE TABLE [SchemaVersions_TBL] ( ");
                            sql.Append("[VersionId] int IDENTITY (1,1) NOT NULL ");
                            sql.Append(", [SchemaVersion] int DEFAULT 1 NOT NULL ");
                            sql.Append(", [CompatibleSchemaVersion] int DEFAULT 0 NOT NULL ");
                            sql.Append(", [Feature] nvarchar(128) NULL ");
                            sql.Append(", [IsCurrentVersion] bit DEFAULT 1 NOT NULL ");
                            sql.Append(", [RowDateTime] datetime NOT NULL ");
                            sql.Append(");");

                            DataAccess.ExecuteNonQuery(appOldDbConnStr, sql.ToString());

                            sql.Clear();

                            sql.Append("SELECT [SchemaVersion] FROM [SchemaVersions_TBL] WHERE [Feature] = 'Default'");

                            var currentVersion = DataAccess.ExecuteScalar(appCurrentDbConnStr, sql.ToString());

                            sql.Clear();

                            sql.Append("INSERT INTO [SchemaVersions_TBL] ");
                            sql.Append("([SchemaVersion],[Feature],[IsCurrentVersion],[RowDateTime]) ");
                            sql.Append("VALUES ");
                            sql.AppendFormat("({0},'Default',1,getdate());", currentVersion);

                            DataAccess.ExecuteNonQuery(appOldDbConnStr, sql.ToString());

                            sql.Clear();

                            // the database didn't contain the schema version table, most like the tables, and columns are not up to date either.
                            CheckUpdateDbSchema(appCurrentDbConnStr, appOldDbConnStr);

                            sql.Clear();

                            sql.Append("UPDATE [SchemaVersions_TBL] SET ");
                            sql.AppendFormat("[SchemaVersion] = {0} ", currentVersion);
                            sql.Append("WHERE [Feature] = 'Default'");

                            DataAccess.ExecuteNonQuery(appOldDbConnStr, sql.ToString());

                            Logger.FileLogger.Info(string.Format(
                                "Update Old Database schema version to reflect the newer Version: {0}",
                                currentVersion));
                        }
                    }
                }
            }

            Logger.FileLogger.Info("FINISHED: Create & Initialize Database");
        }

        // THESE TWO FUNCTIONS ARE NOW MY FUNCTIONS. EARLIER WERE OLD CODE. I DON'T WHAT YOU DONE. NOW WILL TEST
        /// <summary>
        /// Update the old database schema to the new version.
        /// </summary>
        /// <param name="oldConString">The connection string for the old database.</param>
        /// <param name="newConString">The connection string for the new database.</param>
        public static void CheckUpdateDbSchema(string oldConString, string newConString)
        {
            IRepository oldRepository = new DBRepository(oldConString);
            IRepository newRepository = new DBRepository(newConString);

            using (oldRepository)
            {
                var oldTableNames = oldRepository.GetAllTableNames();
                var newTableNames = newRepository.GetAllTableNames();

                foreach (var newTable in newTableNames)
                {
                    Logger.FileLogger.Info(string.Format("Checking Table ({0}) existence in new database.", newTable));

                    if (oldTableNames.Contains(newTable))
                    {
                        Logger.FileLogger.Info(string.Format("Table ({0}) exist in new database.", newTable));

                        var oldColumns = oldRepository.GetAllColumns().Where(o => o.TableName == newTable).ToList();
                        var newColumns = newRepository.GetAllColumns().Where(o => o.TableName == newTable).ToList();

                        foreach (var column in newColumns)
                        {
                            // check to see if column exist
                            // column exist check to make sure has same data type, etc.
                            if (CheckColumnExists(column, oldColumns))
                            {
                                var qeury = oldColumns.Where(o => o.ColumnName == column.ColumnName).ToList();

                                if (qeury.Count <= 0) continue;

                                var theColumn = qeury[0];

                                if (theColumn == null) continue;
                                if ((column.DataType == theColumn.DataType) &&
                                    (column.IsNullable == theColumn.IsNullable) &&
                                    (column.NumericScale == theColumn.NumericScale) &&
                                    (column.NumericPrecision == theColumn.NumericPrecision) &&
                                    (column.CharacterMaxLength == theColumn.CharacterMaxLength)) continue;

                                var generator = new Generator(oldRepository, null, false, false, false, true);
                                generator.GenerateColumnAlterScript(column);

                                var queryCleaned = generator.GeneratedScript.Replace("\r", " \r")
                                    .Replace("GO  \r", "GO\r").Replace("GO \r", "GO\r");

                                newRepository.ExecuteSql(queryCleaned);

                                Logger.FileLogger.Info(string.Format(
                                    "The Table ({0}) Column ({1}) was different column has been altered!",
                                    newTable, column.ColumnName));
                            }
                            else
                            {
                                Logger.FileLogger.Info(string.Format("Creating new columns in Table ({0}).", newTable));

                                // column doesn't exist create it.
                                var generator = new Generator(newRepository, null, false, false, false, true);
                                generator.GenerateColumnAddScript(column);

                                var queryCleaned = generator.GeneratedScript.Replace("\r", " \r")
                                    .Replace("GO  \r", "GO\r").Replace("GO \r", "GO\r");

                                oldRepository.ExecuteSql(queryCleaned);

                                Logger.FileLogger.Info(string.Format("The Table ({0}) Column ({1}) did not exist it has been created!",
                                    newTable, column.ColumnName));
                            }
                        }
                    }
                    else
                    {
                        Logger.FileLogger.Info(string.Format("Creating new Table ({0}).", newTable));

                        // doesn't contain the new tables let created it.
                        var generator = new Generator(newRepository, null, false, false, false, true);
                        generator.GenerateTableScript(newTable);

                        var queryCleaned = generator.GeneratedScript.Replace("\r", " \r").Replace("GO  \r", "GO\r").Replace("GO \r", "GO\r");

                        oldRepository.ExecuteSql(queryCleaned);

                        Logger.FileLogger.Info(string.Format("The Table ({0}) did not exist it has been created!", newTable));
                    }
                }
            }
        }

        /// <summary>
        /// Check if column exists or not.
        /// </summary>
        public static bool CheckColumnExists(Column column, List<Column> columns)
        {
            return columns.Any(col => col.ColumnName.Equals(column.ColumnName));
        }

        /// <summary>
        /// Read data from each table and set their properties to be used later.
        /// </summary>
        public static void GetAllTablesData()
        {
            SoftMgrData = DataAccess.GetDataTable("SELECT * FROM SoftwareManager");
            BuildingData = DataAccess.GetDataTable("SELECT * FROM Buildings");
            DayarimData = DataAccess.GetDataTable(string.Format("SELECT * FROM Dayarim_TBL WHERE BuildingId={0} ORDER BY Dayarapartmentnum", BuildingId));
            PaymentData = DataAccess.GetDataTable(string.Format("SELECT * FROM Payment WHERE BuildingId={0}", BuildingId));
            Income = DataAccess.GetDataTable(string.Format("SELECT * FROM Income_TBL WHERE BuildingId={0}", BuildingId));
            Expence = DataAccess.GetDataTable(string.Format("SELECT * FROM Expence_TBL WHERE BuildingId={0}", BuildingId));
            ExpenceElec = DataAccess.GetDataTable(string.Format("SELECT * FROM ExpenceElec WHERE BuildingId={0}", BuildingId));
            ExpenceGarden = DataAccess.GetDataTable(string.Format("SELECT * FROM ExpenceGarden WHERE BuildingId={0}", BuildingId));
            ExpenceClean = DataAccess.GetDataTable(string.Format("SELECT * FROM EpenceClean WHERE BuildingId={0}", BuildingId));
            ExpenceAlavator = DataAccess.GetDataTable(string.Format("SELECT * FROM ExpenceAlavator WHERE BuildingId={0}", BuildingId));
        }

        /// <summary>
        /// Send email using settings from app.config.
        /// </summary>
        /// <param name="sendTo">Email address of recipient</param>
        /// <param name="sendFrom">Email address of sender</param>
        /// <param name="subject">Subject of email</param>
        /// <param name="body">Body of email</param>
        /// <param name="fileToAttach">Full path of file to attach</param>
        public static void SendEmail(string sendTo, string sendFrom, string subject, string body, string fileToAttach)
        {
            Attachment attachment = null;
            try
            {
                // Get email details from App.config
                var smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                var smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
                var smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
                var smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
                var enableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);

                var smtpClient = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = enableSsl
                };

                var to = new MailAddress(sendTo);
                var from = new MailAddress(sendFrom);
                var mailMsg = new MailMessage { Subject = subject, Body = body, From = from };
                mailMsg.To.Add(to);

                // If file there attach
                if (fileToAttach != null)
                {
                    //var attachment = new Attachment(fileToAttach);
                    //mailMsg.Attachments.Add(attachment);
                    attachment = new Attachment(fileToAttach, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(fileToAttach);
                    disposition.ModificationDate = File.GetLastWriteTime(fileToAttach);
                    disposition.ReadDate = File.GetLastAccessTime(fileToAttach);
                    disposition.FileName = Path.GetFileName(fileToAttach);
                    disposition.Size = new FileInfo(fileToAttach).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    mailMsg.Attachments.Add(attachment);
                }

                smtpClient.Send(mailMsg);

                // Dispose the attachment so that we can delete backup file later without error
                if (attachment != null)
                    attachment.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Check if the trial mode is active or not.
        /// </summary>
        /// <returns>Return true if trial is active</returns>
        public static bool IsTrialActive(out LicenceExpiry licence)
        {
            var tMaker = new TrialMaker("HouseApp", AppDataPath + "\\LICENCE.LICX", AppDataPath + "\\SYS.DAT",
                "Contact us Details:\n\nEmail: ihomesystem2014@gmail.com \n\nWebSite: www.ihome.org.il", 30, 150, "745");

            byte[] myOwnKey = { 
                                  97, 250, 1, 5, 84, 21, 7, 63,
                                  4, 54, 87, 56, 123, 10, 3, 62,
                                  7, 9, 20, 36, 37, 21, 101, 57
                              };

            tMaker.TripleDESKey = myOwnKey;

            TrialMaker.RunTypes rt = tMaker.ShowDialog();

            if (rt == TrialMaker.RunTypes.Expired)
            {
                licence = null;
                return false;
            }
            var isTrial = rt != TrialMaker.RunTypes.Full;

            if (!isTrial)
            {
                // now we need to check that the application has not expired, if so we will delete the licence keys
                licence = LicenceExpiry.Read();
                if (licence != null)
                {
                    if (licence.DaysTillExpiry <= 0)
                    {
                        // delete the licence key
                        if (File.Exists(AppDataPath + "\\LICENCE.LICX"))
                        {
                            File.Delete(string.Format("{0}\\{1}", AppDataPath, "LICENCE.LICX"));
                            MessageBox.Show("Your Licence has Expired", "Licence Expiry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Application.Exit();
                        }
                    }
                }
            }
            else
            {
                licence = new LicenceExpiry();

                DateTime dtNow = DateTime.Now;
                DateTime dtExpires = dtNow.AddDays(tMaker.TrialPeriodDays);

                licence.ExpiryDate = new DateTime(dtExpires.Year, dtExpires.Month, dtExpires.Day + 0, 0, 0, 0);
            }

            return true;
        }

        /// <summary>
        /// Fill passed combobox with months
        /// </summary>
        public static void FillMonths(ComboBox cboMonth)
        {
            cboMonth.Items.Clear();

            // Prepare list of months
            var months = new BindingList<KeyValuePair<string, int>>();

            months.Add(new KeyValuePair<string, int>("ינואר", 1));
            months.Add(new KeyValuePair<string, int>("פברואר", 2));
            months.Add(new KeyValuePair<string, int>("מרץ", 3));
            months.Add(new KeyValuePair<string, int>("אפריל", 4));
            months.Add(new KeyValuePair<string, int>("מאי", 5));
            months.Add(new KeyValuePair<string, int>("יוני", 6));
            months.Add(new KeyValuePair<string, int>("יולי", 7));
            months.Add(new KeyValuePair<string, int>("אוגוסט", 8));
            months.Add(new KeyValuePair<string, int>("ספטמבר", 9));
            months.Add(new KeyValuePair<string, int>("אוקטובר", 10));
            months.Add(new KeyValuePair<string, int>("נובמבר", 11));
            months.Add(new KeyValuePair<string, int>("דצמבר", 12));

            // Set datasource of combboxes
            cboMonth.DataSource = months;
            cboMonth.ValueMember = "Value";
            cboMonth.DisplayMember = "Key";

            cboMonth.SelectedIndex = 0;


            // Get month names
            //var americanCulture = new CultureInfo("en-US");
            //object[] months = americanCulture.DateTimeFormat.MonthNames;

            //// Add and select months
            //cboMonth.Items.AddRange(months);
            //cboMonth.SelectedIndex = 0;

            //// For removing last empty element
            //cboMonth.Items.RemoveAt(12);
        }

        /// <summary>
        /// Validate textboxes for they are empty or not. And set error itself.
        /// </summary>
        /// <param name="textBox">Textbox control to validate</param>
        /// <param name="errorProvider">ErrorProvier control to show error</param>
        /// <param name="isValid">To ensure that all textboxes were found non-empty</param>
        public static void ValidateTextBox(TextBox textBox, ErrorProvider errorProvider, out bool isValid)
        {
            var fieldName = textBox.Name.Remove(0, 3); // Remove 'txt' word

            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                isValid = false;
                var errorMsg = string.Format("'{0}' can't be left blank", fieldName);
                errorProvider.SetError(textBox, errorMsg);
            }
            else
            {
                isValid = true;
                errorProvider.SetError(textBox, null);
            }
        }

        /// <summary>
        /// Save bitmap image to jpeg type and return jpeg image.
        /// </summary>
        public static Bitmap SaveImgToJpg(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = maxWidth / (float)originalWidth;
            float ratioY = maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            var newWidth = (int)(originalWidth * ratio);
            var newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            var newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

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
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            var encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            var encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            newImage.Save(filePath, imageCodecInfo, encoderParameters);
            return newImage;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        #region -- Backup & Restore Functions --

        /// <summary>
        /// Create text file with details
        /// </summary>
        public static void CreateUserFile(DataTable dataTable)
        {
            var userDetails = Path.Combine(Application.StartupPath, "UserDetails.txt");
            using (var sw = File.CreateText(userDetails))
            {
                sw.Write("Demo Date:");
                sw.WriteLine(Settings.Default.DemoDate);
                sw.WriteLine();

                sw.WriteLine("---User Details--");
                sw.WriteLine();
                sw.WriteLine("Manager Name: {0}", dataTable.Rows[0]["MgrName"]);
                sw.WriteLine("Email: {0}", dataTable.Rows[0]["Email"]);
                sw.WriteLine("Street Name: {0}", dataTable.Rows[0]["StreetName"]);
                sw.WriteLine("Street Number: {0}", dataTable.Rows[0]["StreetNumber"]);
                sw.WriteLine("City: {0}", dataTable.Rows[0]["City"]);
                sw.WriteLine("Phone: {0}", dataTable.Rows[0]["Phone"]);
                sw.WriteLine("Mobile: {0}", dataTable.Rows[0]["Mobile"]);
                //sw.WriteLine("Street Number: {0}", dataTable.Rows[0]["streetNum"]);
            }
        }

        /// <summary>
        /// Create backup of important files. 
        /// </summary>
        public static void CreateBackup(string zipFileName)
        {
            // Get path to respective files
            var appDbPath = Path.Combine(AppDataPath, "DBL");
            var appDbFilePath = Path.Combine(appDbPath, AppDbName);
            var licensePath = Path.Combine(AppDataPath, "LICENCE.LICX");
            var sysPath = Path.Combine(AppDataPath, "SYS.DAT");
            var serialPath = Path.Combine(Application.StartupPath, "SERIAL.DAT");
            var txtPath = Path.Combine(Application.StartupPath, "UserDetails.txt");

            // Use Ionic.Zip.Reduced.dll from DLL folder in References
            // Details at- http://dotnetzip.codeplex.com/
            using (var zip = new ZipFile())
            {
                // 1st param : path to file, 2nd param : directoryPath
                if (File.Exists(licensePath))
                    zip.AddFile(licensePath, string.Empty);

                if (File.Exists(sysPath))
                    zip.AddFile(sysPath, string.Empty);

                if (File.Exists(txtPath))
                    zip.AddFile(txtPath, string.Empty);

                if (File.Exists(appDbFilePath))
                    zip.AddFile(appDbFilePath, string.Empty);

                if (File.Exists(serialPath))
                    zip.AddFile(serialPath, string.Empty);

                // Now save                
                zip.Save(zipFileName);

                // If local backup path is not null, take backup                
                if (BackupPath == null) return;

                // If directory exists, then take backup. Done!

                if (Directory.Exists(BackupPath))
                {
                    var zipLocalFile = Path.Combine(BackupPath, zipFileName);
                    zip.Save(zipLocalFile);
                }
                else
                {
                    var errorMsg = string.Format("Backup directory '{0}' not found. So no backup will be made.", BackupPath);
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Upload content to server.
        /// </summary>
        public static void Upload(string zipFilePath, string zipFileName)
        {
            byte[] fileContents;

            var ftpServer = ConfigurationManager.AppSettings["FtpServer"];
            var ftpDirectory = ConfigurationManager.AppSettings["FtpDirectory"];
            var ftpUser = ConfigurationManager.AppSettings["FtpUser"];
            var ftpPass = ConfigurationManager.AppSettings["FtpPass"];

            var ftpBuilder = new StringBuilder("ftp://").Append(ftpServer).Append(ftpDirectory).Append(zipFileName);

            var ftpRequest = (FtpWebRequest)WebRequest.Create(ftpBuilder.ToString());
            ftpRequest.Proxy = null;
            ftpRequest.Credentials = new NetworkCredential(ftpUser, ftpPass);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            using (var sourceStream = new StreamReader(zipFilePath))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            ftpRequest.ContentLength = fileContents.Length;

            var ftpStream = ftpRequest.GetRequestStream();
            ftpStream.Write(fileContents, 0, fileContents.Length);
            ftpStream.Close();
        }

        /// <summary>
        /// Restore from backup file.
        /// </summary>
        public static bool Restore(string backupFile)
        {
            var restored = false;

            // 1. Extract all files from the archive (3 license file + 1 database file)
            var appDbPath = Path.Combine(AppDataPath, "DBL");

            if (File.Exists(backupFile))
            {
                using (var zipFile = ZipFile.Read(backupFile))
                {
                    foreach (var zipEntry in zipFile)
                    {
                        // 2. Get all files extracted to their directories
                        // Get database file extracted to DBL folder in AppDataPath
                        if (zipEntry.FileName.Equals(AppDbName, StringComparison.OrdinalIgnoreCase))
                            zipEntry.Extract(appDbPath, ExtractExistingFileAction.OverwriteSilently);

                        // Get license file extracted to AppDataPath
                        if (zipEntry.FileName.Equals("LICENCE.LICX", StringComparison.OrdinalIgnoreCase))
                            zipEntry.Extract(AppDataPath, ExtractExistingFileAction.OverwriteSilently);

                        // Get Sys.Data file extacted to AppDataPath
                        if (zipEntry.FileName.Equals("SYS.DAT", StringComparison.OrdinalIgnoreCase))
                            zipEntry.Extract(AppDataPath, ExtractExistingFileAction.OverwriteSilently);

                        if (zipEntry.FileName.Equals("SERIAL.DAT", StringComparison.OrdinalIgnoreCase))
                            zipEntry.Extract(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);
                    }

                    // 3. Show message to user
                    var dr = MessageBox.Show("HouseApp was restored to its previous state successfully!", "Restore succeeded", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);

                    if (dr.Equals(DialogResult.OK))
                    {
                        restored = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Backup file '" + backupFile + "' not found.", "Restore failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            return restored;
        }

        #endregion

        #endregion
    }
}
