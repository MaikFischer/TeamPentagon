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
    public partial class MainMenu : Form
    {
        public MainMenu()
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
    }
}
