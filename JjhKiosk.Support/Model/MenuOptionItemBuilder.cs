using JjhKiosk.Support.Enum;
using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class MenuOptionItemBuilder : IMenuOptionItemBuilder
    {
        private string optionName;
        private int optionPrice;
        private ObservableCollection<IOptionSelection> optionSelections;
        private OptionType optionType;
        public MenuOptionItem Build()
        {
            return new MenuOptionItem() { OptionType = optionType, OptionName = optionName, OptionPrice = optionPrice, OptionSelections = optionSelections ?? null };
        }

        public IMenuOptionItemBuilder SetOptionName(string optionName)
        {
            this.optionName = optionName;
            return this;
        }

        public IMenuOptionItemBuilder SetOptionPrice(int optionPrice)
        {
            this.optionPrice = optionPrice;
            return this;
        }

        public IMenuOptionItemBuilder SetOptionSelection(ObservableCollection<IOptionSelection> optionSelections)
        {
            this.optionSelections = optionSelections;
            return this;
        }

        public IMenuOptionItemBuilder SetOptionType(OptionType optionType)
        {
            this.optionType = optionType;
            return this;
        }
    }
}
