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
    private CardElement _cardElement;
    private CardType _cardType;
    private string _text;
    private int _prior;
    public Card(CardElement elem, CardType type, string text, int prior)
    {
        cardElement = elem;
        cardType = type;
        _text = text;
        _prior = prior;
    }
    public override string ToString() 
    {
        return $"\t\n {_cardElement} \n\t {_cardType} \n {_text} \n"
    }
    public int Prior
    {
        get { return _prior; }
    }
    public string Text
    {
        get { return _text; }
    }
    public CardElement Element
    {
        get { return _cardElement; }
    }
    public CardType Type
    {
        get { return _cardType; }
    }
}