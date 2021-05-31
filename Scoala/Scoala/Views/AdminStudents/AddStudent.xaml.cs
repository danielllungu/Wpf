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
using Scoala.Models.EntityLayer;
using Scoala.ViewModel.Classes;
using Scoala.ViewModel.Students;


namespace Scoala.Views.AdminStudents
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
            Classes();
        }

        private void Classes()
        {
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            AllClasses cls = new AllClasses();
            classes = cls.classesList;
            for(int index=0; index<classes.Count(); index++)
            {
                clase.Items.Add(classes[index].ClassNumber.ToString() + classes[index].Letter + " " + classes[index].Specialization);
            }
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            AllClasses cls = new AllClasses();
            classes = cls.classesList;
            if (nume_student.Text=="")
            {
                MessageBox.Show("Adaugati numele studentului.", "Atentie!");
            }
            else
            {
                if(clase.SelectedItem==null)
                {
                    MessageBox.Show("Selectati o clasa!", "Atentie!");
                }
                else
                {
                    AddStudentVM addStudentVM = new AddStudentVM(nume_student.Text, classes[clase.SelectedIndex]);
                    MessageBox.Show("Studentul a fost adaugat cu succes!", "Adaugat!");
                    
                }
            }
        }

        

    }
}
