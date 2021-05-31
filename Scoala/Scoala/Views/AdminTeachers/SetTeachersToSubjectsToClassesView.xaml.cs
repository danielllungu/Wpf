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
    /// Interaction logic for SetTeachersToSubjectsToClassesView.xaml
    /// </summary>
    public partial class SetTeachersToSubjectsToClassesView : Window
    {
        public SetTeachersToSubjectsToClassesView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            GetAllTeacherToSubjectVM get = new GetAllTeacherToSubjectVM();
            ObservableCollection<TeacherToSubjectLST> teachersToSubject = new ObservableCollection<TeacherToSubjectLST>();
            teachersToSubject = get.teacherToSubject;

            for (int index = 0; index < teachersToSubject.Count(); index++)
            {
                lista.Items.Add(teachersToSubject[index].Teacher.Name + " - " + teachersToSubject[index].Subject.Name);
            }

            AllClasses allclasses = new AllClasses();
            ObservableCollection<Class> cls = new ObservableCollection<Class>();
            cls = allclasses.classesList;

            for(int index=0; index<cls.Count(); index++)
            {
                listaClase.Items.Add(cls[index].ClassNumber.ToString() + cls[index].Letter + " - " + cls[index].Specialization);
            }

        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            GetAllTeacherToSubjectVM get = new GetAllTeacherToSubjectVM();
            ObservableCollection<TeacherToSubjectLST> teachersToSubject = new ObservableCollection<TeacherToSubjectLST>();
            teachersToSubject = get.teacherToSubject;

            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            AllClasses cls = new AllClasses();
            classes = cls.classesList;

            if(lista.SelectedItem!=null && listaClase.SelectedItem!=null)
            {
                InsertTeacherSubjectToClassVM insert = new InsertTeacherSubjectToClassVM(teachersToSubject[lista.SelectedIndex].TeacherToSubject, classes[listaClase.SelectedIndex]);
                insert.Insert();
                MessageBox.Show("Cuplaj adaugat!", "Succes!");
            }

            else
            {
                MessageBox.Show("Faceti o selectie!", "Atentie!");
            }




        }
    }
}
