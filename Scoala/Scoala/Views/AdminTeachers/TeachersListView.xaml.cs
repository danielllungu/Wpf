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
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;
using Scoala.ViewModel.Teachers;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for TeachersListView.xaml
    /// </summary>
    public partial class TeachersListView : Window
    {
        public TeachersListView()
        {
            InitializeComponent();
            GetList();
        }

        public void GetList()
        {
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM getAllTeachersVM = new GetAllTeachersVM();
            teachers = getAllTeachersVM.teachersList;

            for(int index=0; index<teachers.Count(); index++)
            {
                if(teachers[index].Name.Length<=9)
                    listaProfesori.Items.Add("Nume: " + teachers[index].Name + "\t\t\tTelefon: " + teachers[index].Phone);
                else
                    listaProfesori.Items.Add("Nume: " + teachers[index].Name + "\t\tTelefon: " + teachers[index].Phone);
            }
        }
    }
}
