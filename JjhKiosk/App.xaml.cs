using JjhKiosk.Title;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
            return Container.Resolve<JjhKiosk.Main.Views.Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IConfiguration>(_config);

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<TitleModule>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }
    }

}
