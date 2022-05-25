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
    /// Lógica de interacción para ActualitzacioPartit.xaml
    /// </summary>
    public partial class ActualitzacioPartit : UserControl
    {
        Equips equips;
        Partits partits;
        public ActualitzacioPartit(Equips e, Partits p)
        {
            InitializeComponent();
            equips = e;
            partits = p;
        }
    }
}
