using JjhKiosk.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Model
{
    public class MenuItemCategory : IMenuCategory
    {
		private string name;
		private uint menuCategoryID;
		private uint? storeID;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public uint MenuCategoryID
        {
            get { return menuCategoryID; }
            set { menuCategoryID = value; }
        }
        public uint? StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }

    }
}
