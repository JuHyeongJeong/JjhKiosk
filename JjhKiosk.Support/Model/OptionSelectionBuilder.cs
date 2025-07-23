using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class OptionSelectionBuilder : IOptionSelectionBuilder
    {
        private bool isSelect;
        private string name;
        private uint price;

        public OptionSelection Build()
        {
            return new OptionSelection() { IsSelected = isSelect, SelectionName = name, SelectionPrice = price };
        }

        public IOptionSelectionBuilder SetSelectionIsSelect(bool isSelect)
        {
            this.isSelect = isSelect;
            return this;
        }

        public IOptionSelectionBuilder SetSelectionName(string name)
        {
            this.name = name;
            return this;
        }

        public IOptionSelectionBuilder SetSelectionPrice(uint price)
        {
            this.price = price;
            return this;
        }
    }
}
