using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Donhefinson
{
    public partial class DrinkInfo : Form
    {
        public DrinkInfo()
        {
            InitializeComponent();
            alreadyrunning = false;
        }
        public DrinkInfo(Drink d)
        {
            theDrink = d;
            InitializeComponent();
            getDrinkInfo();
            alreadyrunning = false;
        }

        protected void getDrinkInfo()
        {
            int tabindex = 0;
            const int rtbxloc = 50, lxloc = 100;
            int yloc = 40;
            Label title = new Label();
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, FontStyle.Underline);
            title.AutoSize = true;
            title.Name = "title";
            title.Text = theDrink.drinkName;
            title.Location = new System.Drawing.Point((this.Width / 2) - (title.PreferredWidth / 2), 10);
            this.Controls.Add(title);
            foreach (Ingredient i in theDrink.drinkIng)
            {
                Label l = new Label();
                RichTextBox rtb = new RichTextBox();
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
                rtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
                rtb.Location = new System.Drawing.Point(rtbxloc, yloc);
                l.Location = new System.Drawing.Point(lxloc, yloc);
                yloc += 45;
                if (i.proof == 0)
                {
                    rtb.Name = "non_alc";
                }
                else
                    rtb.Name = "alc";
                l.Name = "lbl";
                l.AutoSize = true;
                l.Anchor = AnchorStyles.None;
                rtb.Size = new System.Drawing.Size(40, 30);
                rtb.TabIndex = tabindex++;
                rtb.Text = i.ingAmt.ToString();
                rtb.TextChanged += new System.EventHandler(this.update_strength);
                l.Text = "oz of " + i.ingName;
                this.Controls.Add(l);
                this.Controls.Add(rtb);
            }
            // add strength based on ing amounts FINISH
            Label percentAlc = new Label();
            percentAlc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            percentAlc.AutoSize = true;
            percentAlc.Name = "percentAlc";
            // TODO: obj out of range
            percentAlc.Text = theDrink.strength.ToString().Substring(2, 2) + "%";
            percentAlc.Location = new System.Drawing.Point((this.Width / 2) - (percentAlc.PreferredWidth / 2), yloc);
            this.Controls.Add(percentAlc);
            this.MakeDrink.TabIndex = tabindex;
        }

        private void update_strength(object sender, EventArgs e)
        {
            int amt_alc = 0;
            int amt_nonalc = 0;
            RichTextBox rtb = sender as RichTextBox;
            if (rtb.Text == null)
                return;
            foreach (char c in rtb.Text)
            {
                if (c < '0' || c > '9')
                    return;
            }
            foreach (var alc_rtb in this.Controls.Find("alc", false))
            {
                amt_alc += Convert.ToInt32(alc_rtb.Text.ToString());
            }
            foreach (var non_alc_rtb in this.Controls.Find("non_alc", false))
            {
                amt_nonalc += Convert.ToInt32(non_alc_rtb.Text.ToString());
            }
            // need to finish this. have to multiply above alc amounts by proof. then divide that by nonalc amount.
        }

        private void MakeDrink_Click(object sender, EventArgs e)
        {
            string fromArduino;

            if (alreadyrunning)
                return;
            alreadyrunning = true;

            this.MakeDrink.Enabled = false;
            this.statusText.Visible = true;
            this.MakeDrink.Visible = false;
 

            if (Global.arduinoConn.IsOpen)
            {
                Global.arduinoConn.Write(new byte[] { Global.MAKE_DRINK }, 0, 1);
                fromArduino = Global.arduinoConn.ReadLine();
                // go get each individual ingredient
                foreach (Ingredient ing in theDrink.drinkIng)
                {
                    string ingred = ing.ingName;
                    int i = Array.FindIndex(Global.Liquors, index => index.Contains(ingred));
                    // if the ingredient exists
                    if (i >= 0)
                    {
                        Global.arduinoConn.Write( new byte[] { Convert.ToByte(i) }, 0, 1 );
                        // wait for arduino to finish. This function blocks.
                        fromArduino = Global.arduinoConn.ReadLine();
                        if( Global.arduinoConn.ReadLine() == Global.READY )
                        statusText.Text = "Finished getting " + ingred;
                        statusText.Refresh();
                    }
                    // if it does not, we want to return to 0 and throw an error
                    else
                    {
                        // Error
                        Global.arduinoConn.Write(new byte[]{ Global.ERROR }, 0, 1);
                        fromArduino = Global.arduinoConn.ReadLine();
                        statusText.Text = "Ingredient " + ingred + " does not exist";
                        System.Threading.Thread.Sleep(1000);
                        statusText.Refresh();
                    }
                }
                // finished, let arduino know to return to 0
                Global.arduinoConn.Write(new byte[] { Global.FINISH }, 0, 1);
                Global.arduinoConn.ReadLine();
                statusText.Text = "Finished";
                statusText.Refresh();
                System.Threading.Thread.Sleep(1000);
            }
            this.MakeDrink.Enabled = true;
            this.MakeDrink.Visible = true;
            this.statusText.Visible = false;
            this.Hide();
            alreadyrunning = false;
        }
    }
}
