using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class TeacherToSubjectToClass
    {
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
