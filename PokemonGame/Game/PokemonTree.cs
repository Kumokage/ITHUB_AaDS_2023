using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace PokemonGame
{
    public class PokemonTree
    {
        class Node
        {
            public Node? left;
            public Node? right;
            public Node? parent;
            public Pokemon pokemon;
            public int size;

            public Node(Pokemon pokemon, Node? left, Node? right, Node? parent)
            {
                this.pokemon = pokemon;
                this.left = left;
                this.right = right;
                this.parent = parent;
                size = 1;
                if (left is not null)
                    size += left.size;
                if (right is not null)
                    size += right.size;
            }

            public override string ToString()
            {
                return pokemon.Name;
            }
        }

        private Node? root;

        public int Size => root is null ? 0 : root.size;


        public PokemonTree() { }


        public void Add(Pokemon pokemon)
        {
            Node node = new Node(pokemon, null,null,null);

            if (root == null)
            {
                root = node;
                return;
            }

            Node parent = root;
            while (true)
            {
                bool toBreak = false;
                if(node.pokemon.Name.CompareTo(parent.pokemon.Name) < 0)
                {
                    if (parent.left == null)
                    {
                        parent.left = node;
                        node.parent = parent;
                        break;
                    }
                    parent = parent.left;
                }
                else if(node.pokemon.Name.CompareTo(parent.pokemon.Name) > 0)
                {
                    if (parent.right == null)
                    {
                        parent.right = node;
                        node.parent = parent;
                        break;
                    }
                    parent = parent.right;
                }
                else
                {
                    throw new Exception("Покемон с этим именем уже есть в дереве");
                }
            }
            node.size = 1;
            Node bufParent = node;
            while (bufParent is not null)
            {
                bufParent.size = 1;
                if (bufParent.right is not null) bufParent.size += bufParent.right.size;
                if (bufParent.left is not null) bufParent.size += bufParent.left.size;
                bufParent = bufParent.parent;
            }
        }

        public Pokemon Search(string name)
        {
            if (root is null)
                throw new Exception("Дерево пусто");
            if (root.pokemon.Name == name)
                return root.pokemon;

            Node? node = Search(name, root);

            Pokemon? pokemon;
            if (node is not null)
                pokemon = node.pokemon;
            else
                throw new ArgumentException("Покемон не найден");

            return pokemon;
        }

        private Node? Search(string name, Node? parent)
        {
            if (parent is null) return null;
            if (parent.pokemon.Name == name)
                return parent;

            Node? left = Search(name, parent.left);
            Node? right = Search(name, parent.right);

            Node? node = null;
            if (left is not null)
                node = left;
            else if (right is not null)
                node = right;
            return node;
        }


        public Pokemon Delete(string name)
        {
            if (root is null)
                throw new Exception("Дерево пусто");

            Node? node = Search(name, root);

            if(node is null)
                throw new ArgumentException("Покемон не найден");

            Node? newNode = null;

            if(node.left is not null || node.right is not null)
            {
                if(node.right is null && node.left is not null || (node.right is not null && node.left is not null && node.left.size > node.right.size))
                {
                    
                    newNode = node.left;
                    
                    while (newNode.right is not null)
                    {
                        newNode = newNode.right;
                        
                    }

                    if(newNode.pokemon.Name == node.left.pokemon.Name)
                    {
                        newNode.right = node.right;
                        newNode.right.parent = newNode;
                    }
                    else
                    {
                        if (newNode.parent.right.pokemon.Name == newNode.pokemon.Name)
                        {
                            if (newNode.left is not null)
                            {
                                newNode.parent.right = newNode.left;
                                newNode.left.parent = newNode.parent;
                            }
                            else
                            {
                                newNode.parent.right = null;
                            }
                        }
                        else
                        {
                            if (newNode.left is not null)
                            {
                                newNode.parent.left = newNode.right;
                                newNode.left.parent = newNode.parent;
                            }
                            else
                            {
                                newNode.parent.left = null;
                            }
                        }
                        newNode.right = node.right;
                        newNode.left = node.left;
                        if (newNode.right is not null) 
                            newNode.right.parent = newNode;
                        if (newNode.left is not null) 
                            newNode.left.parent = newNode;
                    }
                }
                else if (node.left is null && node.right is not null || (node.right is not null && node.left is not null && node.left.size < node.right.size))
                {
                    newNode = node.right;
                    
                    while (newNode.left is not null)
                    {
                        newNode = newNode.left;
                    }

                    if (newNode.pokemon.Name == node.right.pokemon.Name)
                    {
                        newNode.left = node.left;
                        newNode.right.parent = newNode;
                    }
                    else
                    {

                        if (newNode.parent.left.pokemon.Name == newNode.pokemon.Name)
                        {
                            if (newNode.right is not null)
                            {
                                newNode.parent.left = newNode.right;
                                newNode.right.parent = newNode.parent;
                            }
                            else
                            {
                                newNode.parent.left = null;
                            }
                        }
                        else
                        {
                            if (newNode.right is not null)
                            {
                                newNode.parent.right = newNode.left;
                                newNode.right.parent = newNode.parent;
                            }
                            else
                            {
                                newNode.parent.right = null;
                            }
                        }

                        newNode.right = node.right;
                        newNode.left = node.left;
                        if(newNode.right is not null) 
                            newNode.right.parent = newNode;
                        if (newNode.left is not null) 
                            newNode.left.parent = newNode;
                    }
                }
                if (newNode is not null)
                    newNode.parent = node.parent;

                Node bufParent = newNode;
                while (bufParent is not null)
                {
                    bufParent.size = 1;
                    if(bufParent.right is not null) bufParent.size += bufParent.right.size;
                    if (bufParent.left is not null) bufParent.size += bufParent.left.size;
                    bufParent = bufParent.parent;
                }
                
            }
            if (node.pokemon.Name != root.pokemon.Name)
            {
                if (node.parent.right.pokemon.Name == node.pokemon.Name)
                {
                    node.parent.right = newNode;
                }
                else
                {
                    node.parent.left = newNode;
                }
            }
            else
            {
                root = newNode;
            }

            return node.pokemon;
        }

        public void Balance()
        {
            List<Node> nodes = new List<Node>();
            Balance(root);
        }

        private Node[] GetTreeInWidth()
        {
            if (root is null)
                throw new Exception("Дерево пусто");

            Node[] array = new Node[root.size];

            array[0] = root;
            int parent = 0;
            for (int i = 1; i < root.size;)
            {
                if(array[parent].left is not null)
                {
                    array[i] = array[parent].left;
                    i++;
                }
                if (array[parent].right is not null)
                {
                    array[i] = array[parent].right;
                    i++;
                }
                parent++;
            }
            return array;
        }

        public string ToString(bool inWidth)
        {
            if (root is null)
                throw new Exception("Дерево пусто");

            Node[] nodes;

            if(inWidth) nodes = GetTreeInWidth();
            else nodes = GetTreeInDepth();

            string pokemons = "";

            foreach(Node node in nodes)
            {
                if(node is not null) pokemons += node.ToString() + " ";
            }

            return pokemons;
        }

        private Node[] GetTreeInDepth()
        {
            Debug.WriteLine(root.size);
            Node[] nodes = new Node[root.size];
            int i = 0;
            GetTreeInDepth(root,nodes, ref i);

            return nodes;
        }

        private void GetTreeInDepth(Node parent, Node[] array, ref int i)
        {
            if (parent is null) return;

            GetTreeInDepth(parent.left, array, ref i);
            GetTreeInDepth(parent.right, array, ref i);

            array[i++] = parent;
        }

        private void Balance(Node mainNode)
        {
            if (mainNode is null || mainNode.size < 3)
                return;

            Node? newMainNode = null;
            while (!(mainNode.right is null && mainNode.left is null) && ((mainNode.left is not null && mainNode.right is null) || (mainNode.left is null && mainNode.right is not null) || Math.Abs(mainNode.left.size - mainNode.right.size) > 1))
            {
                if (mainNode.right is null && mainNode.left is not null || (mainNode.right is not null && mainNode.left is not null && mainNode.left.size - mainNode.right.size > 1))
                {
                    newMainNode = mainNode.left;

                    while (newMainNode.right is not null)
                    {
                        newMainNode = newMainNode.right;
                    }

                    if (newMainNode.pokemon.Name != mainNode.left.pokemon.Name)
                    {
                        if (newMainNode.parent.right.pokemon.Name == newMainNode.pokemon.Name)
                        {
                            if (newMainNode.left is not null)
                            {
                                newMainNode.parent.right = newMainNode.left;
                                newMainNode.left.parent = newMainNode.parent;
                            }
                            else
                            {
                                newMainNode.parent.right = null;
                            }
                        }
                        else
                        {
                            if (newMainNode.left is not null)
                            {
                                newMainNode.parent.left = newMainNode.right;
                                newMainNode.left.parent = newMainNode.parent;
                            }
                            else
                            {
                                newMainNode.parent.left = null;
                            }
                        }
                        newMainNode.left = mainNode.left;
                    }
                    newMainNode.right = mainNode;
                    if (newMainNode.right is not null)
                        newMainNode.right.parent = newMainNode;
                    if (newMainNode.left is not null)
                        newMainNode.left.parent = newMainNode;
                    mainNode.left = null;
                }
                else if (mainNode.left is null && mainNode.right is not null || (mainNode.right is not null && mainNode.left is not null && mainNode.right.size - mainNode.left.size > 1))
                {
                    newMainNode = mainNode.right;

                    while (newMainNode.left is not null)
                    {
                        newMainNode = newMainNode.left;
                    }

                    if (newMainNode.pokemon.Name != mainNode.right.pokemon.Name)
                    {
                        if (newMainNode.parent.left.pokemon.Name == newMainNode.pokemon.Name)
                        {
                            if (newMainNode.right is not null)
                            {
                                newMainNode.parent.left = newMainNode.right;
                                newMainNode.right.parent = newMainNode.parent;
                            }
                            else
                            {
                                newMainNode.parent.left = null;
                            }
                        }
                        else
                        {
                            if (newMainNode.right is not null)
                            {
                                newMainNode.parent.right = newMainNode.left;
                                newMainNode.right.parent = newMainNode.parent;
                            }
                            else
                            {
                                newMainNode.parent.right = null;
                            }
                        }
                        newMainNode.right = mainNode.right;
                    }
                    
                    newMainNode.left = mainNode;
                    if (newMainNode.right is not null)
                        newMainNode.right.parent = newMainNode;
                    if (newMainNode.left is not null)
                        newMainNode.left.parent = newMainNode;
                    mainNode.right = null;
                }

                if (root.pokemon.Name == mainNode.pokemon.Name) 
                { 
                    root = newMainNode;
                    newMainNode.parent = null;
                }
                else
                {
                    newMainNode.parent = mainNode.parent;
                }
                mainNode.size = (mainNode.right is null ? 0 : mainNode.right.size) + (mainNode.left is null ? 0 : mainNode.left.size) + 1;
                newMainNode.size = (newMainNode.right is null ? 0 : newMainNode.right.size) + (newMainNode.left is null ? 0 : newMainNode.left.size) + 1;
                mainNode = newMainNode;
            }
            
            if (mainNode is null) return;
            Balance(mainNode.right);
            Balance(mainNode.left);
        }
    }
}