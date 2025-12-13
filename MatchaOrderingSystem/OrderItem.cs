using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MatchaOrderingSystem
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public DateTime OrderDate { get; set; }

        public double Subtotal => Quantity * Price;
    }
}
