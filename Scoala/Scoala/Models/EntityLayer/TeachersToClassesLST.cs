using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class TeachersToClassesLST
    {
        private TeacherToSubject teacherToSubject;
        private TeacherToSubjectToClass teacherToSubjectToClass;
        private Subject subject;
        private Teacher teacher;
        private Class cls;

        public TeachersToClassesLST()
        {
            teacherToSubject = new TeacherToSubject();
            teacherToSubjectToClass = new TeacherToSubjectToClass();
            teacher = new Teacher();
            subject = new Subject();
            cls = new Class();
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

        public TeacherToSubjectToClass TeacherToSubjectToClass
        {
            get
            {
                return teacherToSubjectToClass;
            }

            set
            {
                teacherToSubjectToClass = value;
            }
        }
    }
}
