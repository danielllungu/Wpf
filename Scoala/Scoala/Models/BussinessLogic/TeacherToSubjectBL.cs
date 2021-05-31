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
    class TeacherToSubjectBL
    {
        Subject subject;

        public TeacherToSubjectBL(Subject s)
        {
            this.subject = s;

        }

        public bool IsTheSubjectStillUsed()
        {
            ObservableCollection<TeacherToSubjectLST> t = new ObservableCollection<TeacherToSubjectLST>();
            TeacherLDDAL dal = new TeacherLDDAL();
            t = dal.GetAllTeacherToSubject();

            for(int index=0; index<t.Count(); index++)
            {
                if(t[index].Subject.Name==subject.Name)
                {
                    return true;
                }

            }

            return false;

        }

    }
}
