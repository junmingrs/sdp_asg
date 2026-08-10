namespace SDP_ASG;

public interface IBuilder
{
    IBuilder setDimensions(int height, int width, int depth);
    IBuilder setColour(string colour);
    IBuilder setMaterial(string material);
    IBuilder setType(string type);
    IBuilder setBrand(string brand);
    IBuilder setPrice(double price);
    Furniture build();
}
