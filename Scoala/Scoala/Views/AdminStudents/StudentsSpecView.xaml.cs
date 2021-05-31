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
    /// Interaction logic for StudentsSpecView.xaml
    /// </summary>
    public partial class StudentsSpecView : Window
    {
        public StudentsSpecView()
        {
            InitializeComponent();
            StudentsOrganized();
        }

        public bool IsKey(Dictionary<string, string> org, string key)
        {
            for (int index = 0; index < org.Count(); index++)
            {
                if (key == org.ElementAt(index).Key)
                    return true;
            }
            return false;
        }
        public void StudentsOrganized()
        {
            int it = 0;
            var org = new Dictionary<string, string>();

            StudentsListVM sl = new StudentsListVM();
            for (int index = 0; index < sl.studentsList.Count(); index++)
            {
                if (IsKey(org, sl.studentsList[index].Specializare))
                {
                    if(it<10)
                    {
                        org[sl.studentsList[index].Specializare] += sl.studentsList[index].StudentNume + "; ";
                    }
                    else
                    {
                        org[sl.studentsList[index].Specializare] += sl.studentsList[index].StudentNume + "\n";
                        it = 0;
                    }
                    it++;
                    
                }
                else
                {
                    if(it<10)
                    {
                        org.Add(sl.studentsList[index].Specializare, sl.studentsList[index].StudentNume + "; ");

                    }
                    else
                    {
                        org.Add(sl.studentsList[index].Specializare, sl.studentsList[index].StudentNume + "\n");
                        it = 0;
                    }
                    it++;
                    
                }
            }

            for (int index = 0; index < org.Count(); index++)
            {
                lista.Items.Add(org.ElementAt(index).Key);
                lista.Items.Add(org.ElementAt(index).Value);
                lista.Items.Add("\n");
            }
        }
    }
}
