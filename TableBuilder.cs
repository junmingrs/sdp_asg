namespace SDP_ASG;

public class TableBuilder : IBuilder
{
    private string brand = "ICKER";
    private int height = 120;
    private int width = 100;
    private int depth = 75;
    private string type = "Table";
    private string colour = "Maple";
    private string material = "Wood";
    private double price = 200.0;

    public IBuilder Reset()
    {
        this.brand = "ICKER";
        this.height = 120;
        this.width = 100;
        this.depth = 75;
        this.type = "Table";
        this.colour = "Maple";
        this.material = "Wood";
        this.price = 200.0;
        return this;
    }
    public IBuilder setBrand(string brand)
    {
        this.brand = brand;
        return this;
    }
    public IBuilder setDimensions(int height, int width, int depth)
    {
        this.height = height;
        this.width = width;
        this.depth = depth;
        return this;
    }
    public IBuilder setColour(string colour)
    {
        this.colour = colour;
        return this;
    }
    public IBuilder setMaterial(string material)
    {
        this.material = material;
        return this;
    }
    public IBuilder setType(string type)
    {
        this.type = type;
        return this;
    }
    public IBuilder setPrice(double price)
    {
        this.price = price;
        return this;
    }
    public Furniture build()
    {
        Furniture table = new Table(brand, type, colour, material, height, width, depth, price);
        Reset();
        return table;
    }
}
