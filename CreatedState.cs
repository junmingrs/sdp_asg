using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class CreatedState : IOrderState
    {
        private Order order;

        public CreatedState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            order.OrderItems.Add(item);
            order.Price += item.getPrice();
            Console.WriteLine($"Added Item - {item.getDescription()} - ${item.getPrice().ToString("0.00")}");
        }
        public void removeItem(OrderItem item)
        {            
            order.OrderItems.Remove(item);
            Console.WriteLine($"Removed Item - {item.getDescription()} - ${item.getPrice().ToString("0.00")}");
        }
        public string requestPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Submitting Order {order.OrderID}...");
            int paymentchoice = -1;
            while (paymentchoice != 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please Select Payment Type");
                Console.WriteLine("1. Credit Card");
                Console.WriteLine("2. PayPal");
                Console.WriteLine("3. Cash on Delivery");
                Console.Write("Option: ");
                if (!int.TryParse(Console.ReadLine(), out paymentchoice)) paymentchoice = -1;

                switch (paymentchoice)
                {
                    case 1: order.setState(order.Submitted); return "Credit Card";
                    case 2: order.setState(order.Submitted); return "PayPal";
                    case 3: order.setState(order.Submitted); return "Cash on Delivery";
                    default: Console.WriteLine("\nPlease Select a Valid Payment Type!"); break;
                }
            }
            return null;
        }
        public Boolean processPayment()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is not Submitted yet!");
            return false;
        }
        public void prepare()
        {
            Console.WriteLine("\nOrder is not set for Preparing yet");
        }
        public void deliver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is not Prepared yet!");
        }
        public void markDelivered()
        {
            Console.WriteLine("\nOrder is not out for delivery yet!");
        }
        public void cancel()
        {
            Console.WriteLine("\nOrder is Cancelled");
        }
    }
}
