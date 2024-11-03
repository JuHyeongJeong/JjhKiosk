using JjhKiosk.DB.Server.EF.Core.Context;
using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using JjhKiosk.Login.ViewModels;
using JjhKiosk.Login.Views;
using JjhKiosk.MainWindow;
using JjhKiosk.MainWindow.Views;
using JjhKiosk.Menu;
using JjhKiosk.Menu.Views;
using JjhKiosk.Standby.Views;
using JjhKiosk.Title;
using JjhKiosk.Title.UI.Views;
using JjhKiosk.Title.ViewModels;
using Microsoft.Extensions.Configuration;
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
            var configurationBuilder = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            _config = configurationBuilder;
        }
        protected override Window CreateShell()
        {
            //var mainWindow = Container.Resolve<JjhKiosk.Main.Views.Main>();
            var mainWindow = Container.Resolve<JjhKiosk.MainWindow.Views.MainWindow>();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            return mainWindow;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IConfiguration>(_config);
            containerRegistry.RegisterSingleton<JjhKioskDbContext, MySqlContext>();
            containerRegistry.RegisterForNavigation<LoginView>("LoginView");
            containerRegistry.RegisterForNavigation<MenuView>("MenuView");
            containerRegistry.RegisterForNavigation<StandbyView>("StandbyView");
            containerRegistry.RegisterForNavigation<BannerView>("BannerView");

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainWindowModule>();
            moduleCatalog.AddModule<TitleModule>();
            moduleCatalog.AddModule<MenuViewModule>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<BannerView, BannerViewModel>();
            ViewModelLocationProvider.Register<LoginView, LoginViewModel>();
            ViewModelLocationProvider.Register<StandbyView, LoginViewModel>();
            ViewModelLocationProvider.Register<BannerControl1, BannerControl1ViewModel>();
            ViewModelLocationProvider.Register<BannerControl2, BannerControl2ViewModel>();
            ViewModelLocationProvider.Register<BannerControl3, BannerControl3ViewModel>();
        }
    }

}
