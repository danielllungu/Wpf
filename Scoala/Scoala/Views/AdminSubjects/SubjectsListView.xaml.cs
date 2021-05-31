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
using Scoala.ViewModel.Subjects;
using System.Collections.ObjectModel;
using Scoala.Models.BussinessLogic;

namespace Scoala.Views.AdminSubjects
{
    /// <summary>
    /// Interaction logic for SubjectsListView.xaml
    /// </summary>
    public partial class SubjectsListView : Window
    {
        public SubjectsListView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lista.Items.Clear();
            GetAllSubjectsVM getSubjects = new GetAllSubjectsVM();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            subjects = getSubjects.subjectsList;

            for(int index=0; index<subjects.Count(); index++)
            {
                lista.Items.Add(subjects[index].Name);
            }

        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            GetAllSubjectsVM getSubjects = new GetAllSubjectsVM();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            subjects = getSubjects.subjectsList;

            if(lista.SelectedItem!=null)
            {
                TeacherToSubjectBL bl = new TeacherToSubjectBL(subjects[lista.SelectedIndex]);
                if(bl.IsTheSubjectStillUsed())
                {
                    MessageBox.Show("Materia selectata inca este predata de profesori.", "Atentie!");
                    
                }

                else
                {
                    DeleteSubjectVM dltSubject = new DeleteSubjectVM(subjects[lista.SelectedIndex]);
                    dltSubject.Delete();
                    MessageBox.Show("Materia a fost eliminata!", "Eliminat!");
                    Initialize();
                }
            }

            else
            {
                MessageBox.Show("Faceti o selectie!", "Atentie!");
            }
                


        }
    }
}
