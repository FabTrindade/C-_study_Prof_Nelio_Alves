using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Ordering.Entities.Enuns;

namespace Ordering.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Client Client; 

        public Order()
        {
            Moment = DateTime.Now;
        }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddOrderItem(OrderItem orderitem)
        {
            OrderItems.Add(orderitem);
        }

        public void RemoveOrderItem(OrderItem orderitem)
        {
            OrderItems.Remove(orderitem);
        }

        public double Total()
        {
           double total = 0;
           foreach(OrderItem item in OrderItems)
           {
                total += item.SubTotal();
           }
            return total;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status.ToString());
            sb.AppendLine("Client: " + Client);
            
            sb.AppendLine("Order Items: ");
            
            foreach (OrderItem oi in OrderItems)
            {
                sb.AppendLine(oi.ToString());
            }
            sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            
            return sb.ToString();
        }
    }
}
