using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class OrderItem : Furniture
    {
        public OrderItem()
        {
            price = 0;
            name = null;
        }
        public OrderItem(Furniture item)
        {
            price = item.getPrice();
            name = item.getDescription();
        }

        public override double getPrice()
        {
            return price;
        }
    }
}
