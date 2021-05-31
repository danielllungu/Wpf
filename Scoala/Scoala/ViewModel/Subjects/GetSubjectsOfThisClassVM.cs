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
    class GetSubjectsOfThisClassVM
    {
        private Class cls;

        public GetSubjectsOfThisClassVM(Class c)
        {
            this.cls = c;
        }

        private ObservableCollection<TeachersToClassesLST> t = new ObservableCollection<TeachersToClassesLST>();

        public ObservableCollection<Subject> GetSubjects()
        {
            TeachersToSubjectsToClassDAL dal = new TeachersToSubjectsToClassDAL();
            t = dal.GetTeachersToSubjectsToClass();

            ObservableCollection<Subject> result = new ObservableCollection<Subject>();

            for(int index=0; index<t.Count(); index++)
            {
                if(t[index].Class.ClassID==cls.ClassID)
                {
                    result.Add(t[index].Subject);
                }
            }

            return result;

            
            
        }

    }
}
