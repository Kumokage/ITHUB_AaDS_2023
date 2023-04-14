using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTGCollection;

namespace MTGCollectionTest;

[TestClass]
public class CardCollectionTest {
    [TestMethod]
    public void TestMethod1()
    {
        Card card = new();
        Assert.AreEqual(5, card.colors.Length);
    }
}