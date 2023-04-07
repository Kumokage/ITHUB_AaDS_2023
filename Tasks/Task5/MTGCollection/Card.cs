namespace MTGCollection;
public enum Color
{
    B,
    G,
    R,
    W,
    U
}
public enum Rarity
{
    Bonus,
    Common,
    Mythic,
    Rare,
    Special,
    Uncommon
}
public enum Types
{
    Creature,
    Instant,
    Sorcery,
    Enchantment,
    Land,
    PlanesWalker,
    Artifact
}
public class Card
{
    private int _id;
    private Color[] _colors = new Color[Enum.GetNames(typeof(Color)).Length];
    private string _manaCost;
    private string _name;
    private int _number;
    private string _originalText;
    private int _power;
    private Rarity _rarity;
    private string _subtypes;
    private string _text;
    private Types[] _types;

    public Card(int id, Color[] colors, string manaCost, string name, int number, string originalText, int power, Rarity rarity, string subtypes, string text, Types[] types)
    {
        _id = id;
        _colors = colors;
        _manaCost = manaCost;
        _name = name;
        _number = number;
        _originalText = originalText;
        _power = power;
        _rarity = rarity;
        _subtypes = subtypes;
        _text = text;
    }

    public int Id
    {
        get => _id; 
    }
    public Color[] Colors
    {
        get => _colors;
    }
    public string ManaCost
    {
        get => _manaCost;
    }
    public string Name
    {
        get => _name;
    }
    public int Number
    {
        get => _number;
    }
    public string OriginalText
    {
        get => _originalText;
    }
    public int Power
    {
        get => _power;
    }
    public Rarity Rarity
    {
        get => _rarity;
    }
    public string Subtypes
    {
        get => _subtypes;
    }
    public string Text
    {
        get => _text;
    }
    public Types[] Types
    {
        get => _types;
    }

    public override string ToString() 
    {
        return $"\t\n {_name}";
    }
}
