using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SDP_ASG
{
    public class OrderItem : Furniture
    {
        public OrderItem() : base() {}
        public OrderItem(Furniture item) : base(item.Brand, item.Type, item.Colour, item.Material, item.Height, item.Width, item.Depth, item.getPrice())
        { }
       
        public virtual string getDescription()
        {
            return base.getDescription();
        }

        public virtual double getPrice()
        {
            return base.getPrice();
        }

        public override IIterator createIterator(string iterType, string type)
        {
            return new NullIterator();
        }
        public override void print()
        {
            Console.WriteLine(base.getDescription());

        }
    }
}
