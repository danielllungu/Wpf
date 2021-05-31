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
    class GetAllMastersToClassVM
    {
        public GetAllMastersToClassVM()
        {
            MastersDAL m = new MastersDAL();
            mastersToClassList = m.GetMastersViewList();
        }

        public ObservableCollection<MastersToClass> mastersToClassList { get; set; }
    }
}
