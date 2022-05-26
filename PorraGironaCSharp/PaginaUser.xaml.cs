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
using PorraGironaCSharp.Capes.Model;
using PorraGironaCSharp.Capes.View;
using PorraGironaCSharp.Capes.ViewModel;

namespace PorraGironaCSharp
{
    /// <summary>
    /// Lógica de interacción para PaginaUser.xaml
    /// </summary>
    public partial class PaginaUser : Window
    {

        private string alias ;
        private Partit ultim;
        private Partit anterior;
        private List<Porrista> llistaPorristes;


        public PaginaUser()
        {
            InitializeComponent();
        }
        public PaginaUser(string alias)
        {
            this.alias = alias;
            InitializeComponent();
            labelUsuari.Content = this.alias;
            FramePrincipal.Content = new UsuariPrincipalView(alias);

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

        private void NavButtonPrincipal_Click(object sender, RoutedEventArgs e)
        {

            var ClickedButton = e.OriginalSource as NavButton;

            FramePrincipal.Content = new UsuariPrincipalView(alias);
            //FramePrincipal.Content = ClickedButton.NavUri;

            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(ClickedButton.NavUri);
        }

        private void NavButtonPuntuacions_Click(object sender, RoutedEventArgs e)
        {
            var ClickedButton = e.OriginalSource as NavButton;
            FramePrincipal.Content = new UserPuntuacionsView(alias);

        }
        private void NavButtonHistoric_Click(object sender, RoutedEventArgs e)
        {
            var ClickedButton = e.OriginalSource as NavButton;
            FramePrincipal.Content = new UserHistoric(alias);

        }
    }
}
