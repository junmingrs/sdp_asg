using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class CreatedState : OrderState
    {
        private Order order;

        public CreatedState(Order order)
        {
            this.order = order;
        }

        public void requestPayment()
        {

        }
        public void processPayment()
        {

        }
        public void deliver()
        {

        }
        public void archive()
        {

        }
    }
}
