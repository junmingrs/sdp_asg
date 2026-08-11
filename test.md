
// using SDP_ASG;
//
// IBuilder sofaBuilder = new SofaBuilder();
// IBuilder tableBuilder = new TableBuilder();
// IBuilder chairBuilder = new ChairBuilder();
// IBuilder bedBuilder = new BedBuilder();
//
// FurnitureComponent root = new FurnitureCategory("root");
// FurnitureComponent living = new FurnitureCategory("living");
// living.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).build());
// living.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).setBrand("Lmon").build());
// living.add(chairBuilder.setType("Armchair").setColour("Brown").setMaterial("Leather").setDimensions(60, 28, 25).build());
// root.add(living);
//
// void addSofa()
// {
//     while (true)
//     {
//         Furniture sofa = sofaBuilder.build();
//         Console.WriteLine("=== Add Sofa ===");
//         Console.WriteLine($"Brand: {sofa.Brand}");
//         Console.WriteLine($"Dimensions: {sofa.Height}cm x {sofa.Width}cm x {sofa.Depth}");
//         Console.WriteLine($"Type: {sofa.Type}");
//         Console.WriteLine($"Colour: {sofa.Colour}");
//         Console.WriteLine($"Material: {sofa.Material}");
//         Console.WriteLine($"Price: {sofa.getPrice()}");
//     }
// }
// void addBed()
// { }
// void addTable()
// { }
// void addChair()
// { }
//
// void displayEmployeeMenu()
// {
//     while (true)
//     {
//         Console.WriteLine("=== Employee Menu ===");
//         Console.WriteLine("(1) Add Sofa");
//         Console.WriteLine("(2) Add Bed");
//         Console.WriteLine("(3) Add Table");
//         Console.WriteLine("(4) Add Chair");
//         // NOTE: create discount and special offers also
//         Console.Write("Your choice: (1, 2, 3, 4)");
//         string? choice = Console.ReadLine();
//         if (choice == null)
//         {
//             Console.WriteLine("Please enter a number (1 or 2 or 3 or 4)");
//             continue;
//         }
//         if (int.TryParse(choice, out int num))
//         {
//             switch (num)
//             {
//                 case 1:
//                     break;
//                 case 2:
//                     break;
//                 case 3:
//                     break;
//                 case 4:
//                     break;
//                 default:
//                     Console.WriteLine("Please enter a number from 1 to 4");
//                     break;
//             }
//         }
//         else
//         {
//             Console.WriteLine("Please enter a number (1 or 2 or 3 or 4)");
//         }
//     }
// }
//
// void displayCustomerMenu()
// {
// }
//
// void displayStartMenu()
// {
//     while (true)
//     {
//         Console.WriteLine("=== WELCOME TO ICKER ===");
//         Console.WriteLine("(1) Login as ICKER employee");
//         Console.WriteLine("(2) Login as customer");
//         Console.WriteLine("Your choice (1, 2): ");
//         string? choice = Console.ReadLine();
//         if (choice == null)
//         {
//             Console.WriteLine("Please enter a number (1 or 2)");
//             continue;
//         }
//         if (int.TryParse(choice, out int num) && (num == 1 || num == 2))
//         {
//             if (num == 1)
//             {
//                 displayEmployeeMenu();
//                 break;
//             }
//             else
//             {
//                 displayCustomerMenu();
//                 break;
//             }
//         }
//         else
//         {
//             Console.WriteLine("Please enter a number (1 or 2)");
//         }
//     }
// }
//
// Console.WriteLine("=== TYPE ITERATOR DEMO ===");
// IIterator type = root.createIterator("Type", "Sofa");
// while (type.hasNext())
// {
//     FurnitureComponent c = (FurnitureComponent)type.next()!;
//     if (c is Furniture)
//     {
//         Furniture f = (Furniture)c;
//         Console.WriteLine($"{f.Brand}, {f.Type}");
//     }
// }
// Console.WriteLine();
// Console.WriteLine("=== BRAND ITERATOR DEMO ===");
// IIterator brand = root.createIterator("Brand", "Lmon");
// while (brand.hasNext())
// {
//     FurnitureComponent c = (FurnitureComponent)brand.next()!;
//     c.print();
// }
//
// // ── OBSERVER PATTERN DEMO ──────────────────────
//
// // Create brands
// Brand ikea = new Brand("IKEA");
// Brand ashley = new Brand("Ashley");
//
// // Create customers
// Customer alice = new Customer("Alice", "alice@email.com");
// Customer bob = new Customer("Bob", "bob@email.com");
//
// // Subscribe to brands
// ikea.registerObserver(alice);
// ikea.registerObserver(bob);
// ashley.registerObserver(alice);
//
// Console.WriteLine();
// Console.WriteLine("=== Observer Pattern Demo ===");
//
// // IKEA adds offer - both Alice and Bob notified
// ikea.addSpecialOffer(new SpecialOffer("Summer Sale", 20.0, ikea));
//
// // Bob unsubscribes
// ikea.removeObserver(bob);
// Console.WriteLine("\nBob unsubscribed from IKEA.");
//
// // IKEA adds another offer - only Alice notified
// ikea.addSpecialOffer(new SpecialOffer("Flash Sale", 50.0, ikea));
//
// // Ashley adds offer - only Alice notified
// ashley.addSpecialOffer(new SpecialOffer("Clearance", 30.0, ashley));
//
// // ── DECORATOR PATTERN DEMO ──────────────────────
//
// Console.WriteLine("\n=== Decorator Pattern Demo ===");
//
// // Create furniture using Jun Ming's builder
// Furniture sofa = sofaBuilder
//     .setColour("Grey")
//     .setMaterial("Fabric")
//     .setDimensions(80, 30, 95)
//     .setPrice(500)
//     .build();
//
// Console.WriteLine($"Base: {sofa.getDescription()}");
//
// // Add warranty
// Furniture sofaWithWarranty = new WarrantyDecorator(sofa, 2);
// Console.WriteLine($"After Warranty: {sofaWithWarranty.getDescription()} - ${sofaWithWarranty.getPrice():F2}");
//
// // Add installation
// Furniture sofaWithAll = new InstallationDecorator(sofaWithWarranty, "2026-09-01");
// Console.WriteLine($"After Installation: {sofaWithAll.getDescription()} - ${sofaWithAll.getPrice():F2}");
//

