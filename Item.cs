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
        private int multiplier;

        public Item(string name,int bonus,int multiplier,int price)
        {
            this.name = name;
            this.bonus = bonus;
            this.price = price;
            this.multiplier = multiplier;
        }


        public string getName()
        {
            return this.name;
        }

        public int getBonus()
        {
            return this.bonus;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getMultiplier() 
        {
            return this.multiplier;
        }
    }
}
