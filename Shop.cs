using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditClicker
{
    public partial class Shop : Form
    {

        private Game game;

        //Initialisierung aller Items
        //CheatSheet = +1 Bonus pro Klick +0 Multiplikator Preis: 1000
        private Item cheatSheet = new Item("CheatSheet",1,0,1000);

        public Shop(Game game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void buyCheatSheet_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= cheatSheet.getPrice()) 
            {
                game.setScore(game.getScore() - cheatSheet.getPrice());
                game.addItem(cheatSheet);
                game.raiseMultiplier(cheatSheet);
                game.updateScore();
            }
        }
    }
}
