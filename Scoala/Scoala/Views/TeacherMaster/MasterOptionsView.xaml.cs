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

namespace Scoala.Views.TeacherMaster
{
    /// <summary>
    /// Interaction logic for MasterOptionsView.xaml
    /// </summary>
    public partial class MasterOptionsView : Window
    {
        int? idT;
        Teacher teacher;
        public MasterOptionsView(int? id)
        {
            InitializeComponent();
            this.idT = id;
            Initialize();
        }

        private void Initialize()
        {
            HelpTeacherLoggedInBL bl = new HelpTeacherLoggedInBL(idT);
            teacher = bl.GetTeacher();
            Class cls = new Class();
            GetThisMastersClassVM getClass = new GetThisMastersClassVM(teacher);
            cls = getClass.GetClass();
            clase.Items.Add(cls.ClassNumber.ToString() + cls.Letter + " - " + cls.Specialization);

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(cls);
            students = getstudents.GetStudents();

            for(int index=0; index<students.Count(); index++)
            {
                elevi.Items.Add(students[index].Name);
            }

            absente_elev.Text = "0";
            absente_clasa.Text = "0";
            AllAbsences();
        }

        private void AllAbsences()
        {
            Class cls = new Class();
            GetThisMastersClassVM getClass = new GetThisMastersClassVM(teacher);
            cls = getClass.GetClass();


            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(cls);
            students = getstudents.GetStudents();
            int nr_toate_absentele = 0;

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            ObservableCollection<ObservableCollection<AbsenceStudentLST>> all_absences = new ObservableCollection<ObservableCollection<AbsenceStudentLST>>();

            for(int s=0; s<students.Count(); s++)
            {
                for (int index = 0; index < subjects.Count(); index++)
                {
                    ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
                    GetAbsenceStudentLSTVM getAbsences = new GetAbsenceStudentLSTVM(students[s], subjects[index], teacher);
                    absences = getAbsences.GetAbsences();
                    if (absences.Count() != 0)
                    {
                        nr_toate_absentele += 1;
                        all_absences.Add(absences);
                    }

                }
            }

            absente_clasa.Text = nr_toate_absentele.ToString();



        }
        private void RefreshAbsences()
        {
            absente.Items.Clear();
            Class cls = new Class();
            GetThisMastersClassVM getClass = new GetThisMastersClassVM(teacher);
            cls = getClass.GetClass();


            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(cls);
            students = getstudents.GetStudents();
            
            
            if (elevi.SelectedItem != null)
            {
                ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
                GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
                subjects = get.GetSubjects();

                ObservableCollection<ObservableCollection<AbsenceStudentLST>> all_absences = new ObservableCollection<ObservableCollection<AbsenceStudentLST>>();

                for (int index = 0; index < subjects.Count(); index++)
                {
                    ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
                    GetAbsenceStudentLSTVM getAbsences = new GetAbsenceStudentLSTVM(students[elevi.SelectedIndex], subjects[index], teacher);
                    absences = getAbsences.GetAbsences();
                    if (absences.Count() != 0)
                    {
                        all_absences.Add(absences);
                    }

                }

                int nr_absente_elev = 0;

                for (int index = 0; index < all_absences.Count(); index++)
                {
                    for (int i = 0; i < all_absences[index].Count(); i++)
                    {
                        nr_absente_elev += 1;
                        absente.Items.Add(all_absences[index][i].AbsenceStudent.TipAbsenta + " ; " + all_absences[index][i].AbsenceStudent.Data);
                    }
                }

                absente_elev.Text = nr_absente_elev.ToString();
            }

            AllAbsences();
        }

        private void forward_elevi_absente_Click(object sender, RoutedEventArgs e)
        {
            RefreshAbsences();
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            Class cls = new Class();
            GetThisMastersClassVM getClass = new GetThisMastersClassVM(teacher);
            cls = getClass.GetClass();

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(cls);
            students = getstudents.GetStudents();

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            ObservableCollection<AbsenceStudentLST> all_absences = new ObservableCollection<AbsenceStudentLST>();

            for (int index = 0; index < subjects.Count(); index++)
            {
                ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
                GetAbsenceStudentLSTVM getAbsences = new GetAbsenceStudentLSTVM(students[elevi.SelectedIndex], subjects[index], teacher);
                absences = getAbsences.GetAbsences();
                for(int i=0; i<absences.Count(); i++)
                {
                    all_absences.Add(absences[i]);
                }

            }

            if (absente.SelectedItem!=null)
            {
                if(all_absences[absente.SelectedIndex].AbsenceStudent.TipAbsenta!="nemotivabila")
                {
                    DeleteAbsenceVM dlt = new DeleteAbsenceVM(all_absences[absente.SelectedIndex].AbsenceStudent);
                    dlt.Delete();
                    RefreshAbsences();
                    MessageBox.Show("Absetnta a fost motivata!", "Succes!");
                }

                else
                {
                    MessageBox.Show("Aceasta absenta nemotivabila nu poate fi stearsa!", "Atentie!");
                }
            }
        }
    }
}
