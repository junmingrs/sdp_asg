using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class DeliveredState : IOrderState
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
        public string requestPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
            return order.PaymentType;
        }
        public Boolean processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
            return true;
        }
        public void prepare()
        {
            Console.WriteLine("\nOrder is already Delivered");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Delivered!");
        }
        public void markDelivered()
        {
            Console.WriteLine("\nOrder is already delivered");
        }
    
        public void cancel()
        {
            Console.WriteLine("Cannot cancel Orders that are delivered");
        }
    }
}
