namespace StackTask;

public enum CardElement
{
    Water,
    Fire,
    Earth,
    Air,
    Light,
    Darkness
}

public enum CardType
{
    Creature,
    Spell,
    InstantSpell,
    Territory
}

public class Card
{
    private CardElement element;
    private CardType type;

    public Card(CardElement element, CardType type, string text, int prior)
    {
        this.element = element;
        this.type = type;
        Text = text;
        Prior = prior;
    }

    public CardElement Element
    {
        get
        {
            return element;
        }
    }

    public CardType Type
    {
        get
        {
            return type;
        }
    }

    public string Text
    {
        get;
    }

    public int Prior
    {
        get;
    }
}