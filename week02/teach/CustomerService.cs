/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);
 
        // Test Cases
 
        // Test 1-2
        // Scenario:The user shall specify the maximum size of the Customer Service Queue when it is created. If the size is invalid (less than or equal to 0) then the size shall default to 10.
        //The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: Create a customer service with a specific size and add a new costumer to the queue
        Console.WriteLine("Test 1");
        // Create a new customer service queue
        var cs = new CustomerService(0);
        // Add a new customer
        cs.AddNewCustomer();
        // Display the queue
        Console.WriteLine(cs);
 
        // Test 3
        // Scenario: If the queue is full when trying to add a customer, then an error message will be displayed.
        // Expected Result:If the queue is full then it should display an error message
        // Defect(s) Found: In the function addnewcustomer we found an error in the conditional it should be >= and it was only >
        Console.WriteLine("Test 3");
        var cs2 = new CustomerService(1);
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        Console.WriteLine(cs2);
 
 
        // Test 4
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: the details of the customer that is dequeued should be display
        // Defect(s) Found: The variable customer was in a position that wasn't correct it should be at the beggining of the function
        Console.WriteLine("Test 4");
        var cs3 = new CustomerService(3);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.ServeCustomer();
        Console.WriteLine(cs3);
 
        // Test 5
        // Scenario: If the queue is empty when trying to serve a customer, then an error message will be displayed.
        // Expected Result: It should display an error message when we try to serve a customer and the queue is empty
        // Defect(s) Found:
        Console.WriteLine("Test 5");
        var cs4 = new CustomerService(3);
        cs4.ServeCustomer();
        Console.WriteLine(cs4);
       
        Console.WriteLine("=================");
 
        // Test 2
        // Scenario:
        // Expected Result:
        Console.WriteLine("Test 2");
 
        // Defect(s) Found:
 
        Console.WriteLine("=================");
 
        // Add more Test Cases As Needed Below
    }
 
    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;
 
    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }
 
    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }
 
        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }
 
        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }
 
    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
 
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();
 
        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }
 
    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("The queue is empty");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
 
    }
 
    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}