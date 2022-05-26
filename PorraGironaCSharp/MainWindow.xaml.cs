using MahApps.Metro.Controls;
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

namespace PorraGironaCSharp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Color original1;
        Color original2;
        public MainWindow()
        {
            InitializeComponent();
           original1 = Color1.Color;
           original2 = Color2.Color;
        }
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
        private void BotoLoginUser_Click(object sender, RoutedEventArgs e)
        {
            string alias = LoginUsuari.Text, contrasenya = LoginContrasenya.Password;
            if (alias == "" || contrasenya == "")
            {
                LabelsLogin();
            }
            else if (alias == "Sonic" && contrasenya == "genesis")
            {
                System.Diagnostics.Process.Start("https://www.retrogames.cz/play_117-Genesis.php");
            }
            else
            {
                Usuari usuari = new Usuari(alias, contrasenya);
                string prova = usuari.Verificar(alias, contrasenya);


                if (prova == "user")
                {

                    PaginaUser FinestraPaginaUser = new PaginaUser(alias);
                    FinestraPaginaUser.Owner = this;

                    this.Hide();
                    FinestraPaginaUser.ShowDialog();
                }
                else if (prova == "admin")
                {
                    PaginaAdmin pad = new PaginaAdmin(alias);
                    pad.Owner = this;
                    this.Hide();
                    pad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuari o Contrasenya Introduit Incorrectament");
                    LoginUsuari.Text = null; LoginContrasenya.Text = null; LoginUsuari.Focus();
                }
            }
           

            //Protitip De la idea Inicial (Erronea)
            //if(Select rol from usuari where alias = LoginUsuari.text and contrasenya = LoginContrasenya.Text ==null) //Aqui Comprovem que la contrasenya estigui be
            //{
            //string rol = select rol from usuari where where alias = LoginUsuari.text; 
            //if(rol == "user")
            //  Anem a Pagina USER
            //if(rol == "admin")
            //  Anem a Pagina Admin
            //}
            //else
            //MessageBox.Show("Usuari o Contrasenya Incorrectes);
        }
        public void LabelsLogin()
        {
            if (LoginUsuari.Text == "")
            {
                LabelNoLogin.Content = "Siusplau introdueix un usuari";
            }
            else if (LoginUsuari.Text != "")
            {
                LabelNoLogin.Content = "";
            }

            if (LoginContrasenya.Text == "")
            {
                LabelNoContrasenya.Content = "Siusplau introdueix una contrasenya";
            }
            else if (LoginContrasenya.Text != "")
            {
                LabelNoContrasenya.Content = "";
            }
        }

        private void BotoToolbarTancar_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BotoToolbarMinimitzar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void BotoRegister_Click(object sender, RoutedEventArgs e)
        {
            PaginaRegistre pr = new PaginaRegistre();
            pr.Owner = this;
            this.Hide();
            pr.ShowDialog();
        }

        private void BotoToolbarModeNit_Click(object sender, RoutedEventArgs e)
        {
            
            Color negre = Color3Negre.Color;
            Color blanc = Color2.Color;

            if (BotoToolbarModeNit.Name == "BotoToolbarModeNit")
            {
                
                Color1.Color = blanc;
                Color2.Color = negre;
                BotoToolbarModeNit.Name = "Canvi";
                
            }
            else if(BotoToolbarModeNit.Name == "Canvi")
            {
               

                Color1.Color = original1;
                Color2.Color = original2;
                BotoToolbarModeNit.Name = "BotoToolbarModeNit";
            }
               
        }
    }
}
