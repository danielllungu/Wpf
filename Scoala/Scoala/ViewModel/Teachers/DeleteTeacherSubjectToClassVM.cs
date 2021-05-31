using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class DeleteTeacherSubjectToClassVM
    {
        private TeacherToSubject teacherToSubject;
        private Class cls;

        public DeleteTeacherSubjectToClassVM(TeacherToSubject tts, Class c)
        {
            this.teacherToSubject = tts;
            this.cls = c;
        }

        public void Delete()
        {
            TeachersToSubjectsToClassDAL dal = new TeachersToSubjectsToClassDAL();
            dal.DeleteTeacherSubjectToClass(teacherToSubject, cls);
            

        }

    }
}
