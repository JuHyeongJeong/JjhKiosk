using CommunityToolkit.Mvvm.ComponentModel;
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
    public interface IMenuOptionItem
    {
        public ObservableCollection<IOptionSelection> OptionSelections { get; set; }
        
        public string OptionName {  get; set; }

        public int OptionPrice {  get; set; }

        public OptionType OptionType { get; set; }

    }
}
