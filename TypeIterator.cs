namespace SDP_ASG;

public class TypeIterator : IIterator
{
    private IReadOnlyList<FurnitureComponent> fc;
    private string type;
    private int position = 0;
    public TypeIterator(IReadOnlyList<FurnitureComponent> fc, string type)
    {
        this.fc = fc;
        this.type = type;
    }

    public bool hasNext() // NOTE: why did this get called twice
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
                if (f.Type == this.type)
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
