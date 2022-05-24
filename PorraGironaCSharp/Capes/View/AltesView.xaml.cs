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
    /// Lógica de interacción para AltesView.xaml
    /// </summary>
    public partial class AltesView : UserControl
    {
        Equips equips;
        public AltesView()
        {
            InitializeComponent();
            ComboBoxAfegirElements();
        }
        private void ComboBoxAfegirElements()
        {
            ComboBoxOpcio.Items.Add("Usuari");
            ComboBoxOpcio.Items.Add("Equip");
            ComboBoxOpcio.Items.Add("Partit");
        }

        private void ComboBoxOpcio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBoxOpcio.SelectedIndex)
            {
                case 0:
                    FrameOpcions.Content = new AltaUsuari();
                    break;
                case 1:
                    FrameOpcions.Content = new AltaEquip();
                    break;
                case 2:
                    FrameOpcions.Content = new AltaPartit();
                    break;
            }
        }
    }
}
