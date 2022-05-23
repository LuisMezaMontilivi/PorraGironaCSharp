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
    /// Lógica de interacción para Puntuacions.xaml
    /// </summary>
    public partial class Puntuacions : Window
    {
        private string alias = "user";
        public Puntuacions()
        {
            InitializeComponent();
        }
        public Puntuacions(string alias)
        {
            this.alias = alias;
            labelUsuari.Content = alias;
            InitializeComponent();

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void ButtonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void RadioButton_Checked_Principal(object sender, RoutedEventArgs e)
        {
            PaginaUser FinestraPaginaUser = new PaginaUser();
            FinestraPaginaUser.Owner = this;
            this.Hide();
            FinestraPaginaUser.ShowDialog();

        }

        private void RadioButton_Checked_Puntuacions(object sender, RoutedEventArgs e)
        {
            Puntuacions FinestraPuntuacions = new Puntuacions();
            FinestraPuntuacions.Owner = this;
            this.Hide();
            FinestraPuntuacions.ShowDialog();
        }
        private void RadioButton_Checked_Historic(object sender, RoutedEventArgs e)
        {
            Historic FinestraHistoric = new Historic();
            FinestraHistoric.Owner = this;
            this.Hide();
            FinestraHistoric.ShowDialog();
        }
        private void RadioButton_Checked_Donacions(object sender, RoutedEventArgs e)
        {

        }

    }
}
