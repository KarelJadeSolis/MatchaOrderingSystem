using System;
using System.IO;
using System.Windows.Forms;

namespace MatchaOrderingSystem
{
    public partial class MenuForm : Form
    {
        FoodMenuForm cakes;
        FoodMenuForm iced;

        public MenuForm()
        {
            InitializeComponent();
            string rootPath = Application.StartupPath; // folder where EXE runs
            string matchaImage = Path.Combine(rootPath, "..\\..\\starbucks-iced-matcha-latte-8.jpg");

            cakes = new FoodMenuForm(
                new MenuItem("MatchaCakes", 234, matchaImage),
                new MenuItem("Matcha Cheesecake", 456, matchaImage),
                new MenuItem("Matcha Cupcake", 1234, matchaImage),
                new MenuItem("Matcha Donut", 789, matchaImage)
                );
            iced = new FoodMenuForm(
                new MenuItem("Iced Matcha", 23442),
                new MenuItem("Iced Matcha Latte", 45623),
                new MenuItem("Iced Matcha Frappe", 12345),
                new MenuItem("Iced Matcha Smoothie", 78912)
                );
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            switchTo(iced);
        }

        private void btnShowIced_Click(object sender, EventArgs e)
        {
            switchTo(iced);
        }

        private void btnCake_Click(object sender, EventArgs e)
        {
            switchTo(cakes);
        }

        private void switchTo(Form menuForm)
        {
            this.pnlMenu.Controls.Clear();
            menuForm.TopLevel = false;
            menuForm.FormBorderStyle = FormBorderStyle.None;
            menuForm.Dock = DockStyle.Fill;
            this.pnlMenu.Controls.Add(menuForm);
            menuForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            double total = 0;
            foreach (var item in cakes.Orders) {
                //calculate total price
                Console.WriteLine($"Ordered Cake: {item.Name} - Price: {item.Price}");
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                total += item.Price;
            }

            foreach (var item in iced.Orders) {
                //calculate total price
                Console.WriteLine($"Ordered Iced Drink: {item.Name} - Price: {item.Price}");
                total += item.Price;
            }

            MessageBox.Show($"Total Order Price: {total}");
        }
    }
}
