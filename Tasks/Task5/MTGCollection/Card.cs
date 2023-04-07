using System;

namespace MTGCollection
{
    public enum CardColor
    {
        White,
        Blue,
        Black,
        Red,
        Green
    }

    public enum CardRarity
    {
        Common,
        Uncommon,
        Rare,
        MythicalRare
    }

    public enum CardType
    {
        Creature,
        Instant,
        Enchantment,
        Sorcery,
        Land,
        PlanesWalker,
        Artifact
    }

    public class Card
    {
        public int id { get; }
        public CardColor[] color { get; } = new CardColor[Enum.GetNames(typeof(CardColor)).Length];
        public string manaCost { get; }
        public string name { get; }
        public int number { get; }
        public string originalText { get; }
        public int power { get; }
        public CardRarity rarity { get; }
        public string[] subtypes { get; }
        public string text { get; }
        public CardType[] type { get; } = new CardType[Enum.GetNames(typeof(CardType)).Length];

        

        public Card(int id, CardColor[] color, string manaCost, string name, int number, string originalText, int power, CardRarity rarity, string[] subtypes, string text, CardType[] type)
        {
            this.id = id;
            this.color = color;
            this.manaCost = manaCost;
            this.name = name;
            this.number = number;
            this.originalText = originalText;
            this.power = power;
            this.rarity = rarity;
            this.subtypes = subtypes;
            this.text = text;
            this.type = type;
        }

        public override string ToString()
        {
            return $"\n| {id} | {color} | {manaCost} | {name} | {number} | {originalText} | {power} | {rarity} | {subtypes} | {text} |";
        }
    }

}