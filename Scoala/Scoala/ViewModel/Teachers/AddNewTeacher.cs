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
    class AddNewTeacher
    {
        private string name;
        private string phone;
        public AddNewTeacher(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void AddTeacher()
        {
            TeacherLDDAL t = new TeacherLDDAL();
            t.AddTeacher(name, phone);
            AddTeacherLD add = new AddTeacherLD();
            add.AddLDTeacher();
        }

    }
}
