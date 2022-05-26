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
        Usuaris usuaris;
        Equips equips;
        Partits partits;
        public BaixesView()
        {
            InitializeComponent();
            LlistarUsuaris();
            LlistarEquips();
            LlistarPartits();
        }

        private void LlistarUsuaris()
        {
            usuaris = new Usuaris();
            foreach (string X in usuaris.AliesUsuaris())
            {
                ComboBoxEliminarUsuari.Items.Add(X);
            }
        }

        private void LlistarEquips()
        {
            equips = new Equips();
            foreach (string X in equips.NomsEquips())
            {
                ComboBoxEliminarEquip.Items.Add(X);
            }
        }

        private void LlistarPartits()
        {
            partits = new Partits();
            foreach (Partit X in partits.LlistarPartits())
            {
                ComboBoxEliminarPartit.Items.Add(X.EquipLocal.NomEquip + " " + X.EquipVisitant.NomEquip + " " + X.Data);
            }
        }

        private void ButtonEliminarUsuari_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEliminarUsuari.Text != "")
            {
                try
                {
                    Usuari del = usuaris.RecuperarUsuari(ComboBoxEliminarUsuari.SelectedIndex);
                    usuaris.EliminarUsuari(del);
                    labelAliasUsuari.Content = labelNomUsuari.Content = labelCognomUsuari.Content = labelNifUsuari.Content = ComboBoxEliminarUsuari.Text = "";
                    ComboBoxEliminarUsuari.Items.Remove(del.alias);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ComboBoxEliminarUsuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ComboBoxEliminarUsuari.Text != "")
                {
                    Usuari eliminar = usuaris.RecuperarUsuari(ComboBoxEliminarUsuari.SelectedIndex);
                    labelAliasUsuari.Content = eliminar.alias;
                    labelNomUsuari.Content = eliminar.nom;
                    labelCognomUsuari.Content = eliminar.cognom;
                    labelNifUsuari.Content = eliminar.nif;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxEliminarEquip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxEliminarEquip.Text != "")
            {
                Equip eliminar = equips.RecuperarEquip(ComboBoxEliminarEquip.SelectedIndex);
                labelNomEquip.Content = eliminar.NomEquip;
                labelMunicipiEquip.Content = eliminar.Municipi;
                labelCampEquip.Content = eliminar.NomCamp;
            }
        }

        private void ButtonEliminarEquip_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEliminarEquip.Text != "")
            {
                try
                {
                    Equip eliminar = equips.RecuperarEquip(ComboBoxEliminarEquip.SelectedIndex);
                    equips.EliminarEquip(eliminar);
                    labelNomEquip.Content = labelMunicipiEquip.Content = labelCampEquip.Content = ComboBoxEliminarEquip.Text = "";
                    ComboBoxEliminarEquip.Items.Remove(eliminar.NomEquip);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
             
        }

        private void ComboBoxEliminarPartit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxEliminarPartit.Text != "")
            {
                Partit eliminar = partits.RecuperarPartit(ComboBoxEliminarPartit.SelectedIndex);
                labelData.Content = eliminar.Data;
                labelEquipLocal.Content = eliminar.EquipLocal.NomEquip;
                labelEquipVisitant.Content = eliminar.EquipVisitant.NomEquip;
            }
        }

        private void ButtonEliminarPartit_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEliminarPartit.Text != "")
            {
                Partit eliminar = partits.RecuperarPartit(ComboBoxEliminarPartit.SelectedIndex);
                labelData.Content = labelEquipLocal.Content = labelEquipVisitant.Content = ComboBoxEliminarPartit.Text = "";
                ComboBoxEliminarPartit.Items.Remove(eliminar.EquipLocal.NomEquip + " " + eliminar.EquipVisitant.NomEquip + " " + eliminar.Data);
                try
                {
                    partits.EliminarPartit(eliminar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
