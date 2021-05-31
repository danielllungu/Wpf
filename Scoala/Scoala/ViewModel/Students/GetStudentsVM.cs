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
    class GetStudentsVM
    {
        public GetStudentsVM()
        {
            StudentLDDAL std = new StudentLDDAL();
            studentsList = std.GetStudents();
            
        }

        public ObservableCollection<Student> studentsList { get; set; }
    }
}
