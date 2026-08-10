using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public interface OrderState
    {
        public void requestPayment();
        public void processPayment();
        public void deliver();
        public void archive();
    }
}
