using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class DeleteTeacherVM
    {
        private Teacher teacher;

        public DeleteTeacherVM(Teacher t)
        {
            this.teacher = t;
        }

        public void DeleteTeacher()
        {
            TeacherLDDAL t = new TeacherLDDAL();
            t.DeleteTeacherFromClasses(teacher);
            t.DeleteTeacherFromLogin(teacher);
            t.DeleteTeacherFromMasters(teacher);
            t.DeleteTeacherFromSubjects(teacher);
            t.DeleteTeacherFromTeachers(teacher);
        }
    }
}
