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
    class AllClasses
    {
        public AllClasses()
        {
            ClassDAL allClasses = new ClassDAL();
            classesList = allClasses.GetClasses();
        }

        public ObservableCollection<Class> classesList { get; set; }
    }
}
