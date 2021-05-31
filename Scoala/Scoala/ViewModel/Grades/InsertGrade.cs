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
    class InsertGrade
    {
        private Teacher teacher;
        private Student student;
        private Subject subject;
        private ObservableCollection<TeacherToSubjectLST> teacherToSubject = new ObservableCollection<TeacherToSubjectLST>();
        private int nota;
        private int semestru;
        private string data;
        private string tip_nota;

        public InsertGrade(Student st, Teacher tc, Subject sb, int nota, int semestru, string data, string tip_nota)
        {
            this.teacher = tc;
            this.subject = sb;
            this.student = st;
            TeacherLDDAL tdal = new TeacherLDDAL();
            teacherToSubject = tdal.GetAllTeacherToSubject();
            this.nota = nota;
            this.semestru = semestru;
            this.tip_nota = tip_nota;
            this.data = data;
        }

        public void Insert()
        {
            GradesDAL dal = new GradesDAL();
            for(int index=0; index<teacherToSubject.Count(); index++)
            {
                if(teacherToSubject[index].Subject.SubjectID==subject.SubjectID && teacherToSubject[index].Teacher.TeacherID==teacher.TeacherID)
                {
                    dal.InsertGradeStudent(student, subject, teacherToSubject[index].TeacherToSubject, tip_nota, nota, semestru, data);
                }
            }
        }

    }
}
