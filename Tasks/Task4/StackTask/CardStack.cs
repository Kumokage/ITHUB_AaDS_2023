using System.Diagnostics;
using System;

namespace StackTask
{
    public class CardStack
    {
        class Node
        {
            public Node? next;
            public Card card;

            public Node(Card card, Node? next)
            {
                this.card = card;
                this.next = next;
            }
        }

        public CardStack()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        private Node? _head;
        private Node? _tail;
        private int _size;

        public int Size
        {
            get => _size;
        }

        public void Push(Card card)
        {
            if (_size >= 100)
            {
                throw new Exception("Stack is full");
            }

            Node new_node = new(card, null);

            if (_head is Node head)
            {
                Node? buf = head;
                Node? bufprev = null;

                while (buf != null && card.Prior > buf.card.Prior)
                {
                    bufprev = buf;
                    buf = buf.next;
                }

                if(bufprev is not null)
                {
                    bufprev.next = new_node;
                    new_node.next = buf;
                }
                else
                {
                    new_node.next = buf;
                    _head = new_node;
                }

            }
            else
            {
                _head = new_node;
            }
            ++_size;

        }

        public Card Top()
        {
            if (_head is Node head)
            {
                return head.card;
            }
            else
            {
                throw new Exception("Empty stack");
            }
        }

        public Card Pop()
        {
            if (_head is Node head)
            {
                Card buf = head.card;
                if (head.next is not null)
                {
                    _head = head.next;
                }
                else
                {
                    _head = null;
                }
                --_size;
                return buf;
            }
            else
            {
                throw new Exception("Empty stack");
            }
        }

        public bool IsReadyForGame()
        {
            if (_size > 30)
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

            if (_size < 2) return;

            Random rnd = new Random();
            int mid;

            mid = _size / 2;

            Node buf1start = _head;
            Node buf1end = _head;

            for (int j = 0; j < mid; ++j)
            {
                buf1end = buf1end.next;
            }

            Node buf2start = buf1end.next;
            Node buf2end = buf1end.next;

            for (int j = mid; j < _size - 2; ++j)
            {
                buf2end = buf2end.next;
            }

            buf2end.next = buf1start;
            buf1end.next = null;

            _head = buf2start;

            for (int j = 0; j < _size; ++j)
            {
                Node bufnode = _head;

                Node buf1 = null;
                Node buf2 = _head;

                int position = rnd.Next(1, _size - 1);

                for (int i = 0; i < position; ++i)
                {
                    buf1 = buf2;
                    buf2 = buf2.next;
                }

                _head = bufnode.next;

                bufnode.next = buf2;
                if (buf1 is not null)buf1.next = bufnode;

            }
        }
    }
}