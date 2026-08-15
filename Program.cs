using SDP_ASG;

IBuilder sofaBuilder = new SofaBuilder();
IBuilder tableBuilder = new TableBuilder();
IBuilder chairBuilder = new ChairBuilder();
IBuilder bedBuilder = new BedBuilder();

FurnitureComponent root = new FurnitureCategory("root");
FurnitureComponent sofas = new FurnitureCategory("Sofa");
FurnitureComponent beds = new FurnitureCategory("Bed");
FurnitureComponent tables = new FurnitureCategory("Table");
FurnitureComponent chairs = new FurnitureCategory("Chair");

sofas.add(sofaBuilder.setColour("Grey").setMaterial("Fabric").setDimensions(80, 30, 95).setBrand("ICKER").setType("Sofa").setPrice(450).build());
tables.add(tableBuilder.setColour("Brown").setMaterial("Wood").setDimensions(120, 75, 60).setBrand("ICKER").setType("Table").setPrice(220).build());
beds.add(bedBuilder.setColour("White").setMaterial("Wood").setDimensions(200, 120, 50).setBrand("ICKER").setType("Bed").setPrice(775).build());
chairs.add(chairBuilder.setColour("Black").setMaterial("Leather").setDimensions(60, 28, 25).setBrand("ICKER").setType("Chair").setPrice(75).build());

sofas.add(sofaBuilder.setColour("Grey").setMaterial("Leather").setDimensions(120, 30, 105).setBrand("Ashley").setType("Sofa").setPrice(500).build());
tables.add(tableBuilder.setColour("Brown").setMaterial("Wood").setDimensions(90, 70, 80).setBrand("Ashley").setType("Table").setPrice(300).build());
beds.add(bedBuilder.setColour("White").setMaterial("Metal").setDimensions(300, 120, 75).setBrand("Ashley").setType("Bed").setPrice(1050).build());
chairs.add(chairBuilder.setColour("Black").setMaterial("Fabric").setDimensions(80, 30, 30).setBrand("Ashley").setType("Chair").setPrice(90).build());
root.add(sofas);
root.add(tables);
root.add(beds);
root.add(chairs);

Brand ikea = new Brand("IKEA");
Brand ashley = new Brand("Ashley");
Customer Custtest1 = new Customer("Dummy1", "thisisafake@email.com", "ICKCUS0001");
Customer Custtest2 = new Customer("Dummy2", "lwkymightbeareal@email.com", "ICKCUS0002");
Employee Emptest1 = new Employee("EmployeeDummy1", "ICKEMP0001");
Employee Emptest2 = new Employee("EmployeeDummy2", "ICKEMP0002");
List<Brand> brands = new List<Brand> { ikea, ashley };
List<Customer> customers = new List<Customer> { Custtest1, Custtest2 };
List<Employee> employees = new List<Employee> { Emptest1, Emptest2 };
List<Order> orders = new List<Order>();
Customer? currentCustomer = null;
Employee? currentEmployee = null;
 
// ── MAIN MENU ──────────────────────────────────
void mainMenu()
{
    int choice = -1;
    while (choice != 0)
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine("   Welcome to ICKIER Store!");
        Console.WriteLine("=============================");
        Console.WriteLine("1) Create new customer");
        Console.WriteLine("2) Login as customer");
        Console.WriteLine("3) Login as employee");
        // Console.WriteLine("4) Create new Employee");
        Console.WriteLine("0) Exit");
        Console.Write("Your choice? ");

        if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

        switch (choice)
        {
            case 1: CreateCustomer(customers); break;
            case 2: currentCustomer = Login(customers); if (currentCustomer != null) { CustomerMenu(); }; break;
            case 3: currentEmployee = EmployeeLogin(employees); if (currentEmployee != null) { EmployeeMenu(); }; break;
            case 4: CreateEmployee(employees); break;
            case 0: Console.WriteLine(" "); Console.WriteLine("Thank you for visiting ICKIER!"); break;
            default: Console.WriteLine(" "); Console.WriteLine("Invalid choice."); break;
        }
    }
}

void EmployeeMenu()
{
    int employeeChoice = -1;
    while (employeeChoice != 0)
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine("       Employee Console      ");
        Console.WriteLine("=============================");
        if (currentEmployee != null)
            Console.WriteLine($"   Logged in as: {currentEmployee.Name}");
        Console.WriteLine("1) Browse all furniture in catalog");
        Console.WriteLine("2) Browse furniture by type");
        Console.WriteLine("3) Browse furniture by brand");
        Console.WriteLine("4) Add furniture to catalog");
        Console.WriteLine("5) View brands & special offers");
        Console.WriteLine("6) Add new special offer to brand");
        Console.WriteLine("7) View Orders to Prepare");
        Console.WriteLine("8) View Orders to Send");
        Console.WriteLine("0) Log Out");
        Console.Write("Your choice? ");

        if (!int.TryParse(Console.ReadLine(), out employeeChoice)) employeeChoice = -1;
        
        switch (employeeChoice)
        {
            case 1: iterateEverything(); break;
            case 2: BrowseByType(root); break;
            case 3: BrowseByBrand(root); break;
            case 4: AddFurniture(root); break;
            case 5: ViewOffers(brands); break;
            case 6: AddOffer(brands); break;
            case 7: PrepareOrder(); break;
            case 8: SendOrder(); break;
            case 9: AddAddOns(root); break;
            case 0: currentEmployee = null; Console.WriteLine(" "); Console.WriteLine("Logging Out..."); break;
            default: Console.WriteLine(" "); Console.WriteLine("Invalid choice."); break;
        }
    }
}

void CustomerMenu()
{
    int customerchoice = -1;
    while (customerchoice != 0)
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine($"     Welcome Back {currentCustomer.getName()}!");
        Console.WriteLine("=============================");
        Console.WriteLine("1) Browse all furniture in catalog");
        Console.WriteLine("2) Browse furniture by type");
        Console.WriteLine("3) Browse furniture by brand");
        Console.WriteLine("4) Subscribe to a brand");
        Console.WriteLine("5) Unsubscribe from a brand");
        Console.WriteLine("6) View brands & special offers");
        Console.WriteLine("7) Create An Order");
        Console.WriteLine("8) View Current Orders");
        Console.WriteLine("9) View Order History");
        Console.WriteLine("0) Log Out");
        Console.Write("Your choice? ");

        if (!int.TryParse(Console.ReadLine(), out customerchoice)) customerchoice = -1;

        switch (customerchoice)
        {
            case 1: iterateEverything(); break;
            case 2: BrowseByType(root); break;
            case 3: BrowseByBrand(root); break;
            case 4: Subscribe(currentCustomer, brands); break;
            case 5: Unsubscribe(currentCustomer, brands); break;
            case 6: ViewOffers(brands); break;
            case 7: CreateOrder(currentCustomer); break;
            case 8: ViewCurrentOrders(currentCustomer); break;
            case 9: ViewOrderHistory(currentCustomer); break;
            case 0: currentCustomer = null; Console.WriteLine(" "); Console.WriteLine("Logging Out..."); break;
            default: Console.WriteLine(" "); Console.WriteLine("Invalid choice."); break;
        }
    }
}
void iterateEverything()
{
    IIterator iter = root.createIterator("Normal", "");
    while (iter.hasNext())
    {
        FurnitureComponent fc = (FurnitureComponent)iter.next();
        fc.print();
    }
}

void CreateCustomer(List<Customer> customers)
{
    Console.Write("\nEnter name: ");
    string name = Console.ReadLine() ?? "";
    Console.Write("Enter email: ");
    string email = Console.ReadLine() ?? "";
    string custbaseID = "ICKCUS";
    string id = custbaseID + (customers.Count() + 1).ToString("0000");
    customers.Add(new Customer(name, email, id));
    Console.WriteLine(" ");
    Console.WriteLine($"Customer {name} created!");
}

Customer? Login(List<Customer> customers)
{
    if (customers.Count == 0) { Console.WriteLine("\nNo customers yet."); return null; }
    Console.WriteLine("\nSelect customer:");
    for (int i = 0; i < customers.Count; i++)
        Console.WriteLine($"{i + 1}) {customers[i].getName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= customers.Count)
    {
        return customers[idx - 1];
    }
    Console.WriteLine("\nInvalid choice."); return null;
}

void CreateEmployee(List<Employee> employees)
{
    Console.Write("\nEnter name: ");
    string name = Console.ReadLine() ?? "";
    Console.Write("Enter pasword: ");
    string password = Console.ReadLine() ?? "";
    string empbaseID = "ICKEMP";
    string id = empbaseID + (employees.Count() + 1).ToString("0000");
    employees.Add(new Employee(name, id, password));
    Console.WriteLine(" ");
    Console.WriteLine($"Employee {id} created!");
}

Employee? EmployeeLogin(List<Employee> employees)
{
    if (employees.Count == 0) { Console.WriteLine("\nNo employees yet."); return null; }
    Console.WriteLine("\nSelect Employee:");
    for (int i = 0; i < employees.Count; i++)
        Console.WriteLine($"{i + 1}) {employees[i].Name}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= employees.Count)
    {
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();
        Employee e = employees[idx - 1].logIn(password);
        if (e == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Incorrect Password!");
            return null;
        } 
        else
        {
            return e;
        }
    }
    Console.WriteLine(" ");
    Console.WriteLine("Invalid choice."); return null;
}

void BrowseByType(FurnitureComponent root)
{
    string type = PromptString("Enter type (e.g. Sofa, Table, Bed, Chair): ", "Sofa");
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

void Subscribe(Customer? customer, List<Brand> brands) // Added Whitespace... idk i jst like em
{
    if (customer == null) { Console.WriteLine("Please login first."); return; }
    Console.WriteLine("Select brand:");
    for (int i = 0; i < brands.Count; i++)
        Console.WriteLine($"{i + 1}) {brands[i].getBrandName()}");
    Console.Write("Your choice? ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= brands.Count)
    {
        Console.WriteLine(" ");
        brands[idx - 1].registerObserver(customer);
    }
    else { Console.WriteLine(" "); Console.WriteLine("Invalid choice."); };
}

void Unsubscribe(Customer? customer, List<Brand> brands) // Changed to only display brands customer is subscribed to + Added Whitespace
{
    Console.WriteLine(" ");
    if (customer == null) { Console.WriteLine("Please login first."); return; }
    List<Brand> subscribedBrands = new List<Brand>();
    foreach (Brand b in brands)
    {
        foreach (Customer c in b.Observers)
        {
            if (c.Id == customer.Id)
            {
                subscribedBrands.Add(b);
            }
        }
    }
    if (subscribedBrands.Count() == 0)
    {
        Console.WriteLine("You are not subscribed to any Brands yet.");
    } 
    else
    {
        int i = 1;
        Console.WriteLine("Select brand:");
        foreach (Brand b in subscribedBrands)
        {
            Console.WriteLine($"{i}) {b.getBrandName()}");
            i++;
        }
        Console.Write("Your choice? ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= brands.Count)
        {
            Console.WriteLine(" ");
            subscribedBrands[idx - 1].removeObserver(customer);
        }
        else { Console.WriteLine(" "); Console.WriteLine("Invalid choice."); }
    }
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

void AddAddOns(FurnitureComponent root) // Has been removed take note
{
    /*
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
    */
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

void PromptFurniture(IBuilder builder, string category, FurnitureComponent root)
{
    string brand = PromptString($"Brand (default: ICKER)", "ICKER");
    string type = PromptString($"Type (default: {category})", category);
    string colour = PromptString($"Colour (default: White)", "White");
    string materialDefault = category switch
    {
        "Sofa" => "Fabric",
        "Bed" => "Foam",
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

    FurnitureComponent? fc = root.getChild(category);
    if (fc == null)
    {
        throw new Exception("This shouldnt be possible");
    }
    if (type != category)
    {
        FurnitureCategory newCategory = new FurnitureCategory(type);
        newCategory.add(furniture);
        fc.add(newCategory);
        Console.WriteLine($"\n✓ Created new category under '{category}'");
        Console.WriteLine("this got ran");
    }
    else
    {
        fc.add(furniture);
        Console.WriteLine("this also got ran");
    }
    Console.WriteLine($"\n✓ Added to category '{type}': {furniture.getDescription()}");

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

void PrepareOrder()
{
    Console.WriteLine(" ");
    Console.WriteLine("--- Orders ---");
    int i = 1;
    foreach (Order order in orders)
    {
        if (order.State is PreparingState)
        {
            Console.WriteLine($"{i.ToString()}. {order.OrderID}");
        }
        i += 1;
    }
    Console.WriteLine(" ");
    Console.WriteLine("Enter OrderID to Prepare");
    Console.Write("Enter 0 to exit: ");
    string orderOption = Console.ReadLine();
    if (Convert.ToInt32(orderOption) == 0)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Returning to Employee Console");
        Console.WriteLine(" ");
    }
    Order selectOrder = null;
    foreach (Order o2 in orders)
    {
        if (o2.OrderID == orderOption)
        {
            selectOrder = o2;
        }
    }
    selectOrder.prepare();
}

void SendOrder()
{
    Console.WriteLine(" ");
    Console.WriteLine("--- Orders ---");
    int i = 1;
    foreach (Order order in orders)
    {
        if (order.State is OFDState)
        {
            Console.WriteLine($"{i.ToString()}. {order.OrderID}");
        }
        i += 1;
    }
    Console.WriteLine(" ");
    Console.WriteLine("Enter OrderID to Send Out");
    Console.Write("Enter 0 to exit: ");
    string orderOption = Console.ReadLine();
    if (Convert.ToInt32(orderOption) == 0)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Returning to Employee Console");
        Console.WriteLine(" ");
    }
    Order selectOrder = null;
    foreach (Order o2 in orders)
    {
        if (o2.OrderID == orderOption)
        {
            selectOrder = o2;
        }
    }
    selectOrder.deliver();
    Console.WriteLine(" ");
    Console.WriteLine($"{selectOrder.OrderID} has been Sent Out.");
    Console.WriteLine(" ");
}

void CreateOrder(Customer customer)
{
    Order order = null;
    if (customer.OrderList.Count() != 0 && customer.OrderList[^1].State is CreatedState)
    {
        order = customer.OrderList[^1];
    } 
    else
    {
        order = new Order(customer.OrderList.Count());
        customer.addOrder(order);
    }
    int orderchoice = -1;
    while (orderchoice != 0)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine($"         Item Catalog         ");
        Console.WriteLine("==============================");
        IIterator iter = root.createIterator("Normal", "");
        List<Furniture> furnitures = new List<Furniture>();
        int i = 1;
        while (iter.hasNext())
        {
            FurnitureComponent fc = (FurnitureComponent)iter.next();
            if (fc is Furniture f)
            {
                furnitures.Add(f);
                string[] details = [f.Type, f.Brand, f.Colour, f.getPrice().ToString("0.00")];
                Console.WriteLine($"{i}) {details[0]}: {details[1]}, {details[2]} - ${details[3]}");
                i++;
            } 
        }
        Console.WriteLine(" ");
        Console.WriteLine("1) View Item Details");
        Console.WriteLine("2) Add Item into Order");
        Console.WriteLine("3) Remove Item from Order");
        Console.WriteLine("4) View Current Order");
        Console.WriteLine("5) Checkout Order");
        Console.WriteLine("0) Exit");
        Console.Write("Your choice? ");

        if (!int.TryParse(Console.ReadLine(), out orderchoice)) orderchoice = -1;
  
        switch (orderchoice)
        {
            case 1: ViewItemDetail(furnitures); break;
            case 2: AddItemIntoOrder(furnitures, order); break;
            case 3: RemoveItemFromOrder(order); break;
            case 4: ViewOrder(order); break;
            case 5: if (CheckoutOrder(order)) { orderchoice = 0; Console.WriteLine("\nReturning to Menu"); }; break;
            case 0: Console.WriteLine(" "); Console.WriteLine("Exiting Item Catalog"); break;
            default: Console.WriteLine(" "); Console.WriteLine("Invalid choice."); break;
        }
    }
}

void ViewItemDetail(List<Furniture> furnitures) 
{
    Console.Write("\nSelect Item to View: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= furnitures.Count())
    {
        Furniture f = furnitures[idx - 1];
        Console.WriteLine(" ");
        Console.Write("Selected Item - ");
        f.print();
    }
    else
    {
        Console.WriteLine("\nInvalid choice.");
    }
}
void AddItemIntoOrder(List<Furniture> furnitures, Order order)
{
    Console.Write("\nSelect Item to Add: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= furnitures.Count())
    {
        Furniture f = furnitures[idx - 1];
        OrderItem oi = new OrderItem(f);
        Console.WriteLine($"\nSelected: {oi.getDescription()} - ${oi.getPrice():F2}");
        Console.Write("Add warranty? (1 = 1 year, 2 = 2 years, 0 = no): ");
        string w = Console.ReadLine() ?? "0";
        if (w == "1") oi = new WarrantyDecorator(oi, 1);
        else if (w == "2") oi = new WarrantyDecorator(oi, 2);
        Console.Write("Add installation? (y/n): ");
        if ((Console.ReadLine() ?? "").ToLower() == "y")
        {
            Console.Write("Enter date (e.g. 2026-09-01): ");
            string date = Console.ReadLine() ?? "";
            oi = new InstallationDecorator(oi, date);
        }
        Console.WriteLine(" ");
        order.addItem(oi);   
    }
    else
    {
        Console.WriteLine("\nInvalid choice.");
    }
}
void RemoveItemFromOrder(Order order) // Need to redo Display
{
    int i = 1;
    Console.WriteLine("\n------------------------------");
    Console.WriteLine($"          Your Order          ");
    Console.WriteLine("------------------------------");
    if (order.OrderItems.Count() == 0)
    {
        Console.WriteLine("Order is empty - Add an Item first");
    }
    else
    {
        foreach (OrderItem f in order.OrderItems)
        {
            string[] details = f.getDescription().Split(",");
            if (details.Count() == 5)
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                string warranty = details[3];
                string installation = details[^1];
                Console.WriteLine($"{i}) {type}: {brand}, {colour}" +
                    $"\n -{warranty},{installation} - ${f.getPrice().ToString("0.00")}");
                i++;
            }
            else if (details.Count() == 4)
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                string addon = details[^1];
                Console.WriteLine($"{i}) {type}: {brand}, {colour}" +
                    $"\n -{addon} - ${f.getPrice().ToString("0.00")}");
                i++;
            }
            else
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                Console.WriteLine($"{i}) {type}: {brand}, {colour} - ${f.getPrice().ToString("0.00")}");
                i++;
            }
        }
        Console.Write("\nSelect Item to Remove: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= order.OrderItems.Count())
        {
            order.removeItem(order.OrderItems[idx - 1]);
        }
        else
        {
            Console.WriteLine("\nInvalid choice.");
        }
    }
}
void ViewOrder(Order order)
{
    Console.WriteLine("\n------------------------------");
    Console.WriteLine($"          Your Order          ");
    Console.WriteLine("------------------------------");
    if (order.OrderItems.Count() == 0)
    {
        Console.WriteLine("Order is empty - Add an Item first");
    }
    else
    {
        foreach (OrderItem f in order.OrderItems)
        {
            string[] details = f.getDescription().Split(",");
            if (details.Count() == 5)
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                string warranty = details[3];
                string installation = details[^1];
                Console.WriteLine($"{type}: {brand}, {colour}" +
                    $"\n -{warranty},{installation} - ${f.getPrice().ToString("0.00")}");
            }
            else if (details.Count() == 4)
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                string addon = details[^1];
                Console.WriteLine($"{type}: {brand}, {colour}" +
                    $"\n -{addon} - ${f.getPrice().ToString("0.00")}");
            }
            else
            {
                string type = details[0].Split(":")[0];
                string brand = details[0].Split(":")[1].Replace(" ", "");
                string colour = details[1].Replace(" ", "");
                Console.WriteLine($"{type}: {brand}, {colour} - ${f.getPrice().ToString("0.00")}");
            }
        }
    }
}
Boolean CheckoutOrder(Order order)
{
    ViewOrder(order);
    if (order.OrderItems.Count() == 0)
    {
        return false;
    }
    else
    {
        Console.WriteLine(" ");
        Console.Write("Submit Order? (y/n): ");
        string choice = Console.ReadLine().ToLower();
        if (choice == "y")
        {
            order.requestPayment();
            order.processPayment();
            return true;
        }
        else if (choice == "n")
        {
            Console.WriteLine("\nReturning Back To Item Catalog");
            return false;
        }
        else
        {
            Console.WriteLine("\nInvalid choice.");
            return false;
        }
    }
}
void CancelOrder(Customer customer)
{

}

void ViewCurrentOrders(Customer customer)
{

}

void ViewOrderHistory(Customer customer)
{

}

mainMenu();

