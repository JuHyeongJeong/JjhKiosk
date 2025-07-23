using JjhKiosk.Support.Enum;
using JjhKiosk.Support.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace JjhKiosk.Support.Selector
{
    public class MenuOptionTypeSelector : DataTemplateSelector
    {
        public DataTemplate MaxOneTemplate { get; set; }
        public DataTemplate MultiTemplate { get; set; }
        public DataTemplate OnlyOneTemplate { get; set; }
        public DataTemplate MultiAddTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MenuOptionItem optionItem)
            {
                switch (optionItem.OptionType)
                {
                    case OptionType.MAX_ONE:
                        return MaxOneTemplate;
                    case OptionType.MULTI:
                        return MultiTemplate;
                    case OptionType.ONLY_ONE:
                        return OnlyOneTemplate;
                    case OptionType.MULTI_ADD:
                        return MultiAddTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
