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
    /// Lógica de interacción para AltaPartit.xaml
    /// </summary>
    public partial class AltaPartit : UserControl
    {
        private Partits partits;
        private Equips equips;
        public AltaPartit()
        {
            InitializeComponent();
            equips = new Equips();
            try
            {
                partits = new Partits();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            List<Equip> llistatEquips = equips.EquipsBaseDades();
            foreach(Equip X in llistatEquips)
            {
                ComboBoxLocal.Items.Add(X.NomEquip);
                ComboBoxVisitant.Items.Add(X.NomEquip);
            }
        }

        private void ButtonCrearPartit_Click(object sender, RoutedEventArgs e)
        {
            Partit p = new Partit("Per jugar",
                equips.RetornarEquip((string)ComboBoxLocal.SelectedItem),
                equips.RetornarEquip((string)ComboBoxVisitant.SelectedItem),
                (DateTime)DateTimePartit.SelectedDateTime);
            try
            {
                partits.AfegirPartit(p);
                MessageBox.Show(p.Estat + " " + p.EquipLocal.NomEquip + " " + p.EquipVisitant.NomEquip+" "+p.Data.ToString("O"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            MessageBox.Show("Ha lelgado hasta aquí");
        }
    }
}
