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
using Scoala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for UpdateTeacherView.xaml
    /// </summary>
    public partial class UpdateTeacherView : Window
    {
        public UpdateTeacherView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            listaProfesori.Items.Clear();
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM getAllTeachersVM = new GetAllTeachersVM();
            teachers = getAllTeachersVM.teachersList;

            for (int index = 0; index < teachers.Count(); index++)
            {
                listaProfesori.Items.Add(teachers[index].Name+"\t\t"+teachers[index].Phone);
            }
        }

        private void btn_modifica_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM getAllTeachersVM = new GetAllTeachersVM();
            teachers = getAllTeachersVM.teachersList;


            if(listaProfesori.SelectedItem!=null)
            {
                if (txt_nume.Text == "")
                {
                    MessageBox.Show("Introduceti numele profesorului!", "Atentie!");
                }
                else
                {
                    if (txt_telefon.Text == "")
                    {
                        MessageBox.Show("Introduceti numarul de telefon!", "Atentie!");
                    }
                    else
                    {
                        UpdateTeacherVM update = new UpdateTeacherVM(teachers[listaProfesori.SelectedIndex], txt_nume.Text, txt_telefon.Text);
                        update.UpdateTeacher();
                        MessageBox.Show("Detaliile profesorului au fost actualizate!", "Actualizat!");
                        Initialize();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectati un profesor!", "Atentie!");
            }
            


        }
    }
}
