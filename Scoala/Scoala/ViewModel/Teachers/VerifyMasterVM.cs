using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;
using Scoala.Models.BussinessLogic;

namespace Scoala.ViewModel.Teachers
{
    class VerifyMasterVM
    {
        int? idTeacher;
        Teacher teacher;

        public VerifyMasterVM(int? idT)
        {
            this.idTeacher = idT;
            HelpTeacherLoggedInBL bl = new HelpTeacherLoggedInBL(idT);
            teacher = bl.GetTeacher();

        }

        public bool IsMaster()
        {
            ObservableCollection<MastersToClass> masters = new ObservableCollection<MastersToClass>();
            MastersDAL dal = new MastersDAL();
            masters = dal.GetMastersViewList();

            bool found = false;
            for(int index=0; index<masters.Count(); index++)
            {
                if(masters[index].Teacher.TeacherID==teacher.TeacherID)
                {
                    found = true;
                }
            }
            return found;
        }
    }
}
