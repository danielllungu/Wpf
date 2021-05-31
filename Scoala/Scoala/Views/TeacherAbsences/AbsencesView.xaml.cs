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
using Scoala.ViewModel.Classes;
using Scoala.ViewModel.Students;
using Scoala.ViewModel.Subjects;
using Scoala.ViewModel.Grades;
using Scoala.ViewModel.Teachers;
using System.Collections.ObjectModel;
using Scoala.Models.BussinessLogic;
using Scoala.ViewModel.Absences;

namespace Scoala.Views.TeacherAbsences
{
    /// <summary>
    /// Interaction logic for AbsencesView.xaml
    /// </summary>
    public partial class AbsencesView : Window
    {
        int? idT;
        Teacher teacher;
        public AbsencesView(int? id)
        {
            InitializeComponent();
            this.idT = id;
            Initialize();
        }

        private void Initialize()
        {
            materii.Items.Clear();
            HelpTeacherLoggedInBL bl = new HelpTeacherLoggedInBL(idT);
            teacher = bl.GetTeacher();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            for (int index = 0; index < subjects.Count(); index++)
            {
                materii.Items.Add(subjects[index].Name);
            }

            tip_absenta.Items.Add("motivabila");
            tip_absenta.Items.Add("nemotivabila");

        }

        private void forward_materii_clase_Click(object sender, RoutedEventArgs e)
        {
            clase.Items.Clear();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();



            if (materii.SelectedItem != null)
            {
                ObservableCollection<Class> classes = new ObservableCollection<Class>();
                GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
                classes = getClasses.GetClasses();

                for (int index = 0; index < classes.Count(); index++)
                {
                    clase.Items.Add(classes[index].ClassNumber.ToString() + classes[index].Letter + " - " + classes[index].Specialization);

                }
            }
        }

        private void forward_clase_elevi_Click(object sender, RoutedEventArgs e)
        {
            elevi.Items.Clear();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            if (materii.SelectedItem != null)
            {
                ObservableCollection<Class> classes = new ObservableCollection<Class>();
                GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
                classes = getClasses.GetClasses();
                if (clase.SelectedItem != null)
                {
                    ObservableCollection<Student> students = new ObservableCollection<Student>();
                    GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(classes[clase.SelectedIndex]);
                    students = getstudents.GetStudents();

                    for (int index = 0; index < students.Count(); index++)
                    {
                        elevi.Items.Add(students[index].Name);
                    }
                }
            }

        }

        private void RefreshAbsences()
        {
            absente.Items.Clear();

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
            classes = getClasses.GetClasses();

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(classes[clase.SelectedIndex]);
            students = getstudents.GetStudents();

            if(elevi.SelectedItem!=null)
            {
                ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
                GetAbsenceStudentLSTVM getAbsences = new GetAbsenceStudentLSTVM(students[elevi.SelectedIndex], subjects[materii.SelectedIndex], teacher);
                absences = getAbsences.GetAbsences();
                for(int index=0; index<absences.Count(); index++)
                {
                    absente.Items.Add("Abs: "+absences[index].AbsenceStudent.TipAbsenta + " Data: " + absences[index].AbsenceStudent.Data);
                }
            }
            

            
        }

        private void forward_elevi_absente_Click(object sender, RoutedEventArgs e)
        {
            RefreshAbsences();
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
            classes = getClasses.GetClasses();


            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(classes[clase.SelectedIndex]);
            students = getstudents.GetStudents();

            if(tip_absenta.SelectedItem!=null && data.Text!="")
            {
                InsertAbsence insertAbsence = new InsertAbsence(students[elevi.SelectedIndex], teacher, subjects[materii.SelectedIndex], data.Text, tip_absenta.Text);
                insertAbsence.Insert();
                RefreshAbsences();
                MessageBox.Show("Absenta adaugata!", "Succes!");
            }
        }
    }
}
