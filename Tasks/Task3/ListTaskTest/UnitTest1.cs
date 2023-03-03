using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListTask;

namespace ListTaskTest;

[TestClass]
public class ListUnitTest
{
    [TestMethod]
    public void TestListIndexer()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list[0], 1);
        Assert.AreEqual(list[1], 2);
        Assert.AreEqual(list[2], 3);
        Assert.AreEqual(list[3], 4);
    }

    [TestMethod]
    public void TestListFront()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.Front(), 1);
        list = new List();
        Assert.AreEqual(list.Front(), null);
    }

    [TestMethod]
    public void TestListBack()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.Back(), 4);
        list = new List();
        Assert.AreEqual(list.Back(), null);
    }

    [TestMethod]
    public void TestListEmpty()
    {
        List list = new List();
        Assert.AreEqual(list.Empty(), true);
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.Empty(), false);
    }

    [TestMethod]
    public void TestListSize()
    {
        List list = new List();
        Assert.AreEqual(list.Size(), 0);
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.Size(), 6);
    }

    [TestMethod]
    public void TestListClear()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        list.Clear();
        Assert.AreEqual(list.Empty(), true);
    }

    [TestMethod]
    public void TestListPushBack()
    {
        List list = new List();
        list.PushBack(1);
        list.PushBack(4);
        Assert.AreEqual(list.Back(), 4);
        list.PushBack(10);
        Assert.AreEqual(list.Back(), 10);
    }

    [TestMethod]
    public void TestListPopBack()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.PopBack(), 4);
        Assert.AreEqual(list.PopBack(), 10);
    }

    [TestMethod]
    public void TestListPushFront()
    {
        List list = new List();
        list.PushFront(1);
        list.PushFront(4);
        Assert.AreEqual(list.Front(), 4);
        list.PushFront(10);
        Assert.AreEqual(list.Front(), 10);
    }

    [TestMethod]
    public void TestListPopFront()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        Assert.AreEqual(list.PopFront(), 1);
        Assert.AreEqual(list.PopFront(), 7);
    }

    [TestMethod]
    public void TestListResize()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        list.Resize(2);
        Assert.AreEqual(list[0], 1);
        Assert.AreEqual(list[1], 7);
        list.Resize(4);
        Assert.AreEqual(list[2], 0);
        Assert.AreEqual(list[3], 0);
    }

    [TestMethod]
    public void TestListSwap()
    {
        int[] arr1 = new int[]{1, 7, 2, 4, 10, 4};
        List list1 = new List(arr1);
        int[] arr2 = new int[]{2, 4};
        List list2 = new List(arr2);
        list1.Swap(list2);
        Assert.AreEqual(list1[0], 2);
        Assert.AreEqual(list2[0], 1);
    }

    [TestMethod]
    public void TestListRemove()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        list.Remove(4);
        Assert.AreEqual(list[3], 10);
        list.Remove(4);
        Assert.AreEqual(list.Back(), 10);
    }

    [TestMethod]
    public void TestListUnique()
    {
        int[] arr = new int[]{1, 3, 7, 7, 4, 10, 4, 4, 4, 4};
        List list = new List(arr);
        list.Unique();
        Assert.AreEqual(list[2], 7);
        Assert.AreEqual(list[3], 4);
        Assert.AreEqual(list[5], 4);
    }

    [TestMethod]
    public void TestListSort()
    {
        int[] arr = new int[]{1, 7, 2, 4, 10, 4};
        List list = new List(arr);
        for(int i = 0; i < N - 1; ++i) 
        {
            Assert.IsTrue(list[i] <= list[i+1]);
        }
    }
}