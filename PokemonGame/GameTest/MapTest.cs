namespace GameTest;
using PokemonGame;
using System.Diagnostics;
using System.Net;

[TestClass]
public class MapTest
{
    Map map = null;

    [TestInitialize]
    public void TestInitialize()
    {
        map = new Map(new int[,]
        {
            { 0, 3, 0, 0, 0},
            { 0, 0, 2, 0, 0},
            { 0, 4, 0, 0, 0},
            { 1, 0, 3, 0, 2},
            { 0, 0, 0, 1, 0} 
        }
        );
    }

    [TestMethod]
    public void TestDFS()
    {
        int[] dfs = map.DFS( 3 );
        int[] answer = new int[] {4,1,2,3,5};
        for (int i = 0; i < dfs.Length; i++)
        {
            Assert.AreEqual(dfs[i], answer[i]);
        }
    }

    [TestMethod]
    public void TestBFS()
    {
        int[] bfs = map.BFS(3);
        int[] answer = new int[] { 4, 1, 3, 5, 2 };
        for (int i = 0; i < bfs.Length; i++)
        {
            Assert.AreEqual(bfs[i], answer[i]);
        }
    }

    [TestMethod]
    public void TestPath()
    {
        int pathWeight = map.Path(4,1);
        int answer = 5;
        Assert.AreEqual(pathWeight,answer);
    }
}
