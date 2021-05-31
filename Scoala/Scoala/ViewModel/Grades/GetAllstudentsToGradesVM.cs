using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Grades
{
    class GetAllstudentsToGradesVM
    {
        public GetAllstudentsToGradesVM()
        {
            GradesDAL dal = new GradesDAL();
            studentsToGrades = dal.GetAllStudentsToGrades();

        }

        public ObservableCollection<StudentsToGradesLST> studentsToGrades = new ObservableCollection<StudentsToGradesLST>();
    }
}
