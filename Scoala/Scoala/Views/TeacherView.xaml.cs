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

namespace Scoala.Views
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        int? idT;
        public TeacherView(int? id)
        {
            InitializeComponent();
            
            this.idT = id;
            HelpTeacherLoggedInBL bl = new HelpTeacherLoggedInBL(idT);
            Teacher t = new Teacher();
            t = bl.GetTeacher();
            salut.Text = "Buna ziua, " + t.Name + " !";
            
        }

        

        private void btn_adauga_nota_Click(object sender, RoutedEventArgs e)
        {
            AddGradeView view = new AddGradeView(this.idT);
            view.Show();
        }

        private void btn_adauga_absenta_Click(object sender, RoutedEventArgs e)
        {
            AbsencesView view = new AbsencesView(this.idT);
            view.Show();
        }

        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow view = new MainWindow();
            view.Show();
            Close();
        }

        private void btn_optiuni_diriginte_Click(object sender, RoutedEventArgs e)
        {
            VerifyMasterVM verify = new VerifyMasterVM(idT);
            if(verify.IsMaster())
            {
                MasterOptionsView view = new MasterOptionsView(this.idT);
                view.Show();
            }
            else
            {
                MessageBox.Show("Nu sunteti diriginte inca!", "Atentie!");
            }
            
        }

        private void btn_materiale_didactice_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
