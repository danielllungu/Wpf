using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.ViewModel.Subjects
{
    class GetAllSubjectsVM
    {
        public GetAllSubjectsVM()
        {

            SubjectsDAL sub = new SubjectsDAL();
            subjectsList = sub.GetAllSubjects();

        }

        public ObservableCollection<Subject> subjectsList { get; set; }
    }
}
