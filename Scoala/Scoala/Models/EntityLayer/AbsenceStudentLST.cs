using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class AbsenceStudentLST
    {
        private AbsenceStudent absence;
        public AbsenceStudent AbsenceStudent
        {
            get
            {
                return absence;
            }

            set
            {
                absence = value;
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
