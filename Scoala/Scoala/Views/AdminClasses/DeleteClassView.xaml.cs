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
using Scoala.Models.BussinessLogic;
using Scoala.ViewModel.Classes;
using System.Collections.ObjectModel;

namespace Scoala.Views.AdminClasses
{
    /// <summary>
    /// Interaction logic for DeleteClassView.xaml
    /// </summary>
    public partial class DeleteClassView : Window
    {
        public DeleteClassView()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            lista.Items.Clear();
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            AllClasses get = new AllClasses();
            classes = get.classesList;

            for(int index=0; index<classes.Count(); index++)
            {
                lista.Items.Add(classes[index].ClassNumber + classes[index].Letter + " - " + classes[index].Specialization);
            }
        }

        private void btn_elimina_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            AllClasses get = new AllClasses();
            classes = get.classesList;

            if(lista.SelectedItem!=null)
            {
                ClassesToStudentsBL bl = new ClassesToStudentsBL(classes[lista.SelectedIndex]);
                if(bl.IsEmptyClass())
                {
                    DeleteClassVM dlt = new DeleteClassVM(classes[lista.SelectedIndex]);
                    dlt.Delete();
                    MessageBox.Show("Clasa a fost stearsa!", "Eliminat!");
                    Initialize();
                }

                else
                {
                    MessageBox.Show("Mutati toti elevii intr-o alta clasa inainte de stergerea clasei!", "Atentie!");
                }
            }

            else
            {
                MessageBox.Show("Faceti o selectie!", "Atentie!");
            }
        }
    }
}
