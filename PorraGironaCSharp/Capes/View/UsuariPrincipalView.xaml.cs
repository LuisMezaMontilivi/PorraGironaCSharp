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
            

            darrerPartit = CarregarUltimPartit();
            CarregarAnteriorPartit();

            porra = new Porra();
            

            

        }

        private Partit CarregarUltimPartit()
        {
            Partits partits = new Partits();

            Partit ultim = partits.RecuperarUltimPartitNoJugat();
            ImatgeLocalSeguent.Source = new BitmapImage(new Uri(ultim.EquipLocal.RutaEscut, UriKind.Relative));
            ImatgeVisitantSeguent.Source =  new BitmapImage(new Uri(ultim.EquipVisitant.RutaEscut, UriKind.Relative));
            NomLocalSeguent.Text = ultim.EquipLocal.NomEquip;
            NomVisitantSeguent.Text = ultim.EquipVisitant.NomEquip;
            DataPartitSeguent.Text = ultim.Data.ToString();

            return ultim;
        }

        private void CarregarAnteriorPartit()
        {
            Partits partits = new Partits();

            Partit anterior = partits.RecuperarUltimPartitJugat();
            ImatgeLocalAnterior.Source = new BitmapImage(new Uri(anterior.EquipLocal.RutaEscut, UriKind.Relative));
            ImatgeVisitantAnterior.Source = new BitmapImage(new Uri(anterior.EquipVisitant.RutaEscut, UriKind.Relative));
            NomLocalAnterior.Text = anterior.EquipLocal.NomEquip;
            NomVisitantSeguent.Text = anterior.EquipVisitant.NomEquip;
            DataPartitAnterior.Text = anterior.Data.ToString();
            TextBGolsLocalAnterior.Text = anterior.GolsLocal.ToString();
            TextBGolsVisitantAnterior.Text = anterior.GolsVisitant.ToString();


        }







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
