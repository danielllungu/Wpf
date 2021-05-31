using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Document
    {
        private byte[] buffer;
        private string extn;
        private int? id;
        

        public int? ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public byte[] Buffer
        {
            get
            {
                return buffer;
            }

            set
            {
                buffer = value;
            }

        }

        public string Extension
        {
            get
            {
                return extn;
            }

            set
            {
                extn = value;
            }
        }

    }
}
