using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class PreparedState : IOrderState
    {
        private Order order;

        public PreparedState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Prepared!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Prepared!");
        }
        public string requestPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Prepared!");
            return order.PaymentType;
        }
        public Boolean processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Prepared!");
            return true;
        }
        public void prepare()
        {
            Console.WriteLine("\nOrder is already Prepared");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Order {order.OrderID} sent out for delivery");
            order.setState(order.OFD);
        }
        public void markDelivered()
        {
            Console.WriteLine("\nOrder is not out for delivery yet");
        }
        public void archive(Boolean cancelled)
        {
            if (cancelled)
            {
                order.IsCancelled = cancelled;
                order.setState(order.Archived);
                Console.WriteLine(" ");
                Console.WriteLine("Order Cancelled.");
                order.refund();
            }
            else
            {
                Console.WriteLine("\nOrder Archived");
            }
        }
    }
}
