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
using Scoala.Models.BussinessLogic;
using Scoala.Models.EntityLayer;
using Scoala.Views.TeacherGrades;
using Scoala.Views.TeacherAbsences;
using Scoala.Views.TeacherMaster;
using Scoala.ViewModel.Teachers;
using System.Collections.ObjectModel;
using Scoala.ViewModel.Grades;
using Scoala.ViewModel.Classes;
using Scoala.ViewModel.Subjects;
using Scoala.ViewModel.Absences;

namespace Scoala.Views.StudentAbsences
{
    /// <summary>
    /// Interaction logic for MyAbsences.xaml
    /// </summary>
    public partial class MyAbsences : Window
    {

        int? idS;
        public MyAbsences(int? id)
        {
            this.idS = id;
            InitializeComponent();
            Initialize();
        }


        public void Initialize()
        {
            HelpStudentLoggedInBL hlp = new HelpStudentLoggedInBL(idS);
            Student s = new Student();
            s = hlp.GetStudent();


            Class myclass = new Class();
            GetClassOfThisStudentVM get_class = new GetClassOfThisStudentVM(s);
            myclass = get_class.GetClass();

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsOfThisClassVM get_subjects = new GetSubjectsOfThisClassVM(myclass);
            subjects = get_subjects.GetSubjects();

            for (int index = 0; index < subjects.Count(); index++)
            {
                materii.Items.Add(subjects[index].Name);
            }



        }

        private void forward_materii_absente_Click(object sender, RoutedEventArgs e)
        {
            absente.Items.Clear();
            HelpStudentLoggedInBL hlp = new HelpStudentLoggedInBL(idS);
            Student s = new Student();
            s = hlp.GetStudent();

            Class myclass = new Class();
            GetClassOfThisStudentVM get_class = new GetClassOfThisStudentVM(s);
            myclass = get_class.GetClass();

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsOfThisClassVM get_subjects = new GetSubjectsOfThisClassVM(myclass);
            subjects = get_subjects.GetSubjects();
            int nr_abs_motivabile = 0;
            int nr_abs_nemotivabile = 0;
            if(materii.SelectedItem!=null)
            {
                GetAbsencesOfThisStudent get_abs = new GetAbsencesOfThisStudent(s, subjects[materii.SelectedIndex]);
                ObservableCollection<AbsenceStudentLST> absences = new ObservableCollection<AbsenceStudentLST>();
                absences = get_abs.GetAbsences();

                for(int index=0; index<absences.Count(); index++)
                {
                    absente.Items.Add("abs: " + absences[index].AbsenceStudent.TipAbsenta + " ; data: " + absences[index].AbsenceStudent.Data);
                    if(absences[index].AbsenceStudent.TipAbsenta=="motivabila")
                    {
                        nr_abs_motivabile += 1;
                    }
                    else
                    {
                        nr_abs_nemotivabile += 1;
                    }
                }
            }

            absente_motivabile.Text = nr_abs_motivabile.ToString();
            absente_nemotivabile.Text = nr_abs_nemotivabile.ToString();
            

            
        }
    }
}
