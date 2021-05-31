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

namespace Scoala.Views.AdminTeachers
{
    /// <summary>
    /// Interaction logic for MastersListView.xaml
    /// </summary>
    public partial class MastersListView : Window
    {
        public MastersListView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            listaDiriginti.Items.Clear();
            ObservableCollection<MastersToClass> m = new ObservableCollection<MastersToClass>();
            GetAllMastersToClassVM gm = new GetAllMastersToClassVM();
            m = gm.mastersToClassList;

            for(int index=0; index<m.Count(); index++)
            {
                listaDiriginti.Items.Add(m[index].Teacher.Name + " ; " + m[index].Class.ClassNumber.ToString() + " " + m[index].Class.Letter + " - " + m[index].Class.Specialization);

            }
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<MastersToClass> m = new ObservableCollection<MastersToClass>();
            GetAllMastersToClassVM gm = new GetAllMastersToClassVM();
            m = gm.mastersToClassList;

            if(listaDiriginti.SelectedItem!=null)
            {
                DeleteMasterVM dltMaster = new DeleteMasterVM(m[listaDiriginti.SelectedIndex].MasterToClass);
                dltMaster.Delete();
                MessageBox.Show("Diriginte eliminat cu succes!", "Eliminat!");
                Initialize();
            }

            else
            {
                MessageBox.Show("Faceti o selectie!", "Atentie!");
            }

        }
    }
}
