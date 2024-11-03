using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public partial class MenuItem : ObservableObject, IMenuItem
    {
        private string name;

        private int price;

        [ObservableProperty]
        public ObservableCollection<MenuOptionItem> optionSelections;

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




        public int getPrice()
        {
            throw new NotImplementedException();
        }
    }
}
