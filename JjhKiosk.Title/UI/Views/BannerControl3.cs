using JjhKiosk.Support.ControlBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JjhKiosk.Title.UI.Views
{
    public class BannerControl3 : ContentControlBase
    {
        static BannerControl3()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BannerControl3), new FrameworkPropertyMetadata(typeof(BannerControl3)));
        }
    }
}
