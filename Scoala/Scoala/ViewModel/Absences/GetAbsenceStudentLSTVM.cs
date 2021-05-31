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
    class GetAbsenceStudentLSTVM
    {
        private Subject subject;
        private Student student;
        private Teacher teacher;
        private ObservableCollection<TeacherToSubjectLST> teacherToSubject = new ObservableCollection<TeacherToSubjectLST>();
        public ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();


        public GetAbsenceStudentLSTVM(Student st, Subject sub, Teacher tc)
        {
            this.student = st;
            this.subject = sub;
            this.teacher = tc;
            TeacherLDDAL tdal = new TeacherLDDAL();
            teacherToSubject = tdal.GetAllTeacherToSubject();
            AbsenceDAL adal = new AbsenceDAL();
            absences = adal.GetAllAbsenceStudentListed();
        }

        public ObservableCollection<AbsenceStudentLST> GetAbsences()
        {
            ObservableCollection<AbsenceStudentLST> result = new ObservableCollection<AbsenceStudentLST>();

            for(int index=0; index<teacherToSubject.Count(); index++)
            {
                for(int i=0; i<absences.Count(); i++)
                {
                    if(teacherToSubject[index].Subject.SubjectID==subject.SubjectID && teacherToSubject[index].Teacher.TeacherID==teacher.TeacherID)
                    {
                        if(absences[i].Student.StudentID==student.StudentID && absences[i].TeacherToSubject.CuplajID==teacherToSubject[index].TeacherToSubject.CuplajID)
                        {
                            result.Add(absences[i]);
                        }
                    }
                }
            }

            return result;

        }
    }
}
