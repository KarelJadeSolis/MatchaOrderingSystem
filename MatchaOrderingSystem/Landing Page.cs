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
    public partial class Landing_Page : Form
    {
        public Landing_Page()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Contact_Click(object sender, EventArgs e)
        {
           Form1 myFormContact = new Form1();
            myFormContact.ShowDialog();
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {   
            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();
            
        }
    }
}
