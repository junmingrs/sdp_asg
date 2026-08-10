// Decorator Pattern - Concrete Furniture (ConcreteComponents)

public class Sofa : Furniture
{
    public Sofa()
    {
        name = "Sofa";
        price = 500.00;
    }
    public override double getPrice() { return price; }
}

public class Table : Furniture
{
    public Table()
    {
        name = "Table";
        price = 300.00;
    }
    public override double getPrice() { return price; }
}

public class Bed : Furniture
{
    public Bed()
    {
        name = "Bed";
        price = 800.00;
    }
    public override double getPrice() { return price; }
}

public class Chair : Furniture
{
    public Chair()
    {
        name = "Chair";
        price = 150.00;
    }
    public override double getPrice() { return price; }
}