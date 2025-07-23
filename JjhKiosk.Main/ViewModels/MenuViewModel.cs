using JjhKiosk.Support.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Configuration;

namespace JjhKiosk.Menu.ViewModels
{
    public interface IMenuViewModel { }
    public class MenuViewModel : BindableBase, IMenuViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private bool popupFlag = false;
        public bool PopupFlag
        {
            get => popupFlag;
            set => SetProperty(ref popupFlag, value);
        }

        public DelegateCommand LoadedCommand { get; private set; }
        public MenuViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator eventAggregator)
        {
            LoadedCommand = new DelegateCommand(OnLoaded);
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OptionPopupOpenCloseEvent>().Subscribe(OnPopupOpenClose);
        }

        private void OnPopupOpenClose(bool flag)
        {
            PopupFlag = flag;
        }


        //MenuView의 초기화부분
        private void OnLoaded()
        {
            //_regionManager.RequestNavigate("TitleRegion", "BannerView");
            //_regionManager.RequestNavigate("ItemListRegion", "MenuListView");
            //_regionManager.RequestNavigate("CategoryRegion", "MenuCategoryView");
        }
    }
}
