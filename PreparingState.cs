using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class PreparingState : OrderState
    {
        private Order order;

        public PreparingState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Preparing!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Preparing!");
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Preparing!");
        }
        public void processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Preparing!");
        }
        public void deliver()
        {
            if (order.IsPrepared)
            {
                order.setState(order.OFD);
            } else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Order is not Prepared yet!");
            }
        }
        public void archive()
        {
            order.refund();
            order.setState(order.Archived);
            Console.WriteLine(" ");
            Console.WriteLine("Order Cancelled.");
        }
    }
}
