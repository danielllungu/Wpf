using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class MastersToClass
    {
        private Teacher teacher;
        private Class cls;
        private MasterToClass masterToClass;
        private Subject subject;
        private TeacherToSubject teacherToSubject;

        public MastersToClass()
        {
            teacher = new Teacher();
            cls = new Class();
            masterToClass = new MasterToClass();
            subject = new Subject();
            teacherToSubject = new TeacherToSubject();
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

        public MasterToClass MasterToClass
        {
            get
            {
                return masterToClass;
            }
            set
            {
                masterToClass = value;
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


    }
}
