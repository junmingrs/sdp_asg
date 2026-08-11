namespace SDP_ASG;

public class BrandCompositeIterator : IIterator
{
    private Stack<IIterator> stack = new Stack<IIterator>();
    private string brand;

    public BrandCompositeIterator(IIterator iter, string brand)
    {
        stack.Push(iter);
        this.brand = brand;
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
        return true;
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
            stack.Push(component.createIterator("Brand", brand));
        }
        return component;
    }
}
