/****************************** Module DataAccess ******************************\
* Module Name:  DataAccess.cs
* Project:      HouseApp
* Date:         28th July, 2014
* 
* Provide functions for handling database related tasks.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Text;

namespace HouseApp.Code
{
    class DataAccess
    {
        /// <summary>
        /// Check if SchemaVersions_TBL exists in Database.
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static bool ExistSchemaVersion(string connString)
        {
            int returnValue;

            using (SqlCeConnection cn = new SqlCeConnection(connString))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES ic WHERE ic.TABLE_NAME = 'SchemaVersions_TBL'");

                using (SqlCeCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sql.ToString();

                    cn.Open();

                    returnValue = (int)cm.ExecuteScalar();
                }
            }
            return (returnValue > 0);
        }

        /// <summary>
        /// Execute query and return true or false based on statement executed or not.
        /// </summary>        
        public static bool ExecuteNonQuery(string connString, string query)
        {
            int returnValue;

            using (SqlCeConnection cn = new SqlCeConnection(connString))
            {
                using (SqlCeCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = query;
                    cn.Open();
                    returnValue = cm.ExecuteNonQuery();
                }
            }

            return (returnValue > 0);
        }

        /// <summary>
        /// Execute query and return object with values returned from database.
        /// </summary>        
        public static object ExecuteScalar(string connString, string query)
        {
            object returnValue;

            // Connection created
            using (SqlCeConnection cn = new SqlCeConnection(connString))
            {
                StringBuilder sql = new StringBuilder();

                sql.Append(query);

                // Command created
                using (SqlCeCommand cm = cn.CreateCommand())
                {
                    // Queryset
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sql.ToString();

                    // Connection open
                    cn.Open();

                    // Run query and get me records
                    returnValue = cm.ExecuteScalar();
                }
            }
            // Return that records back
            return returnValue;
        }

        /// <summary>
        /// Get datatable as per query.
        /// </summary>
        public static DataTable GetDataTable(string query)
        {
            DataTable dt;
            using (var da = new SqlCeDataAdapter(query, Utility.ConnectionString))
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Save record to 'Dayarim' related table.
        /// </summary>
        /// <param name="tableName">Name of Dayarim related table</param>
        /// <param name="dayarApartmentNum">The apartment number</param>
        /// <param name="dayarName">First name</param>
        /// <param name="dayarLastName">Last name</param>
        /// <param name="dayarStatus">Status</param>
        /// <param name="dayarJoinMeeting">Join meeting date</param>
        /// <param name="dayarPhone">Phone</param>
        /// <param name="dayarMobile">Mobile</param>
        /// <param name="dayarEmail">Email Id</param>
        /// <param name="dayarPay">Pay</param>
        /// <param name="dayarLastPay">Last pay</param>
        /// <returns></returns>
        public static bool SaveToDayarim(string tableName, string dayarApartmentNum, string dayarName, string dayarLastName, string dayarStatus, string dayarJoinMeeting, string dayarPhone, string dayarMobile, string dayarEmail, string dayarPay, string dayarLastPay)
        {
            bool recordSaved;

            // Build query
            var query = new StringBuilder("INSERT INTO ");
            query.Append(tableName);
            query.Append("(Dayarapartmentnum, BuildingId, Dayarname, Dayarlastname,Dayarstatus,Dayarjoinmeeting,Dayarphone,Dayarmobil,Dayaremail,Dayarpay,DayarLastPay) VALUES (@Dayarapartmentnum,@BuildingId,@Dayarname,@Dayarlastname,@Dayarstatus,@Dayarjoinmeeting,@Dayarphone,@Dayarmobil,@Dayaremail,@Dayarpay,@DayarLastPay)");
            using (var con = new SqlCeConnection(Utility.ConnectionString))
            {
                using (var cmd = new SqlCeCommand(query.ToString(), con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Dayarapartmentnum", Convert.ToInt32(dayarApartmentNum));
                    cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                    cmd.Parameters.AddWithValue("@Dayarname", dayarName);
                    cmd.Parameters.AddWithValue("@Dayarlastname", dayarLastName);
                    cmd.Parameters.AddWithValue("@Dayarstatus", dayarStatus);
                    cmd.Parameters.AddWithValue("@Dayarjoinmeeting", dayarJoinMeeting);
                    cmd.Parameters.AddWithValue("@Dayarphone", dayarPhone);
                    cmd.Parameters.AddWithValue("@Dayarmobil", dayarMobile);
                    cmd.Parameters.AddWithValue("@Dayaremail", dayarEmail);
                    cmd.Parameters.AddWithValue("@Dayarpay", dayarPay);
                    cmd.Parameters.AddWithValue("@DayarLastPay", dayarLastPay);
                    cmd.CommandType = CommandType.Text;
                    recordSaved = cmd.ExecuteNonQuery() > 0;
                }
            }

            return recordSaved;
        }

        /// <summary>
        /// Save record to 'Payment' related table.
        /// </summary>
        /// <param name="tableName">Name of table</param>
        /// <param name="dayarApartmentNum">Apartment number</param>
        /// <param name="dayarName">Name</param>
        /// <param name="dayarLastName">Last name</param>
        /// <param name="payType">Type of payment</param>
        /// <param name="month">Month</param>
        /// <param name="year">Year</param>
        /// <param name="idNotification">Id Notification</param>
        /// <param name="dayarPay">Pay</param>
        /// <param name="amountPaid">Amount paid</param>
        /// <param name="amountLeft">Amount left</param>
        /// <returns></returns>
        public static bool SaveToPayment(string tableName, string dayarApartmentNum, string dayarName, string dayarLastName, string payType, string month, string year, string idNotification, string dayarPay, string amountPaid, string amountLeft)
        {
            bool recordSaved;

            // Build query
            var query = new StringBuilder("INSERT INTO ");
            query.Append(tableName);
            query.Append("(Dayarapartmentnum,BuildingId,Dayarname, Dayarlastname,PayType,Month, Year, IdNotification,Dayarpay,AmountPaid,AmountLeft) VALUES  (@Dayarapartmentnum,@BuildingId,@Dayarname,@Dayarlastname,@PayType,@Month,@Year,@IdNotification,@Dayarpay,@AmountPaid,@AmountLeft)");

            using (var con = new SqlCeConnection(Utility.ConnectionString))
            {
                using (var cmd = new SqlCeCommand(query.ToString(), con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Dayarapartmentnum", Convert.ToInt32(dayarApartmentNum));
                    cmd.Parameters.AddWithValue("@BuildingId", Utility.BuildingId);
                    cmd.Parameters.AddWithValue("@Dayarname", dayarName);
                    cmd.Parameters.AddWithValue("@Dayarlastname", dayarLastName);
                    cmd.Parameters.AddWithValue("@PayType", payType);
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@IdNotification", idNotification);
                    cmd.Parameters.AddWithValue("@Dayarpay", dayarPay);
                    cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                    cmd.Parameters.AddWithValue("@AmountLeft", amountLeft);
                    cmd.CommandType = CommandType.Text;
                    recordSaved = cmd.ExecuteNonQuery() > 0;
                }
            }

            return recordSaved;
        }

        /// <summary>
        /// Check if record exists for respective Dayarim table.
        /// </summary>
        /// <returns>Return true if record exists</returns>
        public static bool IsRecordExistInDayarim(string tableName, string dayarApartmentNum)
        {
            var query = new StringBuilder("SELECT COUNT(*) FROM ");
            query.Append(tableName)
                .Append(" WHERE Dayarapartmentnum LIKE '")
                .Append(dayarApartmentNum)
                .Append("' AND BuildingId=").Append(Utility.BuildingId);

            var count = (int)ExecuteScalar(Utility.ConnectionString, query.ToString());
            return count > 0;
        }
    }
}
