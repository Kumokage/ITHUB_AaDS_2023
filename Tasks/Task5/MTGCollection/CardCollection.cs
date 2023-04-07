using System.Globalization;

namespace MTGCollection;
public class CardCollection
{
    class Node
        {
            public string key;
            public Card value;
            public Node? next;

            public Node(Card value, Node? next, string key)
            {
                this.value = value;
                this.next = next;
                this.key = key;
            }
        }

}