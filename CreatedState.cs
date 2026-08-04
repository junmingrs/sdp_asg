using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class CreaatedState : OrderState
    {
        private Order order;

        public CreatedState(Order order)
        {
            this.order = order;
        }
    }
}
