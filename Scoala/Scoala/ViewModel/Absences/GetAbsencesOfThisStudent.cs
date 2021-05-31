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
    class GetAbsencesOfThisStudent
    {
        Student student;
        Subject subject;

        private ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
        public GetAbsencesOfThisStudent(Student st, Subject sub)
        {
            this.student = st;
            this.subject = sub;
            AbsenceDAL dal = new AbsenceDAL();
            absences = dal.GetAllAbsenceStudentListed();
        }

        public ObservableCollection<AbsenceStudentLST> GetAbsences()
        {
            ObservableCollection<AbsenceStudentLST> result = new ObservableCollection<AbsenceStudentLST>();
            for(int index=0; index<absences.Count(); index++)
            {
                if(absences[index].Student.StudentID==student.StudentID && absences[index].TeacherToSubject.SubjectID==subject.SubjectID)
                {
                    result.Add(absences[index]);
                }
            }
            return result;
        }

    }
}
