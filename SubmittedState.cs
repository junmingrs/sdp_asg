using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class SubmittedState : OrderState
    {
        private Order order;

        public SubmittedState(Order order)
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
