using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;

namespace Scoala.Models.BussinessLogic
{
    class AddStudentLDBL
    {
        private Student student;

        public AddStudentLDBL()
        {
            GetAddedStudentBL get = new GetAddedStudentBL();
            this.student = get.GetStudent();
        }

        public void AddLDStudent()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            string s = "";
            for (int index = 0; index < student.Name.Length; index++)
            {
                if (student.Name[index] == ' ')
                {
                    s += '.';
                    names.Add(s);
                    s = "";
                }
                else if (student.Name[index] != ' ')
                {
                    s += student.Name[index];
                    s = s.ToLower();
                }

            }
            s += "@gmail.com";
            names.Add(s);
            string pass = "parolaelev";

            string email = "";
            for (int index = 0; index < names.Count(); index++)
            {
                email += names[index];
            }

            StudentLDDAL sdal = new StudentLDDAL();
            sdal.AddStudentLD(student, email, pass);
            
        }
    }
}
