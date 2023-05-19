namespace StackTask;

public class CardStack
{
    class Node
    {
        public Card card;
        public Node? prev;
        public Node(Card card, Node? prev)
        {
            this.card = card;
            this.prev = prev;
        }
    }
    private int size;
    private Node? top;

    public int Size
    {
        get
        {
            return size;
        }
    }

    public void Push(Card card)
    {
        if (top is null)
        {
            top = new Node(card, null);
        }
        else if (size == 100)
        {
            throw new System.Exception("Deck overfilled");
        }
        else
        {
            Node new_node = new(Node, top);
            Node buf_node;
            while (new_node.prev.card.Prior < new_node.card.Prior)
            {
                buf_node = new_node.prev;
                new_node.prev = new_node.prev.prev;
                buf_node.prev = new_node;
            }
        }

        ++_size;
    }

    public Card Top()
    {
        if (top is Card card)
        {
            return card;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public Card Pop()
    {
        Node buf_node = top;
        top = top.prev;
        return buf_node;
    }

    public bool IsReadyForGame()
    {
        if (size >= 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Shuffle()
    {
        var rng = new Random();

        for (int i = 0; i < size - 1; ++i)
        {
            Node buf1 = top;
            Node buf2 = top;
            int gened = rng(i, size);
            for (int k = 0; k < i; ++k)
            {
                buf1 = buf1.prev;
            }
            for (int k = 0; k < gened - 1; ++k)
            {
                buf2 = buf2.prev;
            }
            if (buf1 == top)
            {
                Node buf3 = buf2;
                buf2.prev = buf1;
                top = buf3;
            }
            else{
                Node buf3 = buf2;
                buf2.prev = buf1;
                buf1.prev = buf3;
            }
        }
    }
}
