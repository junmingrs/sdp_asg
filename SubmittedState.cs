namespace SDP_ASG;

public class SubmittedState : IOrderState
{
    private Order order;

    public SubmittedState(Order order)
    {
        this.order = order;
    }

    public void addItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Submitted!");
    }
    public void removeItem(OrderItem item)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Submitted!");
    }
    public string requestPayment()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is already Submitted!");
        return order.PaymentType;
    }
    public Boolean processPayment()
    {
        order.setState(order.Preparing);
        Console.WriteLine("\nOrder sent to be prepared");
        return true;
    }
    public void prepare()
    {
        Console.WriteLine("\nOrder is not sent to be Prepared yet");
    }
    public void deliver()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Order is not Prepared yet!");
    }
    public void markDelivered()
    {
        Console.WriteLine("\nOrder is not Out For Delivery yet");
    }
    public void cancel()
    {
        Console.WriteLine("\nOrder is cancelled");
    }
}
