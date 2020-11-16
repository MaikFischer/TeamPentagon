namespace CreditClicker
{
    partial class Shop
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
            this.titleShop = new System.Windows.Forms.Label();
            this.lblpentagon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleShop
            // 
            this.titleShop.AutoSize = true;
            this.titleShop.BackColor = System.Drawing.Color.Transparent;
            this.titleShop.Font = new System.Drawing.Font("hooge 05_55", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.titleShop.Location = new System.Drawing.Point(146, 9);
            this.titleShop.Name = "titleShop";
            this.titleShop.Size = new System.Drawing.Size(192, 36);
            this.titleShop.TabIndex = 2;
            this.titleShop.Text = "CREDIT SHOP";
            // 
            // lblpentagon
            // 
            this.lblpentagon.AutoSize = true;
            this.lblpentagon.BackColor = System.Drawing.Color.Transparent;
            this.lblpentagon.Font = new System.Drawing.Font("hooge 05_55", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpentagon.ForeColor = System.Drawing.Color.White;
            this.lblpentagon.Location = new System.Drawing.Point(180, 482);
            this.lblpentagon.Name = "lblpentagon";
            this.lblpentagon.Size = new System.Drawing.Size(112, 14);
            this.lblpentagon.TabIndex = 11;
            this.lblpentagon.Text = "by Team Pentagon";
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CreditClicker.Properties.Resources.finalbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 505);
            this.Controls.Add(this.lblpentagon);
            this.Controls.Add(this.titleShop);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Shop";
            this.Text = "Credit Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleShop;
        private System.Windows.Forms.Label lblpentagon;
    }
}