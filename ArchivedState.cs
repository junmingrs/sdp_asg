using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class ArchivedState : IOrderState
    {
        private Order order;

        public ArchivedState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void archive()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
    }
}
