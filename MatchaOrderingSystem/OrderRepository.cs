using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MatchaOrderingSystem
{
    public class OrderRepository
    {
        private const int ORDER_LIMIT_PER_DAY = 100;
        public OrderRepository()
        {
            
        }

        public void Save(OrderItem order)
        {
            // Implementation to save the order
        }

        public List<OrderItem> GetOrders()
        {
            // Implementation to get orders
            return new List<OrderItem>();
        }

        public int GetStock(string menuItem)
        {
           var ordersForTheDay = GetOrders()
                .Where(order => order.Item.Equals(menuItem))
                .Where(order => order.OrderDate.Date == DateTime.Now.Date)
                .Count();

           return ORDER_LIMIT_PER_DAY - ordersForTheDay;
        }

        public void UpdateOrder(OrderItem order)
        {
            // Implementation to update an order
            // update customer name
        }

        public void DeleteOrder(int orderId)
        {
            // Implementation to delete an order
        }
    }
}
