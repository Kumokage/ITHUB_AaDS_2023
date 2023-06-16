using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace PokemonGame
{
    public class Map
    {
        public class Node
        {
            public int City;
            public List<Link> Links;

            public Node(IEnumerable<Link> links, int city)
            {
                City = city;
                Links = new List<Link>();
                foreach (Link link in links)
                {
                    Links.Add(link);
                }
            }
        }

        public class Link
        {
            public Node From;
            public Node To;
            public int Weight;

            public Link(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }


        private Node[] nodes;


        public Map(int[,] matrix)
        {
            nodes = new Node[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                nodes[i] = new Node(new List<Link>(),i);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                        nodes[i].Links.Add(new Link(nodes[i], nodes[j], matrix[i,j]));
                }
            }
        }

        public int[] DFS(int city)
        {
            Node start = nodes[city];

            int[] array = new int[nodes.Length];
            List<Node> usedNodes = new List<Node>{ start };
            int index = 0;

            DFS(start, array, usedNodes, ref index);

            return array;
        }

        private void DFS(Node parent, int[] array, List<Node> usedNodes, ref int index)
        {
            array[index++] = parent.City + 1;
            usedNodes.Add(parent);

            for (int i = 0; i < parent.Links.Count; i++)
            {
                Node node = parent.Links[i].To;
                if (!usedNodes.Contains(node)) 
                {
                    DFS(node, array, usedNodes, ref index);
                }
            }
        }

        public int[] BFS(int city)
        {
            Node start = nodes[city];

            Node[] array = new Node[nodes.Length];

            array[0] = start;
            int parent = 0;
            for (int i = 1; i < nodes.Length;)
            {
                for (int j = 0; j < array[parent].Links.Count; j++)
                {
                    array[i] = array[parent].Links[j].To;
                    i++;
                }
                parent++;
            }

            int[] cities = new int[array.Length];
            for(int i = 0; i < cities.Length; i++)
            {
                cities[i] = array[i].City+1;
            }
            return cities;
        }

        public int Path(int startCity, int finishCity)
        {
            Node start = nodes[startCity];
            Node finish = nodes[finishCity];

            List<Node> usedNodes = new List<Node> { start };

            int minWeight = Path(start, finish, usedNodes);

            if (minWeight == -1) throw new Exception("Path not found");
            return minWeight;
        }

        private int Path(Node parent, Node finish, List<Node> usedNodes)
        {
            usedNodes.Add(parent);

            int minWeight = -1;
            for (int i = 0; i < parent.Links.Count; i++)
            {
                Node node = parent.Links[i].To;

                if (node.City == finish.City)
                    return parent.Links[i].Weight;

                if (!usedNodes.Contains(node))
                {
                    int weight = Path(node, finish, usedNodes);

                    if (weight != -1)
                        weight += parent.Links[i].Weight;
                    else
                        continue;

                    if (minWeight == -1 || weight < minWeight)
                        minWeight = weight;
                }
            }

            return minWeight;
        }

        public int this[int index]
        {
            get => nodes[index].City;
        }
    }
}