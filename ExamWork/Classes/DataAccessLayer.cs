using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Classes
{
    internal class DataAccessLayer
    {
        #region Свойства
        public static string ServerName { get; set; } = @"prserver\SQLEXPRESS";
        public static string DatabaseName { get; set; } = "Exam";
        public static string Login { get; set; } = "";
        public static string Password { get; set; } = "";
        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = ServerName,
                    UserID = Login,
                    Password = Password,
                    InitialCatalog = DatabaseName,
                    TrustServerCertificate = true
                };
                return builder.ConnectionString;
            }
        }
        #endregion

        public static bool IsUser(string login, string password)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM  ExamUser WHERE UserLogin = @login AND UserPassword = @password";

            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
