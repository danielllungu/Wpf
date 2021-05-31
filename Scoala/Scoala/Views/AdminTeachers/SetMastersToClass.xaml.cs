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
using Scoala.ViewModel.Teachers;
using System.Collections.ObjectModel;
using Scoala.ViewModel.Classes;

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for SetMastersToClass.xaml
    /// </summary>
    public partial class SetMastersToClass : Window
    {
        public SetMastersToClass()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            ObservableCollection<Class> cls = new ObservableCollection<Class>();
            AllClasses allcls = new AllClasses();
            cls = allcls.classesList;

            for(int index=0; index<cls.Count(); index++)
            {
                listaClase.Items.Add(cls[index].ClassNumber.ToString() + cls[index].Letter + " - " + cls[index].Specialization);
            }

            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM gt = new GetAllTeachersVM();
            teachers = gt.teachersList;

            for(int index=0; index<teachers.Count(); index++)
            {
                listaProfesori.Items.Add(teachers[index].Name);
            }


        }

        private bool VerifyMaster(Teacher t)
        {
            ObservableCollection<MastersToClass> m = new ObservableCollection<MastersToClass>();
            GetAllMastersToClassVM gm = new GetAllMastersToClassVM();
            m = gm.mastersToClassList;

            for(int index=0; index<m.Count(); index++)
            {
                if (m[index].Teacher.TeacherID == t.TeacherID)
                    return false;
                
            }
            return true;
        }

        private bool VerifyClass(Class c)
        {
            ObservableCollection<MastersToClass> m = new ObservableCollection<MastersToClass>();
            GetAllMastersToClassVM gm = new GetAllMastersToClassVM();
            m = gm.mastersToClassList;

            for (int index = 0; index < m.Count(); index++)
            {
                if (m[index].Class.ClassID == c.ClassID)
                    return false;

            }
            return true;
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> cls = new ObservableCollection<Class>();
            AllClasses allcls = new AllClasses();
            cls = allcls.classesList;

            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            GetAllTeachersVM gt = new GetAllTeachersVM();
            teachers = gt.teachersList;

            if (listaProfesori.SelectedItem != null && listaClase.SelectedItem != null)
            {
                if(VerifyMaster(teachers[listaProfesori.SelectedIndex]) && VerifyClass(cls[listaClase.SelectedIndex]))
                {
                    SetMasterToClassVM setMaster = new SetMasterToClassVM(teachers[listaProfesori.SelectedIndex], cls[listaClase.SelectedIndex]);
                    setMaster.Set();
                    MessageBox.Show("Diriginte setat cu succes!", "Succes!");
                }

                /*else
                {
          
                    if(VerifyClass(cls[listaClase.SelectedIndex]))
                    {
                        UpdateMasterToClassVM update = new UpdateMasterToClassVM(teachers[listaProfesori.SelectedIndex], cls[listaClase.SelectedIndex]);
                        update.Set();
                        MessageBox.Show("Dirigintele a fost actualizat cu succes!", "Modificat!");
                    }

                    else
                    {
                        DeleteAndAddMasterToClass dlt = new DeleteAndAddMasterToClass(teachers[listaProfesori.SelectedIndex], cls[listaClase.SelectedIndex]);
                        dlt.Set();
                        MessageBox.Show("Diriginte setat cu succes!\nClasa apartinea unui alt profesor!", "Modificat!");
                    }

                }*/

                else
                {
                    MessageBox.Show("Eliminati actualul diriginte pentru modificare!", "Atentie!");
                }

            }

            else
                MessageBox.Show("Selectati un profesor si o clasa!", "Atentie!");
        }
    }
}
