using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class DeleteAndAddMasterToClass
    {
        private Teacher teacher;
        private Class cls;

        public DeleteAndAddMasterToClass(Teacher t, Class cl)
        {
            this.teacher = t;
            this.cls = cl;

        }

        public void Set()
        {
            MastersDAL m = new MastersDAL();
            m.DeleteAndAddMasterToClass(teacher, cls);
        }
    }
}
