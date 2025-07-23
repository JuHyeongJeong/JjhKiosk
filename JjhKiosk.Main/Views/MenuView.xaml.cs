using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JjhKiosk.Menu.Views
{
    public interface IMenuView{ }
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuView : UserControl, IMenuView
    {
        public MenuView(IRegionManager regionManager)
        {
            InitializeComponent();
            Prism.Mvvm.ViewModelLocator.SetAutoWireViewModel(this, true);

            RegionManager.SetRegionManager(this, regionManager);
            RegionManager.SetRegionName(TitleRegion, "TitleRegion");
            RegionManager.SetRegionName(CategoryRegion, "CategoryRegion");
            //RegionManager.SetRegionName(OptionRegion, "OptionRegion");
            RegionManager.SetRegionName(ItemListRegion, "ItemListRegion");
            RegionManager.SetRegionName(OrderRegion, "OrderRegion");
            RegionManager.SetRegionName(SubMenuRegion, "SubMenuRegion");
            regionManager.RequestNavigate("TitleRegion", "BannerView");
            regionManager.RequestNavigate("ItemListRegion", "MenuListView");
            regionManager.RequestNavigate("CategoryRegion", "MenuCategoryView");
            regionManager.RequestNavigate("SubMenuRegion", "SubMenuView");
        }
    }
}
