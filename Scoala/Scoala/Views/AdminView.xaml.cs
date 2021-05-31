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
using Scoala.Views.AdminStudents;
using Scoala.Views.AdminTeachers;
using Scoala.Views.AdminSubjects;
using Scoala.Views.AdminClasses;

namespace Scoala.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
            HideButtons();
        }

        private void HideButtons()
        {
            btn_lista_studenti.Visibility = Visibility.Hidden;
            btn_lista_studenti_spec.Visibility = Visibility.Hidden;
            btn_lista_studenti_clase.Visibility = Visibility.Hidden;
            btn_adauga_student.Visibility = Visibility.Hidden;
            btn_elimina_student.Visibility = Visibility.Hidden;
            btn_elimina_clasa.Visibility = Visibility.Hidden;
            btn_elimina_scoala.Visibility = Visibility.Hidden;
            btn_lista_profesori.Visibility = Visibility.Hidden;
            btn_lista_materii.Visibility = Visibility.Hidden;
            btn_adauga_profesor.Visibility = Visibility.Hidden;
            btn_elimina_profesor.Visibility = Visibility.Hidden;
            btn_adauga_materie.Visibility = Visibility.Hidden;
            btn_adauga_clasa.Visibility = Visibility.Hidden;
            btn_sterge_clasa.Visibility = Visibility.Hidden;
            btn_modifica_student.Visibility = Visibility.Hidden;
            btn_modifica_profesor.Visibility = Visibility.Hidden;
            btn_cuplaj.Visibility = Visibility.Hidden;
            btn_lista_diriginti.Visibility = Visibility.Hidden;
            btn_lista_profesori_clase.Visibility = Visibility.Hidden;
            btn_seteaza_dirigiti.Visibility = Visibility.Hidden;
            btn_seteaza_profesori_clase.Visibility = Visibility.Hidden;
            btn_lista_profesori_materii.Visibility = Visibility.Hidden;
            btn_seteaza_profesori_materii.Visibility = Visibility.Hidden;
        }


        private void RevealInitialButtons()
        {
            btn_studenti.Visibility = Visibility.Visible;
            btn_profesori.Visibility = Visibility.Visible;
            btn_materii.Visibility = Visibility.Visible;
            btn_Clase.Visibility = Visibility.Visible;
        }
        private void RevealButtonsStudents()
        {
            btn_lista_studenti.Visibility = Visibility.Visible;
            btn_lista_studenti_spec.Visibility = Visibility.Visible;
            btn_lista_studenti_clase.Visibility = Visibility.Visible;
            btn_adauga_student.Visibility = Visibility.Visible;
            btn_elimina_student.Visibility = Visibility.Visible;
            btn_modifica_student.Visibility = Visibility.Visible;
        }

        private void RevealButtonsClasses()
        {
            btn_adauga_clasa.Visibility = Visibility.Visible;
            btn_sterge_clasa.Visibility = Visibility.Visible;
        }

        private void RevealButtonsTeachers()
        {
            btn_lista_profesori.Visibility = Visibility.Visible;
            btn_elimina_profesor.Visibility = Visibility.Visible;
            btn_adauga_profesor.Visibility = Visibility.Visible;
            btn_modifica_profesor.Visibility = Visibility.Visible;
            btn_cuplaj.Visibility = Visibility.Visible;
            
        }

        private void RevealButtonsSubjects()
        {
            btn_lista_materii.Visibility = Visibility.Visible;
            btn_adauga_materie.Visibility = Visibility.Visible;

        }

        private void EliminaStudentMenu()
        {
            HideButtons();
            btn_elimina_clasa.Visibility = Visibility.Visible;
            btn_elimina_scoala.Visibility = Visibility.Visible;
        }

        private void CuplajMenu()
        {
            HideButtons();
            btn_lista_diriginti.Visibility = Visibility.Visible;
            btn_lista_profesori_clase.Visibility = Visibility.Visible;
            btn_seteaza_dirigiti.Visibility = Visibility.Visible;
            btn_seteaza_profesori_clase.Visibility = Visibility.Visible;
            btn_lista_profesori_materii.Visibility = Visibility.Visible;
            btn_seteaza_profesori_materii.Visibility = Visibility.Visible;
        }

        private void btn_profesori_Click(object sender, RoutedEventArgs e)
        {
            btn_studenti.Visibility = Visibility.Hidden;
            btn_profesori.Visibility = Visibility.Hidden;
            btn_materii.Visibility = Visibility.Hidden;
            btn_Clase.Visibility = Visibility.Hidden;
            RevealButtonsTeachers();

        }

        private void btn_studenti_Click(object sender, RoutedEventArgs e)
        {
            btn_studenti.Visibility = Visibility.Hidden;
            btn_profesori.Visibility = Visibility.Hidden;
            btn_materii.Visibility = Visibility.Hidden;
            btn_Clase.Visibility = Visibility.Hidden;
            RevealButtonsStudents();

        }

        private void btn_Clase_Click(object sender, RoutedEventArgs e)
        {
            btn_studenti.Visibility = Visibility.Hidden;
            btn_profesori.Visibility = Visibility.Hidden;
            btn_materii.Visibility = Visibility.Hidden;
            btn_Clase.Visibility = Visibility.Hidden;
            RevealButtonsClasses();

        }


        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            HideButtons();
            RevealInitialButtons();

        }

        private void btn_materii_Click(object sender, RoutedEventArgs e)
        {
            btn_studenti.Visibility = Visibility.Hidden;
            btn_profesori.Visibility = Visibility.Hidden;
            btn_materii.Visibility = Visibility.Hidden;
            btn_Clase.Visibility = Visibility.Hidden;
            RevealButtonsSubjects();
        }

        private void btn_elimina_student_Click(object sender, RoutedEventArgs e)
        {
            EliminaStudentMenu();
        }

        private void btn_modifica_student_Click(object sender, RoutedEventArgs e)
        {
            ModifyStudentView ms = new ModifyStudentView();
            ms.Show();
        }

        private void btn_lista_studenti_Click(object sender, RoutedEventArgs e)
        {
            StudentsTotalListView stlv = new StudentsTotalListView();
            stlv.Show();
        }

        private void btn_lista_studenti_clase_Click(object sender, RoutedEventArgs e)
        {
            StudentsOrgClassesView sorg = new StudentsOrgClassesView();
            sorg.Show();
        }

        private void btn_adauga_clasa_Click(object sender, RoutedEventArgs e)
        {
            AddClassView view = new AddClassView();
            view.Show();
        }
        private void btn_modifica_profesor_Click(object sender, RoutedEventArgs e)
        {
            UpdateTeacherView update = new UpdateTeacherView();
            update.Show();
        }

        private void btn_sterge_clasa_Click(object sender, RoutedEventArgs e)
        {
            DeleteClassView view = new DeleteClassView();
            view.Show();

        }
        private void btn_lista_materii_Click(object sender, RoutedEventArgs e)
        {
            SubjectsListView view = new SubjectsListView();
            view.Show();

        }

        private void btn_lista_studenti_spec_Click(object sender, RoutedEventArgs e)
        {
            StudentsSpecView ssw = new StudentsSpecView();
            ssw.Show();
        }

        private void btn_adauga_student_Click(object sender, RoutedEventArgs e)
        {
            AddStudent add = new AddStudent();
            add.Show();
        }

        private void btn_elimina_clasa_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent ds = new DeleteStudent();
            ds.Show();
        }

        private void btn_elimina_scoala_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudentFromSchool ds = new DeleteStudentFromSchool();
            ds.Show();
        }

        private void btn_lista_profesori_Click(object sender, RoutedEventArgs e)
        {
            TeachersListView tw = new TeachersListView();
            tw.Show();
        }

        private void btn_adauga_profesor_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherView addTeacher = new AddTeacherView();
            addTeacher.Show();
        }

        private void btn_elimina_profesor_Click(object sender, RoutedEventArgs e)
        {
            DeleteTeacherView dlt = new DeleteTeacherView();
            dlt.Show();
        }

        private void btn_cuplaj_Click(object sender, RoutedEventArgs e)
        {
            CuplajMenu();
        }

        private void btn_lista_diriginti_Click(object sender, RoutedEventArgs e)
        {
            MastersListView mw = new MastersListView();
            mw.Show();
        }

        private void btn_lista_profesori_clase_Click(object sender, RoutedEventArgs e)
        {
            TeachersToClassesView t = new TeachersToClassesView();
            t.Show();
        }

        private void btn_seteaza_dirigiti_Click(object sender, RoutedEventArgs e)
        {
            SetMastersToClass set = new SetMastersToClass();
            set.Show();
        }

        private void btn_seteaza_profesori_clase_Click(object sender, RoutedEventArgs e)
        {
            SetTeachersToSubjectsToClassesView view = new SetTeachersToSubjectsToClassesView();
            view.Show();
        }

        private void btn_adauga_materie_Click(object sender, RoutedEventArgs e)
        {
            AddSubjectView view = new AddSubjectView();
            view.Show();
        }

        private void btn_lista_profesori_materii_Click(object sender, RoutedEventArgs e)
        {
            TeacherToSubjectView t = new TeacherToSubjectView();
            t.Show();
        }

        private void btn_seteaza_profesori_materii_Click(object sender, RoutedEventArgs e)
        {
            InsertTeacherToSubjectsView view = new InsertTeacherToSubjectsView();
            view.Show();
        }

        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow view = new MainWindow();
            view.Show();
            Close();
            
        }
    }
}
