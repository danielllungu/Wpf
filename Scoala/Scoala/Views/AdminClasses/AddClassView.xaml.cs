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
using Scoala.ViewModel.Classes;

namespace Scoala.Views.AdminClasses
{
    /// <summary>
    /// Interaction logic for AddClassView.xaml
    /// </summary>
    public partial class AddClassView : Window
    {
        public AddClassView()
        {
            InitializeComponent();
        }


        private void btn_adauga_Click(object sender, RoutedEventArgs e)
        {
            if(numar_clasa.Text!="" && litera.Text!="" && specializare.Text!="")
            {
                ClassesBL bl = new ClassesBL(Int32.Parse(numar_clasa.Text), litera.Text, specializare.Text);
                if(bl.ThisClassAlreadyExists())
                {
                    MessageBox.Show("Aceasta clasa exista deja!", "Atentie!");
                }

                else
                {
                    InsertClassVM ins = new InsertClassVM(Int32.Parse(numar_clasa.Text), litera.Text, specializare.Text);
                    ins.Add();
                    MessageBox.Show("Clasa a fost adaugata!", "Adaugat!");
                }    
            }

            else
            {
                MessageBox.Show("Introduceti datele!", "Atentie!");
            }

        }
    }
}
