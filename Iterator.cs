namespace SDP_ASG;

public class Iterator : IIterator
{
    private IReadOnlyList<FurnitureComponent> fc;
    private int position = 0;
    public Iterator(IReadOnlyList<FurnitureComponent> fc)
    {
        this.fc = fc;
    }

    public bool hasNext()
    {
        return position < fc.Count;
    }

    public Object? next()
    {
        FurnitureComponent fc = this.fc[position];
        position++;
        return fc;
    }
}
