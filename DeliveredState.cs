using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class DeliveredState : OrderState
    {
        private Order order;

        public DeliveredState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void archive()
        {
            order.setState(order.Archived);
            Console.WriteLine(" ");
        }
    }
}
