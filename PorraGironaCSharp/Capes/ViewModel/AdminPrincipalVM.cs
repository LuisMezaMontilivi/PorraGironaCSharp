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

        public RelayCommand AltesComanda { get; set; }

        public RelayCommand BaixesComanda { get; set; }

        public UltimPartitViewModel UltimVm { get; set; }

        public AltesViewModel AltesVm { get; set; }

        public BaixesViewModel BaixesVm { get; set; }

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
            AltesVm = new AltesViewModel();
            UltimVm = new UltimPartitViewModel();
            BaixesVm = new BaixesViewModel();
            CurrentView = UltimVm;
            UltimPartitComanda = new RelayCommand(o => { CurrentView = UltimVm; });
            AltesComanda = new RelayCommand(o => { CurrentView = AltesVm; });
            BaixesComanda = new RelayCommand(o => { CurrentView = BaixesVm; });
        }
    }
}
