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
        public Item cheatSheet { get; set; } = new Item("CheatSheet", 1, 0, 150);
        public Item studyGroup { get; set; } = new Item("StudyGroup", 3, 0, 250);
        public Item conHour { get; set; } = new Item("ConsultationHour", 0, 2, 2500);
        public Item oldExam { get; set; } = new Item("OldExam", 10, 0, 5000);
        public Item insider { get; set; } = new Item("Insider", 0, 4, 15000);
        public BackgroundWorker buyButtonWorker;

        public Shop(Game game)
        {
            FormManager.registerForm(this);
            this.game = game;
            InitializeComponent();
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

        public void buyButtonWorker_Check_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updatePrice(buyCheatSheet, cheatSheet);
            updatePrice(buyStudyGroup, studyGroup);
            updatePrice(buyConsultationHour, conHour);
            updatePrice(buyOldExams, oldExam);
            updatePrice(buyInsider, insider);
            buyButtonWorker.RunWorkerAsync();
        }

        public void buyButtonWorker_DoWork(object sender, DoWorkEventArgs e)
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
                        }else
                        {
                            b.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        public void updatePrice(Button button, Item item)
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
                this.updatePrice(buyCheatSheet,cheatSheet);
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
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            game.playButtonSound();
            this.Hide(); 
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Shop_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
