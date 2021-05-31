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
using Scoala.ViewModel.Subjects;
using Scoala.Models.EntityLayer;

namespace Scoala.Views.AdminSubjects
{
    /// <summary>
    /// Interaction logic for AddSubjectView.xaml
    /// </summary>
    public partial class AddSubjectView : Window
    {
        public AddSubjectView()
        {
            InitializeComponent();
        }

        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            if(denumire.Text!="")
            {
                InsertSubjectVM model = new InsertSubjectVM(denumire.Text);
                model.Add();
                MessageBox.Show("Materia  fost adaugata!", "Adaugat!");

            }
            else
            {
                MessageBox.Show("Scrieti denumirea materiei!", "Atentie!");
            }
        }
    }
}
