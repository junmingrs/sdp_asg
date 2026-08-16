namespace SDP_ASG;

public class PreparingState : IOrderState
{
    private Order order;

    public PreparingState(Order order)
    {
        this.order = order;
    }

    public void addItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Preparing!");
    }
    public void removeItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Preparing!");
    }
    public string requestPayment()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Preparing!");
        return order.PaymentType;
    }
    public Boolean processPayment()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Preparing!");
        return true;
    }
    public void prepare()
    {
        order.setState(order.Prepared);
        Console.WriteLine($"Order {order.OrderID} is Prepared");
    }
    public void deliver()
    {
        Console.WriteLine("\nOrder is not Prepared");
    }
    public void markDelivered()
    {
        Console.WriteLine("\nOrder is not out for delivery yet");
    }
    public void cancel()
    {
        order.refund();
        Console.WriteLine("\nOrder cancelled");
    }
}
