using System;

namespace SDP_ASG 
{
    public class Customer : Observer
    {
        private string name;
        private string email;
        private string password;
        private string id;
        private List<Order> orderList = new List<Order>();
        public string Name
        {
            get { return name; }
        }
        public string Email
        {
            get { return email; }
        }
        public string Id
        {
            get { return id; }
        }

        public Customer()
        {
            name = null;
            email = null;
        }
        public Customer(string name, string email, string ID)
        {
            this.name = name;
            this.email = email;
            this.password = "12345678";
            this.id = ID;
        }

        public void update(SpecialOffer offer)
        {
            Console.WriteLine($"  → {name} received: {offer.getBrand().getBrandName()} has a new offer - {offer.getOfferName()} ({offer.getDiscount()}% off)!");
        }
        public Boolean logIn(string Password)
        {
            if (this.password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void addOrder(Order order)
        {
            orderList.Add(order);
        }
        public void removeOrder(Order order)
        {
            orderList.Remove(order);
        }
    }
}