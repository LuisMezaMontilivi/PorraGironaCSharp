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
        Usuaris usuaris;
        public AltaUsuari(Usuaris u)
        {
            InitializeComponent();
            usuaris = u;
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
                //el codi desitjat, però que no funciona pas, error referència objecte, ni idea perquè només posant el métode de UsuariBD.Insertarusuari a la classe Usuaris falla
                //if (usuaris.AfegirUsuari(alta))
                //    MessageBox.Show("Usuari afegit amb èxit");
                //else
                //    MessageBox.Show("Usuari no afegit, revisa les dades");
                DataBase.UsuariBD.InsertarUsuariBD(alta);
                MessageBox.Show("Usuari insertat correctament");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
