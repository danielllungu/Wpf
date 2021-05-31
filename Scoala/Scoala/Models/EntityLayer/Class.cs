using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Class
    {
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

        private int class_number;
        public int ClassNumber
        {
            get
            {
                return class_number;
            }
            set
            {
                class_number = value;
            }
        }

        private string letter;
        public string Letter
        {
            get
            {
                return letter;
            }
            set
            {
                letter = value;
            }
        }

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
            }
        }

    }
}
