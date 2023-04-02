using System.Diagnostics;
using System;

namespace StackTask
{


    public class CardStack
    {
        class Node
        {
            public Card value;
            public Node? prev;


            public Node(Card value, Node? prev)
            {
                this.value = value;
                this.prev = prev;

            }
        }
        private Node? _top;
        private int _size;

        public int Size
        {
            get
            {
                return _size;
            }
        }
        public CardStack()
        {
            _top = null;
            _size = 0;
        }

        public CardStack(IEnumerable<Card> collection)
        {
            foreach (Card buf in collection)
            {
                Push(buf);
            }
        }

        public void Push(Card card)
        {
            Node new_card = new(card, null);
            if (_top is Node top)
            {
                Node? buff = top;
                if (_size > 99)
                {
                    throw new System.Exception("Deck is full");
                }
                else
                {
                    if (card.Prior < buff.value.Prior)
                    {
                        new_card.prev = _top;
                        _top = new_card;
                    }
                    else
                    {
                        while (buff != null && buff.value.Prior <= card.Prior)
                        {
                            buff = buff.prev;
                        }
                        if (buff != null)
                        {
                            new_card.prev = buff;
                        }
                        else
                        {
                            buff.prev = new_card;
                        }
                    }
                }
            }
            else
            {
                _top = new_card;
            }

            ++_size;
        }

        public Card Top()
        {
            if (_top is Node node)
            {
                return node.value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Card Pop()
        {
            if (_top is null)
            {
                throw new System.Exception("Empty deck");
            }
            Card buf = _top.value;
            _top = _top.prev;
            --_size;
            return buf;
        }

        public bool IsReadyForGame()
        {
            if (_size >= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}
