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
    /// Interaction logic for DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
        public DeleteStudent()
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

            ObservableCollection<Class> listaclase = new ObservableCollection<Class>();
            AllClasses cls = new AllClasses();
            listaclase = cls.classesList;
            for (int index = 0; index < listaclase.Count(); index++)
            {
                comboBoxClase.Items.Add(listaclase[index].ClassNumber.ToString() + listaclase[index].Letter);
            }
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            GetStudentsVM std = new GetStudentsVM();
            students = std.studentsList;

            ObservableCollection<Class> listaclase = new ObservableCollection<Class>();
            AllClasses cls = new AllClasses();
            listaclase = cls.classesList;

            if(listaStudenti.SelectedItem==null)
            {
                MessageBox.Show("Selectati un student!", "Atentie!");
            }
            else
            {
                if(comboBoxClase.SelectedItem==null)
                {
                    MessageBox.Show("Selectati o clasa!", "Atentie!");
                }
                else
                {
                    UpdateStudentToClassVM update = new UpdateStudentToClassVM(students[listaStudenti.SelectedIndex], listaclase[comboBoxClase.SelectedIndex]);
                    update.Update();
                    MessageBox.Show("Transferul studentului a fost realizat cu succes!", "Succes!");
                }
            }
            
        }
    }
}
