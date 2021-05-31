using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Grade
    {
        private int? grade_id;
        public int? GradeID
        {
            get
            {
                return grade_id;
            }
            set
            {
                grade_id = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        private int? gradevalue;
        public int? GradeValue
        {
            get
            {
                return gradevalue;
            }
            set
            {
                gradevalue = value;
            }
        }


    }
}
