using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.Support.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public partial class MenuOptionItem : ObservableObject
    {
		private string optionName;

		private int optionPrice;

		private OptionType optionType;

        [ObservableProperty]
        public ObservableCollection<OptionSelection> optionSelections;


        public string OptionName
        {
            get { return optionName; }
            set { optionName = value; }
        }

        public int OptionPrice
		{
			get { return optionPrice; }
			set { optionPrice = value; }
		}


        public OptionType OptionType
        {
            get { return optionType; }
            set { optionType = value; }
        }

    }
}
