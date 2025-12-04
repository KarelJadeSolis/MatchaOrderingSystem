using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchaOrderingSystem
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
