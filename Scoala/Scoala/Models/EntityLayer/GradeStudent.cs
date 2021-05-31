using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class GradeStudent
    {
        private int? id_nota;
        public int? GradeID
        {
            get
            {
                return id_nota;
            }

            set
            {
                id_nota = value;
            }
        }

        private int nota;
        public int Grade
        {
            get
            {
                return nota;
            }
            set
            {
                nota = value;
            }
        }

        private int? id_elev;
        public int? StudentID
        {
            get
            {
                return id_elev;
            }

            set
            {
                id_elev = value;
            }
        }

        private int? id_cuplaj;
        public int? CuplajID
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
        private string tip_nota;

        public string TipNota
        {
            get
            {
                return tip_nota;
            }

            set
            {
                tip_nota = value;
            }
        }

        private int semestru;

        public int Semsestru
        {
            get
            {
                return semestru;
            }
            set
            {
                semestru = value;
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

    }
}
