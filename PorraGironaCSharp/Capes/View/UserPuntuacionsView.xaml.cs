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
    /// Lógica de interacción para UserPuntuacionsView.xaml
    /// </summary>
    public partial class UserPuntuacionsView : UserControl
    {
        private Porristes porristes;
        private string alias;
        //private Partit ultim;
        //private Partit anterior;
        private List<Porrista> llistaPorristes;

        public UserPuntuacionsView(string alias)
        {
            InitializeComponent();
            this.alias = alias;
            porristes = new Porristes();

            List<Porrista> llistaPorristes = porristes.RecuperarPorristes();
            porristes.AfegirPosicions(llistaPorristes);
            porristes.OrdenarPerPosicions(ref llistaPorristes);



            BindGrid(llistaPorristes);



        }
        //Constructor de 1er Click des de principal
        //public UserPuntuacionsView(string alias, Partit ultim, Partit anterior)
        //{
        //    InitializeComponent();
        //    this.alias = alias;
        //    porristes = new Porristes();

        //    llistaPorristes = porristes.RecuperarPorristes();

        //    BindGrid(llistaPorristes);

        //    this.ultim = ultim;
        //    this.anterior = anterior;


        //}

        //Constructor més tard
        //public UserPuntuacionsView(string alias, Partit ultim, Partit anterior, List<Porrista> llistaPorristes)
        //{
        //    InitializeComponent();
        //    this.alias = alias;
        //    this.ultim = ultim;
        //    this.anterior = anterior;
        //    this.llistaPorristes = llistaPorristes;
        //    BindGrid(llistaPorristes);

        //    //Afegir després pel tema històric


        //}





        private void BindGrid(List<Porrista> llistaPorristes)
        {
            DataGridPuntuacions.ItemsSource = llistaPorristes;
        }


    }
}
