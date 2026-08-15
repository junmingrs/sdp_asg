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
        public string requestPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
            return order.PaymentType;
        }
        public Boolean processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
            return true;
        }
        public void prepare()
        {
            Console.WriteLine("\nOrder is Archived");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
        public void markDelivered()
        {
            Console.WriteLine("\nOrder is Archived");
        }
        public void archive(Boolean cancelled)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is Archived!");
        }
    }
}
