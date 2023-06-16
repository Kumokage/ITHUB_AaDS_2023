namespace StackTask;

public enum CardElement
{

}

public enum CardType
{

}

public class Card
{
    CardElement element;
    CardType type;

    public Card(CardElement elem, CardType type, string text, int prior)
    {

    }

    public CardElement Element
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public CardType Type
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public string Text
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int Prior
    {
        get
        {
            throw new NotImplementedException();
        }
    }
}