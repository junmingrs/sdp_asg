// Decorator Pattern - Furniture (Component)

public abstract class Furniture
{
    protected string name;
    protected double price;

    public virtual string getDescription()
    {
        return name;
    }

    public abstract double getPrice();
}