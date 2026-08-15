using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class Order
    {
        private IOrderState created;
        private IOrderState submitted;
        private IOrderState preparing;
        private IOrderState prepared;
        private IOrderState oFD;
        private IOrderState delivered;
        private IOrderState archived;
        private IOrderState state;

        private string orderID;
        private Boolean isCancelled;
        private Boolean paymentSuccessful;
        private double price;
        private string paymentType;
        private DateTime deliveryTime;
        private string deliveryAddress;
        private List<OrderItem> orderItems = new List<OrderItem>();

        public string OrderID
        {
            get {  return orderID; }
        }
        public Boolean IsCancelled
        {
            get { return isCancelled;}
            set { isCancelled = value; }
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
        public IOrderState Created
        {
            get { return created; }
        }
        public IOrderState Submitted
        {
            get { return submitted; }
        }
        public IOrderState Preparing
        {
            get { return preparing; }
        }
        public IOrderState Prepared
        {
            get { return prepared; }
        }
        public IOrderState OFD
        {
            get { return oFD; }
        }
        public IOrderState Delivered
        {
            get { return delivered; }
        }
        public IOrderState Archived
        {
            get { return archived; }
        }
        public IOrderState State
        {
            get { return state; }
        }

        public Order(int id)
        {
            created = new CreatedState(this);
            submitted = new SubmittedState(this);
            preparing = new PreparingState(this);
            prepared = new PreparedState(this);
            oFD = new OFDState(this);
            delivered = new DeliveredState(this);
            archived = new ArchivedState(this);

            state = created;
            string orderIDBase = "ORD";
            orderID = orderIDBase += (id += 1).ToString("0000");
        }

        public double calculatePrice()
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
        public void setState(IOrderState state)
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
        public void requestPayment()
        {
            paymentType = state.requestPayment();    
        }
        public void processPayment()
        {
            paymentSuccessful = state.processPayment();
        }
        public void prepare()
        {
            state.prepare();
        }
        public void deliver()
        {
            state.deliver();
        }
        public void markDelivered()
        {
            state.markDelivered();
        }
        public void archive(Boolean Cancelled)
        {
            state.archive(Cancelled);
        }
    }
}
