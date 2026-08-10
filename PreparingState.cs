using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class PreparingState : OrderState
    {
        private Order order;

        public PreparingState(Order order)
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
