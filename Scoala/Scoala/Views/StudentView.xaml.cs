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
using Scoala.Views.StudentGrades;
using System.Collections.ObjectModel;
using Scoala.Views.StudentAbsences;

namespace Scoala.Views
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        int? idS;
        public StudentView(int? id)
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
            salut.Text = "Salut, " + s.Name + " !";
        }

        private void btn_note_Click(object sender, RoutedEventArgs e)
        {
            MyGradesView view = new MyGradesView(idS);
            view.Show();
        }

        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow view = new MainWindow();
            view.Show();
            Close();
        }

        private void btn_absente_Click(object sender, RoutedEventArgs e)
        {
            MyAbsences view = new MyAbsences(idS);
            view.Show();
        }
    }
}
