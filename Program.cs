using SDP_ASG;

Boolean end = false;
Boolean employeeEnd = false;
Boolean customerEnd = false;
Boolean prepareEnd = false;
Boolean sendEnd = false;
Employee em1 = new Employee("Test1", "IKEM0001");
Employee em2 = new Employee("Test2", "IKEM0002");
Employee em3 = new Employee("Test3", "IKEM0003");
Customer cu1 = new Customer("Test1", "test1@email.com", "IKCUS0001");
Customer cu2 = new Customer("Test2", "test2@email.com", "IKCUS0002");
Customer cu3 = new Customer("Test3", "test3@email.com", "IKCUS0003");
Furniture fur1 = new Sofa();
Furniture fur2 = new Table();
Furniture fur3 = new Chair();
List<Employee> employeeList = new List<Employee>();
List<Customer> customerList = new List<Customer>();
List<Order> orderList = new List<Order>();
employeeList.Add(em1);
employeeList.Add(em2);
employeeList.Add(em3);

customerList.Add(cu1);
customerList.Add(cu2);
customerList.Add(cu3);

void prepareOrder()
{
    Console.WriteLine(" ");
    Console.WriteLine("--- Orders ---");
    int i = 1;
    foreach (Order order in orderList)
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
        prepareEnd = true;
        Console.WriteLine(" ");
        Console.WriteLine("Returning to Employee Console");
        Console.WriteLine(" ");
    }
    Order selectOrder = null;
    foreach (Order o2 in orderList)
    {
        if (o2.OrderID == orderOption)
        {
            selectOrder = o2;
        }
    }
    selectOrder.IsPrepared = true;
    Console.WriteLine(" ");
    Console.WriteLine($"{selectOrder.OrderID} has been Prepared.");
    Console.WriteLine(" ");
}

void sendOrder()
{
    Console.WriteLine(" ");
    Console.WriteLine("--- Orders ---");
    int i = 1;
    foreach (Order order in orderList)
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
        sendEnd = true;
        Console.WriteLine(" ");
        Console.WriteLine("Returning to Employee Console");
        Console.WriteLine(" ");
    }
    Order selectOrder = null;
    foreach (Order o2 in orderList)
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

void employeeConsole(Employee employee)
{
    Console.WriteLine($"Welcome {employee.Name}");
    Console.WriteLine("1. View Orders to Prepare");
    Console.WriteLine("2. View Orders to Send");
    Console.WriteLine("3. filler");
    Console.WriteLine("4. err");
    Console.WriteLine("5. idk maybe");
    Console.Write("Select Option (0 to exit): ");
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 0)
    {
        employeeEnd = true;
        Console.WriteLine(" ");
        Console.WriteLine("Exiting Employee Console...");
    } else if (option == 1)
    {
        prepareEnd = false; 
        while (!prepareEnd)
        {
            prepareOrder();
        }
    } else if (option == 2)
    {
        sendEnd = false;
        while (!sendEnd)
        {
            sendOrder();
        }
    }
}

void customerConsole(Customer customer)
{
    Console.WriteLine($"Welcome {customer.Name}");
    Console.WriteLine("1. View Item Catalog");
    Console.WriteLine("2. Create Order");
    Console.WriteLine("3. filler");
    Console.WriteLine("4. idk");
    Console.WriteLine("5. Cancel Order");
    Console.Write("Select Option (0 to exit): ");
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 0)
    {
        customerEnd = true;
        Console.WriteLine(" ");
        Console.WriteLine("Exiting Customer Console...");
    } else if (option == 1)
    {
        Console.WriteLine("catalog go here whee");
    } else if (option == 2)
    {
        Console.WriteLine(" Order go here ");
    }
}

void logIn()
{
    Console.WriteLine("-- Select User --");
    Console.Write("Enter UserID (0 to Exit): ");
    string userID = Console.ReadLine();
    if (Convert.ToInt32(userID) == 0)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Returning to Start Console");
    }
    string userType = null;
    Employee maybeEmployee = null;
    Customer maybeCustomer = null;
    foreach (Employee emp in employeeList)
    {
        if (emp.Id == userID)
        {
            userType = "Employee";
            maybeEmployee = emp;
        }
    }
    foreach (Customer cus in customerList)
    {
        if (cus.Id == userID)
        {
            userType = "Customer";
            maybeCustomer = cus;
        }
    }
    if (userType == "Employee")
    {
        Console.Write("Enter Password: ");
        string Password = Console.ReadLine();
        if (maybeEmployee.logIn(Password))
        {
            employeeEnd = false;
            while(!employeeEnd)
            {
                Console.WriteLine(" ");
                employeeConsole(maybeEmployee);
            }
        } else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Incorrect Password!");
            Console.WriteLine(" ");
        }
    } else if (userType == "Customer")
    {
        Console.Write("Enter Password: ");
        string Password = Console.ReadLine();
        if (maybeCustomer.logIn(Password))
        {
            customerEnd = false;
            while (!customerEnd)
            {
                Console.WriteLine(" ");
                customerConsole(maybeCustomer);
            }
        } else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Incorrect Password!");
            Console.WriteLine(" ");
        }
    } else
    {
        Console.WriteLine(" ");
        Console.WriteLine("UserID is Invalid!");
        Console.WriteLine(" ");
    }
}

void startConsole()
{
    Console.WriteLine("----- Start -----");
    Console.WriteLine("1. Select User");
    Console.WriteLine("2. End Console");
    Console.Write("Option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(" ");

    if (option == 1)
    {
        Boolean loginEnd = false;
        while (!loginEnd)
        {
            logIn();
        }
    } else if (option == 2)
    {
        Console.WriteLine("See You Again Soon!");
        end = true;
    }
}

while (!end)
{
    startConsole();
}