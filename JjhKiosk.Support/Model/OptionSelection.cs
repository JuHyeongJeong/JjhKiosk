using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class OptionSelection : IOptionSelection
    {
		private string selectionName;

		private uint selectionPrice;

		private bool isSelected = false;

		public uint SelectionPrice
		{
			get { return selectionPrice; }
			set { selectionPrice = value; }
		}


		public string SelectionName
		{
			get { return selectionName; }
			set { selectionName = value; }
		}

		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value; }
		}

        public IOptionSelection Clone()
        {
            return new OptionSelection
            {
                SelectionName = this.SelectionName,
                SelectionPrice = this.SelectionPrice,
				IsSelected = this.IsSelected
            };
        }
    }
}
