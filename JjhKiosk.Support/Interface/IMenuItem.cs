using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.Support.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Interface
{
    public interface IMenuItem
    {
        string Name { get; set; }

        int Price { get; set; }

        int Qty { get; set; }

        public uint? MenuType { get; set; }

        public uint MenuCategory { get; set; }

        ObservableCollection<IMenuOptionItem> OptionSelections { get;  set; }

        public string MenuIcon { get; set; }
    }

    
}
