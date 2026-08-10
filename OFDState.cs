using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class OFDState : OrderState
    {
        private Order order;

        public OFDState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Out for Delivery!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Out for Delivery!");
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Out for Delivery!");
        }
        public void processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Out for Delivery!");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Out for Delivery!");
        }
        public void archive()
        {
            order.setState(order.Archived);
            Console.WriteLine(" ");
            Console.WriteLine("Cancelled Order Succesfully");
        }
    }
}
