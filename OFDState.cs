namespace SDP_ASG;

public class OFDState : IOrderState
{
    private Order order;

    public OFDState(Order order)
    {
        this.order = order;
    }

    public void addItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Out for Delivery!");
    }
    public void removeItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Out for Delivery!");
    }
    public string requestPayment()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Out for Delivery!");
        return order.PaymentType;
    }
    public Boolean processPayment()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Out for Delivery!");
        return true;
    }
    public void prepare()
    {
        Console.WriteLine("\nOrder is already out for delivery");
    }
    public void deliver()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Out for Delivery!");
    }
    public void markDelivered()
    {
        Console.WriteLine("\nOrder is marked as delivered");
        order.setState(order.Delivered);
    }
    public void cancel()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Cancelled Order Succesfully");
    }
}
