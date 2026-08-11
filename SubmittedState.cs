using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class SubmittedState : OrderState
    {
        private Order order;

        public SubmittedState(Order order)
        {
            this.order = order;
        }

        public void addItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Submitted!");
        }
        public void removeItem(OrderItem item)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Submitted!");
        }
        public void submit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Order is already Submitted!");
        }
        public void processPayment()
        {
            order.selectPaymentType();
            order.setState(order.Preparing);
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
