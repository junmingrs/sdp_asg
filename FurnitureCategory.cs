namespace SDP_ASG;

public class FurnitureCategory : FurnitureComponent
{
    private List<FurnitureComponent> furnitureComponents;
    public IReadOnlyList<FurnitureComponent> FurnitureComponents => furnitureComponents;
    private IIterator? typeIter = null;
    private IIterator? brandIter = null;
    private IIterator? iter = null;
    private string category;
    public string Category { get { return category; } set { category = value; } }

    public FurnitureCategory(string category)
    {
        this.furnitureComponents = new List<FurnitureComponent>();
        this.category = category;
    }

    public override void add(FurnitureComponent furnitureComponent)
    {
        this.furnitureComponents.Add(furnitureComponent);
    }
    public override void remove(FurnitureComponent furnitureComponent)
    {
        this.furnitureComponents.Remove(furnitureComponent);
    }
    public override IIterator createIterator(string iterType, string type)
    {
        if (iterType == "Brand")
        {
            this.brandIter = new BrandCompositeIterator(new BrandIterator(this.furnitureComponents, type), type);
            return this.brandIter;
        }
        else if (iterType == "Type")
        {
            this.typeIter = new TypeCompositeIterator(new TypeIterator(this.furnitureComponents, type), type);
            return this.typeIter;
        }
        else
        {
            this.iter = new CompositeIterator(new Iterator(this.furnitureComponents));
            return this.iter;
        }
    }
    public override FurnitureComponent? getChild(string childName)
    {
        foreach (FurnitureComponent fco in this.furnitureComponents)
        {
            if (fco is FurnitureCategory)
            {
                FurnitureCategory fca = (FurnitureCategory)fco;
                if (fca.Category == childName)
                {
                    return fca;
                }
            }
        }
        return null;
    }
    public override void print()
    {
        string header = $"FurnitureCategory: {this.category}";
        int i = header.Count();
        Console.WriteLine(" ");
        Console.WriteLine(" " + header);
        for (int i2 = 0; i2 < i + 1; i2++)
        {
            Console.Write("-");
        } 
        Console.WriteLine("-");
    }
}
