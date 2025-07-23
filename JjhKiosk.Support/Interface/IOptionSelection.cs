using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Interface
{
    public interface IOptionSelection
    {
        public uint SelectionPrice { get; set; }
        public string SelectionName { get; set; }
        public  bool IsSelected { get; set; }

        public IOptionSelection Clone();
    }
}
