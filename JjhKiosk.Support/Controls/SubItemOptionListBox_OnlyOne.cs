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

namespace JjhKiosk.Support.Controls
{
    public class SubItemOptionListBox_OnlyOne : ListBox
    {
        static SubItemOptionListBox_OnlyOne()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SubItemOptionListBox_OnlyOne), new FrameworkPropertyMetadata(typeof(SubItemOptionListBox_OnlyOne)));
        }

        //protected override DependencyObject GetContainerForItemOverride()
        //{
        //    return new SubItemOptionListBoxItem_OnlyOne();
        //}
        //DataTemplateSelector 사용시 GetContainerForItemOverride는 중복사용 불가.
    }
}
