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
    class GetAddedStudentBL
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();

        public GetAddedStudentBL()
        {
            StudentLDDAL dal = new StudentLDDAL();
            students = dal.GetStudents();
        }

        public Student GetStudent()
        {
            return students[students.Count() - 1];
        }
    }
}
