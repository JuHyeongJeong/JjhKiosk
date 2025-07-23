using JjhKiosk.DB.Server.EF.Core.Context;
using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using JjhKiosk.Login.ViewModels;
using JjhKiosk.Login.Views;
using JjhKiosk.MainWindow;
using JjhKiosk.MainWindow.Views;
using JjhKiosk.Menu;
using JjhKiosk.Menu.ViewModels;
using JjhKiosk.Menu.Views;
using JjhKiosk.MenuCategory;
using JjhKiosk.MenuCategory.ViewModels;
using JjhKiosk.MenuCategory.Views;
using JjhKiosk.MenuList;
using JjhKiosk.MenuList.ViewModels;
using JjhKiosk.MenuList.Views;
using JjhKiosk.Standby.ViewModels;
using JjhKiosk.Standby.Views;
using JjhKiosk.SubMenu.ViewModels;
using JjhKiosk.SubMenu.Views;
using JjhKiosk.Support.Interface;
using JjhKiosk.Support.Model;
using JjhKiosk.Title;
using JjhKiosk.Title.UI.Views;
using JjhKiosk.Title.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Windows;

namespace JjhKiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly IConfigurationRoot _config;
        public App()
        {
            #region call config
            var configurationBuilder = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            _config = configurationBuilder;
            #endregion
        }
        protected override Window CreateShell()
        {
            #region Shell
            var mainWindow = Container.Resolve<JjhKiosk.MainWindow.Views.MainWindow>();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            return mainWindow;
            #endregion
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region RegisterInstance and Navigation
            containerRegistry.RegisterSingleton<LoginAccount>();
            containerRegistry.RegisterSingleton<ObservableCollection<MenuItem>>();
            containerRegistry.RegisterInstance<IConfiguration>(_config);
            containerRegistry.RegisterSingleton<ILoginView, LoginView>();
            containerRegistry.RegisterSingleton<IMenuView, MenuView>();
            containerRegistry.RegisterSingleton<IStandbyView, StandbyView>();
            containerRegistry.RegisterSingleton<IBannerView, BannerView>();
            containerRegistry.RegisterSingleton<IMenuListView, MenuListView>();
            containerRegistry.RegisterSingleton<ICategoryListView, CategoryListView>();
            containerRegistry.RegisterSingleton<ISubMenuView, SubMenuView>();
            //containerRegistry.RegisterSingleton<JjhKioskDbContext, MySqlContext>();
            containerRegistry.Register<ILoginViewModel, LoginViewModel>();
            containerRegistry.Register<IMenuViewModel, MenuViewModel>();
            containerRegistry.Register<IStandbyViewModel, StandbyViewModel>();
            containerRegistry.Register<IBannerViewModel, BannerViewModel>();
            containerRegistry.Register<IMenuListViewModel, MenuListViewModel>();
            containerRegistry.Register<ICategoryListViewModel, CategoryListViewModel>();
            containerRegistry.Register<ISubMenuViewModel, SubMenuViewModel>();
            containerRegistry.RegisterForNavigation<LoginView, ILoginViewModel>("LoginView");
            containerRegistry.RegisterForNavigation<MenuView, IMenuViewModel>("MenuView");
            containerRegistry.RegisterForNavigation<StandbyView, IStandbyViewModel>("StandbyView");
            containerRegistry.RegisterForNavigation<BannerView, IBannerViewModel>("BannerView");
            containerRegistry.RegisterForNavigation<MenuListView, IMenuListViewModel>("MenuListView");
            containerRegistry.RegisterForNavigation<CategoryListView, ICategoryListViewModel>("MenuCategoryView");
            containerRegistry.RegisterForNavigation<SubMenuView, ISubMenuViewModel>("SubMenuView");
            #endregion
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            #region RegisterModule
            moduleCatalog.AddModule<MainWindowModule>();
            //moduleCatalog.AddModule<TitleModule>();
            //moduleCatalog.AddModule<MenuViewModule>();
            //moduleCatalog.AddModule<MenuListModule>();
            //moduleCatalog.AddModule<MenuCategoryModule>();
            #endregion
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            #region View_ViewModel_Connection
            //ViewModelLocationProvider.Register<BannerView, BannerViewModel>();
            //ViewModelLocationProvider.Register<ILoginView, ILoginViewModel>();
            //ViewModelLocationProvider.Register<StandbyView, StandbyViewModel>();
            //ViewModelLocationProvider.Register<MenuListView, MenuListViewModel>();
            ViewModelLocationProvider.Register<BannerControl1, BannerControl1ViewModel>();
            ViewModelLocationProvider.Register<BannerControl2, BannerControl2ViewModel>();
            ViewModelLocationProvider.Register<BannerControl3, BannerControl3ViewModel>();
            #endregion
        }
    }

}
