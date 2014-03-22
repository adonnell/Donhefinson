namespace Donhefinson
{
    partial class Main
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
            this.openSerial = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.DrinkMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openSerial
            // 
            this.openSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.openSerial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openSerial.Location = new System.Drawing.Point(128, 135);
            this.openSerial.Name = "openSerial";
            this.openSerial.Size = new System.Drawing.Size(221, 97);
            this.openSerial.TabIndex = 0;
            this.openSerial.Text = "Initialize";
            this.openSerial.UseVisualStyleBackColor = true;
            this.openSerial.Click += new System.EventHandler(this.openSerial_Click);
            // 
            // Admin
            // 
            this.Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Admin.Location = new System.Drawing.Point(363, 410);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(109, 39);
            this.Admin.TabIndex = 1;
            this.Admin.Text = "Admin";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            this.Admin.Hide();
            // 
            // DrinkMenu
            // 
            this.DrinkMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.DrinkMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DrinkMenu.Location = new System.Drawing.Point(128, 135);
            this.DrinkMenu.Name = "DrinkMenu";
            this.DrinkMenu.Size = new System.Drawing.Size(221, 97);
            this.DrinkMenu.TabIndex = 2;
            this.DrinkMenu.Text = "Drink Menu";
            this.DrinkMenu.UseVisualStyleBackColor = true;
            this.DrinkMenu.Click += new System.EventHandler(this.DrinkMenu_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.openSerial);
            this.Controls.Add(this.DrinkMenu);
            this.Controls.Add(this.Admin);
            this.MaximumSize = this.ClientSize;
            this.MinimumSize = this.ClientSize;
            this.Name = "Main";
            this.Text = "DonHefinSon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openSerial;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Button DrinkMenu;
    }
}