using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class StudentsToGradesLST
    {
        private Student student;
        private Grade grade;
        private StudentToGrade studentToGrade;

        public StudentsToGradesLST()
        {
            student = new Student();
            grade = new Grade();
            studentToGrade = new StudentToGrade();
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

        public Grade Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }

        public StudentToGrade StudentToGrade
        {
            get
            {
                return studentToGrade;
            }

            set
            {
                studentToGrade = value;
            }
        }
        

    }
}
