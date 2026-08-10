using SDP_ASG;

IBuilder sofaBuilder = new SofaBuilder();
IBuilder tableBuilder = new TableBuilder();
IBuilder chairBuilder = new ChairBuilder();
IBuilder bedBuilder = new BedBuilder();

FurnitureComponent root = new FurnitureCategory("root");
FurnitureComponent living = new FurnitureCategory("living");
living.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).build());
living.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).setBrand("Lmon").build());
living.add(chairBuilder.setType("Armchair").setColour("Brown").setMaterial("Leather").setDimensions(60, 28, 25).build());
root.add(living);

Console.WriteLine("test type iter");
IIterator type = root.createIterator("Type", "Sofa");
while (type.hasNext())
{
    FurnitureComponent c = (FurnitureComponent)type.next()!;
    if (c is Furniture)
    {
        Furniture f = (Furniture)c;
        Console.WriteLine($"{f.Brand}, {f.Type}");
    }
}
Console.WriteLine();
Console.WriteLine("test brand iter");
IIterator brand = root.createIterator("Brand", "Lmon");
while (brand.hasNext())
{
    FurnitureComponent c = (FurnitureComponent)brand.next()!;
    c.print();
}

