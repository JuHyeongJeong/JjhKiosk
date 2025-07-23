using JjhKiosk.Support.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Interface
{
    public interface IOptionSelectionBuilder
    {
        OptionSelection Build();
        IOptionSelectionBuilder SetSelectionPrice(uint price);
        IOptionSelectionBuilder SetSelectionName(string name);
        IOptionSelectionBuilder SetSelectionIsSelect(bool isSelect);
    }
}
