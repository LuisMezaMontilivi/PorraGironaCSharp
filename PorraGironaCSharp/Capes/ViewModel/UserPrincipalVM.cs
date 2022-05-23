using System;
using PorraGironaCSharp.Core;

namespace PorraGironaCSharp.Capes.ViewModel
{
    class UserPrincipalVM : ObservableObject
    {

        public ContingutUserVM propContingutUserVM;
        private object _currentView;

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
            propContingutUserVM = new ContingutUserVM();
            _currentView = propContingutUserVM;


        }



    }
}
