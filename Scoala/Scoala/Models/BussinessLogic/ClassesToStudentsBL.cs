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
    class ClassesToStudentsBL
    {
        private Class cls;

        public ClassesToStudentsBL(Class c)
        {
            this.cls = c;
        }

        public bool IsEmptyClass()
        {
            ObservableCollection<ClassesToStudentsLST> classesToStudentsLST = new ObservableCollection<ClassesToStudentsLST>();
            ClassDAL dal = new ClassDAL();
            classesToStudentsLST = dal.GetAllClassesToStudents();

            for(int index=0; index<classesToStudentsLST.Count(); index++)
            {
                if(classesToStudentsLST[index].Class.ClassID==cls.ClassID)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
