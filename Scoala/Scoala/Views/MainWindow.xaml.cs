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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Scoala.Models;
using System.Collections.ObjectModel;
using Scoala.Models.LoginDetails;
using Scoala.Models.DataAccess;
using Scoala.Models.BussinessLogic;
using Scoala.Models.EntityLayer;

namespace Scoala.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Logins l = new Logins(login_email.Text, password_login.Password);
            if (l.IsAdmin())
            {

                AdminView aw = new AdminView();
                aw.Show();
                Close();
            }
            else if (l.IsTeacher())
            {
                Teacher t = new Teacher();
                t = l.GetLoggedInTeacher();
                TeacherView tw = new TeacherView(t.TeacherID);
                tw.Show();
                Close();
            }
            else if (l.IsStudent())
            {
                Student s = new Student();
                s = l.GetLoggedInStudent();
                StudentView sw = new StudentView(s.StudentID);
                sw.Show();
                Close();
            }
            else
                MessageBox.Show("Cont inexistent.", "Atentie!");
        }
    }
}
