using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CreditClicker
{
    public partial class Settings : Form
    {
        private Game game;

        private Shop shop;
        public bool autoSaveEnabled { get; set; } = true;
        public bool autoSaveThemeEnabled { get; set; } = true;
        public bool changeBackgroundEnabled { get; set; } = false;
        public bool changeToColorEnabled { get; set; } = false;
        public bool useImageEnabled { get; set; } = false;

        public string backgroundImagePath = "";
        public Settings(Game game,Shop shop)
        {
            FormManager.registerForm(this);
            this.shop = shop;
            this.game = game;
            InitializeComponent();
        }

        public void initAppSettings()
        {
            //Auto-Save Game
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["autosavegame"])) {
                autoSaveSlot.Checked = true;
                autoSaveEnabled = true;
            }else {
                autoSaveSlot.Checked = false;
                autoSaveEnabled = false;
            }
            //Auto-Save Theme
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["autosavetheme"])) {
                popAutoSaveTheme.Checked = true;
                autoSaveThemeEnabled = true;
            }else {
                popAutoSaveTheme.Checked = false;
                autoSaveThemeEnabled = false;
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["changeback"]))
            {
                popChangeBackground.Checked = true;
                changeBackgroundEnabled = true;
            }else
            {
                popChangeBackground.Checked = false;
                changeBackgroundEnabled = false;
                changeToColorEnabled = false;
                useImageEnabled = false;
            }
            //Change Background to Color
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["changetocolor"])) {
                popChangeToColor.Checked = true;
                changeToColorEnabled = true;
            }else {
                popChangeToColor.Checked = false;
                changeToColorEnabled = false;
            }
            //Use Background Image
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["useimage"])) {
                popUseImage.Checked = true;
                useImageEnabled = true;
            }else {
                popUseImage.Checked = false;
                useImageEnabled = false;
            }

            //Initilize Volumes


            game.getMusicPlayer().settings.volume = Convert.ToInt32(ConfigurationManager.AppSettings["musicvolume"]);
            game.getButtonPlayer().settings.volume = Convert.ToInt32(ConfigurationManager.AppSettings["buttonvolume"]);
            this.musicVolTextBox.Text = Convert.ToInt32(ConfigurationManager.AppSettings["musicvolume"]) * 2 + "%";
            this.musicVolumeBar.Value = Convert.ToInt32(ConfigurationManager.AppSettings["musicvolume"]);
            this.buttonVolTextBox.Text = Convert.ToInt32(ConfigurationManager.AppSettings["buttonvolume"]) * 2 + "%";
            this.buttonVolumeBar.Value = Convert.ToInt32(ConfigurationManager.AppSettings["buttonvolume"]);
            this.effectsVolumeBar.Value = Decimal.ToInt32(Decimal.Parse(ConfigurationManager.AppSettings["effectsvolume"]) * 50);
            this.effectsVolTextBox.Text = Decimal.ToInt32(Decimal.Parse(ConfigurationManager.AppSettings["effectsvolume"]) * 100) + "%";

        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            game.playButtonSound();
            FormManager.initAllColors();
            this.Hide();
            game.Show();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            /*FormManager.initAllColors();
            this.colorAreaButton.BackColor = FormManager.currentButtonColor;
            this.colorAreaButtonText.BackColor = FormManager.currentButtonTextColor;
            this.colorAreaText.BackColor = FormManager.currentCommonTextColor;
            this.colorAreaSpecialText.BackColor = FormManager.currentSpecialTextColor;*/
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
            if (popChangeBackground.Checked)
            {
                popChangeToColor.Visible = true;
                popUseImage.Visible = true;
                changeBackgroundEnabled = true;
                popResetBackground.Visible = true;
                SavesManager.AddUpdateAppSettings("changeback", "True");
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["changetocolor"]))
                {
                    changeToColorEnabled = true;
                    popChangeToColor.Checked = true;
                }
                else
                {
                    changeToColorEnabled = false;
                    popChangeToColor.Checked = false;
                }
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["useimage"]))
                {
                    popUseImage.Checked = true;
                    useImageEnabled = true;
                }
                else
                {
                    useImageEnabled = false;
                    popUseImage.Checked = false;
                }

            }else
            {
                popChangeToColor.Checked = false;
                popChangeToColor.Visible = false; 
                colorAreaBackground.Visible = false;
                popPickBackgroundColor.Visible = false;
                popUseImage.Checked = false;
                popUseImage.Visible = false;
                useImageEnabled = false;
                changeBackgroundEnabled = false;
                popResetBackground.Visible = false;
                SavesManager.AddUpdateAppSettings("changeback", "False");
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
                SavesManager.AddUpdateAppSettings("useimage", "False");
            }
        }

        private void changeToColor_CheckedChanged(object sender, EventArgs e)
        {
            if (popChangeToColor.Checked)
            {
                popUseImage.Checked = false;
                useImageEnabled = false;
                popSelectImage.Visible = false;
                colorAreaBackground.Visible = true;
                popPickBackgroundColor.Visible = true;
                changeToColorEnabled = true;
                SavesManager.AddUpdateAppSettings("changetocolor", "True");
                SavesManager.AddUpdateAppSettings("useimage", "False");
            }
            else
            {
                colorAreaBackground.Visible = false;
                popPickBackgroundColor.Visible = false;
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
            }
        }

        private void useImage_CheckedChanged(object sender, EventArgs e)
        {
            if (popUseImage.Checked)
            {
                popChangeToColor.Checked = false;
                changeToColorEnabled = false;
                colorAreaBackground.Visible = false;
                popPickBackgroundColor.Visible = false;
                popSelectImage.Visible = true;
                useImageEnabled = true;
                SavesManager.AddUpdateAppSettings("useimage", "True");
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
            }
            else
            {
                popSelectImage.Visible = false;
                useImageEnabled = false;
                SavesManager.AddUpdateAppSettings("useimage", "False");
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
        }

        public void initLoadState(int saveId)
        {
            game.getSaves();
            if (isSlotCovered(1)) buttonSave1.Text = "Load #1";
            else
            {
                buttonSave1.Text = "Save #1";
                popGroupBox1.Controls[0].Text = "<empty>";
            }
            if (isSlotCovered(2)) buttonSave2.Text = "Load #2";
            else 
            {
                buttonSave2.Text = "Save #2";
                popGroupBox2.Controls[0].Text = "<empty>";
            }
            if (isSlotCovered(3)) buttonSave3.Text = "Load #3";
            else 
            {
                buttonSave3.Text = "Save #3";
                popGroupBox3.Controls[0].Text = "<empty>";
            }
            if (isSlotCovered(4)) buttonSave4.Text = "Load #4";
            else 
            {
                buttonSave4.Text = "Save #4";
                popGroupBox4.Controls[0].Text = "<empty>";
            }
            /*
            switch (saveId)
            {
                case 1:
                    buttonSave1.Text = "Save #1";
                    break;
                case 2:
                    buttonSave2.Text = "Save #2";
                    break;
                case 3:
                    buttonSave3.Text = "Save #3";
                    break;
                case 4:
                    buttonSave4.Text = "Save #4";
                    break;
            }*/
        }



        private void selectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FormManager.changeBackgroundImage(openFileDialog1.FileName);
                backgroundImagePath = openFileDialog1.FileName;
            }
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            loadSaveLogic(1);
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            loadSaveLogic(2);
        }

        private void buttonSave3_Click(object sender, EventArgs e)
        {
            loadSaveLogic(3);
        }

        private void buttonSave4_Click(object sender, EventArgs e)
        {
            loadSaveLogic(4);
        }

        private void loadSaveLogic(int saveId)
        {
            if (game.currentSaveId == saveId)
            {
                game.saveState(saveId);
                labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;
                MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (game.currentSaveId == 0)
            {
                if (isSlotCovered(saveId))
                {
                    if (game.hasPlayed())
                    {
                        DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            game.saveState(saveId);
                            labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;

                            MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == DialogResult.No)
                        {
                            loadSave(saveId);
                        }
                    }
                    else
                    {
                        loadSave(saveId);
                    }
                }
                else
                {
                    loadSave(saveId);
                }
            }
            else
            {
                if (game.getSave(game.currentSaveId).score != game.getScore() && isSlotCovered(saveId))
                {
                    DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        game.saveState(saveId);
                        labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;
                        MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        loadSave(saveId);
                    }
                }
                else if (isSlotCovered(game.currentSaveId))
                {
                    loadSave(saveId);
                }
                else
                {
                    game.saveState(saveId);
                    labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;
                    initLoadState(saveId);
                    MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            initLoadState(saveId);
            initializeSaves();
        }

        private void autoSaveSlot_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSaveSlot.Checked)
            {
                autoSaveEnabled = true;
                SavesManager.AddUpdateAppSettings("autosavegame", "True");
            }
            else
            {
                autoSaveEnabled = false;
                SavesManager.AddUpdateAppSettings("autosavegame", "False");
            }

        }

        private void autoSaveTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (popAutoSaveTheme.Checked)
            {
                autoSaveThemeEnabled = true;
                SavesManager.AddUpdateAppSettings("autosavetheme", "True");
            }
            else
            {
                autoSaveThemeEnabled = false;
                SavesManager.AddUpdateAppSettings("autosavetheme", "False");
            }
        }

        public void loadSave(int saveId)
        {
            game.getSaves();
            if (isSlotCovered(saveId))
            {
                game.setSaveFromFile(saveId);
                game.currentSaveId = saveId;
                labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;
                initLoadState(saveId);
                MessageBox.Show("Sucessfully loaded Save #" + saveId + "\n" + "Score: " + (long)game.getScore() + "\n" + "CreditsPerClick: " + (long)(game.getBonus() * game.getMultiplier()) + "\n" + "CreditsPerSecond: " + game.getPassiveBonus(),"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (game.getScore() > 0 || game.getBonus() > 1 || game.getMultiplier() > 1 || game.getPassiveBonus() > 0)
            {
                if (autoSaveEnabled)
                {
                    game.currentSaveId = saveId;
                    game.setSaveFromFile(saveId);
                }
                game.saveState(saveId);
                labelCurrentlyLoaded.Text = "Currently Loaded: Save #" + saveId;
                initLoadState(saveId);
                MessageBox.Show("Successfully saved current progress to Slot #" + saveId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This save slot is empty and your score is at 0. Start playing and come back to save or use the auto-save feature.");
            }
        }

        public void saveTheme() {
            string themePath = Application.LocalUserAppDataPath + @"\Themes\theme.txt";
            string[] lines = new string[6];
            lines[0] = FormManager.currentCommonTextColor.ToArgb().ToString();
            lines[1] = FormManager.currentButtonColor.ToArgb().ToString();
            lines[2] = FormManager.currentButtonTextColor.ToArgb().ToString();
            lines[3] = FormManager.currentSpecialTextColor.ToArgb().ToString();
            if (changeBackgroundEnabled)
            {
                if (changeToColorEnabled) lines[4] = FormManager.currentBackgroundColor.ToArgb().ToString();
                else lines[4] = "empty";
                if (useImageEnabled)
                {
                    if (File.Exists(FormManager.currentBackgroundImage))
                    {
                        lines[5] = FormManager.currentBackgroundImage;
                    }
                    else
                    {
                        lines[5] = "empty";
                    }
                }
                else lines[5] = "empty";
            }
            else
            {
                lines[4] = "empty";
                lines[5] = "empty";
            }
            writeToFile(themePath,lines);
        }

        public void loadTheme() {
            if (!Directory.Exists(Application.LocalUserAppDataPath + @"\Themes\")) Directory.CreateDirectory(Application.LocalUserAppDataPath + @"\Themes\");
            string themePath = Application.LocalUserAppDataPath + @"\Themes\theme.txt";
            if (File.Exists(themePath))
            {
                string[] lines = readFromFile(themePath);
                FormManager.changeCommonTextColor(Color.FromArgb(Int32.Parse(lines[0])));
                FormManager.changeButtonColor(Color.FromArgb(Int32.Parse(lines[1])));
                FormManager.changeButtonTextColor(Color.FromArgb(Int32.Parse(lines[2])));
                FormManager.changeSpecialTextColor(Color.FromArgb(Int32.Parse(lines[3])));
                string backColor = lines[4];
                string imagepath = lines[5];
                if (backColor != "empty")
                {
                    FormManager.changeBackgroundColor(Color.FromArgb(Int32.Parse(backColor)));
                }
                if (imagepath != "empty")
                {
                    FormManager.changeBackgroundImage(imagepath);
                }
            }
        }

        public string[] readFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            List<string> lines = new List<string>();
            for(int i = 0;i < 6; i++)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    lines.Add(line);
                }
            }
            sr.Close();
            return lines.ToArray();
        }

        public string[] readSaveFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            List<string> lines = new List<string>();
            
            while (true)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    lines.Add(line);
                }else
                {
                    break;
                }
            }
            sr.Close();
            return lines.ToArray();
        }



        public void writeToFile(string filepath,string[] lines)
        {
            StreamWriter sw = new StreamWriter(filepath);
            for(int i = 0;i < lines.Length;i++)
            {
                sw.WriteLine(lines[i]);
            }
            sw.Close();
        }

        public bool isSlotCovered(int saveId)
        {
            if (!Directory.Exists(Application.LocalUserAppDataPath + @"\Saves\")) return false;
            if (File.Exists(Application.LocalUserAppDataPath + @"\Saves\save" + saveId + ".txt")) return true;
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
                        shop.cheatSheet.setPrice(shop.cheatSheet.getPrice() + (shop.cheatSheet.getPrice() * 25 / 100));
                        break;
                    case "StudyGroup":
                        shop.studyGroup.setPrice(shop.studyGroup.getPrice() + (shop.studyGroup.getPrice() * 25 / 100));
                        break;
                    case "ConsultationHour":
                        shop.conHour.setPrice(shop.conHour.getPrice() + (shop.conHour.getPrice() * 25 / 100));
                        break;
                    case "OldExam":
                        shop.oldExam.setPrice(shop.oldExam.getPrice() + (shop.oldExam.getPrice() * 25 / 100));
                        break;
                    case "Insider":
                        shop.insider.setPrice(shop.insider.getPrice() + (shop.insider.getPrice() * 25 / 100));
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

        private void resetBackground_Click(object sender, EventArgs e)
        {
            FormManager.resetBackgroundImage();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            if (!optionsPanel.Visible)
            {
                game.playButtonSound();
                optionsPanel.Visible = true;
                themePanel.Visible = false;
                savesPanel.Visible = false;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!savesPanel.Visible)
            {
                game.playButtonSound();
                savesPanel.Visible = true;
                themePanel.Visible = false;
                optionsPanel.Visible = false;
            }
        }

        private void buttonTheme_Click(object sender, EventArgs e)
        { 
            if (!themePanel.Visible)
            {
                game.playButtonSound();
                themePanel.Visible = true;
                savesPanel.Visible = false;
                optionsPanel.Visible = false;
            }
        }

        private void quitButtonTheme_Click(object sender, EventArgs e)
        {
            game.playButtonSound();
            FormManager.initAllColors();
            this.Hide();
            game.Show();
        }

        private void quitButtonSave_Click(object sender, EventArgs e)
        {
            game.playButtonSound();
            FormManager.initAllColors();
            this.Hide();
            game.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            game.getMusicPlayer().settings.volume = musicVolumeBar.Value;
            musicVolTextBox.Text = musicVolumeBar.Value * 2 + "%";
            SavesManager.AddUpdateAppSettings("musicvolume", musicVolumeBar.Value.ToString());
        }

        private int getVolumeFromBox(TextBox box)
        {
            return Convert.ToInt32(box.Text);
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (musicVolTextBox.Text != "")
                {
                    if (getVolumeFromBox(musicVolTextBox) < 100)
                    {
                        musicVolumeBar.Value = getVolumeFromBox(musicVolTextBox) / 2;
                        game.getMusicPlayer().settings.volume = getVolumeFromBox(musicVolTextBox) / 2;
                        musicVolTextBox.Text = getVolumeFromBox(musicVolTextBox) + "%";
                        optionsPanel.Focus();
                    }
                    else
                    {
                        musicVolumeBar.Value = 50;
                        game.getMusicPlayer().settings.volume = 50;
                        musicVolTextBox.Text = 100 + "%";
                        optionsPanel.Focus();
                    }
                   
                }else
                {
                    musicVolTextBox.Text = musicVolumeBar.Value * 2 + "%";
                    optionsPanel.Focus();
                }
            }
            else if(e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar);
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (musicVolTextBox.Focused) musicVolTextBox.Text = "";
            }
        }

        private void effectsVolumeBar_Scroll(object sender, EventArgs e)
        {
            effectsVolTextBox.Text = effectsVolumeBar.Value * 2 + "%";
            game.waveChannel.Volume = effectsVolumeBar.Value / 50;
            SavesManager.AddUpdateAppSettings("effectsvolume", "" + Decimal.Divide(effectsVolumeBar.Value, 50));
        }

        private void effectsVolTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (effectsVolTextBox.Text != "")
                {
                    if (getVolumeFromBox(effectsVolTextBox) < 100)
                    {
                        effectsVolumeBar.Value = getVolumeFromBox(effectsVolTextBox) / 2;
                        game.waveChannel.Volume = getVolumeFromBox(effectsVolTextBox) / 50;
                        effectsVolTextBox.Text = getVolumeFromBox(effectsVolTextBox) + "%";
                        SavesManager.AddUpdateAppSettings("effectsvolume", "" + Decimal.Divide(effectsVolumeBar.Value, 50));
                        optionsPanel.Focus();
                    }
                    else
                    {
                        effectsVolumeBar.Value = 50;
                        game.waveChannel.Volume = 1;
                        effectsVolTextBox.Text = 100 + "%";
                        SavesManager.AddUpdateAppSettings("effectsvolume", "" + 1);
                        optionsPanel.Focus();
                    }

                }
                else
                {
                    effectsVolTextBox.Text = effectsVolumeBar.Value * 2 + "%";
                    optionsPanel.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar);
            }
        }

        private void effectsVolTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (effectsVolTextBox.Focused) effectsVolTextBox.Text = "";
            }
        }

        private void buttonVolumeBar_Scroll(object sender, EventArgs e)
        {
            game.getButtonPlayer().settings.volume = buttonVolumeBar.Value;
            buttonVolTextBox.Text = buttonVolumeBar.Value * 2 + "%";

            SavesManager.AddUpdateAppSettings("buttonvolume", buttonVolumeBar.Value.ToString());
        }

        private void buttonVolTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (buttonVolTextBox.Text != "")
                {
                    if (getVolumeFromBox(buttonVolTextBox) < 100)
                    {
                        buttonVolumeBar.Value = getVolumeFromBox(buttonVolTextBox) / 2;
                        game.getButtonPlayer().settings.volume = getVolumeFromBox(buttonVolTextBox) / 2;
                        buttonVolTextBox.Text = getVolumeFromBox(buttonVolTextBox) + "%";
                        optionsPanel.Focus();
                    }
                    else
                    {
                    }

                        buttonVolumeBar.Value = 50;
                        game.getButtonPlayer().settings.volume = 50;
                        buttonVolTextBox.Text = 100 + "%";
                        optionsPanel.Focus();
                }
                else
                {
                    buttonVolTextBox.Text = buttonVolumeBar.Value * 2 + "%";
                    optionsPanel.Focus();
                }
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar);
            }
        }

        private void buttonVolTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (buttonVolTextBox.Focused) buttonVolTextBox.Text = "";
            }
        }


        private void initializeSaves()
        {
            game.getSaves();
            for(int i = 1; i < 5;i++)
            {
                if (isSlotCovered(i))
                {
                    switch (i)
                    {
                        case 1:
                            popGroupBox1.Controls[0].Text = "" + (long) game.getSaveFromFile(1).score;
                            break;
                        case 2:
                            popGroupBox2.Controls[0].Text = "" + (long) game.getSaveFromFile(2).score;
                            break;
                        case 3:
                            popGroupBox3.Controls[0].Text = "" + (long) game.getSaveFromFile(3).score;
                            break;
                        case 4:
                            popGroupBox4.Controls[0].Text = "" + (long) game.getSaveFromFile(4).score;
                            break;
                    }
                }
            }
          
        }

        private void savesPanel_VisibleChanged(object sender, EventArgs e)
        {
            initLoadState(game.currentSaveId);
            initializeSaves();
        }
    }  
}
