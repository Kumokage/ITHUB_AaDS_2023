using System.Collections;

namespace LessonDict;

public class Message
{
    private readonly string _text;

    private readonly string _author;

    public Message(string text, string author)
    {
        _text = text;
        _author = author;
    }

    public override string ToString()
    {
        return $"{_text} \n\t {_author}";
    }
}

public class Dict
{

    const int SIZE = 2;
    struct KeyValuePair
    {
        public string key;
        public Message value;

        public KeyValuePair(string key, Message value)
        {
            this.key = key;
            this.value = value;
        }
    }

    private List<KeyValuePair>[] _container = new List<KeyValuePair>[SIZE];

    public void Add(string key, Message value)
    {
        int hash = Math.Abs(key.GetHashCode() % SIZE);
        // Check if list exist
        Console.WriteLine(hash);
        _container[hash] ??= new List<KeyValuePair>();
        // Check if key exist
        for (int i = 0; i < _container[hash].Count; ++i)
        {
            var item = _container[hash][i];
            if (item.key == key)
            {
                // Update value
                item.value = value;
                return;
            }
        }
        // Create new element hashtable
        _container[hash].Add(new KeyValuePair(key, value));
    }

    public void Remove(string key)
    {
        int hash = Math.Abs(key.GetHashCode() % SIZE);
        for (int i = 0; i < _container[hash].Count; ++i)
        {
            var item = _container[hash][i];
            if (item.key == key)
            {
                _container[hash].RemoveAt(i);
                return;
            }
        }
        throw new Exception("No such key");
    }

    public bool Contain(string key)
    {
        int hash = Math.Abs(key.GetHashCode() % SIZE);
        for (int i = 0; i < _container[hash].Count; ++i)
        {
            var item = _container[hash][i];
            if (item.key == key)
            {
                return true;
            }
        }
        return false;
    }

    public Message this[string key]
    {
        get
        {
            int hash = Math.Abs(key.GetHashCode() % SIZE);
            foreach (var item in _container[hash])
            {
                if (item.key == key)
                {
                    return item.value;
                }
            }
            throw new Exception("No such Key");
        }
        set
        {
            Add(key, value);
        }
    }

    public override string ToString()
    {
        string buf = "";
        foreach (var list in _container)
        {
            foreach (var item in list)
            {
                buf += $"{item.key} ";
            }

            if (list.Count != 0)
            {
                buf += "\n";
            }
        }
        return buf;
    }
}