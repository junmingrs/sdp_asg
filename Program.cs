
using SDP_ASG;
 
// ── SETUP DATA ──────────────────────────────────
IBuilder sofaBuilder = new SofaBuilder();
IBuilder tableBuilder = new TableBuilder();
IBuilder chairBuilder = new ChairBuilder();
IBuilder bedBuilder = new BedBuilder();
 
FurnitureComponent root = new FurnitureCategory("root");
FurnitureComponent living = new FurnitureCategory("living");
FurnitureComponent bedroom = new FurnitureCategory("bedroom");
 
living.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).setBrand("ICKER").setType("Sofa").setPrice(500).build());
living.add(tableBuilder.setColour("Brown").setMaterial("Wood").setDimensions(120, 75, 60).setBrand("ICKER").setType("Table").setPrice(300).build());
bedroom.add(bedBuilder.setColour("White").setMaterial("Wood").setDimensions(200, 120, 50).setBrand("ICKER").setType("Bed").setPrice(800).build());
bedroom.add(chairBuilder.setColour("Black").setMaterial("Leather").setDimensions(60, 28, 25).setBrand("ICKER").setType("Chair").setPrice(150).build());
root.add(living);
root.add(bedroom);
 
Brand ikea = new Brand("IKEA");
Brand ashley = new Brand("Ashley");
List<Brand> brands = new List<Brand> { ikea, ashley };
List<Customer> customers = new List<Customer>();
Customer? currentCustomer = null;
 
// ── MAIN MENU ──────────────────────────────────
int choice = -1;
while (choice != 0)
{
    Console.WriteLine("\n=============================");
    Console.WriteLine("   Welcome to ICKIER Store!");
    Console.WriteLine("=============================");
    if (currentCustomer != null)
        Console.WriteLine($"   Logged in as: {currentCustomer.getName()}");
    Console.WriteLine("1) Create new customer");
    Console.WriteLine("2) Login as customer");
    Console.WriteLine("3) Browse furniture by type");
    Console.WriteLine("4) Browse furniture by brand");
    Console.WriteLine("5) Subscribe to a brand");
    Console.WriteLine("6) Unsubscribe from a brand");
    Console.WriteLine("7) View brands & special offers");
    Console.WriteLine("8) Add new special offer to brand");
    Console.WriteLine("9) Add add-ons to furniture");
    Console.WriteLine("10) Add furniture to catalog");
    Console.WriteLine("0) Exit");
    Console.Write("Your choice? ");
 
    if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
 
    switch (choice)
    {
        case 1: CreateCustomer(customers); break;
        case 2: currentCustomer = Login(customers); break;
        case 3: BrowseByType(root); break;
        case 4: BrowseByBrand(root); break;
        case 5: Subscribe(currentCustomer, brands); break;
        case 6: Unsubscribe(currentCustomer, brands); break;
        case 7: ViewOffers(brands); break;
        case 8: AddOffer(brands); break;
        case 9: AddAddOns(root); break;
        case 10: AddFurniture(root); break;
        case 0: Console.WriteLine("Thank you for visiting ICKIER!"); break;
        default: Console.WriteLine("Invalid choice."); break;
    }
}
 
// ── METHODS ──────────────────────────────────
 
void CreateCustomer(List<Customer> customers)
{
    Console.Write("Enter name: ");
    string name = Console.ReadLine() ?? "";
    Console.Write("Enter email: ");
    string email = Console.ReadLine() ?? "";
    customers.Add(new Customer(name, email));
    Console.WriteLine($"Customer {name} created!");
}
 
Customer? Login(List<Customer> customers)
{
    if (customers.Count == 0) { Console.WriteLine("No customers yet."); return null; }
    Console.WriteLine("Select customer:");
    for (int i = 0; i < customers.Count; i++)
        Console.WriteLine($"{i + 1}) {customers[i].getName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= customers.Count)
    {
        Console.WriteLine($"Logged in as {customers[idx - 1].getName()}!");
        return customers[idx - 1];
    }
    Console.WriteLine("Invalid choice."); return null;
}
 
void BrowseByType(FurnitureComponent root)
{
    Console.Write("Enter type (e.g. Sofa, Table, Bed, Chair): ");
    string type = Console.ReadLine() ?? "";
    Console.WriteLine($"\n--- Furniture of type: {type} ---");
    IIterator it = root.createIterator("Type", type);
    bool found = false;
    while (it.hasNext())
    {
        FurnitureComponent c = (FurnitureComponent)it.next()!;
        if (c is Furniture f) { f.print(); found = true; }
    }
    if (!found) Console.WriteLine("No furniture found.");
}
 
void BrowseByBrand(FurnitureComponent root)
{
    Console.Write("Enter brand: ");
    string brand = Console.ReadLine() ?? "";
    Console.WriteLine($"\n--- Furniture by brand: {brand} ---");
    IIterator it = root.createIterator("Brand", brand);
    bool found = false;
    while (it.hasNext())
    {
        FurnitureComponent c = (FurnitureComponent)it.next()!;
        if (c is Furniture) { c.print(); found = true; }
    }
    if (!found) Console.WriteLine("No furniture found.");
}
 
void Subscribe(Customer? customer, List<Brand> brands)
{
    if (customer == null) { Console.WriteLine("Please login first."); return; }
    Console.WriteLine("Select brand:");
    for (int i = 0; i < brands.Count; i++)
        Console.WriteLine($"{i + 1}) {brands[i].getBrandName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= brands.Count)
    {
        brands[idx - 1].registerObserver(customer);
        Console.WriteLine($"{customer.getName()} subscribed to {brands[idx - 1].getBrandName()}!");
    }
    else Console.WriteLine("Invalid choice.");
}
 
void Unsubscribe(Customer? customer, List<Brand> brands)
{
    if (customer == null) { Console.WriteLine("Please login first."); return; }
    Console.WriteLine("Select brand:");
    for (int i = 0; i < brands.Count; i++)
        Console.WriteLine($"{i + 1}) {brands[i].getBrandName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= brands.Count)
    {
        brands[idx - 1].removeObserver(customer);
        Console.WriteLine($"{customer.getName()} unsubscribed from {brands[idx - 1].getBrandName()}.");
    }
    else Console.WriteLine("Invalid choice.");
}
 
void ViewOffers(List<Brand> brands)
{
    Console.WriteLine("\n--- Brands & Special Offers ---");
    foreach (Brand b in brands)
    {
        Console.WriteLine($"\n{b.getBrandName()}:");
        var offers = b.getOffers();
        if (offers.Count == 0) Console.WriteLine("  No offers.");
        else foreach (var o in offers)
            Console.WriteLine($"  - {o.getOfferName()}: {o.getDiscount()}% off");
    }
}
 
void AddOffer(List<Brand> brands)
{
    Console.WriteLine("Select brand:");
    for (int i = 0; i < brands.Count; i++)
        Console.WriteLine($"{i + 1}) {brands[i].getBrandName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= brands.Count)
    {
        Console.Write("Enter offer name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter discount (%): ");
        double.TryParse(Console.ReadLine(), out double discount);
        brands[idx - 1].addSpecialOffer(new SpecialOffer(name, discount, brands[idx - 1]));
    }
    else Console.WriteLine("Invalid choice.");
}

void AddAddOns(FurnitureComponent root)
{
    Console.Write("Enter furniture type (e.g. Sofa): ");
    string type = Console.ReadLine() ?? "";
    IIterator it = root.createIterator("Type", type);

    Furniture furniture = null;
    while (it.hasNext())
    {
        FurnitureComponent c = (FurnitureComponent)it.next()!;
        if (c is Furniture f) { furniture = f; break; }
    }

    if (furniture == null) { Console.WriteLine("No furniture found."); return; }

    Console.WriteLine($"Selected: {furniture.getDescription()} - ${furniture.getPrice():F2}");

    Console.Write("Add warranty? (1 = 1 year, 2 = 2 years, 0 = no): ");
    string w = Console.ReadLine() ?? "0";
    if (w == "1") furniture = new WarrantyDecorator(furniture, 1);
    else if (w == "2") furniture = new WarrantyDecorator(furniture, 2);

    Console.Write("Add installation? (y/n): ");
    if ((Console.ReadLine() ?? "").ToLower() == "y")
    {
        Console.Write("Enter date (e.g. 2026-09-01): ");
        string date = Console.ReadLine() ?? "";
        furniture = new InstallationDecorator(furniture, date);
    }

    Console.WriteLine($"\n✓ Final: {furniture.getDescription()} - ${furniture.getPrice():F2}");
}

void AddFurniture(FurnitureComponent root)
{
    Console.WriteLine("\n=== Add Furniture ===");
    Console.WriteLine("Which furniture do you want to create?");
    Console.WriteLine("1) Sofa");
    Console.WriteLine("2) Table");
    Console.WriteLine("3) Chair");
    Console.WriteLine("4) Bed");
    Console.Write("Your choice? ");

    int typeChoice = PromptInt("", 1);
    switch (typeChoice)
    {
        case 1:
            PromptFurniture(sofaBuilder, "Sofa", root);
            break;
        case 2:
            PromptFurniture(tableBuilder, "Table", root);
            break;
        case 3:
            PromptFurniture(chairBuilder, "Chair", root);
            break;
        case 4:
            PromptFurniture(bedBuilder, "Bed", root);
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

void PromptFurniture(IBuilder builder, string type, FurnitureComponent root)
{
    string brand = PromptString($"Brand (default: ICKER)", "ICKER");
    string colour = PromptString($"Colour (default: White)", "White");
    string materialDefault = type switch
    {
        "Sofa" => "Fabric",
        "Bed" => "Spring",
        _ => "Wood"
    };
    string material = PromptString($"Material (default: {materialDefault})", materialDefault);
    int height = PromptInt($"Height in cm (default: 10)", 10);
    int width = PromptInt($"Width in cm (default: 10)", 10);
    int depth = PromptInt($"Depth in cm (default: 10)", 10);
    double priceDefault = type switch
    {
        "Sofa" => 50.0,
        "Table" => 30.0,
        "Chair" => 20.0,
        _ => 50.0
    };
    double price = PromptDouble($"Price (default: {priceDefault})", priceDefault);

    Furniture furniture = builder
        .setType(type)
        .setBrand(brand)
        .setColour(colour)
        .setMaterial(material)
        .setDimensions(height, width, depth)
        .setPrice(price)
        .build();

    string categoryName = PromptString($"Category to store in (new category will be created)", type);
    FurnitureCategory category = new FurnitureCategory(categoryName);
    root.add(category);
    category.add(furniture);

    Console.WriteLine($"\n✓ Added to category '{categoryName}': {furniture.getDescription()}");
}

string PromptString(string hint, string defaultValue)
{
    while (true)
    {
        Console.Write($"{hint} (press Enter for default): ");
        string input = Console.ReadLine() ?? "";
        if (input.Length == 0) return defaultValue;
        return input;
    }
}

int PromptInt(string hint, int defaultValue)
{
    while (true)
    {
        Console.Write($"{hint} (press Enter for {defaultValue}): ");
        string input = Console.ReadLine() ?? "";
        if (input.Length == 0) return defaultValue;
        if (int.TryParse(input, out int value) && value > 0) return value;
        Console.WriteLine($"Invalid input. Please enter a positive whole number.");
    }
}

double PromptDouble(string hint, double defaultValue)
{
    while (true)
    {
        Console.Write($"{hint} (press Enter for {defaultValue}): ");
        string input = Console.ReadLine() ?? "";
        if (input.Length == 0) return defaultValue;
        if (double.TryParse(input, out double value) && value >= 0) return value;
        Console.WriteLine($"Invalid input. Please enter a non-negative number.");
    }
}
