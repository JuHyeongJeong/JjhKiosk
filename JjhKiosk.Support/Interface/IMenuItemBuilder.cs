using JjhKiosk.Support.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JjhKiosk.Support.Interface
{
    public interface IMenuItemBuilder
    {
        IMenuItemBuilder SetName(string name);
        IMenuItemBuilder SetPrice(int price);
        IMenuItemBuilder SetQty(int qty);
        IMenuItemBuilder SetMenuType(uint? menuType);
        IMenuItemBuilder SetMenuCategory(uint menuCategory);
        IMenuItemBuilder SetOptionSelection(ObservableCollection<IMenuOptionItem> optionSelections);
        IMenuItemBuilder SetMenuImage(string menuImage);

        MenuItem Build();
    }
}
