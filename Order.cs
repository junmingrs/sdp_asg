using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class Order
    {
        private OrderState created;
        private OrderState submitted;
        private OrderState preparing;
        private OrderState oFD;
        private OrderState delivered;
        private OrderState archived;
        private OrderState state;

        public Order()
        {
            created = new CreatedState(this);
            submitted = new SubmittedState(this);
            preparing = new PreparingState(this);
            oFD = new OFDState(this);
            delivered = new DeliveredState(this);
            archived = new ArchivedState(this);

            state = created;
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
