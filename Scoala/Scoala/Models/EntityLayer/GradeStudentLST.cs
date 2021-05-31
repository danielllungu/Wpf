using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class GradeStudentLST
    {
        private GradeStudent gradeStudent;

        public GradeStudent GradeStudent
        {
            get
            {
                return gradeStudent;
            }
            set
            {
                gradeStudent = value;
            }
        }
        private Student student;

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
        private TeacherToSubject teacherToSubject;
        public TeacherToSubject TeacherToSubject
        {
            get
            {
                return teacherToSubject;
            }

            set
            {
                teacherToSubject = value;
            }
        }
    }
}
