using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private IOrderState state;

        private string orderID;
        private Boolean paymentSuccessful;
        private double price;
        private string paymentType;
        private TimeOnly deliveryTime;
        private string deliveryAddress;
        private List<OrderItem> orderItems = new List<OrderItem>();

        public string OrderID
        {
            get {  return orderID; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string PaymentType
        {
            get { return paymentType; }
        }
        public TimeOnly DeliveryTime
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

            state = created;
            string orderIDBase = "ORD";
            orderID = orderIDBase += (id += 1).ToString("0000");
        }

        public void viewOrderItems()
        {
            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"          Your Order          ");
            Console.WriteLine("------------------------------");
            if (OrderItems.Count() == 0)
            {
                Console.WriteLine("Order is empty - Add an Item first");
            }
            else
            {
                foreach (OrderItem f in OrderItems)
                {
                    string[] details = f.getDescription().Split(",");
                    if (details.Count() == 5)
                    {
                        string type = details[0].Split(":")[0];
                        string brand = details[0].Split(":")[1].Replace(" ", "");
                        string colour = details[1].Replace(" ", "");
                        string warranty = details[3];
                        string installation = details[^1];
                        Console.WriteLine($"{type}: {brand}, {colour}" +
                            $"\n -{warranty},{installation} - ${f.getPrice().ToString("0.00")}");
                    }
                    else if (details.Count() == 4)
                    {
                        string type = details[0].Split(":")[0];
                        string brand = details[0].Split(":")[1].Replace(" ", "");
                        string colour = details[1].Replace(" ", "");
                        string addon = details[^1];
                        Console.WriteLine($"{type}: {brand}, {colour}" +
                            $"\n -{addon} - ${f.getPrice().ToString("0.00")}");
                    }
                    else
                    {
                        string type = details[0].Split(":")[0];
                        string brand = details[0].Split(":")[1].Replace(" ", "");
                        string colour = details[1].Replace(" ", "");
                        Console.WriteLine($"{type}: {brand}, {colour} - ${f.getPrice().ToString("0.00")}");
                    }
                }
                Console.WriteLine($" -> Total Price: ${Price.ToString("0.00")}");
            }  
        }
        public void viewOrderDetails()
        {
            Console.WriteLine("\n----- Order Details -----");
            Console.WriteLine($"OrderID: {OrderID}");
            if (PaymentType != null) { Console.WriteLine($"Payment Type: {PaymentType}"); }
            else { Console.WriteLine($"Payment Type: N/a"); }
            if (Price != 0) { Console.WriteLine($"Price: ${Price}"); }
            else { Console.WriteLine($"Price: $0"); }
            if (DeliveryAddress != null) { Console.WriteLine($"Delivery Address and Time: {DeliveryAddress} | {DeliveryTime}"); }
            else { Console.WriteLine($"Delivery Address and Time: N/a | N/a "); }
            if (State is OFDState)
            {
                Console.WriteLine("Status: Out For Delivery");
            }
            else
            {
                Console.WriteLine($"Status: {State.ToString().Replace("SDP_ASG.", "").Replace("State", "")}");
            }
        }
        public void refund()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Refunding ${Price.ToString("0.00")} from {OrderID}...");
        }
        public void editDeliveryDetails()
        {
            Boolean timeloop = false;
            while (!timeloop)
            {
                Console.Write("\nPlease enter a time for delivery (e.g., 14:30 or 2:30 PM): ");
                if (TimeOnly.TryParse(Console.ReadLine(), out TimeOnly time))
                {
                    deliveryTime = time;
                    timeloop = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid time format. Please try again.");
                }
            }
            Boolean addressloop = false;
            while (!addressloop)
            {
                Console.Write("\nEnter Delivery Address: ");
                string address = Console.ReadLine() ?? "";
                if (address.Length == 0)
                { 
                    Console.WriteLine("\nPlease input a valid Address!");
                } 
                else
                {
                    deliveryAddress = address;
                    addressloop = true;
                }
            }
            Console.WriteLine($"\nDelivery Time and Address Entered: {deliveryTime} | {deliveryAddress}");
        }
        public void editDeliveryDetails(TimeOnly time, string address)
        {
            deliveryTime = time;
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
        public void cancel()
        {
            state.cancel();
        }
    }
}
