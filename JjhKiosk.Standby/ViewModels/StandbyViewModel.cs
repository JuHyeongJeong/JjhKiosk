using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JjhKiosk.Standby.ViewModels
{
    public interface IStandbyViewModel { }
    public class StandbyViewModel : BindableBase, IStandbyViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> TakeTypeSelectionCommand { get; init; }
        public StandbyViewModel(IRegionManager regionManager)
        {
            TakeTypeSelectionCommand = new DelegateCommand<string>(TakeTypeSelection);
            this._regionManager = regionManager;
        }

        private void TakeTypeSelection(string obj)
        {
            _regionManager.RequestNavigate("ContentRegion", "MenuView");
        }
    }
}
