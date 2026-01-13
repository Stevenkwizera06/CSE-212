using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue distinct items with different priorities (10, 20, 30).
    // Expected Result: Dequeue should return items in order of priority: 30, 20, 10.
    // Defect(s) Found: 
    // 1. The loop in Dequeue was missing the last item (index < count - 1).
    // 2. The Dequeue method didn't remove the item from the list. 
    public void TestPriorityQueue_DequeueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 10);
        priorityQueue.Enqueue("High", 30);
        priorityQueue.Enqueue("Medium", 20);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: Dequeue should return items of the same highest priority in FIFO order.
    // Defect(s) Found: 
    // 1. The comparison used >= instead of > for priorities, which broke FIFO order for same-priority items. 
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 50);
        priorityQueue.Enqueue("SecondHigh", 50);
        priorityQueue.Enqueue("Low", 10);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: 
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
    }
}