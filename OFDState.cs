using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class OFDState : OrderState
    {
        private Order order;

        public OFDState(Order order)
        {
            this.order = order;
        }
    }
}
