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
    /// Lógica de interacción para ActualitzacioUsuari.xaml
    /// </summary>
    public partial class ActualitzacioUsuari : UserControl
    {
        Usuaris usuaris;
        public ActualitzacioUsuari(Usuaris u)
        {
            InitializeComponent();
            usuaris = u;
            LlistarUsuaris();
        }

        private void LlistarUsuaris()
        {
            usuaris = new Usuaris();
            foreach (string X in usuaris.AliesUsuaris())
            {
                comboBoxUsuari.Items.Add(X);
            }
        }

        private void ButtonModUsuari_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuari modificar = usuaris.RecuperarUsuari(comboBoxUsuari.SelectedIndex);
                if(passwordBoxContrasenya.Password != "")
                    modificar.contrasenya = passwordBoxContrasenya.Password;
                modificar.nom = textBoxNom.Text;
                modificar.cognom = textBoxCognom.Text;
                modificar.nif = textBoxNif.Text;
                usuaris.ActualitzarUsuari(modificar);
                MessageBox.Show("S'ha modificat correctament");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBoxUsuari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (comboBoxUsuari.Text != "")
                {
                    Usuari modificar = usuaris.RecuperarUsuari(comboBoxUsuari.SelectedIndex);
                    textBoxNom.Text = modificar.nom;
                    textBoxCognom.Text = modificar.cognom;
                    textBoxNif.Text = modificar.nif;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
