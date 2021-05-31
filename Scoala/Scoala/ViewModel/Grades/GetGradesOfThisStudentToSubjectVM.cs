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
    class GetGradesOfThisStudentToSubjectVM
    {
        private Student student;
        private TeacherToSubject teacherToSubject;
        private Teacher teacher;
        private Subject subject;

        public GetGradesOfThisStudentToSubjectVM(Student st, Teacher tc, Subject sb)
        {
            this.student = st;
            this.teacher = tc;
            this.subject = sb;

            TeacherLDDAL dal = new TeacherLDDAL();
            teacherToSubjectLST = dal.GetAllTeacherToSubject();
            GradesDAL dalgrade = new GradesDAL();
            studentsToGrades = dalgrade.GetAllStudentsToGrades();

        }

        public ObservableCollection<StudentsToGradesLST> studentsToGrades = new ObservableCollection<StudentsToGradesLST>();
        public ObservableCollection<TeacherToSubjectLST> teacherToSubjectLST = new ObservableCollection<TeacherToSubjectLST>();
    
        
        public TeacherToSubject GetTeacherToSubject()
        {
            TeacherToSubject result = new TeacherToSubject();
            for(int index=0; index<teacherToSubjectLST.Count(); index++)
            {
                if(teacherToSubjectLST[index].Teacher.TeacherID==teacher.TeacherID && teacherToSubjectLST[index].Subject.SubjectID==subject.SubjectID)
                {
                    result = teacherToSubjectLST[index].TeacherToSubject;
                }
            }
            return result;
        }

       

        public ObservableCollection<StudentsToGradesLST> GetAllGradesDetails()
        {
            teacherToSubject = GetTeacherToSubject();
            ObservableCollection<StudentsToGradesLST> studentsGrades = new ObservableCollection<StudentsToGradesLST>();
            GetAllstudentsToGradesVM gt = new GetAllstudentsToGradesVM();
            studentsGrades = gt.studentsToGrades;
            ObservableCollection<StudentsToGradesLST> result = new ObservableCollection<StudentsToGradesLST>();
            for(int index=0; index<studentsGrades.Count(); index++)
            {
                for(int i=0; i<teacherToSubjectLST.Count(); i++)
                {
                    if(studentsGrades[index].StudentToGrade.CuplajID==teacherToSubjectLST[i].TeacherToSubject.CuplajID)
                    {
                        result.Add(studentsGrades[index]);
                    }
                }
            }

            return result;

        }
    }
}
