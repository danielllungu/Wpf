using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Scoala.Models.BussinessLogic
{
    class AddTeacherLD
    {
        private Teacher teacher;


        public AddTeacherLD()
        {
            GetAddedTeacherBL gt = new GetAddedTeacherBL();
            this.teacher = gt.GetTeacher();
        }

        public void AddLDTeacher()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            string s = "";
            for(int index=0; index<teacher.Name.Length; index++)
            {
                if(teacher.Name[index]==' ')
                {
                    s += '.';
                    names.Add(s);
                    s = "";
                }
                else if(teacher.Name[index]!=' ')
                {
                    s += teacher.Name[index];
                    s=s.ToLower();
                }
                
            }
            s += "@gmail.com";
            names.Add(s);
            string pass = "parolaprof";

            string email = "";
            for(int index=0; index<names.Count(); index++)
            {
                email += names[index];
            }
            
            
            TeacherLDDAL dal = new TeacherLDDAL();
            dal.AddTeacherLD(teacher, email, pass);
        }
    }
}
