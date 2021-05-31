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
    class GetAllTeacherToSubjectVM
    {
        public GetAllTeacherToSubjectVM()
        {

            TeacherLDDAL t = new TeacherLDDAL();
            teacherToSubject = t.GetAllTeacherToSubject();

        }

        public ObservableCollection<TeacherToSubjectLST> teacherToSubject { get; set; }
    }
}
