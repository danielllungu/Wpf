using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class InsertTeacherSubjectToClassVM
    {
        TeacherToSubject teacherToSubject;
        Class cls;
        public InsertTeacherSubjectToClassVM(TeacherToSubject t, Class c)
        {
            this.teacherToSubject = t;
            this.cls = c;
        }

        public void Insert()
        {
            TeachersToSubjectsToClassDAL tdal = new TeachersToSubjectsToClassDAL();
            tdal.InsertTeacherSubjectToClass(teacherToSubject, cls);
        }
    }
}
