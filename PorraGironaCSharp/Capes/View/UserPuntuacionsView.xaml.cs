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
    /// Lógica de interacción para UserPuntuacionsView.xaml
    /// </summary>
    public partial class UserPuntuacionsView : UserControl
    {
        private Porristes porristes;
        private string alias;


        public UserPuntuacionsView(string alias)
        {
            InitializeComponent();
            this.alias = alias;
            porristes = new Porristes();

            List<Porrista> llistaPorristes = porristes.RecuperarPorristes();

            BindGrid(llistaPorristes);



        }



        private void BindGrid(List<Porrista> llistaPorristes)
        {
            DataGridPuntuacions.ItemsSource = llistaPorristes;
        }


    }
}
