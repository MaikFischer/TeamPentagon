using System;
using System.Collections;
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
    public partial class Game : Form
    {

        private long pScore = 0;
        private int pMultiplier = 1;
        private ArrayList pItems = new ArrayList();
        private Item spicker = new Item("Spicker", 1);


        private long getScore()
        {
            return this.pScore;
        }
        private void setScore(long score)
        {
            this.pScore = score;
        }

        public Game()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel1.SendToBack();
            this.Size = new Size(508, 544);
            panel2.Show();
            panel2.BringToFront();
        }

        private void menuButtonGame_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel2.SendToBack();
            this.Size = new Size(508, 399);
            panel1.Show();
            panel1.BringToFront();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuButtonSettings_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel3.SendToBack();
            panel1.Show();
            panel1.BringToFront();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel1.SendToBack();
            panel3.Show();
            panel3.BringToFront();
        }

        private void settingsButtonGame_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel2.SendToBack();
            this.Size = new Size(508, 399);
            panel3.Show();
            panel3.BringToFront();
        }

        private void buttonBackToGameSettings_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel3.SendToBack();
            this.Size = new Size(508, 544);
            panel2.Show();
            panel2.BringToFront();
        }

        private void ClickArea_MouseDown(object sender,EventArgs e)
        {
            this.pScore += 1*this.pMultiplier;
            updateScore();
        }

        public void updateScore()
        {
            score.Text = this.pScore.ToString();
        }

        public void raiseBonus()
        {
            pItems.Add(spicker);
            foreach (Item item in pItems)
            {
                this.pMultiplier += item.getBonus();
            }
        }

        public void addItem(Item item)
        {
            pItems.Add(item);
        }
    }
}
