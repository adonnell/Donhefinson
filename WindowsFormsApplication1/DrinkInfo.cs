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
        }
        public DrinkInfo(string s)
        {
            theDrink = new Drink();
            getDrinkInfo();
            InitializeComponent();
            alreadyrunning = false;
        }

        protected void getDrinkInfo()
        {
            // get the drink info
            // thedrink = search through list?
        }

        private void MakeDrink_Click(object sender, EventArgs e)
        {
            if (alreadyrunning)
                return;
            alreadyrunning = true;

            this.MakeDrink.Enabled = false;
            this.statusText.Visible = true;
            this.MakeDrink.Visible = false;
 

            if (Global.arduinoConn.IsOpen)
            {
                // find the matching drink in the XML file
                foreach (XElement drink in Global.drinkDoc.Root.Elements())
                {
                    if (drink.Attribute("name").Value == theDrink.drinkName)
                    {
                        // go get each individual ingredient
                        foreach (XElement ingredient in drink.Elements())
                        {
                            string ingStr = ingredient.Attribute("name").Value;
                            int i = Array.FindIndex(Global.Liquors, index => index.Contains(ingStr));
                            // if the ingredient exists
                            if (i >= 0)
                            {
                                byte[] buffer = new byte[] { Convert.ToByte(i) };
                                Global.arduinoConn.Write(buffer, 0, 1);
                                // wait for arduino to finish. This function blocks.
                                string fromArduino = Global.arduinoConn.ReadLine();
                                statusText.Text = "Finished getting " + ingStr;
                                statusText.Refresh();
                            }
                            // if it does not, we want to return to 0 and throw an error
                            else
                            {
                                // have arduino recognize 9 as error and print error to computer
                                i = 9;
                                byte[] buffer = new byte[] { Convert.ToByte(i) };
                                Global.arduinoConn.Write(buffer, 0, 1);
                                string fromArduino = Global.arduinoConn.ReadLine();
                                statusText.Text = "Ingredient " + ingStr + " does not exist";
                                statusText.Refresh();
                            }
                        }
                        // finished, let arduino know to return to 0
                        Global.arduinoConn.Write(new byte[] { 10 }, 0, 1);
                        Global.arduinoConn.ReadLine();
                        statusText.Text = "Finished";
                        statusText.Refresh();
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            this.MakeDrink.Enabled = true;
            this.MakeDrink.Visible = true;
            this.statusText.Visible = false;
            System.Windows.Forms.Form f = new DrinkMenu();
            f.Show();
            this.Hide();
            alreadyrunning = false;
        }
    }
}
