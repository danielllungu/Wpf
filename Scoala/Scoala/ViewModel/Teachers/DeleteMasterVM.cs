using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;
namespace Scoala.ViewModel.Teachers
{
    class DeleteMasterVM
    {
        private MasterToClass master;
        public DeleteMasterVM(MasterToClass m)
        {
            this.master = m;
        }

        public void Delete()
        {
            MastersDAL dal = new MastersDAL();
            dal.DeleteMaster(master);
        }

    }
}
