using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Donhefinson
{
    static class Global
    {
        public static MySqlConnection conn = new MySqlConnection("Server=sql3.freemysqlhosting.net;Database=sql321723;Uid=sql321723;Pwd=wH7*vX9!;");
        public static System.IO.Ports.SerialPort arduinoConn { get; set; }
        public static XDocument drinkDoc = XDocument.Load("Resources/Drinks.xml");
        public static string[] Liquors = { "Vodka", "White Rum", "Gin", "Blue Curacao", "Mixers", "Tequila", "Coconut Rum", "Triple Sec", "Amaretto" };
        public static string[] Mixers = { "Sweet and Sour", "Sprite", "Ice", "Orange Juice", "Coke", "Pineapple Juice", "Cranberry Juice" };
        public static List<Drink> drinkList;
        public static int height = 500;
        public static int width = 500;
    }

    public class Drink : IComparable
    {
        public Drink()
        {
            drinkName = "";
            drinkIng = new List<Ingredient>();
            strength = 0;
        }
        public Drink(string n)
        {
            drinkName = n;
            drinkIng = new List<Ingredient>();
            strength = 0;
        }
        public override string ToString()
        {
            return drinkName;
        }
        /////////////// methods for sorting by drink name
        int IComparable.CompareTo(object obj)
        {
            Drink d = (Drink)obj;
            return String.Compare(this.drinkName, d.drinkName);
        }
        private class sortDrinkDesc : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Drink d1 = (Drink)a;
                Drink d2 = (Drink)b;
                return string.Compare(d1.drinkName, d2.drinkName);
            }
        }
        public static IComparer sortDrink()
        {
            return (IComparer)new sortDrinkDesc();
        }
        ///////////////////////////////////////////
        public string drinkName;
        public List<Ingredient> drinkIng;
        public double strength;
    }

    public class Ingredient
    {
        public Ingredient()
        {
            ingAmt = 0;
            ingName = "";
            proof = 0;
        }
        public Ingredient(string n, float a, int p)
        {
            ingName = n;
            ingAmt = a;
            proof = p;
        }
        public string ingName;
        public float ingAmt;
        public int proof;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
