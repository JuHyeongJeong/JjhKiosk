using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Interface
{
    public interface IDeepCloneable<T>
    {
        public T DeepClone(T a);
    }
}
