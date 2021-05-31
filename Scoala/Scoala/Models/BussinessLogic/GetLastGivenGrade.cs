using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;

namespace Scoala.Models.BussinessLogic
{
    class GetLastGivenGrade
    {
        public ObservableCollection<Grade> g = new ObservableCollection<Grade>();
        public GetLastGivenGrade()
        {
            
            GradesDAL dal = new GradesDAL();
            g = dal.GetGrades();

        }
        public Grade GetGrade()
        {
            return g[g.Count() - 1];
        }

    }
}
