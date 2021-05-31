using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class SetMasterToClassVM
    {
        private Teacher teacher;
        private Class cls;

        public SetMasterToClassVM(Teacher t, Class cl)
        {
            this.teacher = t;
            this.cls = cl;

        }

        public void Set()
        {
            MastersDAL m = new MastersDAL();
            m.SetMastersToClass(teacher, cls);
        }

    }
}
