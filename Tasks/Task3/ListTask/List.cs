using System.Collections.Generic;
using System;
namespace ListTask 
{
    public class List
    {
        class Node
        {
            public int value;
            public Node next;
            public Node prev;
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
            foreach (int size in collection)
            {
                PushBack(size);
            }
        }

        public int? Front()
        {
         if (head != null)
            {
                return head.value;
            }   
         else
            {
                return null;
            }
        }

        public int? Back()
        {
            if (tail != null)
            {
                return tail.value;
            }
            else
            {
                return null;
            }
        }
         
        public bool Empty()
        {
            if (head != null)
            {
                return false;
            }
            if (head == null)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public int Size()
        {
            if (head != null)
            {
                return size;
            }
            else
            {
                return 0;
            }
        }

        public void Clear()
        {
            if (head != null)
            {
                head = null;
                tail = null;
                size = 0;
            }
            else
            {
               
            }
        }

        public void PushBack(int value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if (tail is Node && head is Node)
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }

            size++;
        }

        public int PopBack()
        {
            int buf = tail.value;
           // tail = null;
            tail = tail.prev;
            tail.next = null;
            size--;
            return buf;
            
        }

        public void PushFront(int value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if (tail is Node && head is Node)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }

            size++;
        }

        public int PopFront()
        {
            size--;
            int buf = head.value;
            head = head.next;
           // head.prev = null;
            return buf; 
            
        }

        public void Resize(int count)
        {
            if (count > size)
            {
                int a = count - size;
                for (int i = 0; i < a; i++)
                {
                    PushBack(0);
                }
            }
            else if (count < size)
            {
                int b = size - count;
                for (int i = 0; i < b; i++) //Работает

                { 
                        PopBack();
                }

            }
            size = count;
            
          //  return size;
        }

        public void Swap(List other_list)
        {
         //   Node n = head;
          //  Node m = tail;
          //  head = m;
           // tail = n;

                Node n = head;
                Node nb = tail;

                List buf = new List();

                buf.head = other_list.head;
                buf.tail = other_list.tail;

            
                other_list.head = head;
                other_list.tail = tail;

                head = buf.head;
                tail = buf.tail;

             /*      if (other_list.size != size)
                   {
                int bufSize = 0;
                buf.size = size;
                size = other_list.size;
                other_list.size = bufSize;

                   }*/
        }

        public void Remove(int value)
        {
            if (head == null)
            {
                throw new NotImplementedException();
            }
            Node buf = head;
            for (int i = 0; i < size; i++)
            {
                if (buf.value == value)
                {
                    if (buf.prev != null && buf.next != null)
                    {
                        buf.prev.next = buf.next;
                        // head.prev = null;
                        buf.next.prev = buf.prev;
                        size--;
                    }
                    if (buf.prev == null)
                    {
                        buf = buf.next;
                        head = buf;
                        // head.prev.next=null;
                        buf.prev = null;
                        size--;
                    }
                    if (buf.next == null)
                    {

                        buf = buf.prev;

                        //  tail.next.prev=null;
                        buf.next = null;
                        tail = buf;
                        size--;
                    }
                }
                if (buf.next != null)
                {
                    buf = buf.next;
                }
            }
        }

        public void Unique()
        {
            Node node = head;

            for (int i = 0; i < size - 1; ++i)
            {
                if (node.value == node.next.value)
                {
                    Node node2 = node.next;

                    for (int j = i; j < size; ++j)
                    {
                        if (node.value == node2.value)
                        {
                            if (node2.next is Node)
                            {
                                node2.next.prev = node2.prev;
                            }
                            else
                            {
                                node2.prev.next = null;
                                tail = node2;
                            }

                            if (node2.prev is Node)
                            {
                                node2.prev.next = node2.next;
                            }
                            else
                            {
                                node2.next.prev = null;
                                head = node2;
                            }

                            tail = tail.prev;

                            --size;
                        }
                        else
                            break;
                        node2 = node.next;
                    }
                }

                node = node.next;
            }
        }

        public void Sort()
        {
            Node start = head;
            Node n = head;
            Node minNode = head;
            while(start.next != null)
			{
                while (n.next != null) 
                { 
                  if (minNode.value > n.value) 
                    {
                        minNode = n;
                    }
                    n = n.next;
                }

                int buf = start.value;
                start.value = minNode.value;
                minNode.value = buf;

                start = start.next;
                n = start;
                minNode = start;
			}

        }

        public int this[int index]
        {
            get
            {
                Node now = head;
                if (index >= 0 && index < size)
                {

                    for (int k = 0; k < index; ++k)
                    {
                        now = now.next;
                    }
                    return now.value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}