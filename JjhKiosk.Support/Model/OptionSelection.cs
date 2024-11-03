using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class OptionSelection
    {
		private string selectionName;

		private int selectionPrice;

		public int SelectionPrice
		{
			get { return selectionPrice; }
			set { selectionPrice = value; }
		}


		public string SelectionName
		{
			get { return selectionName; }
			set { selectionName = value; }
		}

	}
}
