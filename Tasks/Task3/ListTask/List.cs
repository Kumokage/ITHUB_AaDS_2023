using System.Collections.Generic;
using System;
namespace ListTask
{
    public class List
    {
        class Node
        {
            public int value;
            public Node? next;
            public Node? prev;

            public Node()
            {
                next = null;
                prev = null;
            }
            public Node(int value)
            {
                next = null;
                prev = null;
                this.value = value;
            }

        }

        private Node? head;
        private Node? tail;
        private int size;

        public List()
        {
            size = 0;
            head = null;
            tail = null;
        }

        public List(IEnumerable<int> collection)
        {
            foreach (int i in collection)
            {
                PushBack(i);
            }
        }

        public int? Front()
        {
            if (head != null)
                return head.value;

            else
            {
                return null;
            }
        }

        public int? Back()
        {
            if (tail != null)
                return tail.value;

            else
            {
                return null;
            }
        }

        public bool Empty()
        {
            if (size == 0)
            {
                return true;
            }

            return false;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
            head = null;
            tail = null;
        }

        public void PushBack(int value)
        {
            if (tail == null)
            {
                tail = new Node(value);
                head = tail;
                size++;
            }
            else
            {
                Node buf = tail;
                tail = new Node(value);
                buf.next = tail;
                tail.prev = buf;
                size++;
            }

        }

        public int PopBack()
        {
            if (size > 0)
            {
                size--;
                Node buf = tail;
                tail = tail.prev;
                return buf.value;
            }

            throw new ArgumentNullException();

        }

        public void PushFront(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                tail = head;
                size++;
            }
            else
            {
                Node buf = head;
                head = new Node(value);
                buf.prev = head;
                head.next = buf;
                size++;
            }


        }

        public int PopFront()
        {
            if (size > 0)
            {
                size--;
                Node buf = head;
                head = head.next;
                return buf.value;
            }

            throw new ArgumentNullException();
        }

        public void Resize(int count)
        {
            if (count > size)
            {

                while (size != count)
                {
                    PushBack(0);


                }


            }
            else if (count < size)
            {
                while (size != count)
                {
                    PopBack();

                }

            }
        }

        public void Swap(List other_list)
        {


            List buf = new List();

            buf.head = other_list.head;
            buf.tail = other_list.tail;
            other_list.head = head;
            other_list.tail = tail;

            head = buf.head;
            tail = buf.tail;


        }

        public void Remove(int value)
        {
            Node buf = head;

            while (buf.value != value && buf != tail)
            {
                buf = buf.next;

            }

            if (buf.value != value)
            {
                throw new Exception("No such value");

            }

            if (buf == tail)
            {
                tail = buf.prev;

            }
            else if (buf == head)
            {
                head = buf.next;
            }
            else
            {

                buf.prev.next = buf.next;
                buf.next.prev = buf.prev;
            }
            size--;

        }

        public void Unique()
        {
            if (head == null && tail == null)
            {
                throw new NullReferenceException();
            }

            Node buff = head;
            while (buff.next != null)
            {
                if (buff.next.value == buff.value)
                {
                    Node buff2 = buff.next;
                    while (buff2.next != null && buff2.next.value == buff.value)
                    {
                        buff2 = buff2.next;

                    }

                    if (buff2.next != null)
                    {
                        buff.next = buff2.next;
                        buff2.next.prev = buff;
                    }
                    else
                    {
                        buff.next = null;
                        tail = buff;
                        return;
                    }

                }
                buff = buff.next;
            }
        }

        public void Sort()
        {


            Node node = head;
            Node bufNode = head;
            Node min = head;
            while (node.next != null)
            {
                while (bufNode != null)
                {
                    if (min.value > bufNode.value)
                    {
                        min = bufNode;
                    }
                    bufNode = bufNode.next;
                }

                int buf = node.value;
                node.value = min.value;
                min.value = buf;

                node = node.next;
                bufNode = node;
                min = node;
            }



        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > size - 1)
                {
                    throw new IndexOutOfRangeException();

                }

                if (index == 0)
                {
                    return head.value;
                }
                else
                {
                    int ind = 0;
                    Node buf = head;
                    while (index != ind)
                    {
                        buf = buf.next;
                        ind++;


                    }

                    return buf.value;


                }

            }
            set
            {
                if (index < 0 || index > size - 1)
                {
                    throw new IndexOutOfRangeException();

                }

                if (index == 0)
                {
                    head.value = value;
                }
                else
                {
                    int ind = 0;
                    Node buf = head;
                    while (index != ind)
                    {
                        buf = buf.next;
                        ind++;


                    }

                    buf.value = value;


                }
            }
        }
    }
}