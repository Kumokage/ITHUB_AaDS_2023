using System.Globalization;
using System.Net.Mime;
using System.Collections.Generic;

namespace LessonQueue
{
    public class Message
    {
        private string _text;
        private int _prior;

        public Message(string text, int prior)
        {
            _text = text;
            _prior = prior;
        }

        public int Prior
        {
            get => _prior;
        }

        public override string ToString()
        {
            return _text;
        }
    }

    public class Queue
    {
        class Node
        {
            public Node? next;
            public Node? prev;
            public Message message;

            public Node(Message message, Node? next, Node? prev)
            {
                this.message = message;
                this.next = next;
                this.prev = prev;
            }
        }

        private Node? _head;
        private Node? _tail;
        private int _size;

        public Queue()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public Queue(IEnumerable<Message> collection)
        {
            foreach (Message cur in collection)
            {
                Push(cur);
            }
        }

        public void Push(Message message)
        {
            // Add priority
            Node new_node = new(message, null, null);
            if (_tail is Node tail && _head is Node head)
            {
                Node? buf = tail;
                while(buf != null && buf.message.Prior > message.Prior) {
                    buf = buf.next;
                }

                if(buf is Node forward_node) {
                    new_node.next = forward_node;
                    new_node.prev = forward_node.prev;
                    if(forward_node.prev is not null){
                        forward_node.prev.next = new_node;
                    }
                    else{
                        _tail = new_node;
                    }
                    forward_node.prev = new_node;
                }
                else{
                    new_node.prev = head;
                    head.next = new_node;
                    _head = new_node;
                }
            }
            else
            {
                _head = new_node;
                _tail = new_node;
            }
            ++_size;
        }

        public Message Pop()
        {
            if (_head is Node head)
            {
                Message buf = head.message;
                if (head.prev is not null)
                {
                    head.prev.next = null;
                    _head = head.prev;
                }
                else
                {
                    _tail = null;
                    _head = null;
                }
                --_size;
                return buf;
            }
            else
            {
                throw new Exception("Empty queue");
            }
        }

        public Message First()
        {
            if (_head is Node head)
            {
                return head.message;
            }
            else
            {
                throw new Exception("Empty queue");
            }
        }

        public Message Last(){
            if (_tail is Node tail) {
                return tail.message;
            }
            else{
                throw new Exception("Empty queue");
            }
        }

        public int Length
        {
            get => _size;
        }

        public override string ToString()
        {
            string result = "Message; Prior\n";
            Node? buf = _head;
            while(buf != null) {
                result += $"{buf.message}; {buf.message.Prior}\n";
                buf = buf.prev;
            }
            return result;
        }
    }
}