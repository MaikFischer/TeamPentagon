using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

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
        private BackgroundWorker buyButtonWorker = new BackgroundWorker();

        public Shop(Game game)
        {
            this.game = game;
            InitializeComponent();
            buyButtonWorker = new BackgroundWorker();
            buyButtonWorker.DoWork += buyButtonWorker_DoWork;
            buyButtonWorker.RunWorkerCompleted += buyButtonWorker_Check_RunWorkerCompleted;
            buyButtonWorker.RunWorkerAsync();
        }

        public ArrayList getAllItems()
        {
            ArrayList allItems = new ArrayList();
            allItems.Add(cheatSheet);
            allItems.Add(studyGroup);
            allItems.Add(conHour);
            allItems.Add(oldExam);
            allItems.Add(insider);

            return allItems;
        }

        public ArrayList getAllBuyButtons()
        {
            ArrayList allBuyButtons = new ArrayList();
            allBuyButtons.Add(buyCheatSheet);
            allBuyButtons.Add(buyStudyGroup);
            allBuyButtons.Add(buyConsultationHour);
            allBuyButtons.Add(buyOldExams);
            allBuyButtons.Add(buyInsider);

            return allBuyButtons;
        }

        private void buyButtonWorker_Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buyButtonWorker.RunWorkerAsync();
        }

        private void buyButtonWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            foreach(Item item in getAllItems())
            {
                foreach(Button b in getAllBuyButtons())
                {
                    if ("$" + item.getPrice() == b.Text)
                    {
                        if (game.getScore() < item.getPrice())
                        {
                            b.ForeColor = Color.Red;
                            b.BackColor = Color.DarkOrange;
                        }else
                        {
                            b.ForeColor = Color.Green;
                            b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                        }
                    }
                }
            }
        }

        public void updatePrice(Button button,Item item)
        {
            button.Text = "$" + item.getPrice();
        }

        private void buyCheatSheet_Click(object sender, EventArgs e)
        {
            if (game.getScore() >= cheatSheet.getPrice()) 
            {
                game.playButtonSound();
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
                game.playButtonSound();
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
                game.playButtonSound();
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
                game.playButtonSound();
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
                game.playButtonSound();
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
