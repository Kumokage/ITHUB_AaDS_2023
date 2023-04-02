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
            if (_size >= 100)
            {
                throw new System.Exception("Deck is full");
            }

            Node new_card = new(card, null);

            if (_top is Node top)
            {
                Node? buff = top;
                Node? buffprev = null;

                while (buff != null && card.Prior > buff.value.Prior)
                {
                    buffprev = buff;
                    buff = buff.prev;
                }
                if (buffprev != null)
                {
                    buffprev.prev = new_card;
                    new_card.prev = buff;
                }
                else
                {
                    new_card.prev = buff;
                    _top = new_card;
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
                throw new Exception("Empty deck");
            }
        }

        public Card Pop()
        {
            if (_top is Node top)
            {
                Card buff = _top.value;
                if(top.prev != 0)
                {
                    _top = top.prev;
                }
                else
                {
                    _top = null;
                }
                --_size;
                return buff;
            }
            else
            {
                throw new Exception("Empty deck");
            }
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
