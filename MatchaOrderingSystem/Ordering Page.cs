using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchaOrderingSystem
{
    public partial class Ordering_Page : Form
    {
        private OrderRepository _orderRepository;
        private List<MenuItem> _orderedItems;
       
        public Ordering_Page(double total, List<MenuItem> orderedItems)
        {
            InitializeComponent();
            lbltotal.Text = "Total PhP " + total;
            _orderedItems = orderedItems;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuForm myFormMenu = new MenuForm();
            myFormMenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtName.Text.All(char.IsLetter) && !txtName.Text.Contains(" "))
            {
                MessageBox.Show("Name should only contain letters and spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtAddress.Text.Length < 5)
            {
                MessageBox.Show("Address must be at least 5 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAddress.Text.All(char.IsDigit))
            {
                MessageBox.Show("Address cannot contain only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Name must be at least 2 characters .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtContact.Text.StartsWith("09"))
            {
                MessageBox.Show("Invalid Number!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtContact.Text.Length != 11)
            {
                MessageBox.Show("Contact number must be exactly 11 digits long.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtContact.Text.All(char.IsDigit))
            {
                MessageBox.Show("Contact number should contain only digits.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var menuItem in _orderedItems)
            {
                OrderItem order = new OrderItem
                {
                    Item = menuItem.Name,
                    Quantity = menuItem.Quantity,
                    Price = menuItem.Price,
                    OrderDate = DateTime.Now
                };

                _orderRepository.Save(order);
            }

            LoadUsersToDataGridView();

            MessageBox.Show("Your order has been placed!",
                "Order Confirmation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();

            this.Close();
            
            
        }

  

        private void Ordering_Page_Load(object sender, EventArgs e)
        {
            
            _orderRepository = new OrderRepository();
            LoadUsersToDataGridView();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void LoadUsersToDataGridView()
        {
            dataGidViewOrders.AutoGenerateColumns = true;
            dataGidViewOrders.DataSource = null;
            dataGidViewOrders.DataSource = _orderRepository.GetOrders();

            dataGidViewOrders.AutoGenerateColumns = false;
            dataGidViewOrders.Columns.Clear();

            // Add columns
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id"
            });
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Item",
                DataPropertyName = "Item"
            });
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                DataPropertyName = "Price",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Currency
            });
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Currency
            });
            dataGidViewOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Order Date",
                DataPropertyName = "OrderDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" } // General date/time
            });
        }

        private void dataGidViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Check if the clicked column is the Delete button
                if (dataGidViewOrders.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    int id = Convert.ToInt32(dataGidViewOrders.Rows[e.RowIndex].Cells["Id"].Value);

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this order?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        _orderRepository.DeleteOrder(id); 
                        LoadUsersToDataGridView();
                        MessageBox.Show("Order deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGidViewOrders.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGidViewOrders.CurrentRow.Cells["Id"].Value);

                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this order?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    _orderRepository.DeleteOrder(id); 
                    LoadUsersToDataGridView();      
                    MessageBox.Show("Order deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
