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
    class DeleteSubjectVM
    {
        private Subject subject;

        public DeleteSubjectVM(Subject s)
        {
            this.subject = s;
        }

        public void Delete()
        {
            SubjectsDAL dal = new SubjectsDAL();
            dal.DeleteSubject(subject);
        }
    }
}
