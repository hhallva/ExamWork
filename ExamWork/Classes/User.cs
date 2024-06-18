using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Classes
{
    public class User
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public int RoleID { get; set; }
    }
}
