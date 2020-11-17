using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditClicker
{

    public class Item
    {
        private string name;
        private int bonus;
        private int price;

        public Item(string name,int bonus)
        {
            this.name = name;
            this.bonus = bonus;
        }

        public string getName()
        {
            return this.name;
        }

        public int getBonus()
        {
            return this.bonus;
        }
    }
}
