using System.Collections.Generic;

namespace MTGCollection
{
    public struct KeyValuePair
    {
        public string key;
        public Card value;

        public KeyValuePair(string key, Card value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class Node
    {
        public Node? next;
        public KeyValuePair value;

        public Node(Node node, KeyValuePair pair)
        {
            next = node;
            value = pair;
        }
    }

    public class CardCollection
    {

        private int count;
        private Node[] _collection = new Node[5];

        public CardCollection()
        {
            count = 0;
        }

        public int Count => count;

        public Card this[string key]
        {
            get
            {
                int hash = Math.Abs(key.GetHashCode() % _collection.Length);
                Node node = _collection[hash];

                while (node is not null) 
                {
                    if (node.value.key == key)
                    {
                        return node.value.value;
                    }

                    node = node.next;
                }
                throw new Exception("No such key");
            }
            set
            {
                Add(key, value);
            }
        }

        public string[] Keys
        {
            get
            {
                string[] keysArray = new string[count];
                int arrayIndex = 0;

                for (int i = 0; i < count; ++i)
                {
                    Node node = _collection[i];

                    while (node is not null)
                    {
                        keysArray[arrayIndex] = node.value.key;
                        ++arrayIndex;

                        node = node.next;
                    }
                }

                return keysArray;
            }
        }

        public Card[] Values
        {
            get
            {
                Card[] valueArray = new Card[count];
                int arrayIndex = 0;

                for (int i = 0; i < count; ++i)
                {
                    Node node = _collection[i];

                    while (node is not null)
                    {
                        valueArray[arrayIndex] = node.value.value;
                        ++arrayIndex;

                        node = node.next;
                    }
                }

                return valueArray;
            }
        }

        public void Add(string key, Card value)
        {
            int hash = Math.Abs(key.GetHashCode() % _collection.Length);

            if (_collection[hash] is not null)
            {

                Node node = _collection[hash];

                while (node is not null)
                {
                    if (node.value.key == key)
                    {
                        node.value.value = value;
                        return;
                    }
                    node = node.next;
                }

                _collection[hash] = new Node(_collection[hash], new KeyValuePair(key, value));
            }
            else
            {
                _collection[hash] = new Node(null, new KeyValuePair(key, value));
            }
            count++;
        }

        public void Clear()
        {
            for(int i = 0; i < _collection.Length; ++i)
            {
                _collection[i] = null;
            }
        }

        public void Remove(string key)
        {
            int hash = Math.Abs(key.GetHashCode() % _collection.Length);
            Node node = _collection[hash];
            Node nodeprev = null;
            while (node is not null)
            {
                if (node.value.key == key)
                {
                    if (nodeprev is not null) nodeprev.next = node.next;
                    else _collection[hash] = null;

                    count--;
                    return;
                }

                if (nodeprev is null) nodeprev = node;
                else nodeprev = nodeprev.next;

                node = node.next;
            }
            throw new Exception("No such key");
        }

        public void Remove(string key, Card value)
        {
            int hash = Math.Abs(key.GetHashCode() % _collection.Length);
            Node node = _collection[hash];

            while (node is not null)
            {
                if (node.value.key == key)
                {
                    node.value.value = value;
                    count--;
                    return;
                }

                node = node.next;
            }
            throw new Exception("No such key");
        }
    }
}