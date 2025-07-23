using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class MenuItemCloner : IDeepCloneable<MenuItem>
    {
        private readonly MenuOptionItemCloner _menuOptionItemCloner = new();

        public MenuItem DeepClone(MenuItem source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new MenuItem
            {
                Name = source.Name,
                Price = source.Price,
                Qty = source.Qty,
                MenuType = source.MenuType,
                MenuCategory = source.MenuCategory,
                MenuIcon = source.MenuIcon,
                OptionSelections = new ObservableCollection<IMenuOptionItem>(
                    source.OptionSelections?.Select(option => _menuOptionItemCloner.DeepClone((MenuOptionItem)option)) ?? Enumerable.Empty<IMenuOptionItem>()
                )
            };
        }
    }
}
