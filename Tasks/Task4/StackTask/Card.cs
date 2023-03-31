using System.Diagnostics;

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
    private string text;
    private int prior;
    private CardElement element;
    private CardType cardType;
    public string Text
    {
        get => text;


    }

    public int Prior
    {
        get => prior;
    }

    public CardElement elem
    {
        get => element;
    }
    public CardType type
    {
        get => cardType;
    }
    public Card(CardElement elem, CardType type, string text, int prior)
    {
        this.text = text;
        this.prior = prior;
        this.element = elem;
        cardType = type;



    }

    public override string ToString()
    {
        return $"\t\n {element} \n\t {type} \n {text} \n";
    }



}