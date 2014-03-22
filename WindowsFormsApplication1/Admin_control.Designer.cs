namespace Donhefinson
{
    partial class Admin_control
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
            this.ControlMotor = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ControlMotor
            // 
            this.ControlMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.ControlMotor.Location = new System.Drawing.Point(146, 92);
            this.ControlMotor.Name = "ControlMotor";
            this.ControlMotor.Size = new System.Drawing.Size(205, 66);
            this.ControlMotor.TabIndex = 0;
            this.ControlMotor.Text = "Control Motor";
            this.ControlMotor.UseVisualStyleBackColor = true;
            this.ControlMotor.Click += new System.EventHandler(this.ControlMotor_Click);
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(388, 414);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(84, 35);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // Admin_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.ControlMotor);
            this.Name = "Admin_control";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ControlMotor;
        private System.Windows.Forms.Button back_btn;
    }
}