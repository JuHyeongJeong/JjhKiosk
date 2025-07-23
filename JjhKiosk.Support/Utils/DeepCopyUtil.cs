using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Support.Utils
{
    public static class DeepCopyUtil
    {
        public static T DeepClone<T>(T obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }
    }
}
