namespace SDP_ASG;

public class SofaBuilder : IBuilder
{
    private string brand = "ICKER";
    private int height = 210;
    private int width = 80;
    private int depth = 90;
    private string type = "Sofa";
    private string colour = "Grey";
    private string material = "Fabric";
    private double price = 300.0;

    public IBuilder Reset()
    {
        this.brand = "ICKER";
        this.height = 210;
        this.width = 20;
        this.depth = 90;
        this.type = "Sofa";
        this.colour = "Grey";
        this.material = "Fabric";
        this.price = 300.0;
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
        Furniture sofa = new Sofa(brand, type, colour, material, height, width, depth, price);
        Reset();
        return sofa;
    }
}
