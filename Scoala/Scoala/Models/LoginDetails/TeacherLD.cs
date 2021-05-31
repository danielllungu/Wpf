using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.LoginDetails
{
    class TeacherLD
    {
        private int? teacher_id;
        public int? TeacherID
        {
            get
            {
                return teacher_id;
            }
            set
            {
                teacher_id = value;
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
