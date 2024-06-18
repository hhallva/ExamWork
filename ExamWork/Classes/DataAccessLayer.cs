using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ExamWork.Classes
{
    internal class DataAccessLayer
    {
        #region Свойства
        public static string ServerName { get; set; } = @"MSI";
        public static string DatabaseName { get; set; } = "Exam";
        public static string Login { get; set; } = @"MSI\slavv";
        public static string Password { get; set; } = "";
        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = ServerName, 
                    UserID = Login,
                    //Password = Password,
                    InitialCatalog = DatabaseName,
                    IntegratedSecurity = true,
                    TrustServerCertificate = true
                };
                return builder.ConnectionString;
            }
        }
        #endregion

        public static bool IsUserExist(string login, string password)
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM ExamUser WHERE UserLogin = @login AND UserPassword = @password";

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            return command.ExecuteScalar() != null;
        }
    }
}
