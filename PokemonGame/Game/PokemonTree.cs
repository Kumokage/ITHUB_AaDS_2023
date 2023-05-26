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

    public void Add(Pokemon pokemon)
    {
       if (_root == null)
       {
           _root = new Node(pokemon, null, null, null);
       }
       else
       {
            Node buff = _root;
            bool flag = true;
            while (flag)
            {
                if(String.Compare(buff.value,pokemon.Name)>0)
                {
                    if(buff.left!=null)
                    {
                        buff = buff.left;
                    }
                    else
                    {
                        buff.left = new Node(pokemon, null, null, buff);
                        flag = false;
                    }
                }
                else if(String.Compare(buff.value, pokemon.Name) < 0)
                {
                    if(buff.right!=null)
                    {
                        buff = buff.right;
                    }
                    else
                    {
                        buff.right = new Node(pokemon, null, null, buff);
                        flag = false;
                    }
                }
                else
                {
                    throw new ArgumentException("такой покемон уже есть");
                }
            }
        ++_sizik;
       }
    }
    public Pokemon Search(string name)
    {
       
        if (_root is null)
        {
            throw new ArgumentException("нет покемонов");
        }
        else
        {
            Node buff = _root;
            bool flag = true;
            while (flag)
            {
                if (String.Compare(buff.value, name) > 0)
                {
                    if (buff.left != null)
                    {
                        buff = buff.left;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if (String.Compare(buff.value, name) < 0)
                {
                    if (buff.right != null)
                    {
                        buff = buff.right;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if(String.Compare(buff.value, name) == 0)
                {
                    return buff.pokemon;
                }
            }
            throw new ArgumentException("покемон не нашелся");
        }
    }       
    
    public Pokemon Delete(string name)
    {
       if (_root is null)
        {
            throw new ArgumentException("нет покемонов");
        }
        else
        {
            Pokemon poki;
            Node buff = _root;
            Node? buff2;
            bool flag = true;
            while (flag)
            {
                if (String.Compare(buff.value, name) > 0)
                {
                    if (buff.left != null)
                    {
                        buff = buff.left;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if (String.Compare(buff.value, name) < 0)
                {
                    if (buff.right != null)
                    {
                        buff = buff.right;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if(String.Compare(buff.value, name) == 0)
                {
                    poki = buff.pokemon;
                    if(buff.parent == null)
                    {
                        _root = null;
                    }
                    else
                    {
                     if(buff.right!= null&& buff.left==null)
                    {
                        buff.value = buff.right.value;
                            buff.pokemon = buff.right.pokemon;
                            buff.right = buff.right.right;
                    }
                    if(buff.right== null&& buff.left!=null)
                    {
                        buff.value = buff.left.value;
                            buff.pokemon = buff.left.pokemon;
                            buff.left = buff.left.left;
                    }
                    if(buff.right == null&& buff.left == null)
                    {
                        if(buff.parent.right == buff)
                        {
                           buff.parent.right = null;
                           return buff.pokemon;     
                        }
                        else if(buff.parent.left == buff)
                        {
                            buff.parent.left = null;
                            return buff.pokemon;
                        }
                    }
                    if(buff.right!= null&& buff.left!=null)
                    {
                        buff2 = buff.right;
                        while(buff2.left != null)
                        {
                            buff2 = buff2.left;
                        }
                        buff.pokemon = buff2.pokemon;
                        if(buff2 == buff2.parent.left)
                        {
                            buff2.parent.left = null;
                        }
                        else if(buff2 == buff2.parent.right)
                        {
                            buff2.parent.right = null;
                        }
                    }
                    return poki;
                    }
                }
            }
            throw new ArgumentException("покемон не нашелся");
        }
    }
    public void Balance()
    {
        throw new NotImplementedException();
    }
    public int Size
    {
        get { return _sizik; }
    }
}
