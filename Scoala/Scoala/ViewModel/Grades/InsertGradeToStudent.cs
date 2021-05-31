using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;
using Scoala.Models.BussinessLogic;

namespace Scoala.ViewModel.Grades
{
    class InsertGradeToStudent
    {
        private string tipNota;
        private int? nota;
        private Student student;
        private Teacher teacher;
        private Subject subject;
        private string data;
        private int semestru;

        public InsertGradeToStudent(string tip_nota, int? nota, Student s, Teacher t, string dt, int sem, Subject sub)
        {
            this.data = dt;
            this.nota = nota;
            this.semestru = sem;
            this.student = s;
            this.teacher = t;
            this.tipNota = tip_nota;
            this.subject = sub;
            
        }

        public void InsertGrade()
        {
            GradesDAL dal = new GradesDAL();
            dal.InsertGrade(nota, tipNota);
            Grade g = new Grade();
            GetLastGivenGrade gt = new GetLastGivenGrade();
            g = gt.GetGrade();
            TeacherToSubject teacherToSubject = new TeacherToSubject();
            teacherToSubject = GetTeacherToSubject();

            dal.InsertGradeToStudent(student, teacherToSubject, data, g, semestru);
        }


        public ObservableCollection<TeacherToSubjectLST> teacherToSubjectLST = new ObservableCollection<TeacherToSubjectLST>();
        public TeacherToSubject GetTeacherToSubject()
        {
            TeacherLDDAL dal = new TeacherLDDAL();
            teacherToSubjectLST = dal.GetAllTeacherToSubject();
            TeacherToSubject result = new TeacherToSubject();
            for (int index = 0; index < teacherToSubjectLST.Count(); index++)
            {
                if (teacherToSubjectLST[index].Teacher.TeacherID == teacher.TeacherID && teacherToSubjectLST[index].Subject.SubjectID == subject.SubjectID)
                {
                    result = teacherToSubjectLST[index].TeacherToSubject;
                }
            }
            return result;
        }

    }
}
