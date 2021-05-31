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

namespace Scoala.Views.StudentGrades
{
    /// <summary>
    /// Interaction logic for MyGradesView.xaml
    /// </summary>
    public partial class MyGradesView : Window
    {
        int? idS;
        public MyGradesView(int? id)
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

            for(int index=0; index<subjects.Count(); index++)
            {
                materii.Items.Add(subjects[index].Name);
            }



        }

        private int Medie(ObservableCollection<GradeStudentLST> grades)
        {
            int suma = 0;
            int nr = 0;
            int m = 0;
            int teza = 0;
            bool incheiat = false;
            for(int index=0; index<grades.Count(); index++)
            {
                if(grades[index].GradeStudent.TipNota=="Medie incheiata")
                {
                    incheiat = true;
                    m = grades[index].GradeStudent.Grade;
                }

                else
                {
                    if(grades[index].GradeStudent.TipNota=="test")
                    {
                        suma += grades[index].GradeStudent.Grade;
                        nr += 1;
                    }

                    else if(grades[index].GradeStudent.TipNota=="teza")
                    {
                        teza = grades[index].GradeStudent.Grade;
                    }
                }

            }

            if(incheiat==true)
            {
                return m;
            }

            else
            {
                if(nr>=1)
                {
                    if (teza != 0)
                    {
                        float medieNote = (float)(suma / nr);
                        m = ((int)(medieNote * 3) + teza) / 4;
                    }

                    else
                    {
                        float medieNote = (float)(suma / nr);
                        m = (int)medieNote;
                    }
                }
                

                
            }
            return m;

            
        }
        private void forward_materii_note_Click(object sender, RoutedEventArgs e)
        {
            note.Items.Clear();
            HelpStudentLoggedInBL hlp = new HelpStudentLoggedInBL(idS);
            Student s = new Student();
            s = hlp.GetStudent();
            Class myclass = new Class();
            GetClassOfThisStudentVM get_class = new GetClassOfThisStudentVM(s);
            myclass = get_class.GetClass();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsOfThisClassVM get_subjects = new GetSubjectsOfThisClassVM(myclass);
            subjects = get_subjects.GetSubjects();

            if (materii.SelectedItem!=null)
            {
                GradesOfThisStudent get_grades = new GradesOfThisStudent(s, subjects[materii.SelectedIndex]);
                ObservableCollection<GradeStudentLST> grades = new ObservableCollection<GradeStudentLST>();
                grades = get_grades.GetGrades();

                for(int index=0; index<grades.Count(); index++)
                {
                    note.Items.Add(grades[index].GradeStudent.Grade.ToString() + " ; " + grades[index].GradeStudent.TipNota + " ; sem: " + grades[index].GradeStudent.Semsestru + " ; data: " + grades[index].GradeStudent.Data);
                }

                medie.Text = Medie(grades).ToString();
            }
        }
    }
}
