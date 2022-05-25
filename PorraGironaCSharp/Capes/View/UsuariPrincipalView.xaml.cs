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
        private string alias;

        private Partit darrerPartit;
        private Partits partits;

        public UsuariPrincipalView(string alias)
        {
            InitializeComponent();
            this.alias = alias;
            //darrerPartit = new Partit();
            


            porra = new Porra();
            

            

        }

        //private Partit CarregarUltimPartit()
        //{
        //    Partit ultim = partits.


        //}








        private void IncrementarLocal_Click(object sender, RoutedEventArgs e)
        {
            int gols = porra.PrevisioGolsLocal;
            gols += 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsLocal = gols;
            TextBGolsLocalActual.Text = porra.PrevisioGolsLocal.ToString();
        }

        private void DisminuirLocal_Click(object sender, RoutedEventArgs e)
        {
           
            int gols = porra.PrevisioGolsLocal;
            gols -= 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsLocal = gols;
            TextBGolsLocalActual.Text = porra.PrevisioGolsLocal.ToString();
        }

        private void DisminuirVisitant_Click(object sender, RoutedEventArgs e)
        {
            int gols = porra.PrevisioGolsVisitant;
            gols += 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsVisitant = gols;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();
        }

        private void IncrementarVisitant_Click(object sender, RoutedEventArgs e)
        {
            int gols = porra.PrevisioGolsVisitant;
            gols -= 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsVisitant = gols;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();
        }

       private void ComprovaGols(ref int input)
        {
            if(input > 99) { input = 0; }
            else if (input < 0) { input = 99; }

        }

        
    }
}
