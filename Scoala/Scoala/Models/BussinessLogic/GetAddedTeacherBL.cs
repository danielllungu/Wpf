using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;

namespace Scoala.Models.BussinessLogic
{
    class GetAddedTeacherBL
    {
        private ObservableCollection<Teacher> t = new ObservableCollection<Teacher>();

        public GetAddedTeacherBL()
        {
            TeacherLDDAL dal = new TeacherLDDAL();
            t = dal.GetAllTeachers();
        }

        public Teacher GetTeacher()
        {
            return t[t.Count() - 1];
        }

    }
}
