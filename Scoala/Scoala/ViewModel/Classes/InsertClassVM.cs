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
    class InsertClassVM
    {
        private int numar_clasa;
        private string litera;
        private string specializare;

        public InsertClassVM(int nr_cls, string lit, string spec)
        {
            this.numar_clasa = nr_cls;
            this.litera = lit;
            this.specializare = spec;
        }

        public void Add()
        {
            ClassDAL dal = new ClassDAL();
            dal.AddClass(numar_clasa, litera, specializare);
        }
    }
}
