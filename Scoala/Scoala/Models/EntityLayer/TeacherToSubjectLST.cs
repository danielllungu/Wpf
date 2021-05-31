using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class TeacherToSubjectLST
    {
        Teacher teacher;
        Subject subject;
        TeacherToSubject teacherToSubject;

        public TeacherToSubjectLST()
        {
            teacher = new Teacher();
            subject = new Subject();
            teacherToSubject = new TeacherToSubject();
        }

        public Subject Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }


        public Teacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
            }
        }

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
