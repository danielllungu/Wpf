using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class MasterToClass
    {

        private int? master_id;
        public int? MasterID
        {
            get
            {
                return master_id;
            }
            set
            {
                master_id = value;
            }
        }

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

        private int? class_id;
        public int? ClassID
        {
            get
            {
                return class_id;
            }
            set
            {
                class_id = value;
            }
        }
    }
}
