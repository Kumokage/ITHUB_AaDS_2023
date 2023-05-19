namespace PokemonGame;

public class PokemonTree
{
    public class Node
    {
        public Node? Left;//<
        public Node? Right;//>
        public Pokemon pokemon;
        public Node? Parent;
        public int size;
        public Node(Node left, Node right, Pokemon pokemon)
        {
            this.Left = left;
            this.Right = right;
            this.pokemon = pokemon;
            this.size = 1;
        }

    }
    Node? root;
    public int Size
    {
        get => root.size;
    }

    public void Add(Pokemon pokemon)
    {
        Node testednode = new Node(null, null, pokemon);
        if (root is null)
        {
            root = testednode;
            return;
        }
        int compval = root.pokemon.Name.CompareTo(testednode.pokemon.Name);
        if (compval > 0)
        {
            ++root.size;
            if (root.Right is null)
            {
                root.Right = testednode;

            }
            else
            {
                Node subjectnode = root.Right;
                NodeAdd(subjectnode, testednode);
            }
        }
        else
        {
            ++root.size;
            if (root.Left is null)
            {
                root.Left = testednode;
                testednode.Parent = root;
            }
            else
            {
                Node subjectnode = root.Left;
                NodeAdd(subjectnode, testednode);
            }
        }
    }
    public void NodeAdd(Node main, Node addednode)
    {
        ++main.size;
        int compval = main.pokemon.Name.CompareTo(addednode.pokemon.Name);
        if (compval > 0)
        {
            if (main.Right is null)
            {
                main.Right = addednode;
                addednode.Parent = main;
                return;
            }
            NodeAdd(main.Right, addednode);
        }
        else
        {
            if (main.Left is null)
            {
                main.Left = addednode;
                addednode.Parent = main;
                return;
            }
            NodeAdd(main.Left, addednode);
        }
    }
    public Pokemon Search(string Name)
    {
        return (SearchNode(root, Name));
    }
    public Pokemon SearchNode(Node main, string Name)
    {
        if (main is null)
        {
            throw new ArgumentException("No Pokemon with such name");
        }
        int compval = main.pokemon.Name.CompareTo(Name);
        if (compval == 0)
        {
            return (main.pokemon);
        }
        else if (compval > 0)
        {
            return SearchNode(main.Right, Name);
        }
        else
        {
            return SearchNode(main.Left, Name);
        }
    }
    public Pokemon Delete(string Name)
    {
        Node _deletable = SearchDelete(root, Name);
        Node searchable = null;
        if (_deletable.Left == null)
        {
            searchable = _deletable.Right;
            while (searchable.Right != null)
            {
                searchable = searchable.Right;
            }
            searchable.Parent.Right = null;
        }
        else if (_deletable.Right == null)
        {
            searchable = _deletable.Left;
            while (searchable.Left != null)
            {
                searchable = searchable.Left;
            }
            searchable.Parent.Left = null;
        }
        else if (_deletable.Right.size < _deletable.Left.size)
        {
            searchable = _deletable.Left;
            while (searchable.Left != null)
            {
                searchable = searchable.Left;
            }
            searchable.Parent.Left = null;
        }
        else
        {
            searchable = _deletable.Right;
            while (searchable.Right != null)
            {
                searchable = searchable.Right;
            }
            searchable.Parent.Right = null;
        }
        if (_deletable.Parent == null)
        {
            Node buff = _deletable;
            _deletable = searchable;
            return (buff.pokemon);
        }
        int compval = _deletable.pokemon.Name.CompareTo(_deletable.Parent.pokemon.Name);
        if (compval > 0)
        {
            _deletable.Parent.Left = searchable;
            return (_deletable.pokemon);
        }
        else
        {
            _deletable.Parent.Right = searchable;
            return (_deletable.pokemon);
        }
    }
    public Node SearchDelete(Node main, string Name)
    {
        --main.size;
        if (main is null)
        {
            throw new ArgumentException("No Pokemon with such name");
        }
        int compval = main.pokemon.Name.CompareTo(Name);
        if (compval == 0)
        {
            return (main);
        }
        else if (compval > 0)
        {
            return SearchDelete(main.Right, Name);
        }
        else
        {
            return SearchDelete(main.Left, Name);
        }
    }
    public override string ToString()
    {
        Pokemon[] buf = new Pokemon[root.size * 2];
        Pokemon[] truebuf = new Pokemon[root.size];
        buf[0] = root.pokemon;
        buf[1] = root.Left.pokemon;
        buf[2] = root.Right.pokemon;
        Node bufLeft = root.Left;
        Node bufRight = root.Right;
        SearchWidth(bufLeft, 2, buf);
        SearchWidth(bufRight, 3, buf);
        string textbuf = "";
        int count = 0;
        for (int i = 0; i < buf.Length; i++)
        {
            if (buf[i] != null)
            {
                truebuf[count] = buf[i];
                ++count;
            }
        }
        foreach (var item in truebuf)
        {
            textbuf += $"{item.Name} ";
        }
        return textbuf;
    }
    public void SearchWidth(Node check, int index, Pokemon[] buf)
    {
        if (check.Left != null && check.Right == null)
        {
            buf[index * 2] = check.Left.pokemon;
            SearchWidth(check.Left, index * 2, buf);
        }
        else if (check.Left == null && check.Right != null)
        {
            buf[index * 2 + 1] = check.Right.pokemon;
            SearchWidth(check.Right, index * 2 + 1, buf);
        }
        else if(check.Left == null && check.Right == null){
            return;
        }
        else{
            buf[index * 2] = check.Left.pokemon;
            SearchWidth(check.Left, index * 2, buf);
            buf[index * 2 + 1] = check.Right.pokemon;
            SearchWidth(check.Right, index * 2 + 1, buf);
        }
        return;

    }
}


