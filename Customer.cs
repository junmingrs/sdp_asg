namespace SDP_ASG;

public class Customer : Observer
{
    private string name;
    private string email;
    private string id;
    private List<ICommand> commands = new List<ICommand>();
    private ICommand selectedCommand;
    private List<Order> orderList = new List<Order>();
    public string Id
    {
        get { return id; }
    }
    public List<Order> OrderList
    {
        get { return orderList; }
    }
    public Customer()
    {
        name = null;
        email = null;
    }
    public Customer(string name, string email, string id)
    {
        this.name = name;
        this.email = email;
        this.id = id;
    }

    public string getName()
    {
        return name;
    }
    public string getEmail()
    {
        return email;
    }
    public void update(SpecialOffer offer)
    {
        Console.WriteLine($"  → {name} received: {offer.getBrand().getBrandName()} has a new offer - {offer.getOfferName()} ({offer.getDiscount()}% off)!");
    }
    public void addOrder(Order order)
    {
        orderList.Add(order);
    }
    public void removeOrder(Order order)
    {
        orderList.Remove(order);
    }
    public Order cancelOrder()
    {
        if (orderList.Count == 0)
        {
            Console.WriteLine("No Orders that can be cancelled");
            return null;
        }
        Console.WriteLine("\n----- All Orders -----");
        int i = 1;
        foreach (Order o in OrderList)
        {
            if (o.State is OFDState)
            {
                Console.WriteLine($"{i}) {o.OrderID} - Out For Delivery");
                i++;
            }
            else
            {
                Console.WriteLine($"{i}) {o.OrderID} - {o.State.ToString().Replace("SDP_ASG.", "").Replace("State", "")}");
                i++;
            }
        }
        Console.WriteLine("\nOrders that are cancelled before being sent out for delivery will be refunded!");
        Console.Write("Select an Order to Cancel (0 to exit): ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= OrderList.Count())
        {
            Order selectedOrder = orderList[idx - 1];
            selectedOrder.viewOrderItems();
            selectedOrder.viewOrderDetails();
            if (selectedOrder.State is DeliveredState)
            {
                Console.WriteLine(" ");
                selectedOrder.cancel();
                return null;
            }
            selectedOrder.cancel();
            OrderList.Remove(selectedOrder);
            return selectedOrder;
        }
        else
        {
            Console.WriteLine("\nReturning to Menu.");
            return null;
        }
    }
    public void viewOrders()
    {
        Console.WriteLine("\n----- All Orders -----");
        int i = 1;
        if (orderList.Count() == 0)
        {
            Console.WriteLine("No Orders Recorded");
        }
        else
        {
            foreach (Order o in OrderList)
            {
                if (o.State is OFDState)
                {
                    Console.WriteLine($"{i}) {o.OrderID} - Out For Delivery");
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i}) {o.OrderID} - {o.State.ToString().Replace("SDP_ASG.", "").Replace("State", "")}");
                    i++;
                }
            }
            Console.Write("\nSelect an Order to view details (0 to exit): ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= OrderList.Count())
            {
                Order selectedOrder = orderList[idx - 1];
                selectedOrder.viewOrderItems();
                selectedOrder.viewOrderDetails();
            }
            else
            {
                Console.WriteLine("\nReturning to Menu.");
            }
        }
    }
    public void viewOrderHistory()
    {
        Console.WriteLine("\n--- Order History ---");
        List<Order> orderHistory = new List<Order>();
        int i = 1;
        foreach (Order o in OrderList)
        {
            if (o.State is DeliveredState)
            {
                Console.WriteLine($"{i}) {o.OrderID} - ${o.Price.ToString("0.00")}");
                orderHistory.Add(o);
                i++;
            }
        }
        Console.Write("\nSelect Order to View Details: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= orderHistory.Count())
        {
            Order selectedOrder = orderHistory[idx - 1];
            selectedOrder.viewOrderItems();
        }
        else
        {
            Console.WriteLine("\nInvalid choice.");
        }
    }
    public void addCommand(ICommand command)
    {
        commands.Add(command);
    }
    public void setCommandHotkey(int slot)
    {
        selectedCommand = commands[slot - 1];
    }
    public Order executeSelectedCommand()
    {
        if (selectedCommand != null) { return selectedCommand.execute(); }
        else { Console.WriteLine("\nNo command set yet"); return null; }
    }
}
