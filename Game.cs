using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace CreditClicker
{
    public partial class Game : Form
    {

        private long pScore = 0;
        private int pMultiplier = 1;
        private int pBonus = 0;
        private int passiveBonus = 0;
        private ArrayList pItems = new ArrayList();
        private BackgroundWorker bw;


        private Shop shop;

        public int getPassiveBonus()
        {
            return this.passiveBonus;
        }

        public void setPassiveBonus(int passiveBonus)
        {
            this.passiveBonus = passiveBonus;
        }

        public long getScore()
        {
            return this.pScore;
        }
        public void setScore(long score)
        {
            this.pScore = score;
        }

        public Game()
        {
            InitializeComponent();
            InitializeSound();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_Check_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        public void InitializeSound()
        {
            //Später können wir hier dann Sounds für das Game initialisieren
        }

        private void bw_Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.score.Text = this.getScore().ToString();
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            this.setScore(this.getScore() + this.getPassiveBonus());
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
            if (isShopOpen()) shop.Close();
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

        private void shopButtonGame_Click(object sender, EventArgs e)
        {
            if (!isShopOpen())
            {
                shop = new Shop(this);
                shop.Show(this);
            }

        }

        private void ClickArea_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.pScore += (1 + (int) this.pBonus) * this.pMultiplier;
                updateScore();
            }
          
        }

        public void updateScore()
        {
            score.Text = this.pScore.ToString();
        }

        public void raiseExtras(Item item)
        {
            this.pMultiplier += item.getMultiplier();
            this.pBonus += item.getBonus();
        }

        public void raisePassive(Item item)
        {
            this.passiveBonus += item.getBonus();
        }

        public void raisePrice(Item item)
        {
            item.setPrice(item.getPrice() + item.getPrice() * 25 / 100);
        }

        public void addItem(Item item)
        {
            pItems.Add(item);
        }

        public bool isShopOpen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "Shop") return true;
            }
            return false;
        }
    }
}
