using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;
using Scoala.Models.BussinessLogic;
using System.Collections.ObjectModel;

namespace Scoala.ViewModel.Students
{
    class UpdateStudentToClassVM
    {
        private Student st;
        private Class cls; 
        public UpdateStudentToClassVM(Student student, Class cls)
        {
            this.st = student;
            this.cls = cls;
        }

        public void Update()
        {
            StudentLDDAL studentLDDAL = new StudentLDDAL();
            studentLDDAL.UpdateStudentToClass(st, cls);
        }

    }
}
