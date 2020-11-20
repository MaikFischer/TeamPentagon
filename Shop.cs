using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CreditClicker
{
    public partial class Shop : Form
    {

        private Game game;

        //Initialisierung aller Items
        private Item cheatSheet = new Item("CheatSheet",1,0,150);
        private Item studyGroup = new Item("StudyGroup", 3, 0, 250);
        private Item conHour = new Item("ConsultationHour", 0, 2, 2500);
        private Item oldExam = new Item("OldExam", 10, 0, 5000);
        private Item insider = new Item("Insider", 0, 4, 15000);

        public Shop(Game game)
        {
            this.game = game;
            InitializeComponent();
        }

        public void updatePrice(Button button,Item item)
        {
            button.Text = "$" + item.getPrice();
        }

        private void buyCheatSheet_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= cheatSheet.getPrice()) 
            {
                game.setScore(game.getScore() - cheatSheet.getPrice());
                game.addItem(cheatSheet);
                game.raiseExtras(cheatSheet);
                game.raisePrice(cheatSheet);
                this.updatePrice(buyCheatSheet, cheatSheet);
                game.updateScore();
                
            }
        }

        private void buyStudyGroup_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= studyGroup.getPrice())
            {
                game.setScore(game.getScore() - studyGroup.getPrice());
                game.addItem(studyGroup);
                game.raisePassive(studyGroup);
                game.raisePrice(studyGroup);
                this.updatePrice(buyStudyGroup, studyGroup);
                game.updateScore();
            }
        }

        private void buyConsultationHour_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= conHour.getPrice())
            {
                game.setScore(game.getScore() - conHour.getPrice());
                game.addItem(conHour);
                game.raiseExtras(conHour);
                game.raisePrice(conHour);
                this.updatePrice(buyConsultationHour, conHour);
                game.updateScore();
            }
        }

        private void buyOldExams_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= oldExam.getPrice())
            {
                game.setScore(game.getScore() - oldExam.getPrice());
                game.addItem(oldExam);
                game.raiseExtras(oldExam);
                game.raisePrice(oldExam);
                this.updatePrice(buyOldExams, oldExam);
                game.updateScore();
            }
        }

        private void buyInsider_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= insider.getPrice())
            {
                game.setScore(game.getScore() - insider.getPrice());
                game.addItem(insider);
                game.raiseExtras(insider);
                game.raisePrice(insider);
                this.updatePrice(buyInsider, insider);
                game.updateScore();
            }
        }
    }
}
