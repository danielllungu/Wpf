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
    class GetClassOfThisStudentVM
    {
        private Student student;

        public GetClassOfThisStudentVM(Student st)
        {
            this.student = st;
        }
        private ObservableCollection<ClassesToStudentsLST> classes = new ObservableCollection<ClassesToStudentsLST>();

        public Class GetClass()
        {
            Class result = new Class();

            ClassDAL dal = new ClassDAL();
            classes = dal.GetAllClassesToStudents();

            for(int index=0; index<classes.Count(); index++)
            {
                if (classes[index].Student.StudentID == student.StudentID)
                    result = classes[index].Class;
            }

            return result;
            
        }
    }
}
