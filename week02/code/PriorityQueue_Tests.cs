using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Apple has priority 1, Banana has priority 5, and Cherry has priority 3.
    // Expected Result: Banana should be removed first because it has the highest priority.
    // Defect(s) Found: The last item in the queue was not being checked, and the
    // highest priority item was not being removed from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Cherry", 3);

        Assert.AreEqual("Banana", priorityQueue.Dequeue());
        Assert.AreEqual("Cherry", priorityQueue.Dequeue());
        Assert.AreEqual("Apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items where two items have the same highest priority.
    // Apple and Banana both have priority 5. Apple was added first.
    // Expected Result: Apple should be removed first, followed by Banana.
    // Defect(s) Found: Using >= caused the later item with the same priority
    // to be selected instead of preserving FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 5);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Cherry", 2);

        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());
        Assert.AreEqual("Cherry", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Put the highest priority item at the very back of the queue.
    // Expected Result: Cherry should be removed first because priority 10 is highest.
    // Defect(s) Found: The original loop did not check the final item in the queue.
    public void TestPriorityQueue_HighestPriorityAtBack()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 2);
        priorityQueue.Enqueue("Cherry", 10);

        Assert.AreEqual("Cherry", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                $"Unexpected exception of type {e.GetType()} caught: {e.Message}"
            );
        }
    }
}