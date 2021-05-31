using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;

namespace Scoala.Models.BussinessLogic
{
    class ClassesBL
    {
        private ObservableCollection<Class> classes;
        int nr_clasa;
        string litera;
        string specializare;
        public ClassesBL(int nr_cls, string lit, string spec)
        {
            this.nr_clasa = nr_cls;
            this.litera = lit;
            this.specializare = spec;

            ClassDAL dal = new ClassDAL();
            classes = dal.GetClasses();

        }

        public bool ThisClassAlreadyExists()
        {
            for(int index=0; index<classes.Count(); index++)
            {
                if(classes[index].ClassNumber==nr_clasa && classes[index].Letter==litera)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
