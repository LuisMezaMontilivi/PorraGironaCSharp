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
        private Porrista Porrista;
        //List<Porrista> llistaPorristes;
        
        private Partit ultim;
        private Partit anterior;
        private Partits partits;

        //Primer click
        public UsuariPrincipalView(string alias)
        {
            InitializeComponent();
            this.alias = alias;
            

            ultim = CarregarUltimPartit();
            anterior = CarregarAnteriorPartit();

            Porrista = new Porrista();
            porra = new Porra( );

        }

        //Click sobre si mateix
        //public UsuariPrincipalView(string alias, Partit ultim, Partit anterior)
        //{
        //    InitializeComponent();
        //    this.alias = alias;
        //    this.ultim = ultim;
        //    this.anterior = anterior;
        //    CarregarAnteriorPartit();
        //    CarregarUltimPartit();


        //}

        //2on Click extern


        //public UsuariPrincipalView(string alias, Partit ultim, Partit anterior, List<Porrista> llistaPorristes)
        //{
        //    InitializeComponent();
        //    this.alias = alias;
        //    this.ultim = ultim;
        //    this.anterior = anterior;
        //    this.llistaPorristes = llistaPorristes;
        //    CarregarAnteriorPartit();
        //    CarregarUltimPartit();


        //}





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

        private void ConfigurarUltimPartit()
        {
            ImatgeLocalSeguent.Source = new BitmapImage(new Uri(ultim.EquipLocal.RutaEscut, UriKind.Relative));
            ImatgeVisitantSeguent.Source = new BitmapImage(new Uri(ultim.EquipVisitant.RutaEscut, UriKind.Relative));
            NomLocalSeguent.Text = ultim.EquipLocal.NomEquip;
            NomVisitantSeguent.Text = ultim.EquipVisitant.NomEquip;
            DataPartitSeguent.Text = ultim.Data.ToString();

        }

        private Partit CarregarAnteriorPartit()
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

            return anterior;
        }

        private void ConfigurarAnteriorPartit()
        {
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
            gols -= 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsVisitant = gols;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();
        }

        private void IncrementarVisitant_Click(object sender, RoutedEventArgs e)
        {
            int gols = porra.PrevisioGolsVisitant;
            gols += 1;
            ComprovaGols(ref gols);
            porra.PrevisioGolsVisitant = gols;
            TextBGolsVisitantActual.Text = porra.PrevisioGolsVisitant.ToString();
        }

       private void ComprovaGols(ref int input)
        {
            if(input > 99) { input = 0; }
            else if (input < 0) { input = 99; }

        }

        private void EnviarPorraButton_Click(object sender, RoutedEventArgs e)
        {
            porra.Partit = ultim;
            porra.PrevisioGolsLocal = int.Parse(TextBGolsLocalActual.Text);
            porra.PrevisioGolsVisitant = int.Parse(TextBGolsVisitantActual.Text);

            Porrista.FerPrediccio(porra, alias);

        }
    }
}
