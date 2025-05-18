using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add Item A, Item B and Item C to the queue, all with 1 of priority.
    // Dequeue two items. Then, add Item D with priority 1 to the queue.
    // Expected Result: [Item C (Pri:1), Item D (Pri:1)] (Item A and Item B
    // are the first two items on the queue).
    // Defect(s) Found: On dequeue function, the items are not removed.
    public void TestPriorityQueue_BasicQueueFunctionality()
    {
        PriorityQueue priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item A", 1);
        priorityQueue.Enqueue("Item B", 1);
        priorityQueue.Enqueue("Item C", 1);
        priorityQueue.Dequeue();
        priorityQueue.Dequeue();
        priorityQueue.Enqueue("Item D", 1);

        string expectedResult = "[Item C (Pri:1), Item D (Pri:1)]";

        string result = priorityQueue.ToString();

        Assert.AreEqual(expectedResult, result);

    }

    [TestMethod]
    // Scenario: Add to the queue: Item A (Prio:1), Item B (Prio:2) and Item C (Prio:3).
    // Then, dequeue the high priority item. Finally, add Item D (Prio:1) to the queue.
    // Expected Result: [Item A (Pri:1), Item B (Pri:2), Item D (Pri:1)] (Item C is the high priority item)
    // Defect(s) Found: On for loop, the index should start at 0 and the statement should be index < _queue.Count.

    public void TestPriorityQueue_RemoveAnHighPriorityItem()
    {
        PriorityQueue priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item A", 1);
        priorityQueue.Enqueue("Item B", 2);
        priorityQueue.Enqueue("Item C", 3);
        priorityQueue.Dequeue();
        priorityQueue.Enqueue("Item D", 1);

        string expectedResult = "[Item A (Pri:1), Item B (Pri:2), Item D (Pri:1)]";

        string result = priorityQueue.ToString();

        Assert.AreEqual(expectedResult, result);

    }

    [TestMethod]
    // Scenario: Add Item A with priority 1, Item B and Item C with priority 2,
    // and Item D with priority 1 to the queue. Dequeue an item.
    // Expected Result: [Item A (Pri:1), Item C (Pri:2), Item D (Pri:1)] (Item B is
    // first high priority item).
    // Defect(s) Found: The if statement for highPriorityIndex should be only for
    // high priority, not equal.

    public void TestPriorityQueue_RemoveFirstOfHighPriority()
    {
        PriorityQueue priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item A", 1);
        priorityQueue.Enqueue("Item B", 2);
        priorityQueue.Enqueue("Item C", 2);
        priorityQueue.Enqueue("Item D", 1);
        priorityQueue.Dequeue();


        string expectedResult = "[Item A (Pri:1), Item C (Pri:2), Item D (Pri:1)]";

        string result = priorityQueue.ToString();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    // Scenario: Try to dequeue when the queue is empty.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        PriorityQueue priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        
    }
    
}