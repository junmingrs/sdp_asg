using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class CreatedState : OrderState
    {
        private Order order;

        public CreatedState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            order.OrderItems.Add(item);
        }
        public void removeItem(OrderItem item)
        {
            order.OrderItems.Remove(item);
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Submitting Order {order.OrderID}...");
            order.setState(order.Submitted);
        }
        public void processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is not Submitted yet!");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is not Out For Delivery yet!");
        }
        public void archive()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order can't be Archived!");
        }
    }
}
