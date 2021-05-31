using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataAccess;
using System.Collections.ObjectModel;
using Scoala.Models.LoginDetails;

namespace Scoala.Models.BussinessLogic
{
    class HelpTeacherLoggedInBL
    {
        private int? idTeacher;

        public HelpTeacherLoggedInBL(int? id)
        {
            this.idTeacher = id;
        }

        public Teacher GetTeacher()
        {
            TeacherLDDAL dal = new TeacherLDDAL();
            ObservableCollection<Teacher> t = new ObservableCollection<Teacher>();
            t = dal.GetAllTeachers();
            ObservableCollection<TeacherLD> tLD = new ObservableCollection<TeacherLD>();
            tLD = dal.GetTeachersLoginDetails();

            for(int index=0; index<tLD.Count(); index++)
            {
                if(tLD[index].TeacherID==idTeacher)
                {
                    for (int i = 0; i < t.Count(); i++)
                    {
                        if (idTeacher == t[i].TeacherID)
                            return t[i];
                    }
                }
            }

            

            return null;
        }


    }
}
