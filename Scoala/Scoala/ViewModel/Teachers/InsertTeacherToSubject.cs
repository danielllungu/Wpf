using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class InsertTeacherToSubject
    {
        Teacher teacher;
        Subject subject;

        public InsertTeacherToSubject(Teacher t, Subject s)
        {
            this.teacher = t;
            this.subject = s;
        }

        public void Add()
        {
            TeacherLDDAL teacherLDDAL = new TeacherLDDAL();
            teacherLDDAL.InsertTeacherToSubject(teacher, subject);
        }
    }
}
