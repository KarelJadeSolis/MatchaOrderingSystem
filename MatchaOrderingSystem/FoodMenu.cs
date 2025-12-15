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

            SetMinimumOrdersCake();
            SetMinimumOrdersIced();
        }

        private void SetMinimumOrdersCake()
        {
            for (int i = 0; i < _menuItems.Length; i++)
            {
                int availableStock = _orderRepository.GetStock(_menuItems[i].Name);

               
                {
                    numUpDownSM.Maximum = _orderRepository.GetStock(_menuItems[0].Name);
                    numUpDownAM.Maximum = _orderRepository.GetStock(_menuItems[1].Name);
                    numUpDownCM.Maximum = _orderRepository.GetStock(_menuItems[2].Name);
                    numUpDownM.Maximum = _orderRepository.GetStock(_menuItems[3].Name);

                    numUpDownSM.Minimum = 0;
                    numUpDownAM.Minimum = 0;
                    numUpDownCM.Minimum = 0;
                    numUpDownM.Minimum = 0;
                }
            }
        }

        private void SetMinimumOrdersIced()
        {
            for (int i = 0; i < _menuItems.Length; i++)
            {
                int availableStock = _orderRepository.GetStock(_menuItems[i].Name);


                {
                    numUpDownSM.Maximum = _orderRepository.GetStock(_menuItems[0].Name);
                    numUpDownAM.Maximum = _orderRepository.GetStock(_menuItems[1].Name);
                    numUpDownCM.Maximum = _orderRepository.GetStock(_menuItems[2].Name);
                    numUpDownM.Maximum = _orderRepository.GetStock(_menuItems[3].Name);

                    numUpDownAM.Minimum = 0;
                    numUpDownAM.Minimum = 0;
                    numUpDownCM.Minimum = 0;
                    numUpDownM.Minimum = 0;
                }
            }
        }

        private void UpdateOrderQuantity(int index, NumericUpDown numUpDown)
        {
            if (index < 0 || index >= _menuItems.Length) return;

            var menuItem = _menuItems[index];
            int stock = _orderRepository.GetStock(menuItem.Name); // check stock
            var existing = Orders.FirstOrDefault(o => o.Name == menuItem.Name);

            if ((int)numUpDown.Value > 0)
            {
                if (numUpDown.Value > stock)
                {
                    MessageBox.Show($"{menuItem.Name} is out of stock or you exceeded the available quantity ({stock})!",
                                    "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numUpDown.Value = stock; // reset to max available
                    return;
                }

                if (existing != null)
                {
                    existing.Quantity = (int)numUpDown.Value;
                }
                else
                {
                    Orders.Add(new MenuItem(menuItem.Name, menuItem.Price, menuItem.PhotoPath)
                    {
                        Quantity = (int)numUpDown.Value
                    });
                }
            }
            else
            {
                if (existing != null)
                {
                    Orders.Remove(existing);
                }
            }
        }
        private void txtOrderQty1_ValueChanged(object sender, EventArgs e)
        {
            if (numUpDownSM.Value < 0) numUpDownSM.Value = 0;
            UpdateOrderQuantity(0, numUpDownSM);
        }

        private void txtOrderQty2_ValueChanged(object sender, EventArgs e)
        {
            if (numUpDownSM.Value < 0) numUpDownAM.Value = 0;
            UpdateOrderQuantity(1, numUpDownAM);
        }

        private void txtOrderQty3_ValueChanged(object sender, EventArgs e)
        {
            if (numUpDownSM.Value < 0) numUpDownCM.Value = 0;
            UpdateOrderQuantity(2, numUpDownCM);
        }

        private void txtOrderQty4_ValueChanged(object sender, EventArgs e)
        {
            if (numUpDownSM.Value < 0) numUpDownM.Value = 0;
            UpdateOrderQuantity(3, numUpDownM);
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

        private void pBoxMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 1;
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
