using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Grades
{
    class DeleteGradeStudentVM
    {
        private GradeStudent grade;

        public DeleteGradeStudentVM(GradeStudent g)
        {
            this.grade = g;
        }

        public void Delete()
        {
            GradesDAL dal = new GradesDAL();
            dal.DeleteGradeStudent(grade);
        }
    }
}
