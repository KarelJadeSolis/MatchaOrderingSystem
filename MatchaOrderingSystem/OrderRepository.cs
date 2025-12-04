using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MatchaOrderingSystem
{
    public class OrderRepository
    {
        private const int ORDER_LIMIT_PER_DAY = 100;

        // In-memory store for example
        private readonly List<OrderItem> _orders = new List<OrderItem>();

        public void Save(OrderItem order)
        {
            _orders.Add(order);
        }

        public List<OrderItem> GetOrders()
        {
            return _orders;
        }

        public int GetStock(string menuItem)
        {
            int ordersForTheDay = _orders.Count(order =>
                order.Item.Equals(menuItem, StringComparison.OrdinalIgnoreCase) &&
                order.OrderDate.Date == DateTime.Today);

            return ORDER_LIMIT_PER_DAY - ordersForTheDay;
        }

        public void UpdateOrder(OrderItem updatedOrder)
        {
            var existing = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);

            if (existing != null)
            {
                existing.CustomerName = updatedOrder.CustomerName;
                existing.Item = updatedOrder.Item;
                existing.Quantity = updatedOrder.Quantity;
                existing.OrderDate = updatedOrder.OrderDate;
            }
        }

        public void DeleteOrder(int orderId)
        {
            var orderToDelete = _orders.FirstOrDefault(o => o.Id == orderId);
            if (orderToDelete != null)
            {
                _orders.Remove(orderToDelete);
            }
        }
    }
}

