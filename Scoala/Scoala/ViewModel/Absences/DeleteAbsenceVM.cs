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
    class DeleteAbsenceVM
    {
        private AbsenceStudent absenceStudent;

        public DeleteAbsenceVM(AbsenceStudent abs)
        {
            this.absenceStudent = abs;
        }

        public void Delete()
        {
            AbsenceDAL dal = new AbsenceDAL();
            dal.DeleteAbsence(absenceStudent);
        }
    }
}
