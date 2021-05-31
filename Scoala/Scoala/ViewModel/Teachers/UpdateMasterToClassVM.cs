using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class UpdateMasterToClassVM
    {
        private Teacher teacher;
        private Class cls;

        public UpdateMasterToClassVM(Teacher t, Class cl)
        {
            this.teacher = t;
            this.cls = cl;

        }

        public void Set()
        {
            MastersDAL m = new MastersDAL();
            
        }
    }
}
