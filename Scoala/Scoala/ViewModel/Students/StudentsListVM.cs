using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.Lists;

namespace Scoala.ViewModel.Students
{
    class StudentsListVM
    {
        public StudentsListVM()
        {
            TotalListStudentsDAL totalListStudents = new TotalListStudentsDAL();
            studentsList = totalListStudents.GetAllStudentsList();
        }
         
        public ObservableCollection<StudentsList> studentsList { get; set; }

        
    }
}
