namespace Donhefinson
{
    partial class DrinkInfo
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
            this.MakeDrink = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MakeDrink
            // 
            this.MakeDrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.MakeDrink.Location = new System.Drawing.Point(124, 429);
            this.MakeDrink.Name = "MakeDrink";
            this.MakeDrink.Size = new System.Drawing.Size(234, 67);
            this.MakeDrink.TabIndex = 2;
            this.MakeDrink.Text = "Make Drink";
            this.MakeDrink.UseVisualStyleBackColor = true;
            this.MakeDrink.Click += new System.EventHandler(this.MakeDrink_Click);
            // 
            // statusText
            // 
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.statusText.Location = new System.Drawing.Point(124, 391);
            this.statusText.Name = "statusText";
            this.statusText.ReadOnly = true;
            this.statusText.Size = new System.Drawing.Size(234, 32);
            this.statusText.TabIndex = 1;
            this.statusText.Visible = false;
            // 
            // DrinkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 515);
            this.ControlBox = false;
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.MakeDrink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrinkInfo";
            this.Text = "DrinkInfo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MakeDrink;
        private System.Windows.Forms.TextBox statusText;
        private Drink theDrink;
        private bool alreadyrunning;
    }
}