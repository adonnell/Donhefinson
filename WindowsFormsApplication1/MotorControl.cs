using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donhefinson
{
    public partial class MotorControl : Form
    {
        public MotorControl()
        {
            InitializeComponent();
        }

        private void left_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseButtons pressedButtons = System.Windows.Forms.Control.MouseButtons;
            // add slider for speed and accel and stuff
            while (pressedButtons == MouseButtons.Left)
            {
                
            }
        }

        private void right_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseButtons pressedButtons = System.Windows.Forms.Control.MouseButtons;
            // add slider for speed and accel and stuff
            while (pressedButtons == MouseButtons.Left)
            {
                
            }
        }

        private void do_step_Click(object sender, EventArgs e)
        {
            Global.arduinoConn.Write(new byte[] { 13 }, 0, 1);
        }
    }
}
