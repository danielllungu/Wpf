using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class GetAllTeachersVM
    {
        public GetAllTeachersVM()
        {
            
            TeacherLDDAL t = new TeacherLDDAL();
            teachersList = t.GetAllTeachers();

        }

        public ObservableCollection<Teacher> teachersList { get; set; }
    }
}
