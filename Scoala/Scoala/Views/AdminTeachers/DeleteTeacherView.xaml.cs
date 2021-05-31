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
using Scoala.ViewModel.Teachers;
using Scoala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for DeleteTeacherView.xaml
    /// </summary>
    public partial class DeleteTeacherView : Window
    {
        public DeleteTeacherView()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            listaProfesori.Items.Clear();
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM getAllTeachersVM = new GetAllTeachersVM();
            teachers = getAllTeachersVM.teachersList;

            for (int index = 0; index < teachers.Count(); index++)
            {
                listaProfesori.Items.Add(teachers[index].Name);
            }
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM getAllTeachersVM = new GetAllTeachersVM();
            teachers = getAllTeachersVM.teachersList;

            if(listaProfesori.SelectedItem==null)
            {
                MessageBox.Show("Selectati un profesor!", "Atentie!");
            }
            else
            {
                DeleteTeacherVM deleteTeacherVM = new DeleteTeacherVM(teachers[listaProfesori.SelectedIndex]);
                deleteTeacherVM.DeleteTeacher();
                MessageBox.Show("Toate detaliile despre acest profesor au fost sterse!", "Succes!");
                Initialize();
            }
        }
    }
}
