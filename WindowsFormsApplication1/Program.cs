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
    public static class Global
    {
        public static System.IO.Ports.SerialPort arduinoConn = new System.IO.Ports.SerialPort();
        public static MySqlConnection conn = new MySqlConnection("Server=Donhefenson.db.11757223.hostedresource.com;Database=Donhefenson;Uid=TheDonhefenson;Pwd=Power121!;");
        public static string[] Liquors = { "Vodka", "White Rum", "Gin", "Blue Curacao", "Mixers", "Tequila", "Coconut Rum", "Triple Sec", "Amaretto" };
        public static string[] Mixers = { "Sweet and Sour", "Sprite", "Ice", "Orange Juice", "Coke", "Pineapple Juice", "Cranberry Juice" };
        public static List<Drink> drinkList;
        public static int height = 500;
        public static int width = 500;
        public static byte ERROR = 9;
        public static byte FINISH = 10;
        public static byte MAKE_DRINK = 16;
        public static byte ADMIN_CONTROL = 32;
        public static byte READY = 2;
        public static byte AT_TARGET = 1; 
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
