using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorraGironaCSharp.Core;

namespace PorraGironaCSharp.Capes.ViewModel
{
    class AdminPrincipalVM : ObservableObject
    {
        public RelayCommand UltimPartitComanda { get; set; }

        public UltimPartitViewModel UltimVm { get; set; }


        private object vistaActual;

        public object CurrentView
        {
            get { return vistaActual; }
            set
            {
                vistaActual = value;
                OnPropertyChanged();
            }
        }

        public AdminPrincipalVM()
        {
            UltimVm = new UltimPartitViewModel();
            CurrentView = UltimVm;
            UltimPartitComanda = new RelayCommand(o => { CurrentView = UltimVm; });
        }
    }
}
