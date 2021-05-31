using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class UpdateTeacherVM
    {
        private Teacher teacher;
        private string name;
        private string phone;

        public UpdateTeacherVM(Teacher t, string n, string ph)
        {
            this.teacher = t;
            this.name = n;
            this.phone = ph;
        }

        public void UpdateTeacher()
        {
            TeacherLDDAL t = new TeacherLDDAL();
            t.UpdateTeacher(teacher, name, phone);
        }

    }
}
