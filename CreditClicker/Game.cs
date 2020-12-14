using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;
using WMPLib;
using AxWMPLib;
using NSpeex;
using NAudio;
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
        private Shop shop;
        private Settings settings;
        public List<Save> savesList = new List<Save>();

        public string title = "CreditClicker"; //Edit Title here
        public string currentVersion = "v2.0"; //Edit Version here

        public string getTitle() => this.title;

        public string getCurrentVersion() => this.currentVersion;

        public List<Item> Items => this.pItems;

        public int getMultiplier() => this.pMultiplier;
        public int getBonus() => this.pBonus;

        public double getPassiveBonus() => this.passiveBonus;

        public void setPassiveBonus(double passiveBonus) => this.passiveBonus = passiveBonus;

        public double getScore() => this.pScore;

        public void setScore(double score) => this.pScore = score;

        public AxWindowsMediaPlayer getMusicPlayer() => this.musicPlayer;
        public AxWindowsMediaPlayer getEffectsPlayer() => this.gameSoundPlayer;

        public AxWindowsMediaPlayer getButtonPlayer() => this.buttonSoundPlayer;

        public NAudio.Wave.WaveFileReader waveReader = new NAudio.Wave.WaveFileReader(Application.StartupPath + @"/Sounds/clickb1.wav");

        public NAudio.Wave.DirectSoundOut output = null;

        public NAudio.Wave.WaveChannel32 waveChannel = null;



        public Game()
        {
            FormManager.registerForm(this);
            shop = new Shop(this);
            currentSaveId = 0;
            InitializeComponent();
        }

        public void initializeWorker()
        {
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_Check_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        public void initializeAudio()
        {
            waveChannel = new NAudio.Wave.WaveChannel32(waveReader);
            output = new NAudio.Wave.DirectSoundOut();
            buttonSoundPlayer.URL = Application.StartupPath + @"\Sounds\press.wav";
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
            long longScore = (long)this.getScore();
            this.score.Text = longScore.ToString();
            updateBonus();
            updateClicksPerSecond();
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.Visible && panel2.Visible)
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

        private void ClickArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                playClickSound();
                this.pScore += ((int)this.pBonus) * this.pMultiplier;
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

        public void playClickSound()
        {
            string[] paths = new string[7];
            paths[0] = Application.StartupPath + @"\Sounds\clickb1.wav";
            paths[1] = Application.StartupPath + @"\Sounds\clickb2.wav";
            paths[2] = Application.StartupPath + @"\Sounds\clickb3.wav";
            paths[3] = Application.StartupPath + @"\Sounds\clickb4.wav";
            paths[4] = Application.StartupPath + @"\Sounds\clickb5.wav";
            paths[5] = Application.StartupPath + @"\Sounds\clickb6.wav";
            paths[6] = Application.StartupPath + @"\Sounds\clickb7.wav";
            Random r = new Random();

            waveReader = new NAudio.Wave.WaveFileReader(paths[r.Next(0,6)]);
            
            waveChannel = new NAudio.Wave.WaveChannel32(waveReader);
            waveChannel.Volume = float.Parse(ConfigurationManager.AppSettings["effectsvolume"]);
            output.Init(waveChannel);
            output.Play();
            /*gameSoundPlayer.Ctlcontrols.stop();
            gameSoundPlayer.URL = paths[r.Next(0, 6)];
            gameSoundPlayer.settings.volume = Convert.ToInt32(ConfigurationManager.AppSettings["effectsvolume"]);
            gameSoundPlayer.Ctlcontrols.play();*/
        }

        public void playButtonSound()
        {
            buttonSoundPlayer.settings.volume = Convert.ToInt32(ConfigurationManager.AppSettings["buttonvolume"]);
            buttonSoundPlayer.Ctlcontrols.play();
        }

        public void playBackgroundMusic()
        {
            musicPlayer.settings.autoStart = false;
            musicPlayer.URL = Application.StartupPath + @"\Sounds\background1.wav";
            musicPlayer.settings.volume = Convert.ToInt32(ConfigurationManager.AppSettings["musicvolume"]);
            musicPlayer.Ctlcontrols.play();
            musicPlayer.settings.setMode("loop", true);
        }


        public int getEmptySlot()
        {
            int empty = 0;
            for (int i = 1; i < 5; i++)
            {
                if (!File.Exists(Application.StartupPath + @"\Saves\save" + i + ".txt"))
                {
                    empty = i;
                    break;
                }
            }
            return empty;
        }

        public void saveState(int saveId)
        {
            if (!Directory.Exists(Application.LocalUserAppDataPath + @"\Saves\")) Directory.CreateDirectory(Application.LocalUserAppDataPath + @"\Saves\");
            string savePath = Application.LocalUserAppDataPath + @"\Saves\save" + saveId + ".txt";
                Save save = new Save(saveId, this.getScore(), this.getMultiplier(), this.getBonus(), this.getPassiveBonus(), this.Items);
                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    sw.WriteLine(save.score);
                    sw.WriteLine(save.bonus);
                    sw.WriteLine(save.multiplier);
                    sw.WriteLine(save.passiveBonus);
                    foreach (Item item in save.items)
                    {
                        sw.WriteLine(item.getName());
                    }
                }
                savesList.Add(save);
                currentSaveId = saveId;
        }

        public void getSaves()
        {
            string savePath = "";
            if (!Directory.Exists(Application.LocalUserAppDataPath + @"\Saves\")) Directory.CreateDirectory(Application.LocalUserAppDataPath + @"\Saves\");
            for (int saveId = 1; saveId < 5; saveId++)
            {
                savePath = Application.LocalUserAppDataPath + @"\Saves\save" + saveId + ".txt";
                if (File.Exists(savePath))
                {
                    string[] lines = settings.readSaveFromFile(savePath);
                    if (lines != null)
                    {
                        Save save = new Save(saveId, 0, 0, 0, 0, new List<Item>());
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
                        foreach(Item item in save.items)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public void getSaveFromFile(int saveId)
        {
            foreach (Save save in savesList)
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

        public Save getSave(int saveId)
        {
            Save s = null;
            foreach (Save save in savesList)
            {
                if (save.id == saveId)
                {
                    s = save;
                }
            }
            return s;
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
            initializeAudio();
            FormManager.initAllColors();
            settings = new Settings(this, shop);
            getSaves();
            syncTitleAndVersion();
            initializeWorker();
            playBackgroundMusic();
            shop.buyButtonWorker = new BackgroundWorker();
            shop.buyButtonWorker.DoWork += shop.buyButtonWorker_DoWork;
            shop.buyButtonWorker.RunWorkerCompleted += shop.buyButtonWorker_Check_RunWorkerCompleted;
            shop.buyButtonWorker.RunWorkerAsync();
            settings.initAppSettings();
            settings.loadTheme();
        }

        private void Game_Activated(object sender, EventArgs e)
        {
            //FormManager.initAllColors();
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
                        if (getSave(currentSaveId).score != getScore())
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
                        }
                        else
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
            if (settings.autoSaveThemeEnabled)
            {
                settings.saveTheme();
            }
        }

        public bool hasPlayed()
        {
            return this.getScore() > 0 || this.getBonus() > 1 || this.getMultiplier() > 1 || this.getPassiveBonus() > 0;
        }
    }
}
