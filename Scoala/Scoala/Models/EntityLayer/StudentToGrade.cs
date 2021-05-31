using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class StudentToGrade
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

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        private int? semester;
        public int? Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }

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

    }
}
