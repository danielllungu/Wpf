using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class ClassesToStudentsLST
    {
        Student student;
        Class cls;
        StudentToClass studentToClass;

        public ClassesToStudentsLST()
        {
            student = new Student();
            cls = new Class();
            studentToClass = new StudentToClass();
        }

        public Student Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
            }
        }

        public Class Class
        {
            get
            {
                return cls;
            }

            set
            {
                cls = value;
            }
        }
        public StudentToClass StudentToClass
        {
            get
            {
                return studentToClass;
            }

            set
            {
                studentToClass = value;
            }
        }

    }
}
