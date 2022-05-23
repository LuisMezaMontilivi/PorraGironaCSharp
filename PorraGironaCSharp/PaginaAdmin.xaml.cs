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
using MahApps.Metro.Controls;
using PorraGironaCSharp.Capes.Model;

namespace PorraGironaCSharp
{
    /// <summary>
    /// Lógica de interacción para PaginaAdmin.xaml
    /// </summary>
    public partial class PaginaAdmin : Window
    {
        private Equips equips;
        private string alias;
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public PaginaAdmin()

        public PaginaAdmin(string alias)
        {
            this.alias = alias;
            InitializeComponent();
            equips = new Equips();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void ButtonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
