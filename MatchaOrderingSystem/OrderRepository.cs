using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace MatchaOrderingSystem
{
    public class OrderRepository
    {
        private readonly SQLiteConnection _connection;
        // In-memory store for example
        private readonly List<OrderItem> _orders;


        public OrderRepository()
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "matcha_order.db");
            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<OrderItem>();
            
            _orders = _connection.Table<OrderItem>().ToList();
        }
        private const int ORDER_LIMIT_PER_DAY = 100;
       
        public void Save(OrderItem order)
        {
            _orders.Add(order);
            _connection.Insert(order);
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
            _connection.Update(updatedOrder);
            var existing = _orders.FirstOrDefault(o => o.Id == updatedOrder.Id);

            if (existing != null)
            {
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
                _connection.Delete(orderToDelete);
                _orders.Remove(orderToDelete);
            }
        }
        public int GetSoldToday(string itemName)
        {
            DateTime today = DateTime.Today;
            return _orders
                .Where(o => o.Item == itemName && o.OrderDate.Date == today)
                .Sum(o => o.Quantity);
        }
    }
}

