using System;
using PorraGironaCSharp.Core;

namespace PorraGironaCSharp.Capes.ViewModel
{
    class UserPrincipalVM : ObservableObject
    {

        private ContingutUserVM propContingutUserVM;
        public RelayCommand PrincipalCommand { get; set; }

        public RelayCommand PuntuacionsCommand { get; set; }

        private object _currentView;

        private UserPuntuacionsVM userPuntuacionsVM;


        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        internal UserPuntuacionsVM UserPuntuacionsVM { get => userPuntuacionsVM; set => userPuntuacionsVM = value; }
        internal ContingutUserVM PropContingutUserVM { get => propContingutUserVM; set => propContingutUserVM = value; }

        public UserPrincipalVM()
        {
            PropContingutUserVM = new ContingutUserVM();
            _currentView = PropContingutUserVM;
            UserPuntuacionsVM = new UserPuntuacionsVM();

            PrincipalCommand = new RelayCommand(o => { CurrentView = propContingutUserVM; });
            PuntuacionsCommand = new RelayCommand(o => { CurrentView = userPuntuacionsVM; });

        }



    }
}
