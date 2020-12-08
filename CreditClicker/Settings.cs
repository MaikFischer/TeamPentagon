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
            initAppSettings();
            loadTheme();
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
                autoSaveTheme.Checked = true;
                autoSaveThemeEnabled = true;
            }else {
                autoSaveTheme.Checked = false;
                autoSaveThemeEnabled = false;
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["changeback"]))
            {
                changeBackground.Checked = true;
                changeBackgroundEnabled = true;
            }else
            {
                changeBackground.Checked = false;
                changeBackgroundEnabled = false;
                changeToColorEnabled = false;
                useImageEnabled = false;
            }
            //Change Background to Color
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["changetocolor"])) {
                changeToColor.Checked = true;
                changeToColorEnabled = true;
            }else {
                changeToColor.Checked = false;
                changeToColorEnabled = false;
            }
            //Use Background Image
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["useimage"])) {
                useImage.Checked = true;
                useImageEnabled = true;
            }else {
                useImage.Checked = false;
                useImageEnabled = false;
            }
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
                changeBackgroundEnabled = true;
                resetBackground.Visible = true;
                SavesManager.AddUpdateAppSettings("changeback", "True");
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["changetocolor"]))
                {
                    changeToColorEnabled = true;
                    changeToColor.Checked = true;
                }
                else
                {
                    changeToColorEnabled = false;
                    changeToColor.Checked = false;
                }
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["useimage"]))
                {
                    useImage.Checked = true;
                    useImageEnabled = true;
                }
                else
                {
                    useImageEnabled = false;
                    useImage.Checked = false;
                }

            }else
            {
                changeToColor.Checked = false;
                changeToColor.Visible = false; 
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;
                useImage.Checked = false;
                useImage.Visible = false;
                useImageEnabled = false;
                changeBackgroundEnabled = false;
                resetBackground.Visible = false;
                SavesManager.AddUpdateAppSettings("changeback", "False");
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
                SavesManager.AddUpdateAppSettings("useimage", "False");
            }
        }

        private void changeToColor_CheckedChanged(object sender, EventArgs e)
        {
            if (changeToColor.Checked)
            {
                useImage.Checked = false;
                useImageEnabled = false;
                selectImage.Visible = false;
                lblBackground.Visible = true;
                colorAreaBackground.Visible = true;
                pickBackgroundColor.Visible = true;
                changeToColorEnabled = true;
                SavesManager.AddUpdateAppSettings("changetocolor", "True");
                SavesManager.AddUpdateAppSettings("useimage", "False");
            }
            else
            {
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
            }
        }

        private void useImage_CheckedChanged(object sender, EventArgs e)
        {
            if (useImage.Checked)
            {
                changeToColor.Checked = false;
                changeToColorEnabled = false;
                lblBackground.Visible = false;
                colorAreaBackground.Visible = false;
                pickBackgroundColor.Visible = false;
                selectImage.Visible = true;
                useImageEnabled = true;
                SavesManager.AddUpdateAppSettings("useimage", "True");
                SavesManager.AddUpdateAppSettings("changetocolor", "False");
            }
            else
            {
                selectImage.Visible = false;
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
                backgroundImagePath = openFileDialog1.FileName;
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
                if (isSlotCovered(1))
                {
                    if (game.hasPlayed()) {
                        DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            game.saveState(1);
                            game.currentSaveId = 1;
                            MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == DialogResult.No)
                        {
                            loadSave(1);
                        }
                    }else {
                        loadSave(1);
                    }
                }
                else
                {
                    loadSave(1);                
                }
            }
            else
            {
                if (game.getSave(game.currentSaveId).score != game.getScore()) {
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
                else if (isSlotCovered(game.currentSaveId))
                {
                    loadSave(1);
                }
                else
                {
                    game.saveState(1);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 1, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (isSlotCovered(2))
                {
                    if (game.hasPlayed()) {
                        DialogResult result = MessageBox.Show("This Slot is covered. Do you wish to overwrite or load from it? Press 'Yes' to override and 'No' to load.", "Slot covered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            game.saveState(2);
                            game.currentSaveId = 2;
                            MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == DialogResult.No)
                        {
                            loadSave(2);
                        }
                    }else {
                        loadSave(2);
                    }
                }
                else
                {
                    loadSave(2);
                }
            }
            else
            {
                if (game.getSave(game.currentSaveId).score != game.getScore() && isSlotCovered(2)) {
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
                }else if (isSlotCovered(game.currentSaveId)){
                    loadSave(2);
                }else
                {
                    game.saveState(2);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (isSlotCovered(3))
                {
                    if (game.hasPlayed())
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
                    else
                    {
                        loadSave(3);
                    }
                }
                else
                {
                    loadSave(3);
                }
            }
            else
            {
                if (game.getSave(game.currentSaveId).score != game.getScore()) {
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
                else if (isSlotCovered(game.currentSaveId))
                {
                    loadSave(3);
                }
                else
                {
                    game.saveState(3);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 3, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonSave4_Click(object sender, EventArgs e)
        {
            if (game.currentSaveId == 4)
            {
                game.saveState(4);
                MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (game.currentSaveId == 0)
            {
                if (isSlotCovered(4))
                {
                    if (game.hasPlayed())
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
                    }
                    else
                    {
                        loadSave(4);
                    }
                }
                else
                {
                    loadSave(4);
                }
            }
            else
            {
                if (game.getSave(game.currentSaveId).score != game.getScore()) {
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
                }
                else if (isSlotCovered(game.currentSaveId))
                {
                    loadSave(4);
                }
                else
                {
                    game.saveState(4);
                    MessageBox.Show("Successfully saved current progress to Slot #" + 4, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            if (autoSaveTheme.Checked)
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
                game.getSaveFromFile(saveId);
                game.currentSaveId = saveId;
                MessageBox.Show("Sucessfully loaded Save #" + saveId + "\n" + "Score: " + (long)game.getScore() + "\n" + "CreditsPerClick: " + (long)(game.getBonus() * game.getMultiplier()) + "\n" + "CreditsPerSecond: " + game.getPassiveBonus(),"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (game.getScore() > 0 || game.getBonus() > 1 || game.getMultiplier() > 1 || game.getPassiveBonus() > 0)
            {
                if (autoSaveEnabled)
                {
                    game.currentSaveId = saveId;
                    game.getSaveFromFile(saveId);
                }
                game.saveState(saveId);
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
            optionsPanel.Visible = true;
            themePanel.Visible = false;
            savesPanel.Visible = false;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            savesPanel.Visible = true;
            themePanel.Visible = false;
            optionsPanel.Visible = false;
        }

        private void buttonTheme_Click(object sender, EventArgs e)
        {
            themePanel.Visible = true;
            savesPanel.Visible = false;
            optionsPanel.Visible = false;
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
    }  
}
