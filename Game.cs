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
using WMPLib;
namespace CreditClicker
{


    public partial class Game : Form
    {

        private double pScore = 0;
        private int pMultiplier = 1;
        private int pBonus = 0;
        private double passiveBonus = 0;
        private ArrayList pItems = new ArrayList();
        private BackgroundWorker bw;
        private SoundPlayer sp;
        private Shop shop;
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        public double getPassiveBonus()
        {
            return this.passiveBonus;
        }

        public void setPassiveBonus(double passiveBonus)
        {
            this.passiveBonus = passiveBonus;
        }

        public double getScore()
        {
            return this.pScore;
        }
        public void setScore(double score)
        {    
            this.pScore = score;
        }

        public Game()
        {
            this.shop = new Shop(this);
            this.shop.Hide();
            InitializeComponent();
            initializeWorker();
            playBackgroundMusic(); //Spielt später Hintergrundmusik ab
            shop.buyButtonWorker = new BackgroundWorker();
            shop.buyButtonWorker.DoWork += shop.buyButtonWorker_DoWork;
            shop.buyButtonWorker.RunWorkerCompleted += shop.buyButtonWorker_Check_RunWorkerCompleted;
            shop.buyButtonWorker.RunWorkerAsync();
        }

        public void initializeWorker()
        {
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_Check_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }


        private void bw_Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            long test = (long) this.getScore();
            this.score.Text = test.ToString();
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            double dScore = this.getScore() + this.getPassiveBonus() / 10;
            this.setScore(dScore);
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel1.Hide();
            panel1.SendToBack();
            this.Size = new Size(508, 544);
            panel2.Show();
            panel2.BringToFront();
            playButtonSound();
        }

        private void menuButtonGame_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel2.Hide();
            panel2.SendToBack();
            this.Size = new Size(508, 399);
            panel1.Show();
            panel1.BringToFront();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            playButtonSound();
            this.Close();
            if (isShopOpen()) shop.Close();
        }

        private void menuButtonSettings_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel3.Hide();
            panel3.SendToBack();
            panel1.Show();
            panel1.BringToFront();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel1.Hide();
            panel1.SendToBack();
            panel3.Show();
            panel3.BringToFront();
        }

        private void settingsButtonGame_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel2.Hide();
            panel2.SendToBack();
            this.Size = new Size(508, 399);
            panel3.Show();
            panel3.BringToFront();
        }

        private void buttonBackToGameSettings_Click(object sender, EventArgs e)
        {
            playButtonSound();
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
                playButtonSound();
                shop.Show();
            }
        }

        private void ClickArea_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                playClickSound();
                this.pScore += (1 + (int) this.pBonus) * this.pMultiplier;
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
            if (shop.Visible) return true;
            return false;
        }

        public void playClickSound() {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Stream[] streams = new Stream[7];
            streams[0] = a.GetManifestResourceStream("CreditClicker.clickb1.wav");
            streams[1] = a.GetManifestResourceStream("CreditClicker.clickb2.wav");
            streams[2] = a.GetManifestResourceStream("CreditClicker.clickb3.wav");
            streams[3] = a.GetManifestResourceStream("CreditClicker.clickb4.wav");
            streams[4] = a.GetManifestResourceStream("CreditClicker.clickb5.wav");
            streams[5] = a.GetManifestResourceStream("CreditClicker.clickb6.wav");
            streams[6] = a.GetManifestResourceStream("CreditClicker.clickb7.wav");
            Random r = new Random();
            sp = new SoundPlayer(streams[r.Next(0, 6)]);
            sp.Play();
        }

        public void playButtonSound()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Stream s = a.GetManifestResourceStream("CreditClicker.press.wav");
            sp = new SoundPlayer(s);
            sp.Play();
        }

        public void playBackgroundMusic()
        {
            string path = @"C:\Users\Jan\source\repos\TeamPentagon\background1.wav";
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            String[] s = a.GetManifestResourceNames();
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string newpath = Path.GetFullPath(RunningPath + "\\background1.wav");
            string url = new Uri(newpath).AbsoluteUri;
            Console.WriteLine("[DEBUG] " + newpath);
            player.settings.volume = 30;
            player.uiMode = "invisible";
            player.URL = url;
            player.settings.setMode("loop", true);
            player.controls.play();
        }

    }
}
