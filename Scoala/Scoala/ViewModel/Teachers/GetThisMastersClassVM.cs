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
    
    class GetThisMastersClassVM
    {
        private Teacher teacher;
        private ObservableCollection<MastersToClass> masters = new ObservableCollection<MastersToClass>();

        public GetThisMastersClassVM(Teacher t)
        {
            this.teacher = t;
            MastersDAL mdal = new MastersDAL();
            masters = mdal.GetMastersViewList();
        }

        public Class GetClass()
        {
            Class result = new Class();
            for(int index=0; index<masters.Count(); index++)
            {

                if(masters[index].Teacher.TeacherID==teacher.TeacherID)
                {
                    result = masters[index].Class;
                }
            }
            return result;
        }


    }
}
