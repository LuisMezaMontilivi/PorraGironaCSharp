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
            LlistarPartits();
        }

        private void ButtonModificarPartit_Click(object sender, RoutedEventArgs e)
        {
            Partit modificar = partits.RecuperarPartit(comboBoxModPartit.SelectedIndex);
            modificar.Data = (DateTime)dateTimePartit.SelectedDateTime;
            partits.ActualitzarPartit(modificar);
            MessageBox.Show("S'ha modificat la data del partit correctament");
        }

        private void comboBoxModPartit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Partit recuperar = partits.RecuperarPartit(comboBoxModPartit.SelectedIndex);
            dateTimePartit.SelectedDateTime = recuperar.Data;
            labelLocal.Content = recuperar.EquipLocal.NomEquip;
            labelVisitant.Content = recuperar.EquipVisitant.NomEquip;
        }

        private void LlistarPartits()
        {
            partits = new Partits();
            foreach (Partit X in partits.LlistarPartits())
            {
                comboBoxModPartit.Items.Add(X.EquipLocal.NomEquip + " " + X.EquipVisitant.NomEquip + " " + X.Data);
            }
        }
    }
}
