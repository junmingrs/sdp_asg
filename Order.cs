using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class Order
    {
        private OrderState created;
        private OrderState submitted;
        private OrderState preparing;
        private OrderState oFD;
        private OrderState delivered;
        private OrderState archived;
        private OrderState state;

        private string orderID;
        private double price;
        private string paymentType;
        private DateTime deliveryTime;
        private string deliveryAddress;
        private List<OrderItem> orderItems = new List<OrderItem>();

        public string OrderID
        {
            get {  return orderID; }
        }
        public double Price
        {
            get { return price; }
        }
        public string PaymentType
        {
            get { return paymentType; }
        }
        public DateTime DeliveryTime
        {
            get { return deliveryTime; }
        }
        public string DeliveryAddress
        {
            get { return deliveryAddress; }
        }
        public List<OrderItem> OrderItems
        {
            get { return orderItems; }
        }
        public OrderState Created
        {
            get { return created; }
        }
        public OrderState Submitted
        {
            get { return submitted; }
        }
        public OrderState Preparing
        {
            get { return preparing; }
        }
        public OrderState OFD
        {
            get { return oFD; }
        }
        public OrderState Delivered
        {
            get { return delivered; }
        }
        public OrderState Archived
        {
            get { return archived; }
        }
        public OrderState State
        {
            get { return state; }
        }

        public Order(int id)
        {
            created = new CreatedState(this);
            submitted = new SubmittedState(this);
            preparing = new PreparingState(this);
            oFD = new OFDState(this);
            delivered = new DeliveredState(this);
            archived = new ArchivedState(this);

            state = created;
            string orderIDBase = "ORD";
            orderID = orderIDBase += (id += 1).ToString();
        }

        public double getPrice()
        {
            foreach(OrderItem item in orderItems)
            {
                price += item.getPrice();
            }
            return price;
        }
        public void refund()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Refunding {Price} from {OrderID}...");
        }
        public void editDeliveryTime(DateTime time)
        {
            deliveryTime = time;
        }
        public void editDeliveryAddress(string address)
        {
            deliveryAddress = address;
        }
        public void selectPaymentType()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Please Select Payment Type");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Cash on Delivery");
            Console.Write("Option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                paymentType = "Credit Card";
            } else if (option == 2)
            {
                paymentType = "PayPal";
            } else if (option == 3)
            {
                paymentType = "Cash on Delivery";
            } else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please Select a Valid Payment Type!");
            }
        }
        public void setState(OrderState state)
        {
            this.state = state;
        }
        public void addItem(OrderItem item)
        {
            state.addItem(item);
        }
        public void removeItem(OrderItem item)
        {
            state.removeItem(item);
        }
        public void submit()
        {
            state.submit();
        }
        public void processPayment()
        {
            state.processPayment();
        }
        public void deliver()
        {
            state.deliver();
        }
        public void archive()
        {
            state.archive();
        }
    }
}
