namespace StackTask;

public class CardStack
{
    private Stack<Card> stack;


    public int Size
    {
        get
        {
            return stack.Count;
        }
    }

    public CardStack()
    {
        stack = new Stack<Card>();
    }

    public void Push(Card card)
    {
        if (stack.Count > 100)
            throw new InvalidOperationException("Stack is full");

        Stack<Card> tempStack = new Stack<Card>();

        while (stack.Count > 0 && stack.Peek().Prior < card.Prior)
        {
            tempStack.Push(stack.Pop());
        }

        stack.Push(card);

        while (tempStack.Count > 0)
        {
            stack.Push(tempStack.Pop());
        }
    }

    public Card Top()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return stack.Peek();
    }

    public Card Pop()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return stack.Pop();
    }

    public bool IsReadyForGame()
    {
        return stack.Count >= 30;
    }

    public void Shuffle()
    {
        List<Card> cards = new List<Card>(stack);
        Random random = new Random();

        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }

        stack = new Stack<Card>(cards);
    }
}