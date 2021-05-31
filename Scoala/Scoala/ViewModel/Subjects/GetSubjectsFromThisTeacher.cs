using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Subjects
{
    class GetSubjectsFromThisTeacher
    {
        private Teacher teacher;
        public ObservableCollection<TeacherToSubjectLST> teacherToSubject = new ObservableCollection<TeacherToSubjectLST>();
        public GetSubjectsFromThisTeacher(Teacher t)
        {
            this.teacher = t;
            TeacherLDDAL dal = new TeacherLDDAL();
            teacherToSubject = dal.GetAllTeacherToSubject();

        }

        
        public ObservableCollection<Subject> GetSubjects()
        {
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            for(int index=0; index<teacherToSubject.Count(); index++)
            {
                if(teacherToSubject[index].Teacher.TeacherID==teacher.TeacherID)
                {
                    subjects.Add(teacherToSubject[index].Subject);
                }

            }

            return subjects;
        }

    }
}
