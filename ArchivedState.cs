using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class ArchivedState : OrderState
    {
        private Order order;

        public ArchivedState(Order order)
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
