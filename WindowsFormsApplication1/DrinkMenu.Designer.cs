using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Donhefinson
{
    partial class DrinkMenu
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
            this.FindBy = new System.Windows.Forms.TabControl();
            this.ByName = new System.Windows.Forms.TabPage();
            this.Results = new System.Windows.Forms.ListBox();
            this.search = new System.Windows.Forms.Button();
            this.SearchFor = new System.Windows.Forms.TextBox();
            this.ByIngredient = new System.Windows.Forms.TabPage();
            this.Favorites = new System.Windows.Forms.TabPage();
            this.FindBy.SuspendLayout();
            this.ByName.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindBy
            // 
            this.FindBy.Controls.Add(this.ByName);
            this.FindBy.Controls.Add(this.ByIngredient);
            this.FindBy.Controls.Add(this.Favorites);
            this.FindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.FindBy.Location = new System.Drawing.Point(1, -3);
            this.FindBy.Name = "FindBy";
            this.FindBy.SelectedIndex = 0;
            this.FindBy.Size = new System.Drawing.Size(486, 468);
            this.FindBy.TabIndex = 3;
            // 
            // ByName
            // 
            this.ByName.Controls.Add(this.Results);
            this.ByName.Controls.Add(this.search);
            this.ByName.Controls.Add(this.SearchFor);
            this.ByName.Location = new System.Drawing.Point(4, 35);
            this.ByName.Name = "ByName";
            this.ByName.Padding = new System.Windows.Forms.Padding(3);
            this.ByName.Size = new System.Drawing.Size(478, 429);
            this.ByName.TabIndex = 0;
            this.ByName.Text = "Find By Name";
            this.ByName.UseVisualStyleBackColor = true;
            // 
            // Results
            // 
            this.Results.FormattingEnabled = true;
            this.Results.ItemHeight = 26;
            this.Results.Location = new System.Drawing.Point(0, 45);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(467, 368);
            this.Results.TabIndex = 2;
            this.Results.SelectedIndexChanged += new System.EventHandler(this.Results_SelectedIndexChanged);
            this.Results.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.results_MouseDoubleClick);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.search.Location = new System.Drawing.Point(335, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(132, 32);
            this.search.TabIndex = 1;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // SearchFor
            // 
            this.SearchFor.Location = new System.Drawing.Point(10, 11);
            this.SearchFor.Name = "SearchFor";
            this.SearchFor.Size = new System.Drawing.Size(319, 32);
            this.SearchFor.TabIndex = 0;
            // 
            // ByIngredient
            // 
            this.ByIngredient.Location = new System.Drawing.Point(4, 35);
            this.ByIngredient.Name = "ByIngredient";
            this.ByIngredient.Padding = new System.Windows.Forms.Padding(3);
            this.ByIngredient.Size = new System.Drawing.Size(477, 427);
            this.ByIngredient.TabIndex = 1;
            this.ByIngredient.Text = "Find By Ingredient";
            this.ByIngredient.UseVisualStyleBackColor = true;
            // 
            // Favorites
            // 
            this.Favorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Favorites.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Favorites.Location = new System.Drawing.Point(4, 35);
            this.Favorites.Name = "Favorites";
            this.Favorites.Padding = new System.Windows.Forms.Padding(3);
            this.Favorites.Size = new System.Drawing.Size(477, 427);
            this.Favorites.TabIndex = 2;
            this.Favorites.Text = "Favorites";
            this.Favorites.UseVisualStyleBackColor = true;
            // 
            // DrinkMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 486);
            this.Controls.Add(this.FindBy);
            this.MaximumSize = this.ClientSize;
            this.MinimumSize = this.ClientSize;
            this.Name = "DrinkMenu";
            this.FindBy.ResumeLayout(false);
            this.ByName.ResumeLayout(false);
            this.ByName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private List<System.Windows.Forms.Button> Buttons = new List<System.Windows.Forms.Button>();
        private System.Windows.Forms.TabControl FindBy;
        private System.Windows.Forms.TabPage ByName;
        private System.Windows.Forms.TabPage ByIngredient;
        private System.Windows.Forms.TabPage Favorites;
        private System.Windows.Forms.ListBox Results;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox SearchFor;
        private AutoCompleteStringCollection source;
    }
}

// make it so you can type in lower or upper case on admin menu. Next button for ingredients.