using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class MenuOptionItemCloner : IDeepCloneable<MenuOptionItem>
    {
        public MenuOptionItem DeepClone(MenuOptionItem source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new MenuOptionItem
            {
                OptionName = source.OptionName,
                OptionPrice = source.OptionPrice,
                OptionType = source.OptionType,
                OptionSelections = new ObservableCollection<IOptionSelection>(
                    source.OptionSelections?.Select(option => option.Clone()) ?? Enumerable.Empty<IOptionSelection>()
                )
            };
        }
    }
}
