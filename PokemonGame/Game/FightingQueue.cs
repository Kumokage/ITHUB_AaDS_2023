namespace PokemonGame
{
    public class FightingQueue
    {
        class Node
        {
            public Node? next;
            public Node? prev;
            public Pokemon pokemon;

            public Node(Pokemon pokemon, Node? next, Node? prev)
            {
                this.pokemon = pokemon;
                this.next = next;
                this.prev = prev;
            }
        }

        Node? _head;
        Node? _tail;
        private int _size;

        public FightingQueue(IEnumerable<Pokemon> collection)
        {
            foreach (Pokemon pokemon in collection)
            {
                Push(pokemon);
            }
        }

        public FightingQueue()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public int Length => _size;

        public void Push(Pokemon pokemon)
        {
            Node new_node = new(pokemon, null, null);
            if (_tail is Node tail && _head is Node head)
            {
                Node? buf = tail;
                while (buf != null && buf.pokemon.Speed < pokemon.Speed)
                {
                    buf = buf.next;
                }

                if (buf is Node forward_node)
                {
                    new_node.next = forward_node;
                    new_node.prev = forward_node.prev;
                    if (forward_node.prev is not null)
                    {
                        forward_node.prev.next = new_node;
                    }
                    else
                    {
                        _tail = new_node;
                    }
                    forward_node.prev = new_node;
                }
                else
                {
                    new_node.prev = head;
                    head.next = new_node;
                    _head = new_node;
                }
            }
            else
            {
                _head = new_node;
                _tail = new_node;
            }

            ++_size;
        }

        public Pokemon Pop()
        {
            if (_head is Node head)
            {
                Pokemon buf = head.pokemon;
                if (head.prev is not null)
                {
                    head.prev.next = null;
                    _head = head.prev;
                }
                else
                {
                    _tail = null;
                    _head = null;
                }
                --_size;
                return buf;
            }
            else
            {
                throw new Exception("No pokemon left");
            }
        }

        public Pokemon Top()
        {
            if (_head is Node head)
            {
                return head.pokemon;
            }
            else
            {
                throw new Exception("No pokemon left");
            }
        }

        public Pokemon FindByName(string name)
        {
            if (_head is not null)
            {
                Node node = _head;

                while (node is not null)
                {
                    if (node.pokemon.Name == name && !node.pokemon.isDead)
                    {
                        return node.pokemon;
                    }
                    node = node.prev;
                }
            }

            throw new Exception("No such pokemon");
        }

        public override string ToString() 
        {
            string str = "";
            Node? node = _head;

            while (node is not null)
            {
                if (!node.pokemon.isDead)
                {
                    if(node.prev is not null) 
                        str += node.pokemon.Name + ",";
                    else
                        str += node.pokemon.Name;
                    node = node.prev;
                }
            }

            return str;
        }
    }
}