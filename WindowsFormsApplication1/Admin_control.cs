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
    public partial class Admin_control : Form
    {
        public Admin_control()
        {
            InitializeComponent();
        }

        private void ControlMotor_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form mc = new MotorControl();
            Global.arduinoConn.Write( new byte[]{ Global.ADMIN_CONTROL }, 0, 1 );
            mc.Show();
            this.Hide();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
