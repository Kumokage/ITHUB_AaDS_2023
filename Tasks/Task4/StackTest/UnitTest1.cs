using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackTask;

namespace StackTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestPush()
    {
        CardStack stack = new();
        stack.Push(new Card((CardElement)1, (CardType)1, "Some1", 1));
        stack.Push(new Card((CardElement)1, (CardType)1, "Some", 0));
    }

    [TestMethod]
    public void TestTop()
    {

    }

    [TestMethod]
    public void TestPop()
    {

    }

    [TestMethod]
    public void TestIsReadyForGame()
    {

    }

}