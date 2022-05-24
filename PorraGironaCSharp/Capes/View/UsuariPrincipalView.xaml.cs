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
    /// Lógica de interacción para UsuariPrincipalView.xaml
    /// </summary>
    public partial class UsuariPrincipalView : UserControl
    {
        private Porra porra;
        private Porrista porrista;
        private Porristes porristes;
        public UsuariPrincipalView()
        {
            InitializeComponent();
            porra = new Porra();
            porristes = new Porristes();
           

        }

        private void IncrementarLocal_Click(object sender, RoutedEventArgs e)
        {
            porra.PrevisioGolsLocal += 1;
            TextBGolsLocalActual.Text = porra.PrevisioGolsLocal.ToString();
        }

        private void DisminuirLocal_Click(object sender, RoutedEventArgs e)
        {
            porra.PrevisioGolsLocal -= 1;
            TextBGolsLocalActual.Text = porra.PrevisioGolsLocal.ToString();
        }

        private void DisminuirVisitant_Click(object sender, RoutedEventArgs e)
        {
            porra.PrevisioGolsVisitant += 1;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();
        }

        private void IncrementarVisitant_Click(object sender, RoutedEventArgs e)
        {
            porra.PrevisioGolsVisitant -= 1;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();

        }

        
    }
}
