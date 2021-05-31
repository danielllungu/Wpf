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

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for TeachersToClassesView.xaml
    /// </summary>
    public partial class TeachersToClassesView : Window
    {
        public TeachersToClassesView()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            listaProfesoriClase.Items.Clear();
            ObservableCollection<TeachersToClassesLST> t = new ObservableCollection<TeachersToClassesLST>();
            GetAllTeachersToClassVM gt = new GetAllTeachersToClassVM();
            t = gt.teachersToClasses;

            for (int index = 0; index < t.Count(); index++)
            {
                listaProfesoriClase.Items.Add(t[index].Teacher.Name + " - " + t[index].Subject.Name + " - " + t[index].Class.ClassNumber.ToString() + t[index].Class.Letter + " - " + t[index].Class.Specialization);

            }
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<TeachersToClassesLST> t = new ObservableCollection<TeachersToClassesLST>();
            GetAllTeachersToClassVM gt = new GetAllTeachersToClassVM();
            t = gt.teachersToClasses;

            if(listaProfesoriClase.SelectedItem!=null)
            {
                DeleteTeacherSubjectToClassVM dlt = new DeleteTeacherSubjectToClassVM(t[listaProfesoriClase.SelectedIndex].TeacherToSubject, t[listaProfesoriClase.SelectedIndex].Class);
                dlt.Delete();
                MessageBox.Show("Cuplajul a fost eliminat!", "Eliminat!");
                Initialize();
                
            }
            
            else
            {
                MessageBox.Show("Selectati un cuplaj!", "Atentie!");
            }
            
        }
    }
}
