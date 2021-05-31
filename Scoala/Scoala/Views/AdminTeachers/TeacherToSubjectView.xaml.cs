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
using Scoala.Models.EntityLayer;
using Scoala.ViewModel.Teachers;
using System.Collections.ObjectModel;
using Scoala.ViewModel.Classes;
using Scoala.ViewModel.Subjects;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for TeacherToSubjectView.xaml
    /// </summary>
    public partial class TeacherToSubjectView : Window
    {
        public TeacherToSubjectView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lista.Items.Clear();
            GetAllTeacherToSubjectVM get = new GetAllTeacherToSubjectVM();
            ObservableCollection<TeacherToSubjectLST> teachersToSubject = new ObservableCollection<TeacherToSubjectLST>();
            teachersToSubject = get.teacherToSubject;

            for(int index=0; index<teachersToSubject.Count(); index++)
            {
                lista.Items.Add(teachersToSubject[index].Teacher.Name + " - " + teachersToSubject[index].Subject.Name);
            }
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            GetAllTeacherToSubjectVM get = new GetAllTeacherToSubjectVM();
            ObservableCollection<TeacherToSubjectLST> teachersToSubject = new ObservableCollection<TeacherToSubjectLST>();
            teachersToSubject = get.teacherToSubject;

            if(lista.SelectedItem!=null)
            {
                DeleteTeacherToSubjectVM dlt = new DeleteTeacherToSubjectVM(teachersToSubject[lista.SelectedIndex].TeacherToSubject);
                dlt.Delete();
                MessageBox.Show("Cuplajul a fost sters!", "Eliminare reusita!");
                Initialize();
            }
            
            else
            {
                MessageBox.Show("Selectati un cuplaj profesor-materie!", "Atentie!");
            }

        }
    }
}
