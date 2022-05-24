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
            Usuari eliminar = usuaris.Find(x => x.alias == ComboBoxEliminarUsuari.Text);
            eliminar.Eliminar();
            LlistarUsuaris();
            labelAliasUsuari.Content = labelNomUsuari.Content = labelCognomUsuari.Content = labelNifUsuari.Content = "";
        }

        private void ComboBoxEliminarUsuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxEliminarUsuari.Text != "")
            {
                Usuari eliminar = usuaris[ComboBoxEliminarUsuari.SelectedIndex];
                labelAliasUsuari.Content = eliminar.alias;
                labelNomUsuari.Content = eliminar.nom;
                labelCognomUsuari.Content = eliminar.cognom;
                labelNifUsuari.Content = eliminar.nif;
            }
            
        }

        private void ComboBoxEliminarEquip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxEliminarEquip.Text != "")
            {
                Equip eliminar = equips.EquipsBaseDades()[ComboBoxEliminarEquip.SelectedIndex];
                labelNomEquip.Content = eliminar.NomEquip;
                labelMunicipiEquip.Content = eliminar.Municipi;
                labelCampEquip.Content = eliminar.NomCamp;
            }
        }

        private void ButtonEliminarEquip_Click(object sender, RoutedEventArgs e)
        {
            Equip eliminar = equips.EquipsBaseDades()[ComboBoxEliminarEquip.SelectedIndex];
            equips.EliminarEquip(eliminar.IdEquip);
            labelNomEquip.Content = labelMunicipiEquip.Content = labelCampEquip.Content = ComboBoxEliminarEquip.Text = "";
            ComboBoxEliminarEquip.Items.RemoveAt(ComboBoxEliminarEquip.SelectedIndex);
        }
    }
}
