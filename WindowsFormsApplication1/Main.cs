using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Donhefinson
{
    public partial class Main : Form
    {
        public Main()
        {
            Global.drinkList = new List<Drink>();
            InitializeComponent();
        }

        // load all of the drinks into memory at the start of the program
        protected void loadDrinks()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            try
            {
                Global.conn.Open();
                cmd = Global.conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Recipes,Drinks,Ingredients WHERE Recipes.DrinkID = Drinks.Drink_ID and Recipes.IngredID = Ingredients.Ingredient_ID;";
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {
                throw e;
            }
            
            // go through and make a drink object out of every returned record
            while ( reader.Read() )
            {
                double totalAmt = 0;
                double alcAmt = 0;

                // first occurence
                int currDrink = reader.GetInt32("Drink_ID");

                string dname = reader.GetString("dName");
                Drink d = new Drink(dname);

                // get the first ingredient
                string iname = reader.GetString("iName");
                float amt = reader.GetInt32("NumUnitsMin");
                int proof = reader.GetInt32("Proof");
                Ingredient i = new Ingredient(iname, amt, proof);

                // calculate the strength of the ingredient and ultimately the drink
                totalAmt += amt;
                alcAmt += getAlcContent(amt, proof);

                d.drinkIng.Add(i);

                // get the rest of the ingredients until a new drink is found
                while ( reader.Read() )
                {
                    int drinkid = reader.GetInt32("Drink_ID");

                    // when this line fails, it means a new drink is up
                    if (drinkid == currDrink)
                    {
                        iname = reader.GetString("iName");
                        amt = reader.GetInt32("NumUnitsMin");
                        proof = reader.GetInt32("Proof");
                        i = new Ingredient(iname, amt, proof);

                        totalAmt += amt;
                        alcAmt += getAlcContent(amt, proof);

                        d.drinkIng.Add(i);

                    }
                    else break;
                }
                d.strength = alcAmt / totalAmt;
                Global.drinkList.Add(d);
            }
            if (Global.conn.State == ConnectionState.Open)
                Global.conn.Close();
        }

        private double getAlcContent(float amt, double proof)
        {
            if (proof == 0) return proof;
            else
            {
                double alcPercent = proof / 200;
                return amt * alcPercent;
            }
        }

        // will open a com port to the arduino and then display the drink menu
        private void openSerial_Click(object sender, EventArgs e)
        {
            Global.arduinoConn.Close();
            Global.arduinoConn.PortName = "COM3";
            Global.arduinoConn.BaudRate = 9600;
            Global.arduinoConn.DataBits = 8;
            Global.arduinoConn.Parity = System.IO.Ports.Parity.None;
            Global.arduinoConn.Handshake = System.IO.Ports.Handshake.None;
            Global.arduinoConn.Encoding = System.Text.Encoding.Default;
            Global.arduinoConn.Open();
            this.DrinkMenu.Show();
            this.openSerial.Hide();
            this.Controls.Remove(this.openSerial);
            this.Admin.Show();
        }

        private void DrinkMenu_Click(object sender, EventArgs e)
        {
            loadDrinks();
            findRecipesFromBar();
            System.Windows.Forms.Form drinks = new DrinkMenu();
            drinks.Show();
            this.Hide();
        }

        // go through the list of drinks and the list of alcohols and determine which drinks can be made
        public void findRecipesFromBar()
        {
            // light/rum 1943 2033 to white rum 1871, absolut vodka to vodka 1848 to 2045, gold tequila to tequila1931 to 2191, malibu to coconut rum 1765 to 2197
            List<Drink> drinkMenu = new List<Drink>();
            foreach (Drink d in Global.drinkList)
            {
                bool canMake = true;
                foreach (Ingredient i in d.drinkIng)
                {
                    if (i.proof > 0)
                    {
                        // if the ingredient does not exist in our liquor array, do not add
                        if (string.Join("", Global.Liquors).IndexOf(i.ingName, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            canMake = false;
                            break;
                        }
                    }
                    else
                    {
                        if (string.Join("", Global.Mixers).IndexOf(i.ingName, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            canMake = false;
                            break;
                        }
                    }
                }
                if (canMake == true)
                {
                    drinkMenu.Add(d);
                }
            }
            Global.drinkList = drinkMenu;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Global.arduinoConn.Write(new byte[] { Global.ADMIN_CONTROL }, 0, 1);
            System.Windows.Forms.Form admin = new Admin_control();
            admin.Show();
            this.Hide();
        }
    }
}
