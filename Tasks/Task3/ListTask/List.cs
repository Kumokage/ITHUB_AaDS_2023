using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTask 
{
    public class List
    {
        class Node
        {
            public int Value { get;  set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private Node tail;
        private int size;

        public List() 
        {
            head = null;
            tail = null;
            size = 0;
        }

        public List(IEnumerable<int> collection) 
        {
            foreach (var item in collection)
            {
                PushBack(item);
            }
        }

        public int? Front()
        {
            if (!Empty())
            {
                return head.Value;
            }

            return null;
        }

        public int? Back()
        {
            if (!Empty())
            {
                return tail.Value;     
            }

            return null;
        }

        public bool Empty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void PushBack(int value)
        {
            var newNode = new Node(value);

            if (Empty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            size++;
        }

        public int PopBack()
        {
            if (Empty())
            {
                throw new InvalidOperationException("List is empty.");
            }

            int value;

            if (head == tail)
            {
                value = head.Value;
                head = null;
                tail = null;
            }
            else
            {
                var currentNode = head;
                while (currentNode.Next != tail)
                {
                    currentNode = currentNode.Next;
                }

                value = tail.Value;
                tail = currentNode;
                tail.Next = null;
            }

            size--;
            return value;
        }

        public void PushFront(int value)
        {
            var newNode = new Node(value);

            if (Empty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            size++;
        }

        public int PopFront()
        {
            if (Empty())
            {
                throw new InvalidOperationException("List is empty.");
            }

            int value = head.Value;

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }

            size--;
            return value;
        }

        public void Resize(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count cannot be negative.");
            }

            if (count == size)
            {
                return;
            }
            else if (count < size)
            {
                var currentNode = head;
                for (int i = 0; i < count - 1; i++)
                {
                    currentNode = currentNode.Next;
                }

                tail = currentNode;
                tail.Next = null;
                size = count;
            }
            else
            {
                var currentNode = tail;
                for (int i = size; i < count; i++)
                {
                    var newNode = new Node(0);
                    currentNode.Next = newNode;
                    currentNode = newNode;
                }

                tail = currentNode;
                size = count;
            }
        }

        public void Swap(List other_list)
        {
            var tempHead = head;
            var tempTail = tail;
            var tempSize = size;

            head = other_list.head;
            tail = other_list.tail;
            size = other_list.size;

            other_list.head = tempHead;
            other_list.tail = tempTail;
            other_list.size = tempSize;
        }

        public void Remove(int value)
        {
            if (Empty())
            {
                return;
            }
            if (head.Value == value)
            {
                head = head.Next;
                size--;
                return;
            }

            var currentNode = head;
            while (currentNode.Next != null && currentNode.Next.Value != value)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next = currentNode.Next.Next;
                size--;
            }

            if (currentNode.Next == null)
            {
                tail = currentNode;
            }
        }

        public void Unique()
        {
            if (Empty())
            {
                return;
            }

            var currentNode = head;
            while (currentNode.Next != null)
            {
                if (currentNode.Value == currentNode.Next.Value)
                {
                    currentNode.Next = currentNode.Next.Next;
                    size--;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }

            tail = currentNode;
        }

        public void Sort()
        {
            Node node = head;
            Node bufNode = head;
            Node min = head;
            while (node.Next != null)
            {
                while (bufNode != null)
                {
                    if (min.Value > bufNode.Value)
                    {
                        min = bufNode;
                    }
                    bufNode = bufNode.Next;
                }

                int buf = node.Value;
                node.Value = min.Value;
                min.Value = buf;

                node = node.Next;
                bufNode = node;
                min = node;
            }
        }



        public int this[int index]
        {
            get
            {
                if (index < 0 & index >= size)
            {
                    throw new IndexOutOfRangeException();
                }

                var currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Value;
            }
            set
            {
                if (index < 0 & index >= size)
            {
                    throw new IndexOutOfRangeException();
                }

                var currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Value = value;
            }
        }
    }
}