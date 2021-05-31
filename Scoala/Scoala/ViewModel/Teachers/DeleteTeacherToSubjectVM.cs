using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class DeleteTeacherToSubjectVM
    {
        TeacherToSubject teacherToSubject;

        public DeleteTeacherToSubjectVM(TeacherToSubject tts)
        {
            this.teacherToSubject = tts;
        }

        public void Delete()
        {
            TeacherLDDAL t = new TeacherLDDAL();
            t.DeleteTeacherToSubject(teacherToSubject);
        }

    }
}
