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
        public UltimPartitView()
        {
            InitializeComponent();
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
    }
}
