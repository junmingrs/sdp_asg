namespace SDP_ASG;

public class BrandIterator : IIterator
{
    private List<FurnitureComponent> fc;
    private string brand;
    private int position = 0;

    public string Brand { get { return brand; } set { brand = value; } }

    public BrandIterator(List<FurnitureComponent> fc, string brand)
    {
        this.fc = fc;
        this.brand = brand;
    }

    public bool hasNext()
    {
        while (position < fc.Count)
        {
            FurnitureComponent fc = this.fc[position];
            if (fc is FurnitureCategory)
            {
                return true;
            }
            if (fc is Furniture)
            {
                Furniture f = (Furniture)fc;
                if (f.Brand == this.brand)
                {
                    return true;
                }
            }
            position++;
        }
        return position < fc.Count;
    }

    public Object? next()
    {
        FurnitureComponent fc = this.fc[position];
        position++;
        return fc;
    }
}
