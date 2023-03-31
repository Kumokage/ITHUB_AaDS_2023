using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackTask;

namespace StackTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestTopPush()
    {
        CardStack stack = new();
        stack.Push(new Card((CardElement)1, (CardType)1, "Some", 0));
        stack.Push(new Card((CardElement)1, (CardType)1, "Some1", 1));
        Assert.AreEqual(2, stack.Size);
        Assert.AreEqual("Some", stack.Top().Text);

        stack.Push(new Card((CardElement)1, (CardType)1, "Some3", 0));
        Assert.AreEqual(3, stack.Size);
        Assert.AreEqual("Some3", stack.Top().Text);
    }

    [TestMethod]
    public void TestPushPop()
    {
        CardStack stack = new();
        stack.Push(new Card((CardElement)1, (CardType)1, "Some1", 1));
        stack.Push(new Card((CardElement)1, (CardType)1, "Some2", 1));
        stack.Push(new Card((CardElement)1, (CardType)1, "Some3", 0));
        stack.Push(new Card((CardElement)1, (CardType)1, "Some4", 3));

        Assert.AreEqual(4, stack.Size);
        Assert.AreEqual("Some3", stack.Pop().Text);
        Assert.AreEqual(3, stack.Size);
        Assert.AreEqual("Some2", stack.Pop().Text);
        Assert.AreEqual(2, stack.Size);
        Assert.AreEqual("Some1", stack.Pop().Text);
        Assert.AreEqual(1, stack.Size);
        Assert.AreEqual("Some4", stack.Pop().Text);
        Assert.AreEqual(0, stack.Size);
    }

    [TestMethod]
    public void TestIsReadyForGame()
    {
        CardStack stack = new();
        for (int i = 0; i < 29; ++i)
        {
            stack.Push(new Card((CardElement)1, (CardType)1, $"Some{i}", 3));
            Assert.AreEqual(false, stack.IsReadyForGame());
        }

        stack.Push(new Card((CardElement)1, (CardType)1, "Some29", 3));
        Assert.AreEqual(true, stack.IsReadyForGame());
    }

    [TestMethod]
    public void TestPush100()
    {
        CardStack stack = new();
        for (int i = 0; i < 99; ++i)
        {
            stack.Push(new Card((CardElement)1, (CardType)1, $"Some{i}", 3));
        }

        Assert.ThrowsException<InvalidOperationException>(
            () => stack.Push(new Card((CardElement)1, (CardType)1, "Some99", 3)));
    }
}