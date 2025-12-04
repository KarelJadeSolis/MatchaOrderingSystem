using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchaOrderingSystem
{
    public partial class FoodMenuForm : Form
    {
        public List<MenuItem> Orders { get; set; }
        private readonly MenuItem[] _menuItems;
        private readonly OrderRepository _orderRepository;
        public FoodMenuForm()
        {
            InitializeComponent();
            _orderRepository = new OrderRepository();


        }

        public FoodMenuForm(params MenuItem[] menuItems)
        {
            InitializeComponent();

            _orderRepository = new OrderRepository();   // REQUIRED FIX
            _menuItems = menuItems;                     // REQUIRED FIX
            Orders = new List<MenuItem>();              // keep this

            lblMenu1.Text = menuItems.Length > 0 ? menuItems[0].Name : "";
            lblMenu2.Text = menuItems.Length > 1 ? menuItems[1].Name : "";
            lblMenu3.Text = menuItems.Length > 2 ? menuItems[2].Name : "";
            lblMenu4.Text = menuItems.Length > 3 ? menuItems[3].Name : "";

            lblMenuPrice1.Text = menuItems.Length > 0 ? "PhP " + menuItems[0].Price.ToString("0.00") : "";
            lblMenuPrice2.Text = menuItems.Length > 1 ? "PhP " + menuItems[1].Price.ToString("0.00") : "";
            lblMenuPrice3.Text = menuItems.Length > 2 ? "PhP " + menuItems[2].Price.ToString("0.00") : "";
            lblMenuPrice4.Text = menuItems.Length > 3 ? "PhP " + menuItems[3].Price.ToString("0.00") : "";

            pBoxMenuItem1.Image = menuItems.Length > 0 ? LoadSafe(menuItems[0].PhotoPath) : null;
            pBoxMenuItem1.SizeMode = PictureBoxSizeMode.StretchImage;
            pBoxMenuItem1.BorderStyle = BorderStyle.FixedSingle;

            pBoxMenuItem2.Image = menuItems.Length > 1 ? LoadSafe(menuItems[1].PhotoPath) : null;
            pBoxMenuItem2.SizeMode = PictureBoxSizeMode.StretchImage;

            pBoxMenuItem3.Image = menuItems.Length > 2 ? LoadSafe(menuItems[2].PhotoPath) : null;
            pBoxMenuItem3.SizeMode = PictureBoxSizeMode.StretchImage;

            pBoxMenuItem4.Image = menuItems.Length > 3 ? LoadSafe(menuItems[3].PhotoPath) : null;
            pBoxMenuItem4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FoodMenu_Load(object sender, EventArgs e)
        {
            

            SetMinimumOrders();
        }

        private void SetMinimumOrders()
        {
            int strawberryMatchaStock = _orderRepository.GetStock(_menuItems[0].Name);
            int azukiMatchaStock = _orderRepository.GetStock(_menuItems[1].Name);
            int classicMatchaStock = _orderRepository.GetStock(_menuItems[2].Name);
            int chocolateMatchaStock = _orderRepository.GetStock(_menuItems[3].Name);


            numUpDownSM.Maximum = strawberryMatchaStock;
            numUpDownAM.Maximum = azukiMatchaStock;
            numUpDownCM.Maximum = classicMatchaStock;
            numUpDownM.Maximum = chocolateMatchaStock;
            ///
        }

        private void txtOrderQty1_ValueChanged(object sender, EventArgs e)
        {
            if (Orders.Any(q => q.Name.Equals(_menuItems[0].Name)))
                Orders.Remove(Orders.FirstOrDefault(o => o.Name == _menuItems[0].Name));
            Orders.Add(new MenuItem(_menuItems[0].Name, _menuItems[0].Price * Convert.ToDouble(numUpDownSM.Value)));
        }

        private void txtOrderQty2_ValueChanged(object sender, EventArgs e)
        {
            if (Orders.Any(q => q.Name.Equals(_menuItems[1].Name)))
                Orders.Remove(Orders.FirstOrDefault(o => o.Name == _menuItems[1].Name));
            Orders.Add(new MenuItem(_menuItems[1].Name, _menuItems[1].Price * Convert.ToDouble(numUpDownAM.Value)));
        }

        private void txtOrderQty3_ValueChanged(object sender, EventArgs e)
        {
            if (Orders.Any(q => q.Name.Equals(_menuItems[2].Name)))
                Orders.Remove(Orders.FirstOrDefault(o => o.Name == _menuItems[2].Name));
            Orders.Add(new MenuItem(_menuItems[2].Name, _menuItems[2].Price * Convert.ToDouble(numUpDownM.Value)));
        }

        private void txtOrderQty4_ValueChanged(object sender, EventArgs e)
        {
            if (Orders.Any(q => q.Name.Equals(_menuItems[3].Name)))
                Orders.Remove(Orders.FirstOrDefault(o => o.Name == _menuItems[3].Name));
            Orders.Add(new MenuItem(_menuItems[3].Name, _menuItems[3].Price * Convert.ToDouble(numUpDownCM.Value)));
        }

        private Image LoadSafe(string path)
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path)
                ? Image.FromFile(path)
                : null;
        }

        private void lblMenu1_Click(object sender, EventArgs e)
        {

        }

        private void lblMenuPrice1_Click(object sender, EventArgs e)
        {

        }

        private void pBoxMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void lblMenuPrice2_Click(object sender, EventArgs e)
        {

        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }
        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public MenuItem(string name, double price, string photoPath)
        {
            Name = name;
            Price = price;
            PhotoPath = photoPath?? "";
        }
    }
}
