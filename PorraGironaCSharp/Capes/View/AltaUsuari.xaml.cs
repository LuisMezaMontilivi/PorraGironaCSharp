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
    /// Lógica de interacción para AltaUsuari.xaml
    /// </summary>
    public partial class AltaUsuari : UserControl
    {
        public AltaUsuari()
        {
            InitializeComponent();
        }

        private void ButtonAltaUsuari_Click(object sender, RoutedEventArgs e)
        {
            string rol;
            if ((bool)radioButtonPorrista.IsChecked)
                rol = "user";
            else
                rol = "admin";

            Usuari alta = new Usuari(textBoxNom.Text,textBoxCognom.Text,textBoxNif.Text,textBoxAlias.Text,passwordBoxContrasenya.Password,rol);
            try
            {
                alta.AfegirABaseDades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            
        }
    }
}
