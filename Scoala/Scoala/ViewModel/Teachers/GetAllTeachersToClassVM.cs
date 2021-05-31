using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class GetAllTeachersToClassVM
    {
        public GetAllTeachersToClassVM()
        {
            TeachersToSubjectsToClassDAL t = new TeachersToSubjectsToClassDAL();
            teachersToClasses = t.GetTeachersToSubjectsToClass();

        }
        public ObservableCollection<TeachersToClassesLST> teachersToClasses = new ObservableCollection<TeachersToClassesLST>();
    }
}
