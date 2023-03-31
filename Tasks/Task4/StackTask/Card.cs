namespace StackTask
{
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
        private CardElement elem;
        private CardType type;
        private string text;
        private int prior;

        public Card(CardElement elem, CardType type, string text, int prior)
        {
            this.elem = elem;
            this.type = type;
            this.text = text;
            this.prior = prior;
        }

        public CardElement Element
        {
            get => elem;
        }

        public CardType Type
        {
            get => type;
        }

        public string Text
        {
            get => text;
        }

        public int Prior
        {
            get => prior;
        }

        public override string ToString()
        {
            return $"\t\n {elem} \n\t {type} \n {text} \n";
        }
    }
}