using PorraGironaCSharp.Capes.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PorraGironaCSharp.Capes.View
{
    /// <summary>
    /// Lógica de interacción para UserHistoric.xaml
    /// </summary>
    public partial class UserHistoric : UserControl
    {

        private string alias;
        private Historics historics;
        private List<Historic> llistahistorics;

        public UserHistoric(string alias)
        {
            this.alias = alias;
            InitializeComponent();
            historics = new Historics();

            llistahistorics = historics.RecuperarHistorics(alias);

            BindGrid(llistahistorics);

        }





        private void BindGrid(List<Historic> llistaHistorics)
        {
            DataGridHistorics.ItemsSource = llistaHistorics;
        }
    }
}
