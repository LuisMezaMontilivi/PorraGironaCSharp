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
    /// Lógica de interacción para AltaPartit.xaml
    /// </summary>
    public partial class AltaPartit : UserControl
    {
        public AltaPartit()
        {
            InitializeComponent();
            ComboBoxVisitant.Items.Add("Usuari");
            ComboBoxVisitant.Items.Add("Equip");
            ComboBoxVisitant.Items.Add("Partit");
            ComboBoxVisitant.Items.Add("Categoria");
            ComboBoxLocal.Items.Add("Usuari");
            ComboBoxLocal.Items.Add("Equip");
            ComboBoxLocal.Items.Add("Partit");
            ComboBoxLocal.Items.Add("Categoria");
        }
    }
}
