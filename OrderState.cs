using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public interface OrderState
    {
        public void addItem(OrderItem item);
        public void removeItem(OrderItem item);
        public void submit();
        public void processPayment();
        public void deliver();
        public void archive();
    }
}
