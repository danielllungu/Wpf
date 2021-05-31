using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class TeacherToSubject
    {
        private int? teacher_id;
        public int? TeacherID
        {
            get
            {
                return teacher_id;
            }
            set
            {
                teacher_id = value;
            }
        }

        private int? subject_id;
        public int? SubjectID
        {
            get
            {
                return subject_id;
            }
            set
            {
                subject_id = value;
            }
        }

        private int? cuplaj_id;
        public int? CuplajID
        {
            get
            {
                return cuplaj_id;
            }
            set
            {
                cuplaj_id = value;
            }
        }
    }
}
