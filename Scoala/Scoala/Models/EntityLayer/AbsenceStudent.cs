using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class AbsenceStudent
    {
        private int? absence_id;
        public int? AbsenceID
        {
            get
            {
                return absence_id;
            }
            set
            {
                absence_id = value;
            }
        }

        private string tip_absenta;
        public string TipAbsenta
        {
            get
            {
                return tip_absenta;
            }
            set
            {
                tip_absenta = value;
            }
        }

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        private int id_cuplaj;
        public int CuplajID
        {
            get
            {
                return id_cuplaj;
            }
            set
            {
                id_cuplaj = value;
            }
        }

        private int student_id;
        public int StudentID
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


    }
}
