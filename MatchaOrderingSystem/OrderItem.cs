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
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
