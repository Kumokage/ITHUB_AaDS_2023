using System;
using System.Collections.Generic;

namespace Map;


class Map 
{
    public class Link 
    {
        public Node from;
        public Node to;
        public int weight;

        // You can add constructors here, if you need one.
    }

    public class Node 
    {
        public string name;
        public List<Link> linked;

        // You can add constructors here, if you need one.
    }
    private Node[] nodes;

    public Map(int [,] adjacency_matrix) 
    {
        if(adjacency_matrix.GetLength(0)!=adjacency_matrix.GetLength(1))
        {
            throw new ArgumentException("Нужна квадратная матрица");
        }
        nodes = new Node[adjacency_matrix.GetLength(0)];
        for(int i = 0; i < adjacency_matrix.GetLength(0); i++)
        {
            nodes[i] = new Node();
            nodes[i].name = i.ToString();
        }
        for(int i = 0; i < adjacency_matrix.GetLength(0); ++i)
        {
            for(int j = 0; j < adjacency_matrix.GetLength(1); ++j)
            {
                if(adjacency_matrix[i,j]!=0)
                {
                    Link newlink = new();
                    newlink.from = nodes[i];
                    newlink.to = nodes[j];
                    newlink.weight = adjacency_matrix[i,j];
                    nodes[i].linked.Add(newlink);
                }
            }
        }
    }

    public Node[] DFS(Node start)
    {
        throw new NotImplementedException();
    }

    public Node[] BFS(Node start) 
    {
        int u = 0;
        for(int i = 0; i < nodes.Length; i++)
        {
            if(nodes[i] == start)
            {
                u = i;
            }
            else
            {
                throw new ArgumentException("Нет такого нода");
            }
        }
       int[][] g = new int[u + 1][];
       bool[]visited = new bool[u+1];
       Queue<Node> que = new Queue<Node>();
       for(int i = 0; i < u + 1; ++i)
       {
        g[i] = new int[u+1];
        for (int j = 0; j < u + 1; j++)
          {
                  //g[i][j] = ;
           }
       }
       return null;
    }

    public int Path(Node start, Node finish)
    {
        throw new NotImplementedException();
    }

    public Node this[int index] {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }
}