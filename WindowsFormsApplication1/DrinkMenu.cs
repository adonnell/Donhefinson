using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Donhefinson
{
    public partial class DrinkMenu : Form
    {
        public DrinkMenu()
        {

            InitializeComponent();
            initSearch();
        }
	
        private void initSearch()
        {
            ArrayList temp = new ArrayList();
            source = new AutoCompleteStringCollection();
            foreach (Drink d in Global.drinkList)
            {
                source.Add(d.drinkName);
                temp.Add(d);
            }
            temp.Sort(Drink.sortDrink());
            Results.DisplayMember = "Drink";
            Results.BeginUpdate();
            foreach (object o in temp)
            {
                Results.Items.Add(o);
            }
            Results.EndUpdate();
            SearchFor.AutoCompleteCustomSource = source;
            SearchFor.AutoCompleteMode = AutoCompleteMode.Suggest;
            SearchFor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
     
        private void search_Click(object sender, EventArgs e)
        {
            ArrayList temp = new ArrayList();
            Results.BeginUpdate();
            Results.Items.Clear();
            foreach(Drink d in Global.drinkList)
            {
                if (d.drinkName.IndexOf(SearchFor.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Results.Items.Add(d);
                }
            }
            Results.EndUpdate();
        }
    }
}