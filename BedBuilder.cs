namespace SDP_ASG;

public class BedBuilder : IBuilder
{
    private Brand brand = new Brand("ICKER");
    private int height = 91;
    private int width = 190;
    private int depth = 20;
    private string type = "Bed";
    private string colour = "White";
    private string material = "Foam";
    private double price = 99.0;

    public IBuilder Reset()
    {
        this.brand = new Brand("ICKER");
        this.height = 91;
        this.width = 190;
        this.depth = 20;
        this.type = "Bed";
        this.colour = "White";
        this.material = "Foam";
        this.price = 99.0;
        return this;
    }
    public IBuilder setBrand(Brand brand)
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
        Furniture bed = new Bed(brand, type, colour, material, height, width, depth, price);
        Reset();
        return bed;
    }
}
