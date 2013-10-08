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

namespace WindowsFormsApplication1
{
    public partial class drinkMenu : Form
    {
        private string[] Liquors = {"Vodka", "White Rum", "Gin", "Blue Curacao", "Mixers", "Tequila", "Coconut Rum", "Triple Sec", "Amaretto"};
        private XDocument doc;

        public drinkMenu()
        {
            InitializeComponent();
            doc = XDocument.Load("Resources/Drinks.xml");
        }
            
        private void openSerial_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.Handshake = System.IO.Ports.Handshake.None;
            serialPort1.Encoding = System.Text.Encoding.Default;
            serialPort1.Open();
        }

        private void MakeDrink(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                // disable buttons so multiple drink requests can't be sent
                disableButtons();
                // push any button, that buttons text becomes the string to search for
                // need to change this
                String toMake;
                if (sender == LongIsland)
                    toMake = "Long Island Iced Tea";
                else if (sender == AdiosMF)
                    toMake = "Adios Motherfucker";
                else if (sender == BayBreeze)
                    toMake = "Malibu Bay Breeze";
                else
                    toMake = "NULL";
                // find the matching drink in the XML file
                foreach (XElement drink in doc.Root.Elements())
                {
                    if (drink.Attribute("name").Value == toMake)
                    {
                        // go get each individual ingredient
                        foreach (XElement ingredient in drink.Elements())
                        {
                            String ingStr = ingredient.Attribute("name").Value;
                            int i = Array.FindIndex(Liquors, index => index.Contains(ingStr));
                            // if the ingredient exists
                            if (i >= 0)
                            {
                                byte[] buffer = new byte[] { Convert.ToByte(i) };
                                serialPort1.Write(buffer, 0, 1);
                                // wait for arduino to finish. This function blocks.
                                String fromArduino = serialPort1.ReadLine();
                                textBox1.Text = "Finished getting " + ingStr;
                            }
                            // if it does not, we want to return to 0 and throw an error
                            else
                            {
                                // have arduino recognize 9 as error and print error to computer
                                i = 9;
                                byte[] buffer = new byte[] { Convert.ToByte(i) };
                                serialPort1.Write(buffer, 0, 1);
                                String fromArduino = serialPort1.ReadLine();
                                textBox1.Text = "Ingredient " + ingStr + " does not exist";
                            }
                        }
                        // finished, let arduino know to return to 0
                        serialPort1.Write(new byte[] { 10 }, 0, 1);
                        serialPort1.ReadLine();
                        textBox1.Text = "Ready for next drink";
                    }
                }

                enableButtons();
               
            }
        }
        private void disableButtons()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                    c.Enabled = false;
            }
        }
        private void enableButtons()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                    c.Enabled = true;
            }
        }
    }
}