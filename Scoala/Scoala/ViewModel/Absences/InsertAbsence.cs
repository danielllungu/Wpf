using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Absences
{
    class InsertAbsence
    {
        private Teacher teacher;
        private Student student;
        private Subject subject;
        private ObservableCollection<TeacherToSubjectLST> teacherToSubject = new ObservableCollection<TeacherToSubjectLST>();
        private string data;
        private string tip_absenta;

        public InsertAbsence(Student st, Teacher tc, Subject sb, string dt, string tipAbs)
        {
            this.student = st;
            this.teacher = tc;
            this.subject = sb;
            this.data = dt;
            this.tip_absenta = tipAbs;
            TeacherLDDAL tdal = new TeacherLDDAL();
            teacherToSubject = tdal.GetAllTeacherToSubject();

        }

        public void Insert()
        {
            AbsenceDAL dal = new AbsenceDAL();
            for(int index=0; index<teacherToSubject.Count(); index++)
            {
                if(teacherToSubject[index].Teacher.TeacherID==teacher.TeacherID && teacherToSubject[index].Subject.SubjectID==subject.SubjectID)
                {
                    dal.InsertAbsence(student, teacherToSubject[index].TeacherToSubject, tip_absenta, data);
                }
            }
        }
    }
}
