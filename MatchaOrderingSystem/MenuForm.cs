using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
            string cakeImage0 = Path.Combine(projectRoot, "Screenshot 2025-12-03 200704.png");
            string cakeImage1 = Path.Combine(projectRoot, "Screenshot 2025-12-03 200801.png");
            string cakeImage2 = Path.Combine(projectRoot, "Screenshot 2025-12-03 200940.png");
            string cakeImage3 = Path.Combine(projectRoot, "Screenshot 2025-12-03 201159.png");

            string icedImage0 = Path.Combine(projectRoot, "Screenshot 2025-12-03 210306.png");
            string icedImage1 = Path.Combine(projectRoot, "Screenshot 2025-12-03 210320.png");
            string icedImage2 = Path.Combine(projectRoot, "Screenshot 2025-12-03 210406.png");
            string icedImage3 = Path.Combine(projectRoot, "Screenshot 2025-12-03 210422.png");

            cakes = new FoodMenuForm(
                new MenuItem("Strawberry Matcha", 220, cakeImage0),
                new MenuItem("Azuki Matcha", 300, cakeImage1),
                new MenuItem("Matcha", 200, cakeImage2),
                new MenuItem("Chocolate Matcha", 210, cakeImage3)
                );
            iced = new FoodMenuForm(
                new MenuItem("Mint Matcha", 180, icedImage0),
                new MenuItem("Lavander Matcha", 200, icedImage1),
                new MenuItem("Matcha", 120, icedImage2),
                new MenuItem("Cococnut Matcha", 180, icedImage3)
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
            
            List<MenuItem> allOrders = new List<MenuItem>();


            foreach (var item in cakes.Orders)
            {
                allOrders.Add(item);

            }

            foreach (var item in iced.Orders)
            {
                allOrders.Add(item);
            }

            double total = allOrders.Sum(i => i.Price * i.Quantity);

            if (total == 0)
            {
                MessageBox.Show("No items ordered.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            Ordering_Page orderingPage = new Ordering_Page(total, allOrders);
            orderingPage.ShowDialog();
            this.Close();


        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
