using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Task2STEM.Classes;
using Task2STEM.Enums;
using Task2STEM.Interfaces;

namespace Task2STEM
{
    public partial class Form1 : Form
    {
        private IGift _gift;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        public void Initialize()
        {
            _gift = new Gift("Gift 1", new List<ISweetness>());
            Candy candy1 = new Candy("Сhupa Chups XXL 4D", 29, 0.65, 370, TypeOfCandy.Bars);
            Candy candy2 = new Candy("Аэрофлотские", 150, 64.3, 483, TypeOfCandy.Chocolate);
            Chocolate choco1 = new Chocolate("Спартак", 75, 48, 540, TypeOfChocolate.Dark);
            Chocolate choco2 = new Chocolate("Любимая Алёнка", 200, 51.5, 550, TypeOfChocolate.Milk);
            _gift.AddSweet(candy1);
            _gift.AddSweet(candy2);
            _gift.AddSweet(choco1);
            _gift.AddSweet(choco2);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("{0}, consist {1} elements", _gift.GiftName, _gift.CountOfSweet);
            Console.WriteLine();
            Console.WriteLine("Gift Weight: {0}", _gift.GiftWeight);
            Console.WriteLine();
            Console.WriteLine("/-------------------------------------------/");
            Console.WriteLine();

            foreach (var i in _gift.Items)
            {
                Console.WriteLine("{0}, {1}", i.TypeOfSweetness, i.ItemInfo);
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var temp = _gift.SortSweetnessByWeight();
            int j = 0;
            foreach (var i in temp)
            {
                listBox1.Items.Insert(j, String.Format("Name: {0}, SugarPerUnit: {1}",
                   i.Name, i.SugarPerUnit));
                j++;
            }
        }
        private void Find_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var min = Convert.ToDouble(textBoxMinSugar.Text);
            var max = Convert.ToDouble(textBoxMaxSugar.Text);
            var gifts = _gift.FindSweetnessBySugar(min, max);
            for (int i =0;i < gifts.Count();i++)
            {
                listBox1.Items.Insert(i, String.Format("Name: {0}, SugarPerUnit: {1}",
                    gifts.ElementAt(i).Name, gifts.ElementAt(i).SugarPerUnit));
            }
           
        }
    }
}
