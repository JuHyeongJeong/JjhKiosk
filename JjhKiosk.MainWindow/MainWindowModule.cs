using JjhKiosk.Login.Views;
using JjhKiosk.Main.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;


namespace JjhKiosk.MainWindow
{
    public class MainWindowModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //IRegion region = regionManager.Regions["ContentRegion"];
            //region.Add(containerProvider.Resolve<JjhKiosk.Main.Views.Main>());
            //
            //foreach (var view in region.Views)
            //{
            //    System.Diagnostics.Debug.WriteLine($"View found in region: {view.GetType().Name}");
            //}

            regionManager.RequestNavigate("ContentRegion", "LoginView");

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}