using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<JjhKiosk.Main.Views.Main>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
