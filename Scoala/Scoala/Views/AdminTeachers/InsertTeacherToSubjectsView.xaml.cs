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
using Scoala.ViewModel.Subjects;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for InsertTeacherToSubjectsView.xaml
    /// </summary>
    public partial class InsertTeacherToSubjectsView : Window
    {
        public InsertTeacherToSubjectsView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            GetAllTeachersVM gt = new GetAllTeachersVM();
            ObservableCollection<Teacher> t = new ObservableCollection<Teacher>();
            t = gt.teachersList;

            for(int index=0; index<t.Count(); index++)
            {
                listaProfesori.Items.Add(t[index].Name);
            }

            GetAllSubjectsVM gs = new GetAllSubjectsVM();
            ObservableCollection<Subject> s = new ObservableCollection<Subject>();
            s = gs.subjectsList;

            for(int index=0; index<s.Count(); index++)
            {
                listaMaterii.Items.Add(s[index].Name);
            }


        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            GetAllTeachersVM gt = new GetAllTeachersVM();
            ObservableCollection<Teacher> t = new ObservableCollection<Teacher>();
            t = gt.teachersList;

            GetAllSubjectsVM gs = new GetAllSubjectsVM();
            ObservableCollection<Subject> s = new ObservableCollection<Subject>();
            s = gs.subjectsList;

            if(listaProfesori.SelectedItem!=null && listaMaterii.SelectedItem!=null)
            {
                InsertTeacherToSubject insert = new InsertTeacherToSubject(t[listaProfesori.SelectedIndex], s[listaMaterii.SelectedIndex]);
                insert.Add();
                MessageBox.Show("Atribuirea s-a efectuat cu succes!", "Adaugat!");
            }

            else
            {
                MessageBox.Show("Selectati un profesor si o materie!", "Atentie!");
            }

        }
    }
}
