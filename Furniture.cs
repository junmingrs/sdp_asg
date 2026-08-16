namespace SDP_ASG;

public abstract class Furniture : FurnitureComponent
{
    private Brand brand;
    private string type;
    private string colour;
    private string material;
    private int height;
    private int width;
    private int depth;
    private double price;

    public Brand Brand { get { return brand; } set { brand = value; } }
    public string Type { get { return type; } set { type = value; } }
    public string Colour { get { return colour; } set { colour = value; } }
    public string Material { get { return material; } set { material = value; } }
    public int Height { get { return height; } set { height = value; } }
    public int Width { get { return width; } set { width = value; } }
    public int Depth { get { return depth; } set { depth = value; } }

    public Furniture() { }
    public Furniture(Brand brand, string type, string colour, string material, int height, int width, int depth, double price)
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

    public virtual string getDescription()
    {
        return $"{this.type}: {this.brand.getBrandName()}, {this.colour}, {this.material} of {this.height}cm x{this.width}cm x{this.depth}cm";
    }

    public virtual double getPrice()
    {
        List<SpecialOffer> offers = this.brand.getOffers();
        double discounts = 0.0;
        foreach (SpecialOffer offer in offers)
        {
            if (discounts > 100.0) break;
            discounts += offer.getDiscount();
        }
        return this.price - (this.price * (discounts / 100));
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
