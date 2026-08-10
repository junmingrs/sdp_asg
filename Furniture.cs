namespace SDP_ASG;

public class Furniture : FurnitureComponent
{
    private string brand;
    private string type;
    private string colour;
    private string material;
    private int height;
    private int width;
    private int depth;
    private double price;

    public string Brand { get { return brand; } set { brand = value; } }
    public string Type { get { return type; } set { type = value; } }
    public string Colour { get { return colour; } set { colour = value; } }
    public string Material { get { return material; } set { material = value; } }
    public int Height { get { return height; } set { height = value; } }
    public int Width { get { return width; } set { width = value; } }
    public int Depth { get { return depth; } set { depth = value; } }

    public Furniture(string brand, string type, string colour, string material, int height, int width, int depth, double price)
    {
        this.brand = brand;
        this.type = type;
        this.colour = colour;
        this.material = material;
        this.height = height;
        this.width = width;
        this.depth = depth;
        this.price = price;
    }

    public string getDescription()
    {
        return $"Furniture: {this.brand}, {this.type}, {this.colour}, {this.material} of {this.height}cm x{this.width}cm x{this.depth}cm, costing ${price}";
    }

    public double getPrice()
    {
        return this.price;
    }

    public override IIterator createIterator(string iterType, string type)
    {
        return new NullIterator();
    }
    public override void print()
    {
        Console.WriteLine(this.getDescription());
    }
}
