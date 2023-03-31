namespace StackTask;

public enum CardElement
{
    water,
    fire,
    earth,
    air,
    light,
    darkness
}


public enum CardType
{
    creature,
    spell,
    instantSpell,
    territory
}

public class Card
{

    CardType type ;
    CardElement elemnt;
    int prior;


    public Card(CardElement elem, CardType type, string text, int prior)
    {
       this.type = type;
        this.elemnt = elem;
        this.prior = prior;
    }

    public override string ToString()
    {
        string boof = ("type: " +this.type);
        Console.WriteLine(boof);
        string booftwo = ("element: " + this.elemnt);
        Console.WriteLine(booftwo);
        string boofThree = ("prior: " + this.prior);
        Console.WriteLine(boofThree);
        return "End";
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