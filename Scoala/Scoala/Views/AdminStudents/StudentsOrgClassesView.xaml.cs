using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Scoala.ViewModel.Students;

namespace Scoala.Views.AdminStudents
{
    /// <summary>
    /// Interaction logic for StudentsOrgClassesView.xaml
    /// </summary>
    public partial class StudentsOrgClassesView : Window
    {
        public StudentsOrgClassesView()
        {
            InitializeComponent();
            StudentsOrganized();
        }


        public bool IsKey(Dictionary<string, string> org, string key)
        {
            for(int index=0; index<org.Count(); index++)
            {
                if (key == org.ElementAt(index).Key)
                    return true;
            }
            return false;
        }
        public void StudentsOrganized()
        {
            var org = new Dictionary<string, string>();
            int it = 0;
            StudentsListVM sl = new StudentsListVM();
            for (int index=0; index<sl.studentsList.Count(); index++)
            {
                if(IsKey(org, sl.studentsList[index].Numar_clasa.ToString() + sl.studentsList[index].Litera))
                {
                    if (it < 10)
                    {
                        org[sl.studentsList[index].Numar_clasa.ToString() + sl.studentsList[index].Litera] += sl.studentsList[index].StudentNume + "; ";

                    }
                    else
                        org[sl.studentsList[index].Numar_clasa.ToString() + sl.studentsList[index].Litera] += sl.studentsList[index].StudentNume + "\n";

                }
                else
                {
                    if(it<10)
                    {
                        org.Add(sl.studentsList[index].Numar_clasa.ToString() + sl.studentsList[index].Litera, sl.studentsList[index].StudentNume + "; ");

                    }
                    else
                    {
                        org.Add(sl.studentsList[index].Numar_clasa.ToString() + sl.studentsList[index].Litera, sl.studentsList[index].StudentNume + "\n");
                    }
                    
                }
            }

            for(int index=0; index<org.Count(); index++)
            {
                lista.Items.Add(org.ElementAt(index).Key);
                lista.Items.Add(org.ElementAt(index).Value);
            }
        }
    }
}
