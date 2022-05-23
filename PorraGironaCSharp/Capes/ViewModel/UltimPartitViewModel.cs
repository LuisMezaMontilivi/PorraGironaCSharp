using PorraGironaCSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.ViewModel
{
    class UltimPartitViewModel : ObservableObject
    {
        public RelayCommand AltaEquipComanda { get; set; }

        public RelayCommand AltaUsuariComanda { get; set; }

        public AltaEquipViewModel AltaEquipVm { get; set; }

        public AltaUsuariViewModel AltaUsuariVm { get; set; }

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

        public UltimPartitViewModel()
        {
            AltaEquipVm = new AltaEquipViewModel();
            AltaUsuariVm = new AltaUsuariViewModel();
            CurrentView = AltaUsuariVm;
            AltaUsuariComanda = new RelayCommand(o => { CurrentView = AltaUsuariVm; });
            AltaEquipComanda = new RelayCommand(o => { CurrentView = AltaEquipVm; });
        }
    }
}
