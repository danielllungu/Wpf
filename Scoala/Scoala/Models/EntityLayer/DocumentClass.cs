using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class DocumentClass
    {
        private Class cls;
        private Document document;

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

        public Document Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }
    }
}
