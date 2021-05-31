using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.LoginDetails;

namespace Scoala.Models.BussinessLogic
{
    class HelpStudentLoggedInBL
    {
        private int? id;

        public HelpStudentLoggedInBL(int? idS)
        {
            this.id = idS;
        }

        public Student GetStudent()
        {
            StudentLDDAL dal = new StudentLDDAL();
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students = dal.GetStudents();

            for(int index=0; index<students.Count(); index++)
            {
                if(students[index].StudentID==id)
                {
                    return students[index];
                }
            }

            return null;
        }
    }
}
