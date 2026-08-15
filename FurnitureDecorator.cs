// Decorator Pattern - FurnitureDecorator (Decorator)
namespace SDP_ASG;

public abstract class FurnitureDecorator : OrderItem
{
    public abstract override string getDescription();
    public abstract override double getPrice();
}
