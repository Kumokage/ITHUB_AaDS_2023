using System.Diagnostics;

namespace StackTask;

public enum Element
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
    Element element;
    CardType cardType;
    public string Text
    {
        get => text;



    }

    public int Prior
    {
        get => prior;
    }

    public Element elem
    {
        get { return element; }
    }
    public CardType type
    {
        get => cardType;
    }
    public Card(Element elem, CardType type, string text, int prior)
    {
        this.text = text;
        this.prior = prior;
        this.element = elem;
        this.cardType = type;



    }

    public override string ToString()
    {
        return $"\t\n {element} \n\t {type} \n {text} \n";
    }



}