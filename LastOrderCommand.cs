namespace SDP_ASG;

public class LastOrderCommand : ICommand
{
    private Customer customer;
    private Order lastOrder;
    private Order newOrder;

    public LastOrderCommand(Customer customer)
    {
        this.customer = customer;
    }

    public Order execute()
    {
        foreach (Order o in customer.OrderList)
        {
            if (o.State is DeliveredState)
            {
                lastOrder = o;
            }
        }
        if (lastOrder == null) { Console.WriteLine("\nThere is no last Order"); return null; }
        lastOrder.viewOrderItems();
        Console.Write("\nReOrder Last Order? (y/n) ");
        string choice = Console.ReadLine().ToLower();
        if (choice == "y")
        {
            string id = lastOrder.OrderID.Replace("ORD", "");
            int identity = Convert.ToInt32(id);
            newOrder = new Order(identity);
            customer.addOrder(newOrder);

            foreach (OrderItem oi in lastOrder.OrderItems)
            {
                newOrder.addItem(oi);
            }

            Console.Write("\nReuse the same Delivery Details? (y/n) ");
            string deliverychoice = Console.ReadLine().ToLower();
            if (deliverychoice == "y")
            {
                newOrder.editDeliveryDetails(lastOrder.DeliveryTime, lastOrder.DeliveryAddress);
                newOrder.requestPayment();
                newOrder.processPayment();
                newOrder.viewOrderDetails();
                return newOrder;
            }
            else
            {
                newOrder.editDeliveryDetails();
                newOrder.requestPayment();
                newOrder.processPayment();
                newOrder.viewOrderDetails();
                return newOrder;
            }
        }
        else if (choice == "n")
        {
            Console.WriteLine("\nReturning to Menu");
            return null;
        }
        else
        {
            Console.WriteLine("\nInvalid Input");
            return null;
        }
    }
}
