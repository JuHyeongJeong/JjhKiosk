using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace JjhKiosk.Menu.ViewModels
{
    public class MenuViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand LoadedCommand { get; private set; }
        public MenuViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            LoadedCommand = new DelegateCommand(OnLoaded);
            this._regionManager = regionManager;
        }


        //MenuView의 초기화부분
        private void OnLoaded()
        {
            _regionManager.RequestNavigate("TitleRegion", "BannerView");
        }
    }
}
