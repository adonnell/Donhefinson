namespace WindowsFormsApplication1
{
    partial class drinkMenu
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.OpenSerial = new System.Windows.Forms.Button();
            this.LongIsland = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BayBreeze = new System.Windows.Forms.Button();
            this.AdiosMF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // OpenSerial
            // 
            this.OpenSerial.Location = new System.Drawing.Point(103, 46);
            this.OpenSerial.Name = "OpenSerial";
            this.OpenSerial.Size = new System.Drawing.Size(75, 23);
            this.OpenSerial.TabIndex = 1;
            this.OpenSerial.Text = "Open Serial";
            this.OpenSerial.UseVisualStyleBackColor = true;
            this.OpenSerial.Click += new System.EventHandler(this.openSerial_Click);
            // 
            // LongIsland
            // 
            this.LongIsland.Location = new System.Drawing.Point(12, 182);
            this.LongIsland.Name = "LongIsland";
            this.LongIsland.Size = new System.Drawing.Size(86, 40);
            this.LongIsland.TabIndex = 3;
            this.LongIsland.Text = "Long Island Iced Tea";
            this.LongIsland.UseVisualStyleBackColor = true;
            this.LongIsland.Click += new System.EventHandler(this.MakeDrink);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 4;
            // 
            // BayBreeze
            // 
            this.BayBreeze.Location = new System.Drawing.Point(104, 182);
            this.BayBreeze.Name = "BayBreeze";
            this.BayBreeze.Size = new System.Drawing.Size(71, 40);
            this.BayBreeze.TabIndex = 5;
            this.BayBreeze.Text = "Malibu Bay Breeze";
            this.BayBreeze.UseVisualStyleBackColor = true;
            this.BayBreeze.Click += new System.EventHandler(this.MakeDrink);
            // 
            // AdiosMF
            // 
            this.AdiosMF.Location = new System.Drawing.Point(181, 182);
            this.AdiosMF.Name = "AdiosMF";
            this.AdiosMF.Size = new System.Drawing.Size(91, 40);
            this.AdiosMF.TabIndex = 6;
            this.AdiosMF.Text = "Adios Motherfucker";
            this.AdiosMF.UseVisualStyleBackColor = true;
            this.AdiosMF.Click += new System.EventHandler(this.MakeDrink);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AdiosMF);
            this.Controls.Add(this.BayBreeze);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LongIsland);
            this.Controls.Add(this.OpenSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button OpenSerial;
        private System.Windows.Forms.Button LongIsland;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BayBreeze;
        private System.Windows.Forms.Button AdiosMF;
    }
}

