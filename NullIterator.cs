namespace SDP_ASG;

public class NullIterator : IIterator
{
    public bool hasNext()
    {
        return false;
    }
    public Object? next()
    {
        return null;
    }
}
