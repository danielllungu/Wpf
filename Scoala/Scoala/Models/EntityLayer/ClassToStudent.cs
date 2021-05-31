using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class ClassToStudent
    {
        
        private int? student_id;
        public int? StudentID
        {
            get
            {
                return student_id;
            }
            set
            {
                student_id = value;
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
