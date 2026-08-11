using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class LastOrder : Command
    {
        private Order newOrder;

        public LastOrder(Order order, int id)
        {
            newOrder = new Order(id);
            foreach (OrderItem item in order.OrderItems)
            {
                newOrder.addItem(item);
            }
            newOrder.editDeliveryTime(order.DeliveryTime);
            newOrder.editDeliveryAddress(order.DeliveryAddress);
        }

        public void purchase()
        {
            newOrder.submit();
            newOrder.processPayment();
        }
    }
}
