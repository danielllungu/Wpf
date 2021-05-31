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
using Scoala.ViewModel.Teachers;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for AddTeacherView.xaml
    /// </summary>
    public partial class AddTeacherView : Window
    {
        public AddTeacherView()
        {
            InitializeComponent();
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            if(nume_profesor.Text=="" || telefon.Text=="")
            {
                MessageBox.Show("Introduceti numele profesorului si telefonul!", "Atentie!");
            }
            else
            {
                AddNewTeacher newTeacher = new AddNewTeacher(nume_profesor.Text, telefon.Text);
                newTeacher.AddTeacher();
                MessageBox.Show("Profesor adaugat cu succes!", "Adaugat!");
            }
            
        }
    }
}
