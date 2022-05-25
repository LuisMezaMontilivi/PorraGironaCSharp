using Microsoft.Win32;
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
    /// Lógica de interacción para ActualitzacioEquip.xaml
    /// </summary>
    public partial class ActualitzacioEquip : UserControl
    {
        Equips equips;
        public ActualitzacioEquip(Equips e)
        {
            InitializeComponent();
            equips = e;
            LlistarEquips();
        }

        private void LlistarEquips()
        {
            equips = new Equips();
            foreach (string X in equips.NomsEquips())
            {
                comboBoxActualitzarEquip.Items.Add(X);
            }
        }

        private void ButtonAfegirImatge_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\"
            };
            openFileDialog.ShowDialog();
            TextBoxImatge.Text = openFileDialog.FileName;
        }

        private void ButtonModEquip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Equip modificar = equips.RecuperarEquip(comboBoxActualitzarEquip.SelectedIndex);
                modificar.RutaEscut = TextBoxImatge.Text;
                modificar.NomCamp = TextBoxCamp.Text;
                equips.ActualitzarEquip(modificar);
                MessageBox.Show("L'equip s'ha actualitzat correctament");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    Usuari modificar = usuaris.RecuperarUsuari(comboBoxUsuari.SelectedIndex);
            //    if (passwordBoxContrasenya.Password != "")
            //        modificar.contrasenya = passwordBoxContrasenya.Password;
            //    modificar.nom = textBoxNom.Text;
            //    modificar.cognom = textBoxCognom.Text;
            //    modificar.nif = textBoxNif.Text;
            //    usuaris.ActualitzarUsuari(modificar);
            //    MessageBox.Show("S'ha modificat correctament");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void comboBoxActualitzarEquip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxActualitzarEquip.Text != "")
            {
                Equip modificar = equips.RecuperarEquip(comboBoxActualitzarEquip.SelectedIndex);
                TextBoxCamp.Text = modificar.NomCamp;
                TextBoxImatge.Text = modificar.RutaEscut;
            }
        }
    }
}
