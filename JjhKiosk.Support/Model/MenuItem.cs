using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JjhKiosk.Support.Model
{
    public partial class MenuItem : ObservableObject, IMenuItem
    {
        private string name;
        private int price;
        private int qty;
        private uint? menuType;
        private uint menuCategory;

        [ObservableProperty]
        private ObservableCollection<IMenuOptionItem> optionSelections;

        [ObservableProperty]
        private string menuIcon;

        public string Name
        {
            get { return name; }
            set { name = value; }
            
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public uint? MenuType
        {
            get => menuType;
            set => menuType = value;
        }

        public uint MenuCategory
        {
            get => menuCategory;
            set => menuCategory = value;
        }


        public int getPrice()
        {
            return Price * qty;
        }

    }

}
