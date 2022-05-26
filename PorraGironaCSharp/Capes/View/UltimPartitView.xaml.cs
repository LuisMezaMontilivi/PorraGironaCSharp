using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para UltimPartitView.xaml
    /// </summary>
    public partial class UltimPartitView : UserControl
    {
        Partits partits;
        public UltimPartitView()
        {
            InitializeComponent();
            partits = new Partits();
            CarregarUltimPartit();
            //MessageBox.Show(partits.LlistarPartits()[0].Estat);
            //Proves();
        }

        private void Proves()
        {   //Esto es para testear las clases, funka ya
            Equip local = new Equip(1, "San Pep", "Figueres", "Co co", "/Images/EscutAlcorcon.png");
            Equip visitant = new Equip(2, "F Sota", "Girona", "Fu fu", "/Images/EscutAlmeria.png");
            DateTime hola = DateTime.Now;
            Partit prova = new Partit("Per Jugar", local, visitant, hola);

            textBlockLocal.Text = prova.EquipLocal.NomCamp;//prova.EquipLocal.NomEquip
            textBlockVisitant.Text = prova.EquipVisitant.NomCamp;//prova.EquipVisitant.NomEquip
            textBlockData.Text = Convert.ToString(prova.Data);
            imageLocal.Source = new BitmapImage(new Uri(prova.EquipLocal.RutaEscut, UriKind.Relative));
            imageVisitant.Source = new BitmapImage(new Uri(prova.EquipVisitant.RutaEscut, UriKind.Relative));
        }

        private void CarregarUltimPartit()
        {
            Partit ultim = partits.RecuperarUltimPartitNoJugat();
            if (!(ultim is null))
            {
                textBlockLocal.Text = ultim.EquipLocal.NomCamp;//prova.EquipLocal.NomEquip
                textBlockVisitant.Text = ultim.EquipVisitant.NomCamp;//prova.EquipVisitant.NomEquip
                textBlockData.Text = Convert.ToString(ultim.Data);
                imageLocal.Source = new BitmapImage(new Uri(ultim.EquipLocal.RutaEscut, UriKind.Relative));
                imageVisitant.Source = new BitmapImage(new Uri(ultim.EquipVisitant.RutaEscut, UriKind.Relative));
                textBlockTitol.Text = "Següent";
            }
            else
            {
                textBlockNoExisteix.Text = "No hi ha cap partit pendent";
                DeshabilitarEdicions();
            }
        }

        private void DeshabilitarEdicions()
        {
            TextBoxPuntsLocal.IsEnabled = TextBoxPuntsVisitant.IsEnabled = buttonFinalitzarPartit.IsEnabled = ButtonAugmentarLocal.IsEnabled = ButtonAugmentarVisitant.IsEnabled = ButtonDisminuirLocal.IsEnabled = ButtonDisminuirVisitant.IsEnabled = false;
        }

        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        private void PasteNumericValidation(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String input = (String)e.DataObject.GetData(typeof(String));
                if (new Regex("[^0-9]+").IsMatch(input))
                {
                    e.CancelCommand();
                }
            }
            else e.CancelCommand();
        }

        private void ButtonAugmentarLocal_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPuntsLocal.Text == "")
                TextBoxPuntsLocal.Text = "0";
            TextBoxPuntsLocal.Text = (Convert.ToInt32(TextBoxPuntsLocal.Text) + 1).ToString();
        }

        private void ButtonDisminuirLocal_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPuntsLocal.Text == "")
                TextBoxPuntsLocal.Text = "0";
            if (TextBoxPuntsLocal.Text != "0")
                TextBoxPuntsLocal.Text = (Convert.ToInt32(TextBoxPuntsLocal.Text) - 1).ToString();
        }

        private void ButtonAugmentarVisitant_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPuntsVisitant.Text == "")
                TextBoxPuntsVisitant.Text = "0";
            TextBoxPuntsVisitant.Text = (Convert.ToInt32(TextBoxPuntsVisitant.Text) + 1).ToString();
        }

        private void ButtonDisminuirVisitant_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPuntsVisitant.Text == "")
                TextBoxPuntsVisitant.Text = "0";
            if (TextBoxPuntsVisitant.Text != "0")
                TextBoxPuntsVisitant.Text = (Convert.ToInt32(TextBoxPuntsVisitant.Text) - 1).ToString();
        }

        private void buttonFinalitzarPartit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Partit ultim = partits.RecuperarUltimPartitNoJugat();
                ultim.ActualitzarMarcador(Convert.ToInt32(TextBoxPuntsLocal.Text),Convert.ToInt32(TextBoxPuntsVisitant.Text));
                ultim.CanviarEstat("Acabat");
                Porres porres = new Porres();
                porres.ActualitzarResultatsPorra(ultim);
                ultim.EnviarCanvis();
                DeshabilitarEdicions();
                MessageBox.Show("S'ha acabat el partit.");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
