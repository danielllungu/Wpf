using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;
using Scoala.Models.BussinessLogic;

namespace Scoala.ViewModel.Students
{
    class AddStudentVM
    {
        public AddStudentVM(string name, Class cls)
        {
            StudentLDDAL student = new StudentLDDAL();
            student.AddStudent(name);
            Student st = new Student();
            st = Get_Added_Student(name);
            student.AddStudentToClass(st, cls);

            AddStudentLDBL addLD = new AddStudentLDBL();
            addLD.AddLDStudent();

        }

        public Student Get_Added_Student(string name)
        {
            Student st = new Student();
            AddStudentBL addStudentBL = new AddStudentBL(name);
            st = addStudentBL.student;
            return st;

        }
    }
}
