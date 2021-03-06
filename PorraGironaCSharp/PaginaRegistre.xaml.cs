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
using System.Windows.Shapes;

namespace PorraGironaCSharp
{
    /// <summary>
    /// Lógica de interacción para PaginaRegistre.xaml
    /// </summary>
    public partial class PaginaRegistre : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        public PaginaRegistre()
        {
            InitializeComponent();
        }

        private void BotoMinimitzar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BotoTancar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BotoTornar_Click(object sender, RoutedEventArgs e)
        {
            TornarPantallaMenu();
        }
        public void TornarPantallaMenu()
        {
            MainWindow pp = new MainWindow();
            pp.Owner = this;
            this.Hide();
            pp.ShowDialog();
        }

        private void BotoRegistrarUsuari_Click(object sender, RoutedEventArgs e)
        {
            bool correcte;
            
            string nom=TextBoxNom.Text, cognom=TextBoxCogom.Text, nif=TextBoxDNI.Text, alias = TextBoxAlias.Text, contrasenya = TextBoxContrasenya.Password, confirmarContrasenya=TextBoxConfirmarContrasenya.Password;
            if (confirmarContrasenya != contrasenya)
            {
                MessageBox.Show("Error Dades Introduïdes Incorrectament");
            }
            else
            {
                Usuari usuari = new Usuari(nom, cognom, nif, alias, contrasenya);
                correcte = usuari.Afegir(nom, cognom, nif, alias, contrasenya);
                if (correcte)
                {
                    MessageBox.Show("Usuari Introduït Correctament");
                    TornarPantallaMenu();
                }
                else
                {
                    MessageBox.Show("ERROR Usuari No Valid");
                }
            }
            
        }
    }
}
