using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Teachers
{
    class GetTeacherToSubjectsVM
    {
        public GetTeacherToSubjectsVM()
        {

            TeacherLDDAL t = new TeacherLDDAL();
            tList = t.GetTeacherToSubject();

        }

        public ObservableCollection<TeacherToSubject> tList { get; set; }
    }
}
