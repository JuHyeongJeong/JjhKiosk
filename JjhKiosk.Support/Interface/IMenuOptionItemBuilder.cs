using JjhKiosk.Support.Enum;
using JjhKiosk.Support.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Interface
{
    public interface IMenuOptionItemBuilder
    {
        IMenuOptionItemBuilder SetOptionName(string optionName);
        IMenuOptionItemBuilder SetOptionPrice(int optionPrice);
        IMenuOptionItemBuilder SetOptionType(OptionType optionType);
        IMenuOptionItemBuilder SetOptionSelection(ObservableCollection<IOptionSelection> optionSelections);

        MenuOptionItem Build();
    }
}
