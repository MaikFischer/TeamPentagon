﻿using System;
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
        private int pBonus = 1;
        private double passiveBonus = 0;
        public int currentSaveId { get; set; } = 0;
        private List<Item> pItems = new List<Item>();
        private BackgroundWorker bw;
        private SoundPlayer sp;
        private Shop shop;
        private Settings settings;
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        public List<Save> savesList = new List<Save>();
        private Color gameColor;

        public string title = "CreditClicker"; //Edit Title here
        public string currentVersion = "v1.6"; //Edit Version here

        public void setGameColor(Color color) => this.gameColor = color;
        public string getTitle() => this.title;

        public string getCurrentVersion() => this.currentVersion;

        public List<Item> getItems() => this.pItems;

        public int getMultiplier() => this.pMultiplier;

        public int getBonus() => this.pBonus;

        public double getPassiveBonus() => this.passiveBonus;

        public void setPassiveBonus(double passiveBonus) => this.passiveBonus = passiveBonus;

        public double getScore() => this.pScore;

        public void setScore(double score) => this.pScore = score;

        public Game()
        {
            FormManager.registerForm(this);
            shop = new Shop(this);
            settings = new Settings(this,shop);
            getSaves();
            
            InitializeComponent();
            syncTitleAndVersion();
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

        public void syncTitleAndVersion()
        {
            this.Text = title + " " + currentVersion;
            version.Text = currentVersion;
            versionGame.Text = currentVersion;
            versionSettings.Text = currentVersion;
        }


        private void bw_Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            long longScore = (long) this.getScore();
            this.score.Text = longScore.ToString();
            updateBonus();
            updateClicksPerSecond();
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (panel2.Visible)
            {
                Thread.Sleep(100);
                double dScore = this.getScore() + this.getPassiveBonus() / 10;
                this.setScore(dScore);
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            playButtonSound();
            panel1.Hide();
            panel1.SendToBack();
            this.Size = new Size(508, 544);
            panel2.Show();
            panel2.BringToFront();
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
            this.Hide();
            settings.Show();
        }

        private void settingsButtonGame_Click(object sender, EventArgs e)
        {
            playButtonSound();
            settings.Show();
            this.Hide();
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
                this.pScore += ((int) this.pBonus) * this.pMultiplier;
            }     
        }

        public void updateScore()
        {
            score.Text = this.pScore.ToString();
        }

        public void updateBonus()
        {
            lblCurrentBonus.Text = (this.pBonus * this.pMultiplier).ToString();
        }

        public void updateClicksPerSecond()
        {
            lblCurrentCPS.Text = this.passiveBonus.ToString();
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
            player.settings.volume = 30;
            player.uiMode = "invisible";
            player.URL = url;
            player.settings.setMode("loop", true);
            player.controls.play();
        }

        public int getEmptySlot()
        {
            int empty = 0;
            for(int i = 1; i < 5; i++)
            {
                if (!File.Exists("C:/CreditClicker/Saves/save" + i + ".txt"))
                {
                    empty = i;
                    break;
                }
            }
            return empty;
        }

        public void saveState(int saveId)
        {
            if (settings.isSlotCovered(saveId))
            {
                using (StreamWriter sw = new StreamWriter("C:/CreditClicker/Saves/save" + saveId + ".txt"))
                {
                    sw.WriteLine(this.getScore());
                    sw.WriteLine((long)this.getBonus());
                    sw.WriteLine(this.getMultiplier());
                    sw.WriteLine(this.getPassiveBonus());
                    foreach (Item item in this.getItems())
                    {
                        sw.WriteLine(item.getName());
                    }
                }
            }
            else
            {
                Directory.CreateDirectory("C:/CreditClicker/Saves/");
                using (StreamWriter sw = new StreamWriter("C:/CreditClicker/Saves/save" + saveId + ".txt"))
                {
                    sw.WriteLine(this.getScore());
                    sw.WriteLine(this.getBonus());
                    sw.WriteLine(this.getMultiplier());
                    sw.WriteLine(this.getPassiveBonus());
                    foreach (Item item in this.getItems())
                    {
                        sw.WriteLine(item.getName());
                    }
                }
                MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void getSaves()
        {
            for (int saveId = 1; saveId < 5; saveId++)
            {
                
                if (File.Exists("C:/CreditClicker/Saves/save" + saveId + ".txt"))
                {
                    string[] lines = File.ReadAllLines("C:/CreditClicker/Saves/save" + saveId + ".txt");
                    if (lines != null)
                    {
                        Save save = new Save(saveId,0,0,0,0,new List<Item>());
                        save.id = saveId;
                        save.score = Double.Parse(lines[0]);
                        save.bonus = Int32.Parse(lines[1]);
                        save.multiplier = Int32.Parse(lines[2]);
                        save.passiveBonus = Double.Parse(lines[3]);
                        if (lines.Length > 4)
                        {
                            for (int i = 4; i < lines.Length; i++)
                            {
                                switch (lines[i])
                                {
                                    case "CheatSheet":
                                        save.items.Add(new Item("CheatSheet", 1, 0, 150));
                                        break;
                                    case "StudyGroup":
                                        save.items.Add(new Item("StudyGroup", 3, 0, 250));
                                        break;
                                    case "ConsultationHour":
                                        save.items.Add(new Item("ConsultationHour", 0, 2, 2500));
                                        break;
                                    case "OldExam":
                                        save.items.Add(new Item("OldExam", 10, 0, 5000));
                                        break;
                                    case "Insider":
                                        save.items.Add(new Item("Insider", 0, 4, 15000));
                                        break;
                                }
                            }
                        }
                        savesList.Add(save);
                    }
                }
            }
        }

        public void getSave(int saveId)
        {
            foreach(Save save in savesList)
            {
                if (save.id == saveId)
                {
                    this.currentSaveId = save.id;
                    this.setScore(save.score);
                    this.pMultiplier = save.multiplier;
                    this.pBonus = save.bonus;
                    this.setPassiveBonus(save.passiveBonus);
                    this.pItems = save.items;
                    settings.calcItemPrices(pItems);
                }
            }
        }


        public void delSaveState()
        {

        }

        private void Game_Shown(object sender, EventArgs e)
        {
            //FormManager.initializeCurrentColors(this);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //FormManager.initializeCurrentColors(this);
        }

        private void Game_Activated(object sender, EventArgs e)
        {
            FormManager.initAllColors();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasPlayed())
            {
                if (currentSaveId != 0)
                {
                    if (settings.autoSaveEnabled)
                    {
                        saveState(currentSaveId);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Auto-Save is off and you haven't saved your game yet. Do you want to save it to Slot#" + currentSaveId + "? Press 'Cancel' to cancel.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            saveState(currentSaveId);
                            settings.Show();
                            this.Hide();
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            settings.Show();
                        }

                        if (settings.autoSaveThemeEnabled)
                        {

                        }
                    }
                }
                else
                {
                    if (getEmptySlot() == 0)
                    {
                        DialogResult result = MessageBox.Show("All Slots are in use and your progress is not saved yet. Current progress will be lost. Continue?", "Progress not saved!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            settings.Show();
                        }else
                        {
                            settings.Close();
                            shop.Close();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Your progress is not saved yet. Do you wish to continue?", "Progress not saved!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            settings.Show();
                        }
                        else
                        {
                            settings.Close();
                            shop.Close();
                        }
                    }
                }
            }
        }

        public bool hasPlayed()
        {
            return this.getScore() > 0 || this.getBonus() > 1 || this.getMultiplier() > 1 || this.getPassiveBonus() > 0;
        }
    }
}