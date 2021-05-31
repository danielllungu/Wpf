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
    class InsertSubjectVM
    {
        private string denumire;

        public InsertSubjectVM(string d)
        {
            this.denumire = d;
        }

        public void Add()
        {
            SubjectsDAL dal = new SubjectsDAL();
            dal.InsertSubject(denumire);
        }
    }
}
