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
    class DeleteClassVM
    {
        Class cls;

        public DeleteClassVM(Class c)
        {
            this.cls = c;
        }

        public void Delete()
        {
            ClassDAL dal = new ClassDAL();
            dal.DeleteClass(cls);
        }
    }
}
