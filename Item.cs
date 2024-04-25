using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2_k
{
    internal class Item
    {
        private string name;
        private int type;   // 0: HP, 1: MP, 2: SP
        private int value;
        private int price;

        public Item(string name, int type, int value, int price)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
        }

        public int Type
        {
            get { return type; }
        }

        public int Value
        {
            get { return value; }
        }

        public int Price
        {
            get { return price; }
        }

        public virtual void Use()
        {

        }
    }
}
