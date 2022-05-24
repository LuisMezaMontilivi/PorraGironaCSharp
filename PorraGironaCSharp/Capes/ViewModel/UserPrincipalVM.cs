using System;
using PorraGironaCSharp.Core;

namespace PorraGironaCSharp.Capes.ViewModel
{
    class UserPrincipalVM : ObservableObject
    {

        public ContingutUserVM propContingutUserVM;
        public UserPuntuacionsVM userPuntuacionsVM;
        private object _currentView;


        public RelayCommand PuntuacionsCommanda { get; set; }
        public RelayCommand ContingutsCommanda { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public UserPrincipalVM()
        {
            //propContingutUserVM = new ContingutUserVM();
            //userPuntuacionsVM = new UserPuntuacionsVM();
            //_currentView = propContingutUserVM;
            //ContingutsCommanda = new RelayCommand(o => { CurrentView = propContingutUserVM; });
            //PuntuacionsCommanda = new RelayCommand(o => { CurrentView = userPuntuacionsVM; });




        }



    }
}
