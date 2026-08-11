namespace SDP_ASG;

public abstract class FurnitureComponent
{
    public virtual void add(FurnitureComponent component)
    {
        throw new NotSupportedException();
    }

    public virtual void remove(FurnitureComponent component)
    {
        throw new NotSupportedException();
    }

    public virtual IIterator createIterator(string iterType, string type)
    {
        throw new NotSupportedException();
    }

    public virtual void print()
    {
        throw new NotSupportedException();
    }
}
