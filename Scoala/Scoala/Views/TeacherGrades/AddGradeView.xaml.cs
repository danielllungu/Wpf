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

namespace Scoala.Views.TeacherGrades
{
    /// <summary>
    /// Interaction logic for AddGradeView.xaml
    /// </summary>
    public partial class AddGradeView : Window
    {
        int? idT;
        Teacher teacher;
        public AddGradeView(int? id)
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

            
            for(int index=0; index<subjects.Count(); index++)
            {
                materii.Items.Add(subjects[index].Name);
            }

            tip_nota.Items.Add("test");
            tip_nota.Items.Add("teza");
            tip_nota.Items.Add("Medie incheiata");
            semestru.Items.Add("1");
            semestru.Items.Add("2");
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

            if (tip_nota.SelectedItem!=null && semestru.SelectedItem!=null && data.Text!="")
            {
                if(tip_nota.Text!="Medie incheiata" && nota.Text != "")
                {
                    InsertGrade insertGrade = new InsertGrade(students[elevi.SelectedIndex], teacher, subjects[materii.SelectedIndex], Int32.Parse(nota.Text), Int32.Parse(semestru.Text), data.Text, tip_nota.Text);
                    insertGrade.Insert();
                    RefreshGrades();
                    MessageBox.Show("Nota adaugata!", "Succes!");
                }
                else
                {
                    int medie_incheiata = 0;
                    int suma = 0;
                    int nr = 0;
                    int teza = 0;
                    GetGradeStudentLSTVM get_grades = new GetGradeStudentLSTVM(students[elevi.SelectedIndex], subjects[materii.SelectedIndex], teacher);
                    ObservableCollection<GradeStudent> grades = new ObservableCollection<GradeStudent>();
                    grades = get_grades.GetGrades();
                    if(semestru.Text=="1")
                    {
                        
                        for (int index = 0; index < grades.Count(); index++)
                        {
                            if (grades[index].Semsestru==1 && grades[index].TipNota=="test")
                            {
                                suma += grades[index].Grade;
                                nr += 1;
                            }
                            else if(grades[index].Semsestru==1 && grades[index].TipNota=="teza")
                            {
                                teza = grades[index].Grade;
                            }
                        }
                        float medieNote = (float)(suma / nr);
                        medie_incheiata = ((int)(medieNote * 3) + teza) / 4;

                    }

                    else if (semestru.Text == "2")
                    {
                        
                        for (int index = 0; index < grades.Count(); index++)
                        {
                            if (grades[index].Semsestru == 2 && grades[index].TipNota == "test")
                            {
                                suma += grades[index].Grade;
                                nr += 1;
                            }
                            else if (grades[index].Semsestru == 2 && grades[index].TipNota == "teza")
                            {
                                teza = grades[index].Grade;
                            }
                        }
                        if(teza!=0)
                        {
                            float medieNote = (float)(suma / nr);
                            medie_incheiata = ((int)(medieNote * 3) + teza) / 4;
                        }

                        else
                        {
                            int medieNote = suma / nr;
                            medie_incheiata = medieNote;
                        }
                        

                    }

                    else
                    {
                        MessageBox.Show("Selectati un semestru pentru a incheia media!", "Atentie!");
                    }
                    if (nr >= 3)
                    {
                        InsertGrade insertGrade = new InsertGrade(students[elevi.SelectedIndex], teacher, subjects[materii.SelectedIndex], medie_incheiata, Int32.Parse(semestru.Text), data.Text, tip_nota.Text);
                        insertGrade.Insert();
                        RefreshGrades();
                        MessageBox.Show("Medie incheiata!", "Succes!");
                    }
                    else
                        MessageBox.Show("Numar insuficient de note!", "Atentie!");
                    

                }
                
                
                
            }   
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
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

            GetGradeStudentLSTVM get_grades = new GetGradeStudentLSTVM(students[elevi.SelectedIndex], subjects[materii.SelectedIndex], teacher);
            ObservableCollection<GradeStudent> grades = new ObservableCollection<GradeStudent>();
            grades = get_grades.GetGrades();

            if(note.SelectedItem!=null)
            {
                DeleteGradeStudentVM dlt = new DeleteGradeStudentVM(grades[note.SelectedIndex]);
                dlt.Delete();
                RefreshGrades();
                MessageBox.Show("Nota a fost stearsa!", "Succes!");
                
            }

        }

        private void forward_materii_clase_Click(object sender, RoutedEventArgs e)
        {
            clase.Items.Clear();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            

            if (materii.SelectedItem!=null)
            {
                ObservableCollection<Class> classes = new ObservableCollection<Class>();
                GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
                classes = getClasses.GetClasses();

                for(int index=0; index<classes.Count(); index++)
                {
                    clase.Items.Add(classes[index].ClassNumber.ToString() + classes[index].Letter + " - " + classes[index].Specialization);
                    
                }
            }
        }


        private void RefreshGrades()
        {
            note.Items.Clear();

            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            GetClassesFromThisTeacherSubjectVM getClasses = new GetClassesFromThisTeacherSubjectVM(teacher, subjects[materii.SelectedIndex]);
            classes = getClasses.GetClasses();

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsFromThisClassVM getstudents = new GetStudentsFromThisClassVM(classes[clase.SelectedIndex]);
            students = getstudents.GetStudents();


            GetGradeStudentLSTVM get_grades = new GetGradeStudentLSTVM(students[elevi.SelectedIndex], subjects[materii.SelectedIndex], teacher);
            ObservableCollection<GradeStudent> grades = new ObservableCollection<GradeStudent>();
            grades = get_grades.GetGrades();

            for (int index = 0; index < grades.Count(); index++)
            {
                note.Items.Add(grades[index].Grade.ToString() + " ; " + grades[index].TipNota + " ; sem:" + grades[index].Semsestru + " ; " + grades[index].Data);
            }
        }
        private void forward_clase_elevi_Click(object sender, RoutedEventArgs e)
        {
            elevi.Items.Clear();
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();
            GetSubjectsFromThisTeacher get = new GetSubjectsFromThisTeacher(teacher);
            subjects = get.GetSubjects();

            if(materii.SelectedItem!=null)
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

        private void forward_elevi_note_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrades();

        }

        
    }
}
