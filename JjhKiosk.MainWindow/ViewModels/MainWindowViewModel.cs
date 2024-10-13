using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JjhKiosk.MainWindow.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            //regionManager.RequestNavigate("ContentRegion", "MainView");

            //var region = regionManager.Regions["ContentRegion"];
            //foreach (var view in region.Views)
            //{
            //    System.Diagnostics.Debug.WriteLine($"View found in region: {view.GetType().Name}");
            //}
        }
    }
}
