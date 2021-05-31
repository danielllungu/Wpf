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
    class GetGradeStudentLSTVM
    {
        private Student student;
        private Subject subject;
        private Teacher teacher;
        private ObservableCollection<TeacherToSubjectLST> all_teacherToSubject = new ObservableCollection<TeacherToSubjectLST>();
        public ObservableCollection<GradeStudentLST> gradesStudent = new ObservableCollection<GradeStudentLST>();
        public GetGradeStudentLSTVM(Student st, Subject sub, Teacher tc)
        {
            this.student = st;
            this.subject = sub;
            this.teacher = tc;
            TeacherLDDAL dal_teacher = new TeacherLDDAL();
            all_teacherToSubject = dal_teacher.GetAllTeacherToSubject();
            GradesDAL dal = new GradesDAL();
            gradesStudent = dal.GetAllGradeStudents();
        }

        public ObservableCollection<GradeStudent> GetGrades()
        {
            ObservableCollection<GradeStudent> grades = new ObservableCollection<GradeStudent>();

            for (int index = 0; index < all_teacherToSubject.Count(); index++)
            {
                for (int i = 0; i < gradesStudent.Count(); i++)
                {

                    if (all_teacherToSubject[index].Subject.SubjectID == subject.SubjectID && all_teacherToSubject[index].Teacher.TeacherID == teacher.TeacherID && all_teacherToSubject[index].TeacherToSubject.CuplajID == gradesStudent[i].TeacherToSubject.CuplajID)
                    {
                        if (gradesStudent[i].Student.StudentID == student.StudentID)
                        {
                            grades.Add(new GradeStudent() { CuplajID= gradesStudent[i].GradeStudent.CuplajID, Data= gradesStudent[i].GradeStudent.Data, Grade= gradesStudent[i].GradeStudent.Grade, GradeID= gradesStudent[i].GradeStudent.GradeID, Semsestru= gradesStudent[i].GradeStudent.Semsestru, StudentID= gradesStudent[i].GradeStudent.StudentID, TipNota= gradesStudent[i].GradeStudent.TipNota });
                        }
                    }
                }
            }

            return grades;
        }

    }
}
