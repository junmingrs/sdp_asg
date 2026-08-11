namespace SDP_ASG;

public class Iterator : IIterator
{
    private List<FurnitureComponent> fc;
    private int position = 0;
    public Iterator(List<FurnitureComponent> fc)
    {
        this.fc = fc;
    }

    public bool hasNext() // NOTE: why did this get called twice
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
