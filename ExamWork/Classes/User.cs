using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Classes
{
    public class User
    {
        #region Свойства
        public string _name { get; set; }
        public string _patronymic { get; set; }
        public string _surname { get; set; }
        public string _login { get; set; }
        public string _password { get; set; }
        public int _roleID { get; set; }
        #endregion

        #region Констуркторы 
        public User(string name, string patronymic, string surname, string login, string password, int role)
        {
            _name = name;
            _patronymic = patronymic;
            _surname = surname;
            _login = login;
            _password = password;
            _roleID = role;
        }

        public User() : this("Гость", string.Empty, string.Empty, string.Empty, string.Empty, 2) { }
        #endregion

    }
}
