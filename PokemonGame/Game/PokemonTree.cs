using System;
namespace PokemonGame;


public class PokemonTree
{
    public class Node
    {
        public Pokemon pokemon;
        public Node? left;
        public Node? right;
        public Node? parent;
        public string value;
        public Node(Pokemon pokemonchik, Node? left, Node? right, Node? parent)
        {
            this.pokemon = pokemonchik;
            this.left = left;
            this.right = right;
            this.parent = parent;
            this.value = pokemonchik.Name;
        }
    }
    Node? _root;
    int _sizik;

    public PokemonTree()
    {

    }
    public void Add(Pokemon pokemon)
    {

        if (_root == null)
        {
            _root = new Node(pokemon,null,null,null);
        }
        else
        {
            Node buff = _root;
            while (buff.right!=null&&buff.left!=null)
            {
                if(buff.value.CompareTo(pokemon.Name)==1)
                {
                    buff.right = buff;
                }
                else if(buff.value.CompareTo(pokemon.Name) == -1)
                {
                    buff.left = buff;
                }
                else
                {
                    throw new ArgumentException("такой покемончи уже есть");
                }
            }
            if (pokemon.Name.CompareTo(buff.value) == 1)
            {
                buff.right = new Node(pokemon, null, null,buff);
            }
            else
            {
                buff.left = new Node(pokemon, null, null,buff);
            }
        }
        ++_sizik;
    }
    public Pokemon Search(string name)
    {
        if(_root is not null)
        {
            Node buff = _root;
            while (buff.right != null && buff.left != null)
            {
                if (buff.value.CompareTo(name) == 1)
                {
                    buff.right = buff;
                }
                else if (buff.value.CompareTo(name) == -1)
                {
                    buff.left = buff;
                }
                else if(buff.value.CompareTo(name) == 0)
                {
                    return buff.pokemon;
                }
            }
        }
        throw new ArgumentException("покемончи не нашёуся");
    }
    public Pokemon Delete(string name)
    {
        if (_root is not null)
        {
            Node buff = _root;
            while (buff.right != null && buff.left != null)
            {
                if (buff.value.CompareTo(name) == 1)
                {
                    buff.right = buff;
                }
                else if (buff.value.CompareTo(name) == -1)
                {
                    buff.left = buff;
                }
                else if (buff.value.CompareTo(name) == 0)
                {
                    if (buff.parent != null && buff.parent.right == buff)
                    {
                        buff.parent.right = buff.left;
                        buff.left.parent = buff.parent;
                        buff.left.right = buff.right;
                    }
                    else if(buff.parent != null && buff.parent.left == buff)
                    {
                        buff.parent.left = buff.left;
                        buff.left.parent = buff.parent;
                        buff.left.right = buff.right;
                    }
                    return buff.pokemon;
                }
            }
        }
        throw new ArgumentException("покемончи не нашёуся");
    }
    public void Balance()
    {

    }
    public int Size
    {
        get { return _sizik; }
    }
}
