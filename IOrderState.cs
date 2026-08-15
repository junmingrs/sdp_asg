using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public interface IOrderState
    {
        public void addItem(OrderItem item);
        public void removeItem(OrderItem item);
        public string requestPayment();
        public Boolean processPayment();
        public void prepare();
        public void deliver();
        public void markDelivered();
        public void archive(Boolean cancelled);
    }
}
