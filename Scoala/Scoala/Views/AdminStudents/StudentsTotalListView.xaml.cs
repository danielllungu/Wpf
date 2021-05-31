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
    /// Interaction logic for StudentsTotalListView.xaml
    /// </summary>
    public partial class StudentsTotalListView : Window
    {
        public StudentsTotalListView()
        {
            InitializeComponent();
            StudentsList();
        }

        private void StudentsList()
        {
            StudentsListVM SL = new StudentsListVM();
            for(int index=0; index<SL.studentsList.Count(); index++)
            {
                lista_totala_studenti.Items.Add(SL.studentsList[index].StudentNume + "\t-\t" + SL.studentsList[index].Specializare + "\t-\t" + SL.studentsList[index].Numar_clasa.ToString() + " " + SL.studentsList[index].Litera);
                
            }
        }
    }
}
