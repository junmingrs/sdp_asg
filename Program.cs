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

Console.WriteLine("=== TYPE ITERATOR DEMO ===");
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
Console.WriteLine("=== BRAND ITERATOR DEMO ===");
IIterator brand = root.createIterator("Brand", "Lmon");
while (brand.hasNext())
{
    FurnitureComponent c = (FurnitureComponent)brand.next()!;
    c.print();
}

// ── OBSERVER PATTERN DEMO ──────────────────────
 
// Create brands
Brand ikea = new Brand("IKEA");
Brand ashley = new Brand("Ashley");

// Create customers
Customer alice = new Customer("Alice", "alice@email.com");
Customer bob = new Customer("Bob", "bob@email.com");

// Subscribe to brands
ikea.registerObserver(alice);
ikea.registerObserver(bob);
ashley.registerObserver(alice);

Console.WriteLine();
Console.WriteLine("=== Observer Pattern Demo ===");

// IKEA adds offer - both Alice and Bob notified
ikea.addSpecialOffer(new SpecialOffer("Summer Sale", 20.0, ikea));

// Bob unsubscribes
ikea.removeObserver(bob);
Console.WriteLine("\nBob unsubscribed from IKEA.");

// IKEA adds another offer - only Alice notified
ikea.addSpecialOffer(new SpecialOffer("Flash Sale", 50.0, ikea));

// Ashley adds offer - only Alice notified
ashley.addSpecialOffer(new SpecialOffer("Clearance", 30.0, ashley));

// ── DECORATOR PATTERN DEMO ──────────────────────

Console.WriteLine("\n=== Decorator Pattern Demo ===");

// Create furniture using Jun Ming's builder
Furniture sofa = sofaBuilder
    .setColour("Grey")
    .setMaterial("Fabric")
    .setDimensions(80, 30, 95)
    .setPrice(500)
    .build();

Console.WriteLine($"Base: {sofa.getDescription()}");

// Add warranty
Furniture sofaWithWarranty = new WarrantyDecorator(sofa, 2);
Console.WriteLine($"After Warranty: {sofaWithWarranty.getDescription()} - ${sofaWithWarranty.getPrice():F2}");

// Add installation
Furniture sofaWithAll = new InstallationDecorator(sofaWithWarranty, "2026-09-01");
Console.WriteLine($"After Installation: {sofaWithAll.getDescription()} - ${sofaWithAll.getPrice():F2}");

