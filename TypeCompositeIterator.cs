namespace SDP_ASG;

public class TypeCompositeIterator : IIterator
{
    private Stack<IIterator> stack = new Stack<IIterator>();
    private string type;

    public TypeCompositeIterator(IIterator iter, string type) // NOTE: better to use IIterator
    {
        stack.Push(iter);
        this.type = type;
    }
    public bool hasNext()
    {
        if (stack.Count == 0)
        {
            return false;
        }
        IIterator iter = stack.Peek();
        if (!iter.hasNext())
        {
            stack.Pop();
            return hasNext();
        }
        else
        {
            return true;
        }
    }
    public Object? next()
    {
        if (!hasNext())
        {
            return null;
        }
        FurnitureComponent component = (FurnitureComponent)stack.Peek().next();
        if (component is FurnitureCategory)
        {
            stack.Push(component.createIterator("Type", this.type));
        }
        return component;
    }
}
