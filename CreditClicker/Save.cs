using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditClicker
{
    public class Save
    {
        public int id { get; set; }
        public double score { get; set; }
        public int multiplier { get; set; }
        public int bonus { get; set; }
        public double passiveBonus { get; set; }

        public List<Item> items = new List<Item>();

        public Save(int id, double score, int multiplier, int bonus, double passiveBonus,List<Item> items)
        {
            this.id = id;
            this.score = score;
            this.multiplier = multiplier;
            this.bonus = bonus;
            this.passiveBonus = passiveBonus;
            this.items = items;
        }
    }
}
