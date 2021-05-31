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
    class AddStudentBL
    {
        public Student student { get; set; }
        public AddStudentBL(string nume)
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            StudentLDDAL studentLDDAL = new StudentLDDAL();
            students = studentLDDAL.GetStudents();
            student = students[students.Count() - 1];
        }

        
    }
}
