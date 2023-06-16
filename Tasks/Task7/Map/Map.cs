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
        throw new NotImplementedException();
    }

    public Node[] DFS(Node start)
    {
        throw new NotImplementedException();
    }

    public Node[] BFS(Node start) 
    {
        throw new NotImplementedException();
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