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
    class UpdateStudentNameVM
    {
        Student student;
        string name;
        public UpdateStudentNameVM(Student st, string n)
        {
            this.student = st;
            this.name = n;
        }

        public void UpdateStudent()
        {
            StudentLDDAL s = new StudentLDDAL();
            s.UpdateStudentName(student, name);

        }

    }
}
