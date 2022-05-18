using MahApps.Metro.Controls;
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

        private void BotoLoginUser_Click(object sender, RoutedEventArgs e)
        {
            PaginaUser pus = new PaginaUser();
            pus.Owner = this;
            this.Hide();
            pus.ShowDialog();
        }

        private void BotoLoginAdmin_Click(object sender, RoutedEventArgs e)
        {
            PaginaAdmin pad = new PaginaAdmin();
            pad.Owner = this;
            this.Hide();
            pad.ShowDialog();
        }
    }
}
