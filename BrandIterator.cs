namespace SDP_ASG;

public class BrandIterator : IIterator
{
    private IReadOnlyList<FurnitureComponent> fc;
    private string brandName;
    private int position = 0;

    public string Brand { get { return brandName; } set { brandName = value; } }

    public BrandIterator(IReadOnlyList<FurnitureComponent> fc, string brandName)
    {
        this.fc = fc;
        this.brandName = brandName;
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
                if (f.Brand.getBrandName() == this.brandName)
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
