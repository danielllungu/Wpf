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
    class GradesOfThisStudent
    {
        private Student student;
        private Subject subject;
        private TeacherToSubject teacherToSubject;

        public ObservableCollection<GradeStudentLST> gradesStudent = new ObservableCollection<GradeStudentLST>();
        
    
        public GradesOfThisStudent(Student st, Subject sub)
        {
            this.student = st;
            this.subject = sub;
            GradesDAL dalgrade = new GradesDAL();
            gradesStudent = dalgrade.GetAllGradeStudents();
        }


        

        public ObservableCollection<GradeStudentLST> GetGrades()
        {
            ObservableCollection<GradeStudentLST> result = new ObservableCollection<GradeStudentLST>();

            for(int index=0; index<gradesStudent.Count(); index++)
            {
                if(gradesStudent[index].Student.StudentID==student.StudentID && gradesStudent[index].TeacherToSubject.SubjectID==subject.SubjectID)
                {
                    result.Add(gradesStudent[index]);
                }
            }
            
            return result;

        }
    }
}
