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
    class GetStudentsFromThisClassVM
    {
        private Class cls;
        public GetStudentsFromThisClassVM(Class c)
        {
            this.cls = c;
            ClassDAL dal = new ClassDAL();
            classesToStudents = dal.GetAllClassesToStudents();
        }

        public ObservableCollection<ClassesToStudentsLST> classesToStudents = new ObservableCollection<ClassesToStudentsLST>();
        
        public ObservableCollection<Student> GetStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            for(int index=0; index<classesToStudents.Count(); index++)
            {
                if (classesToStudents[index].Class.ClassID == cls.ClassID)
                    students.Add(classesToStudents[index].Student);
            }

            return students;
        }

    }
}
