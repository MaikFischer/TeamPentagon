using System;
using System.Drawing;

namespace CreditClicker
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameSoundPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonSoundPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.musicPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.hoogePentagon = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.startGameButton = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCurrentBonus = new System.Windows.Forms.Label();
            this.lblCurrentCPS = new System.Windows.Forms.Label();
            this.lblPerClick = new System.Windows.Forms.Label();
            this.lblPerSecond = new System.Windows.Forms.Label();
            this.lblCreditsPerSecond = new System.Windows.Forms.Label();
            this.lblBonus = new System.Windows.Forms.Label();
            this.lblpentagonGame = new System.Windows.Forms.Label();
            this.settingsButtonGame = new System.Windows.Forms.Button();
            this.menuButtonGame = new System.Windows.Forms.Button();
            this.shopButtonGame = new System.Windows.Forms.Button();
            this.versionGame = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.ClickArea = new System.Windows.Forms.PictureBox();
            this.titleGame = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonBackToGameSettings = new System.Windows.Forms.Button();
            this.menuButtonSettings = new System.Windows.Forms.Button();
            this.button2Settings = new System.Windows.Forms.Button();
            this.versionSettings = new System.Windows.Forms.Label();
            this.titleSettings = new System.Windows.Forms.Label();
            this.button1Settings = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSoundPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSoundPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClickArea)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.gameSoundPlayer);
            this.panel1.Controls.Add(this.buttonSoundPlayer);
            this.panel1.Controls.Add(this.musicPlayer);
            this.panel1.Controls.Add(this.hoogePentagon);
            this.panel1.Controls.Add(this.quitButton);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.startGameButton);
            this.panel1.Controls.Add(this.version);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 368);
            this.panel1.TabIndex = 11;
            // 
            // gameSoundPlayer
            // 
            this.gameSoundPlayer.Enabled = true;
            this.gameSoundPlayer.Location = new System.Drawing.Point(58, 132);
            this.gameSoundPlayer.Name = "gameSoundPlayer";
            this.gameSoundPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("gameSoundPlayer.OcxState")));
            this.gameSoundPlayer.Size = new System.Drawing.Size(75, 23);
            this.gameSoundPlayer.TabIndex = 14;
            this.gameSoundPlayer.Visible = false;
            // 
            // buttonSoundPlayer
            // 
            this.buttonSoundPlayer.Enabled = true;
            this.buttonSoundPlayer.Location = new System.Drawing.Point(67, 183);
            this.buttonSoundPlayer.Name = "buttonSoundPlayer";
            this.buttonSoundPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("buttonSoundPlayer.OcxState")));
            this.buttonSoundPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonSoundPlayer.TabIndex = 13;
            this.buttonSoundPlayer.Visible = false;
            // 
            // musicPlayer
            // 
            this.musicPlayer.Enabled = true;
            this.musicPlayer.Location = new System.Drawing.Point(86, 255);
            this.musicPlayer.Name = "musicPlayer";
            this.musicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("musicPlayer.OcxState")));
            this.musicPlayer.Size = new System.Drawing.Size(75, 23);
            this.musicPlayer.TabIndex = 12;
            this.musicPlayer.Visible = false;
            // 
            // hoogePentagon
            // 
            this.hoogePentagon.AutoSize = true;
            this.hoogePentagon.BackColor = System.Drawing.Color.Transparent;
            this.hoogePentagon.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoogePentagon.ForeColor = System.Drawing.Color.White;
            this.hoogePentagon.Location = new System.Drawing.Point(184, 338);
            this.hoogePentagon.Name = "hoogePentagon";
            this.hoogePentagon.Size = new System.Drawing.Size(112, 14);
            this.hoogePentagon.TabIndex = 10;
            this.hoogePentagon.Text = "by Team Pentagon";
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.DarkOrange;
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Black;
            this.quitButton.Location = new System.Drawing.Point(148, 252);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(191, 54);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "QUIT ";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.Black;
            this.buttonSettings.Location = new System.Drawing.Point(148, 176);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(191, 54);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.Text = "SETTINGS";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.DarkOrange;
            this.startGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGameButton.FlatAppearance.BorderSize = 0;
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.ForeColor = System.Drawing.Color.Black;
            this.startGameButton.Location = new System.Drawing.Point(148, 97);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(191, 54);
            this.startGameButton.TabIndex = 7;
            this.startGameButton.Text = "START GAME";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.DarkOrange;
            this.version.Location = new System.Drawing.Point(346, 27);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(0, 14);
            this.version.TabIndex = 5;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("hooge 05_55", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.DarkOrange;
            this.Title.Location = new System.Drawing.Point(125, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(232, 36);
            this.Title.TabIndex = 1;
            this.Title.Text = "Credit Clicker";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::CreditClicker.Properties.Resources.backgroundanimated;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(493, 368);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::CreditClicker.Properties.Resources.backgroundanimated;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(493, 507);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::CreditClicker.Properties.Resources.backgroundanimated;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(493, 368);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblCurrentBonus);
            this.panel2.Controls.Add(this.lblCurrentCPS);
            this.panel2.Controls.Add(this.lblPerClick);
            this.panel2.Controls.Add(this.lblPerSecond);
            this.panel2.Controls.Add(this.lblCreditsPerSecond);
            this.panel2.Controls.Add(this.lblBonus);
            this.panel2.Controls.Add(this.lblpentagonGame);
            this.panel2.Controls.Add(this.settingsButtonGame);
            this.panel2.Controls.Add(this.menuButtonGame);
            this.panel2.Controls.Add(this.shopButtonGame);
            this.panel2.Controls.Add(this.versionGame);
            this.panel2.Controls.Add(this.score);
            this.panel2.Controls.Add(this.ClickArea);
            this.panel2.Controls.Add(this.titleGame);
            this.panel2.Controls.Add(this.lblScore);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 504);
            this.panel2.TabIndex = 9;
            // 
            // lblCurrentBonus
            // 
            this.lblCurrentBonus.AutoSize = true;
            this.lblCurrentBonus.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentBonus.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBonus.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblCurrentBonus.Location = new System.Drawing.Point(25, 155);
            this.lblCurrentBonus.Name = "lblCurrentBonus";
            this.lblCurrentBonus.Size = new System.Drawing.Size(17, 24);
            this.lblCurrentBonus.TabIndex = 12;
            this.lblCurrentBonus.Text = "1";
            // 
            // lblCurrentCPS
            // 
            this.lblCurrentCPS.AutoSize = true;
            this.lblCurrentCPS.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentCPS.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCPS.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblCurrentCPS.Location = new System.Drawing.Point(25, 237);
            this.lblCurrentCPS.Name = "lblCurrentCPS";
            this.lblCurrentCPS.Size = new System.Drawing.Size(22, 24);
            this.lblCurrentCPS.TabIndex = 14;
            this.lblCurrentCPS.Text = "0";
            // 
            // lblPerClick
            // 
            this.lblPerClick.AutoSize = true;
            this.lblPerClick.BackColor = System.Drawing.Color.Transparent;
            this.lblPerClick.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerClick.ForeColor = System.Drawing.Color.White;
            this.lblPerClick.Location = new System.Drawing.Point(26, 132);
            this.lblPerClick.Name = "lblPerClick";
            this.lblPerClick.Size = new System.Drawing.Size(62, 14);
            this.lblPerClick.TabIndex = 16;
            this.lblPerClick.Text = "per Click";
            // 
            // lblPerSecond
            // 
            this.lblPerSecond.AutoSize = true;
            this.lblPerSecond.BackColor = System.Drawing.Color.Transparent;
            this.lblPerSecond.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerSecond.ForeColor = System.Drawing.Color.White;
            this.lblPerSecond.Location = new System.Drawing.Point(23, 209);
            this.lblPerSecond.Name = "lblPerSecond";
            this.lblPerSecond.Size = new System.Drawing.Size(74, 14);
            this.lblPerSecond.TabIndex = 15;
            this.lblPerSecond.Text = "per Second";
            // 
            // lblCreditsPerSecond
            // 
            this.lblCreditsPerSecond.AutoSize = true;
            this.lblCreditsPerSecond.BackColor = System.Drawing.Color.Transparent;
            this.lblCreditsPerSecond.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsPerSecond.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCreditsPerSecond.Location = new System.Drawing.Point(19, 185);
            this.lblCreditsPerSecond.Name = "lblCreditsPerSecond";
            this.lblCreditsPerSecond.Size = new System.Drawing.Size(85, 24);
            this.lblCreditsPerSecond.TabIndex = 10;
            this.lblCreditsPerSecond.Text = "Credits";
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.BackColor = System.Drawing.Color.Transparent;
            this.lblBonus.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblBonus.Location = new System.Drawing.Point(19, 108);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(85, 24);
            this.lblBonus.TabIndex = 9;
            this.lblBonus.Text = "Credits";
            // 
            // lblpentagonGame
            // 
            this.lblpentagonGame.AutoSize = true;
            this.lblpentagonGame.BackColor = System.Drawing.Color.Transparent;
            this.lblpentagonGame.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpentagonGame.ForeColor = System.Drawing.Color.White;
            this.lblpentagonGame.Location = new System.Drawing.Point(185, 482);
            this.lblpentagonGame.Name = "lblpentagonGame";
            this.lblpentagonGame.Size = new System.Drawing.Size(112, 14);
            this.lblpentagonGame.TabIndex = 8;
            this.lblpentagonGame.Text = "by Team Pentagon";
            // 
            // settingsButtonGame
            // 
            this.settingsButtonGame.BackColor = System.Drawing.Color.DarkOrange;
            this.settingsButtonGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settingsButtonGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButtonGame.FlatAppearance.BorderSize = 0;
            this.settingsButtonGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButtonGame.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButtonGame.ForeColor = System.Drawing.Color.Black;
            this.settingsButtonGame.Location = new System.Drawing.Point(23, 382);
            this.settingsButtonGame.Name = "settingsButtonGame";
            this.settingsButtonGame.Size = new System.Drawing.Size(138, 54);
            this.settingsButtonGame.TabIndex = 7;
            this.settingsButtonGame.Text = "SETTINGS";
            this.settingsButtonGame.UseVisualStyleBackColor = false;
            this.settingsButtonGame.Click += new System.EventHandler(this.settingsButtonGame_Click);
            // 
            // menuButtonGame
            // 
            this.menuButtonGame.BackColor = System.Drawing.Color.DarkOrange;
            this.menuButtonGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuButtonGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButtonGame.FlatAppearance.BorderSize = 0;
            this.menuButtonGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButtonGame.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButtonGame.ForeColor = System.Drawing.Color.Black;
            this.menuButtonGame.Location = new System.Drawing.Point(322, 382);
            this.menuButtonGame.Name = "menuButtonGame";
            this.menuButtonGame.Size = new System.Drawing.Size(148, 54);
            this.menuButtonGame.TabIndex = 6;
            this.menuButtonGame.Text = "MAIN MENU";
            this.menuButtonGame.UseVisualStyleBackColor = false;
            this.menuButtonGame.Click += new System.EventHandler(this.menuButtonGame_Click);
            // 
            // shopButtonGame
            // 
            this.shopButtonGame.BackColor = System.Drawing.Color.DarkOrange;
            this.shopButtonGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shopButtonGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shopButtonGame.FlatAppearance.BorderSize = 0;
            this.shopButtonGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shopButtonGame.Font = new System.Drawing.Font("hooge 05_53", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopButtonGame.ForeColor = System.Drawing.Color.Black;
            this.shopButtonGame.Location = new System.Drawing.Point(188, 409);
            this.shopButtonGame.Name = "shopButtonGame";
            this.shopButtonGame.Size = new System.Drawing.Size(109, 54);
            this.shopButtonGame.TabIndex = 5;
            this.shopButtonGame.Text = "SHOP";
            this.shopButtonGame.UseVisualStyleBackColor = false;
            this.shopButtonGame.Click += new System.EventHandler(this.shopButtonGame_Click);
            // 
            // versionGame
            // 
            this.versionGame.AutoSize = true;
            this.versionGame.BackColor = System.Drawing.Color.Transparent;
            this.versionGame.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.versionGame.Location = new System.Drawing.Point(349, 27);
            this.versionGame.Name = "versionGame";
            this.versionGame.Size = new System.Drawing.Size(0, 14);
            this.versionGame.TabIndex = 4;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.SlateBlue;
            this.score.Location = new System.Drawing.Point(200, 61);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(22, 24);
            this.score.TabIndex = 3;
            this.score.Text = "0";
            this.score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClickArea
            // 
            this.ClickArea.BackColor = System.Drawing.Color.Transparent;
            this.ClickArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClickArea.Image = global::CreditClicker.Properties.Resources.clickme;
            this.ClickArea.Location = new System.Drawing.Point(114, 106);
            this.ClickArea.Name = "ClickArea";
            this.ClickArea.Size = new System.Drawing.Size(282, 235);
            this.ClickArea.TabIndex = 1;
            this.ClickArea.TabStop = false;
            this.ClickArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClickArea_MouseDown);
            // 
            // titleGame
            // 
            this.titleGame.AutoSize = true;
            this.titleGame.BackColor = System.Drawing.Color.Transparent;
            this.titleGame.Font = new System.Drawing.Font("hooge 05_55", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleGame.ForeColor = System.Drawing.Color.DarkOrange;
            this.titleGame.Location = new System.Drawing.Point(129, 9);
            this.titleGame.Name = "titleGame";
            this.titleGame.Size = new System.Drawing.Size(232, 36);
            this.titleGame.TabIndex = 0;
            this.titleGame.Text = "Credit Clicker";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("hooge 05_55", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblScore.Location = new System.Drawing.Point(113, 61);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(75, 24);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score:";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 12;
            // 
            // buttonBackToGameSettings
            // 
            this.buttonBackToGameSettings.Location = new System.Drawing.Point(0, 0);
            this.buttonBackToGameSettings.Name = "buttonBackToGameSettings";
            this.buttonBackToGameSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonBackToGameSettings.TabIndex = 0;
            // 
            // menuButtonSettings
            // 
            this.menuButtonSettings.Location = new System.Drawing.Point(0, 0);
            this.menuButtonSettings.Name = "menuButtonSettings";
            this.menuButtonSettings.Size = new System.Drawing.Size(75, 23);
            this.menuButtonSettings.TabIndex = 0;
            // 
            // button2Settings
            // 
            this.button2Settings.Location = new System.Drawing.Point(0, 0);
            this.button2Settings.Name = "button2Settings";
            this.button2Settings.Size = new System.Drawing.Size(75, 23);
            this.button2Settings.TabIndex = 0;
            // 
            // versionSettings
            // 
            this.versionSettings.Location = new System.Drawing.Point(0, 0);
            this.versionSettings.Name = "versionSettings";
            this.versionSettings.Size = new System.Drawing.Size(100, 23);
            this.versionSettings.TabIndex = 0;
            // 
            // titleSettings
            // 
            this.titleSettings.Location = new System.Drawing.Point(0, 0);
            this.titleSettings.Name = "titleSettings";
            this.titleSettings.Size = new System.Drawing.Size(100, 23);
            this.titleSettings.TabIndex = 0;
            // 
            // button1Settings
            // 
            this.button1Settings.Location = new System.Drawing.Point(0, 0);
            this.button1Settings.Name = "button1Settings";
            this.button1Settings.Size = new System.Drawing.Size(75, 23);
            this.button1Settings.TabIndex = 0;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = " ";
            this.Activated += new System.EventHandler(this.Game_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.Shown += new System.EventHandler(this.Game_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSoundPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSoundPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClickArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label hoogePentagon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleGame;
        private System.Windows.Forms.PictureBox ClickArea;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label versionGame;
        private System.Windows.Forms.Button shopButtonGame;
        private System.Windows.Forms.Button menuButtonGame;
        private System.Windows.Forms.Button settingsButtonGame;
        private System.Windows.Forms.Label lblpentagonGame;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label versionSettings;
        private System.Windows.Forms.Label titleSettings;
        private System.Windows.Forms.Button button1Settings;
        private System.Windows.Forms.Button menuButtonSettings;
        private System.Windows.Forms.Button button2Settings;
        private System.Windows.Forms.Button buttonBackToGameSettings;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.Label lblCurrentBonus;
        private System.Windows.Forms.Label lblCreditsPerSecond;
        private System.Windows.Forms.Label lblCurrentCPS;
        private System.Windows.Forms.Label lblPerClick;
        private System.Windows.Forms.Label lblPerSecond;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private AxWMPLib.AxWindowsMediaPlayer musicPlayer;
        private AxWMPLib.AxWindowsMediaPlayer buttonSoundPlayer;
        private AxWMPLib.AxWindowsMediaPlayer gameSoundPlayer;
    }
}
