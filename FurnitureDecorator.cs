// Decorator Pattern - FurnitureDecorator (Decorator)
namespace SDP_ASG;

public abstract class FurnitureDecorator : Furniture
{
    protected Furniture item;

    public FurnitureDecorator(Furniture item): base(item.Brand, item.Type, item.Colour, item.Material, item.Height, item.Width, item.Depth, item.getPrice())
    {
        this.item = item;
    }

    public abstract override string getDescription();
    public abstract override double getPrice();
}
