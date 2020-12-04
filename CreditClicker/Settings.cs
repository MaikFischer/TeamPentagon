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
    public partial class Settings : Form
    {
        private Game game;

        private Shop shop;
        public bool autoSaveEnabled { get; set; } = true;
        public bool autoSaveThemeEnabled { get; set; } = true;
        public Settings(Game game,Shop shop)
        {
            FormManager.registerForm(this);
            this.shop = shop;
            this.game = game;
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            game.playButtonSound();
            this.Hide();
            game.Show();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            FormManager.initAllColors();
            this.colorAreaButton.BackColor = FormManager.currentButtonColor;
            this.colorAreaButtonText.BackColor = FormManager.currentButtonTextColor;
            this.colorAreaText.BackColor = FormManager.currentCommonTextColor;
            this.colorAreaSpecialText.BackColor = FormManager.currentSpecialTextColor;
        }

        private void buttonPickTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                colorAreaText.BackColor = colorDialogText.Color;
                FormManager.changeCommonTextColor(colorDialogText.Color);
            }
        }

        private void buttonPickButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialogButton.ShowDialog() == DialogResult.OK)
            {
                colorAreaButton.BackColor = colorDialogButton.Color;
                FormManager.changeButtonColor(colorDialogButton.Color);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialogButtonText.ShowDialog() == DialogResult.OK)
            {
                colorAreaButtonText.BackColor = colorDialogButtonText.Color;
                FormManager.changeButtonTextColor(colorDialogButtonText.Color);
            }
        }

        private void buttonPickSpecialTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialogSpecialText.ShowDialog() == DialogResult.OK)
            {
                colorAreaSpecialText.BackColor = colorDialogSpecialText.Color;
                FormManager.changeSpecialTextColor(colorDialogSpecialText.Color);
            }
        }

        private void changeBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (changeBackground.Checked)
            {
                changeToColor.Visible = true;
                useImage.Visible = true;
            }else
            {
                changeToColor.Checked = false;
                changeToColor.Visible = false; 
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;

                useImage.Checked = false;
                useImage.Visible = false;
                
            }
        }

        private void changeToColor_CheckedChanged(object sender, EventArgs e)
        {
            if (changeToColor.Checked)
            {
                useImage.Checked = false;
                selectImage.Visible = false;
                lblBackground.Visible = true;
                colorAreaBackground.Visible = true;
                pickBackgroundColor.Visible = true;
            }
            else
            {
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;
            }
        }

        private void useImage_CheckedChanged(object sender, EventArgs e)
        {
            if (useImage.Checked)
            {
                changeToColor.Checked = false;
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;
                selectImage.Visible = true;
            }else
            {
                selectImage.Visible = false;
            }
        }

        private void pickBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                colorAreaBackground.BackColor = colorDialogBackground.Color;
                FormManager.changeBackgroundColor(colorDialogBackground.Color);
            }
        }

        private void Settings_Activated(object sender, EventArgs e)
        {
            FormManager.initAllColors();
            switch (game.currentSaveId)
            {
                case 1:
                    buttonSave1.Text = "Save #1";
                    buttonSave2.Text = "Load #2";
                    buttonSave3.Text = "Load #3";
                    buttonSave4.Text = "Load #4";
                    labelCurrentlyLoaded.Text = "Currently Loaded: Save #1";
                    break;
                case 2:
                    buttonSave2.Text = "Save #2";
                    buttonSave1.Text = "Load #1";
                    buttonSave3.Text = "Load #3";
                    buttonSave4.Text = "Load #4";
                    labelCurrentlyLoaded.Text = "Currently Loaded: Save #2";
                    break;
                case 3:
                    buttonSave3.Text = "Save #3";
                    buttonSave2.Text = "Load #2";
                    buttonSave4.Text = "Load #4";
                    buttonSave1.Text = "Load #1";
                    labelCurrentlyLoaded.Text = "Currently Loaded: Save #3";
                    break;
                case 4:
                    buttonSave4.Text = "Save #4";
                    buttonSave1.Text = "Load #1";
                    buttonSave2.Text = "Load #2";
                    buttonSave3.Text = "Load #3";
                    labelCurrentlyLoaded.Text = "Currently Loaded: Save #4";
                    break;
                case 0:
                    if (isSlotCovered(1)) buttonSave1.Text = "Load #1";
                    else buttonSave1.Text = "Save #1";
                    if (isSlotCovered(2)) buttonSave2.Text = "Load #2";
                    else buttonSave2.Text = "Save #2";
                    if (isSlotCovered(3)) buttonSave3.Text = "Load #3";
                    else buttonSave3.Text = "Save #3";
                    if (isSlotCovered(4)) buttonSave4.Text = "Load #4";
                    else buttonSave4.Text = "Save #4";
                    break;
            }
           
        }



        private void selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FormManager.changeBackgroundImage(openFileDialog1.FileName);
            }
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (game.currentSaveId == 1)
            {
                game.saveState(1);
                MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (game.currentSaveId == 0)
            {
                if (isSlotCovered(1) && game.hasPlayed())
                {
                    DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        game.saveState(1);
                        MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        loadSave(1);
                    }
                }
                else if (game.hasPlayed())
                {
                    game.saveState(1);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    game.saveState(1);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    loadSave(1);
                }
            }
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            if (game.currentSaveId == 2)
            {
                game.saveState(2);
                MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (game.currentSaveId == 0)
            {
                if (isSlotCovered(2) && game.hasPlayed())
                {
                    DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        game.saveState(2);
                        MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        loadSave(2);
                    }
                }
                else if (game.hasPlayed())
                {
                    game.saveState(2);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    game.saveState(2);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    loadSave(2);
                }
            }
        }

        private void buttonSave3_Click(object sender, EventArgs e)
        {
            if (game.currentSaveId == 3)
            {
                game.saveState(3);
                MessageBox.Show("Successfully saved current progress to Slot #" + 3, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (game.currentSaveId == 0)
            {
                if (isSlotCovered(3) && game.hasPlayed())
                {
                    DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        game.saveState(3);
                        MessageBox.Show("Successfully saved current progress to Slot #" + 3, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        loadSave(3);
                    }
                }
                else if (game.hasPlayed())
                {
                    game.saveState(3);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 3, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    game.saveState(3);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 3, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    loadSave(3);
                }
            }
        }

        private void buttonSave4_Click(object sender, EventArgs e)
        {
            if (game.currentSaveId == 4)
            {
                game.saveState(4);
                MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(game.currentSaveId == 0)
            {
                if (isSlotCovered(4) && game.hasPlayed())
                {
                    DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        game.saveState(4);
                        MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        loadSave(4);
                    }
                }else if (game.hasPlayed())
                {
                    game.saveState(4);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    game.saveState(4);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    game.currentSaveId = 4;
                    loadSave(4);
                }
            }
        }

        private void autoSaveSlot_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSaveSlot.Checked) autoSaveEnabled = true;
            else autoSaveEnabled = false;

        }

        private void autoSaveTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSaveTheme.Checked) autoSaveThemeEnabled = true;
            else autoSaveThemeEnabled = false;
        }

        public void loadSave(int saveId)
        {
            game.getSaves();
            if (isSlotCovered(saveId))
            {
                game.getSave(saveId);
                MessageBox.Show("Sucessfully loaded Save #" + saveId + "\n" + "Score: " + (long)game.getScore() + "\n" + "CreditsPerClick: " + (long)(game.getBonus() * game.getMultiplier()) + "\n" + "CreditsPerSecond: " + game.getPassiveBonus(),"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (game.getScore() > 0 || game.getBonus() > 1 || game.getMultiplier() > 1 || game.getPassiveBonus() > 0)
            {
                if (autoSaveEnabled)
                {
                    game.currentSaveId = saveId;
                    game.getSave(saveId);
                }
                game.saveState(saveId);
            }
            else
            {
                MessageBox.Show("This save slot is empty and your score is at 0. Start playing and come back to save or use the auto-save feature.");
            }
        }

        public bool isSlotCovered(int saveId)
        {
            if (System.IO.File.Exists("C:/CreditClicker/Saves/save" + saveId + ".txt")) return true;
            return false;
        }

        public void calcItemPrices(List<Item> items)
        {
            shop.cheatSheet.setPrice(150);
            shop.studyGroup.setPrice(250);
            shop.conHour.setPrice(2500);
            shop.oldExam.setPrice(5000);
            shop.insider.setPrice(15000);
            foreach(Item item in items)
            {
                switch (item.getName())
                {
                    case "CheatSheet":
                        shop.cheatSheet.setPrice(shop.cheatSheet.getPrice()+ (shop.cheatSheet.getPrice() * 25 / 100));
                        Console.WriteLine("[DEBUG] Cheat Sheet: "+shop.cheatSheet.getPrice());
                        break;
                    case "StudyGroup":
                        shop.studyGroup.setPrice(shop.studyGroup.getPrice() + (shop.studyGroup.getPrice() * 25 / 100));
                        Console.WriteLine("[DEBUG] Study Group: " + shop.studyGroup.getPrice());
                        break;
                    case "ConsultationHour":
                        shop.conHour.setPrice(shop.conHour.getPrice() + (shop.conHour.getPrice() * 25 / 100));
                        Console.WriteLine("[DEBUG] Con Hour: " + shop.conHour.getPrice());
                        break;
                    case "OldExam":
                        shop.oldExam.setPrice(shop.oldExam.getPrice() + (shop.oldExam.getPrice() * 25 / 100));
                        Console.WriteLine("[DEBUG] Old Exam " + shop.oldExam.getPrice());
                        break;
                    case "Insider":
                        shop.insider.setPrice(shop.insider.getPrice() + (shop.insider.getPrice() * 25 / 100));
                        Console.WriteLine("[DEBUG] Insider " + shop.insider.getPrice());
                        break;
                }
            }
        }

        private void buttonResetTextColor_Click(object sender, EventArgs e)
        {
            FormManager.changeCommonTextColor(FormManager.DEFAULT_COLOR);
            colorAreaText.BackColor = FormManager.DEFAULT_COLOR;
        }

        private void buttonResetButtonColor_Click(object sender, EventArgs e)
        {
            FormManager.changeButtonColor(FormManager.DEFAULT_COLOR);
            colorAreaButton.BackColor = FormManager.DEFAULT_COLOR;
        }

        private void buttonResetButtonTxt_Click(object sender, EventArgs e)
        {
            FormManager.changeButtonTextColor(Color.Black);
            colorAreaButtonText.BackColor = Color.Black;
        }

        private void buttonResetSpecialTextColor_Click(object sender, EventArgs e)
        {
            FormManager.changeSpecialTextColor(Color.White);
            colorAreaSpecialText.BackColor = Color.White;
        }
    }
}
