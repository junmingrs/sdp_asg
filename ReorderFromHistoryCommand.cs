namespace SDP_ASG;

public class ReorderFromHistoryCommand : ICommand
{
    private Customer customer;
    private Order newOrder;

    public ReorderFromHistoryCommand(Customer customer)
    {
        this.customer = customer;
    }

    public Order execute()
    {
        Console.WriteLine("\n--- Order History ---");
        List<Order> orderHistory = new List<Order>();
        Order selectedOrder = null;
        int i = 1;
        foreach (Order o in customer.OrderList)
        {
            if (o.State is DeliveredState)
            {
                Console.WriteLine($"{i}) {o.OrderID} - ${o.Price.ToString("0.00")}");
                orderHistory.Add(o);
                i++;
            }
        }
        if (orderHistory.Count() == 0) { Console.WriteLine("No Orders Recorded"); return null; }
        Console.Write("\nSelect Order to View Details: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= orderHistory.Count())
        {
            selectedOrder = orderHistory[idx - 1];
            selectedOrder.viewOrderItems();
        }
        else
        {
            Console.WriteLine("\nInvalid choice.");
        }
        Console.Write("\nReorder selected Order? (y/n) ");
        string choice = Console.ReadLine().ToLower();
        if (choice == "y")
        {
            newOrder = new Order(customer.OrderList.Count());
            customer.addOrder(newOrder);

            foreach (OrderItem oi in selectedOrder.OrderItems)
            {
                newOrder.addItem(oi);
            }

            Console.Write("\nReuse the same Delivery Details? (y/n) ");
            string deliverychoice = Console.ReadLine().ToLower();
            if (deliverychoice == "y")
            {
                newOrder.editDeliveryDetails(selectedOrder.DeliveryTime, selectedOrder.DeliveryAddress);
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
