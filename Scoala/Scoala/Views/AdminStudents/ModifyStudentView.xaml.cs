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
using System.Collections.ObjectModel;
using Scoala.ViewModel.Students;
using Scoala.Models.EntityLayer;
using Scoala.ViewModel.Classes;

namespace Scoala.Views.AdminStudents
{
    /// <summary>
    /// Interaction logic for ModifyStudentView.xaml
    /// </summary>
    public partial class ModifyStudentView : Window
    {
        public ModifyStudentView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsVM std = new GetStudentsVM();
            students = std.studentsList;

            for (int index = 0; index < students.Count(); index++)
            {
                listaStudenti.Items.Add(students[index].Name);
            }
        }

        private void btn_modifica_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsVM std = new GetStudentsVM();
            students = std.studentsList;
            if (listaStudenti.SelectedItem==null)
            {
                MessageBox.Show("Selectati un student!", "Atentie!");
            }

            else
            {
                if(txt_nume.Text=="")
                {
                    MessageBox.Show("Introduceti numele modificat al studentului!", "Atentie!");
                }
                else
                {
                    UpdateStudentNameVM ups = new UpdateStudentNameVM(students[listaStudenti.SelectedIndex], txt_nume.Text);
                    ups.UpdateStudent();
                    MessageBox.Show("Numele studentului a fost actualizat cu succes!", "Modificat!");
                }
                

            }
            
        }
    }
}
