using System.Drawing;
using System.Xml.Linq;

namespace StackTask;

public class CardStack
{
    private Card? top;
    private Card? prev;

    private int size;

    public int Size
    {
        get
        {
            return size;
        }

    }

    public void Push(Card card)
    {
        if (size > 100)
        {
            throw new InvalidOperationException(message: "Already full stack");
        }
        else
        {
            top = card;


            ++size;

        }
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
        if (top is null)
        {
            throw new System.Exception("Empty stack");
        }

        Card buf = top;
        top = prev;

        --size;
        return buf;
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
    }

    public void Shuffle()
    {
        throw new NotImplementedException();
    }
}
