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
        public MainWindow()
        {
            InitializeComponent();
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
            Usuari usuari = new Usuari(alias,contrasenya);
            string prova= usuari.Verificar(alias, contrasenya);
            if(alias=="" || contrasenya == "")
            {
                LabelsLogin();
            }
            else if (prova == "user")
            {
                PaginaUser pus = new PaginaUser();
                pus.Owner = this;
                this.Hide();
                pus.ShowDialog();
            }
            else if(prova == "admin")
            {
                PaginaAdmin pad = new PaginaAdmin();
                pad.Owner = this;
                this.Hide();
                pad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuari o Contrasenya Introduit Incorrectament");
                LoginUsuari.Text = null; LoginContrasenya.Text = null; LoginUsuari.Focus();
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


    }
}
