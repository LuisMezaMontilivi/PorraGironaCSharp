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
    /// Lógica de interacción para BaixesView.xaml
    /// </summary>
    public partial class BaixesView : UserControl
    {
        List<Usuari> usuaris;
        Equips equips;
        Partits partits;
        public BaixesView()
        {
            InitializeComponent();
            LlistarUsuaris();
            LlistarEquips();
            //LlistarPartits();
        }

        private void LlistarUsuaris()
        {
            usuaris = DataBase.UsuariBD.LlistatUsuaris();
            foreach (Usuari X in usuaris)
            {
                ComboBoxEliminarUsuari.Items.Add(X.alias);
            }
        }

        private void LlistarEquips()
        {
            equips = new Equips();
            foreach (Equip X in equips.EquipsBaseDades())
            {
                ComboBoxEliminarEquip.Items.Add(X.NomEquip);
            }
        }

        private void LlistarPartits()
        {
            partits = new Partits();
            foreach (Partit X in partits.LlistarPartits())
            {
                ComboBoxEliminarPartit.Items.Add(X.EquipLocal.NomEquip +" "+ X.EquipVisitant.NomEquip);
            }
        }

        private void ButtonEliminarUsuari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuari eliminar = usuaris.Find(x => x.alias == ComboBoxEliminarUsuari.Text);
                eliminar.Eliminar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ComboBoxEliminarUsuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usuari eliminar = usuaris.Find(x => x.alias == ComboBoxEliminarUsuari.Text);
            labelAliasUsuari.Content = ComboBoxEliminarUsuari.Text;
        }
    }
}
