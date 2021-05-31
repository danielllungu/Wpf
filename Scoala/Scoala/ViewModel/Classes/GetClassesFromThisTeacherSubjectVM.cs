using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Classes
{
    class GetClassesFromThisTeacherSubjectVM
    {
        private Teacher teacher;
        private Subject subject;
        //public ObservableCollection<Class> classes = new ObservableCollection<Class>();
        private ObservableCollection<TeachersToClassesLST> t = new ObservableCollection<TeachersToClassesLST>();

        public GetClassesFromThisTeacherSubjectVM(Teacher tc, Subject s)
        {
            this.teacher = tc;
            this.subject = s;
            TeachersToSubjectsToClassDAL dal = new TeachersToSubjectsToClassDAL();
            t = dal.GetTeachersToSubjectsToClass();
        }

        public ObservableCollection<Class> GetClasses()
        {
            ObservableCollection<Class> cls = new ObservableCollection<Class>();
            for(int index=0; index<t.Count(); index++)
            {
                if(t[index].Teacher.TeacherID==teacher.TeacherID && t[index].Subject.SubjectID==subject.SubjectID)
                {
                    cls.Add(t[index].Class);
                }
            }

            return cls;
        }

    }
}
