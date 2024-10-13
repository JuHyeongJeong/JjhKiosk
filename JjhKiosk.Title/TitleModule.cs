using JjhKiosk.Title;
using JjhKiosk.Title.UI.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;

namespace JjhKiosk.Title
{
    public class TitleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //IRegion region = regionManager.Regions["TitleRegion"];
            //region.Add(containerProvider.Resolve<MainView>());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}