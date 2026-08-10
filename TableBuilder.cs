namespace SDP_ASG;

public class TableBuilder : IBuilder
{
    private string brand = "ICKER";
    private int height = 10;
    private int width = 10;
    private int depth = 10;
    private string type = "Table";
    private string colour = "White";
    private string material = "Wood";
    private double price = 30.0;

    public TableBuilder Reset()
    {
        this.brand = "ICKER";
        this.height = 10;
        this.width = 10;
        this.depth = 10;
        this.type = "Table";
        this.colour = "White";
        this.material = "Wood";
        this.price = 30.0;
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
        Furniture table = new Furniture(brand, type, colour, material, height, width, depth, price);
        Reset();
        return table;
    }
}
