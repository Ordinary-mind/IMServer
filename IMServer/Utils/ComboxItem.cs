using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMServer.Utils
{
    class ComboxItem
    {
        public ComboxItem()
        {

        }
        public ComboxItem(string Key, object Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
        public string Key { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Key;
        }
    }
}
