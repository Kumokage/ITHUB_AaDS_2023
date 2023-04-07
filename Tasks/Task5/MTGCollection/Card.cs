namespace MTGCollection;
public class Card
{
   public int id;
   public int number;
   public int power;

    public string manaCost;
    public string name;
    public string originalText;
    public string text;

    public string outText;

    public CardColors[] colors = new CardColors[Enum.GetNames(typeof(CardColors)).Length];
    public CardRarity[] rarity = new CardRarity[Enum.GetNames(typeof(CardRarity)).Length];
    public CardSubtypes[] subtypes = new CardSubtypes[Enum.GetNames(typeof(CardRarity)).Length];



    public override string ToString()
    {
        return ("Name is: "+name);
    }
    public Card(int id,int number,int power,string manaCost,string name,string originalText,string text, CardColors[] colors, CardRarity[] rarity,CardSubtypes[] subtypes)
    {
        this.id = id; 
        this.number = number;
        this.power = power;
        this.manaCost = manaCost;
        this.name = name;
        this.originalText = originalText;
        this.text = text;
        this.colors = colors;
        this.rarity = rarity;
        this.subtypes = subtypes;

    }
    public int Id
    {
        get { return id; }
    }
    public int Number
    {
        get { return number; }
    }
    public int Power
    {
        get { return power; }
    }

    public string ManaCost
    {
        get { return manaCost; }
    }
    public string Name
    {
        get { return name; }
    }
    public string OriginalText
    {
        get { return originalText; }
    }
    public string Text
    {
        get { return text; }
    }
    public CardColors CardColors
    {
        get { return CardColors; }
    }
    public CardRarity[] Rarity
    {
        get { return rarity; }
    }
    public CardSubtypes[] Subtypes
    {
        get { return subtypes; } 
    }
}
public enum CardColors
{
    red,
    green,
    blue,
    white,
    black
}
public enum CardRarity
{
    common,
    rare,
    epic,
    legendary
}
public enum CardSubtypes
{
    creature,
    iustaut,
    sorce,
    equipment
}
