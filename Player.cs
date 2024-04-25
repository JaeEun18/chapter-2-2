using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2_k
{
    internal class Player
    {
        private string level;
        private string name;
        private int power;
        private int shield;
        private int hp;
        private int money;
        private List<Item> itemList;

        public Player(string level, string name, int power, int shield, int hp, int money, List<Item> itemList)
        {
 
            this.level = level;
            this.name = name;
            this.power = power;
            this.shield = shield;
            this.hp = hp;
            this.money = money;
        }


        public string Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int GetItemCount()
        {
            return itemList.Count;
        }

        public void OpenItemInventory()
        {
            int idx = 1;
            foreach (Item item in itemList)
            {
                Console.WriteLine("{0}. {1} {2}", idx, item.Name, item.Value);
                idx++;
            }
        }

        public void UseItem(int itemIdx)
        {
            Item item = itemList[itemIdx];
            Console.WriteLine("{0}번 {1}을(를) 사용합니다!", itemIdx + 1, item.Name);
            item.Use();
            switch (item.Type)
            {
                case 0:
                    hp += item.Value;
                    break;
                case 1:
                    power += item.Value;
                    break;
                case 2:
                    shield += item.Value;
                    break;
            }
            itemList.Remove(item);
        }

    }
}
