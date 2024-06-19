using Microsoft.Data.SqlClient;
using System.Data;

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

        public static User GetUserData(string login, string password)
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM ExamUser WHERE UserLogin = @login AND UserPassword = @password";

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            var reader = command.ExecuteReader();

            DataTable table = new();
            table.Load(reader);
           
            User user = new()
            {
                Name = table.Rows[0]["UserName", DataRowVersion.Current].ToString(),
                Patronymic = table.Rows[0]["UserPatronymic", DataRowVersion.Current].ToString(),
                Surname = table.Rows[0]["UserSurname", DataRowVersion.Current].ToString(),
                UserLogin = table.Rows[0]["UserLogin", DataRowVersion.Current].ToString(),
                UserPassword = table.Rows[0]["UserPassword", DataRowVersion.Current].ToString(),
                RoleID = Convert.ToInt32(table.Rows[0]["RoleID", DataRowVersion.Current]),
            };
            return user;
        }
    }
}
