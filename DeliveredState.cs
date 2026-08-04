using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class DeliveredState : OrderState
    {
        private Order order;

        public DeliveredState(Order order)
        {
            this.order = order;
        }
    }
}
