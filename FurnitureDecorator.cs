// Decorator Pattern - FurnitureDecorator (Decorator)

public abstract class FurnitureDecorator : Furniture
{
    protected Furniture item;

    public FurnitureDecorator(Furniture item)
    {
        this.item = item;
    }

    public abstract override string getDescription();
    public abstract override double getPrice();
}