using System.Collections.Generic;
namespace KT4
{
    class Stack
    {
        class Card
        {
            public int value;
            public Card? prev;

            public Card(int value, Card? prev)
            {
                this.value = value;
                this.prev = prev;
            }
        }

        // bool? test -> true, false, null
        // Console.WriteLine(test ?? false);
        // bool? is Nullable<bool>
        // test.HasValue() -> if not null true, else false
        // int? a = 42;
        // if (a is int valueOfA)
        // {
        //     Console.WriteLine($"a is {valueOfA}");
        // }
        // else
        // {
        //     Console.WriteLine("a does not have a value");
        // }
        // Output:
        // a is 42
        private Card? top;
        private int size;

        public Stack()
        {
            top = null;
            size = 0;
        }

        public Stack(IEnumerable<int> collection)
        {
            foreach (int buf in collection)
            {
                Push(buf);
            }
        }

        public void Push(int value)
        {
            if (size < 100)
            {
                top = new Card(value, top);
                ++size;
            }
        }

        public int Top()
        {
            // return top.value;
            if (top is Card node)
            {
                return node.value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Pop()
        {
            if (top is null)
            {
                throw new System.Exception("Empty stack");
            }

            int buf = top.value;
            top = top.prev;
            --size;
            return buf;
        }

        public bool Empty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            Card? buf = top;
            string result = "";
            while (buf != null)
            {
                result += $"{buf.value}\n";
                buf = buf.prev;
            }
            return result;
        }
        public bool IsReadyForGame()
        {
            if (size > 30)
            {
                return true;
            }
            else
            {
                return false;
            }
           // throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
        public int Length()
        {
            return size = size;
        }

    }
}