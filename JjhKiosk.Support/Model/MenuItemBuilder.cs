using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class MenuItemBuilder : IMenuItemBuilder
    {
        private string name;
        private string menuImage;
        private uint? menuType;
        private ObservableCollection<IMenuOptionItem> optionSelections;
        private int price;
        private int qty;
        private uint menuCategory;

        public MenuItem Build()
        {
            return new MenuItem() { MenuCategory = menuCategory, MenuIcon = this.menuImage, MenuType = this.menuType, Name = this.name, OptionSelections = this.optionSelections ?? null, Price = this.price, Qty = this.qty  };
        }

        public IMenuItemBuilder SetMenuCategory(uint menuCategory)
        {
            this.menuCategory = menuCategory;
            return this;
        }

        public IMenuItemBuilder SetMenuImage(string menuImage)
        {
            this.menuImage = menuImage;
            return this;
        }

        public IMenuItemBuilder SetMenuType(uint? menuType)
        {
            this.menuType = menuType;
            return this;
        }

        public IMenuItemBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public IMenuItemBuilder SetOptionSelection(ObservableCollection<IMenuOptionItem> optionSelections)
        {
            this.optionSelections = optionSelections;
            return this;
        }

        public IMenuItemBuilder SetPrice(int price)
        {
            this.price = price;
            return this;
        }

        public IMenuItemBuilder SetQty(int qty)
        {
            this.qty = qty;
            return this;
        }
    }
}
