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
    /// Lógica de interacción para AltaEquip.xaml
    /// </summary>
    public partial class AltaEquip : UserControl
    {
        Equips equips;

        public AltaEquip()
        {
            InitializeComponent();
            equips = new Equips();
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

        private void ButtonCrearEquip_Click(object sender, RoutedEventArgs e)
        {
            Equip insertar = new Equip(24, TextBoxEquip.Text, TextBoxMunicipi.Text, TextBoxCamp.Text, TextBoxImatge.Text);
            if (equips.AfegirEquip(insertar))
            {
                MessageBox.Show("Equip insertat amb éxit");
            }
            else
            {
                MessageBox.Show("No s'ha pogut insertat");
            }
        }
    }
}
