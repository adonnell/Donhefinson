namespace Donhefinson
{
    partial class MotorControl
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
            this.do_step = new System.Windows.Forms.Button();
            this.step_text = new System.Windows.Forms.TextBox();
            this.speedbar = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.Speed = new System.Windows.Forms.Label();
            this.Accel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speedbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // do_step
            // 
            this.do_step.Location = new System.Drawing.Point(170, 347);
            this.do_step.Name = "do_step";
            this.do_step.Size = new System.Drawing.Size(122, 39);
            this.do_step.TabIndex = 4;
            this.do_step.Text = "Step";
            this.do_step.UseVisualStyleBackColor = true;
            this.do_step.Click += new System.EventHandler(this.do_step_Click);
            // 
            // step_text
            // 
            this.step_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.step_text.Location = new System.Drawing.Point(156, 281);
            this.step_text.Name = "step_text";
            this.step_text.Size = new System.Drawing.Size(161, 31);
            this.step_text.TabIndex = 5;
            // 
            // speedbar
            // 
            this.speedbar.LargeChange = 1000;
            this.speedbar.Location = new System.Drawing.Point(47, 80);
            this.speedbar.Maximum = 5000;
            this.speedbar.Name = "speedbar";
            this.speedbar.Size = new System.Drawing.Size(389, 45);
            this.speedbar.SmallChange = 500;
            this.speedbar.TabIndex = 6;
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 600;
            this.trackBar2.Location = new System.Drawing.Point(47, 174);
            this.trackBar2.Maximum = 3000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(389, 45);
            this.trackBar2.SmallChange = 300;
            this.trackBar2.TabIndex = 7;
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Speed.Location = new System.Drawing.Point(54, 46);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(74, 25);
            this.Speed.TabIndex = 8;
            this.Speed.Text = "Speed";
            // 
            // Accel
            // 
            this.Accel.AutoSize = true;
            this.Accel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Accel.Location = new System.Drawing.Point(58, 128);
            this.Accel.Name = "Accel";
            this.Accel.Size = new System.Drawing.Size(131, 25);
            this.Accel.TabIndex = 9;
            this.Accel.Text = "Acceleration";
            // 
            // MotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Accel);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.speedbar);
            this.Controls.Add(this.step_text);
            this.Controls.Add(this.do_step);
            this.Name = "MotorControl";
            this.Text = "Motor Control";
            ((System.ComponentModel.ISupportInitialize)(this.speedbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button do_step;
        private System.Windows.Forms.TextBox step_text;
        private System.Windows.Forms.TrackBar speedbar;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label Accel;
    }
}