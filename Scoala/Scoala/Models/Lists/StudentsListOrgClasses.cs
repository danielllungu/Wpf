using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.Lists
{
    class StudentsListOrgClasses
    {
        private string student_nume;
        public string StudentNume
        {
            get
            {
                return student_nume;
            }
            set
            {
                student_nume = value;
            }
        }

        private string specializare;
        public string Specializare
        {
            get
            {
                return specializare;
            }
            set
            {
                specializare = value;
            }
        }

        private int numar_clasa;
        public int Numar_clasa
        {
            get
            {
                return numar_clasa;
            }
            set
            {
                numar_clasa = value;
            }
        }

        private string litera;
        public string Litera
        {
            get
            {
                return litera;
            }
            set
            {
                litera = value;
            }
        }
    }
}
