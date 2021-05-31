using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;
using Scoala.Models.BussinessLogic;
using System.Collections.ObjectModel;

namespace Scoala.ViewModel.Students
{
    
    class DeleteStudentFromSchoolVM
    {
        private Student student;

        public DeleteStudentFromSchoolVM(Student st)
        {
            this.student = st;
        }

        public void DeleteStudent()
        {
            StudentLDDAL studentLDDAL = new StudentLDDAL();
            studentLDDAL.DeleteStudentFromLogin(student);
            studentLDDAL.DeleteStudentFromMarks(student);
            studentLDDAL.DeleteStudentFromClass(student);
            studentLDDAL.DeleteStudentFromAbsences(student);
            studentLDDAL.DeleteStudentFromStudents(student);
        }

    }
}
