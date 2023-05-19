using System.Diagnostics;
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
                if(node.pokemon.Name.CompareTo(parent.pokemon.Name) > 0)
                {
                    if (parent.left == null)
                    {
                        parent.left = node;
                        node.parent = parent;
                        return;
                    }
                    parent = parent.left;
                }
                else if(node.pokemon.Name.CompareTo(parent.pokemon.Name) < 0)
                {
                    if (parent.right == null)
                    {
                        parent.right = node;
                        node.parent = parent;
                        return;
                    }
                    parent = parent.right;
                }
                else
                {
                    throw new Exception("Покемон с этим именем уже есть в дереве");
                }
                Node bufParent = node;
                while (bufParent is not null)
                {
                    bufParent.size = 1;
                    if (bufParent.right is not null) bufParent.size += bufParent.right.size;
                    if (bufParent.left is not null) bufParent.size += bufParent.left.size;
                    bufParent = bufParent.parent;
                }
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
            Balance(root);
        }

        private void Balance(Node mainNode)
        {
            if (mainNode is null || mainNode.size < 3)
                return;

            Node? newNode = null;

            while (mainNode.right is null || mainNode.left is null || Math.Abs(mainNode.left.size - mainNode.right.size) > 1)
            {
                if (mainNode.right is null || mainNode.left.size > mainNode.right.size)
                {

                    newNode = mainNode.left;
                    while (newNode.right is not null)
                    {
                        newNode = newNode.right;
                    }

                    newNode.right = mainNode;
                    newNode.left = mainNode.left;
                    mainNode.left = null;
                }
                else if (mainNode.left is null || mainNode.left.size < mainNode.right.size)
                {
                    newNode = mainNode.right;
                    while (newNode.right is not null)
                    {
                        newNode = newNode.left;
                    }

                    newNode.right = mainNode.right;
                    newNode.left = mainNode;
                    mainNode.right = null;
                }

                if (root.pokemon.Name != newNode.pokemon.Name) 
                { 
                    root = newNode;
                    newNode.parent = null;
                }
                else
                {
                    newNode.parent = mainNode.parent;
                }

                mainNode.size = mainNode.right.size + mainNode.left.size + 1;

                Node bufParent = newNode;
                while (bufParent is not null)
                {
                    bufParent.size = 1;
                    if (bufParent.right is not null) bufParent.size += bufParent.right.size;
                    if (bufParent.left is not null) bufParent.size += bufParent.left.size;
                    bufParent = bufParent.parent;
                }
            }
            Balance(newNode.right);
            Balance(newNode.left);
        }
    }
}