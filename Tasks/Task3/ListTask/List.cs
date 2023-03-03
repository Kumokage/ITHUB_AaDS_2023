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

        public List() {
            throw new NotImplementedException();
        }

        public List(IEnumerable<int> collection) 
        {
            throw new NotImplementedException();
        }

        public int Front()
        {
            throw new NotImplementedException();
        }

        public int Back()
        {
            throw new NotImplementedException();
        }

        public bool Empty()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void PushBack(int value)
        {
            throw new NotImplementedException();
        }

        public int PopBack()
        {
            throw new NotImplementedException();
        }

        public void PushFront(int value)
        {
            throw new NotImplementedException();
        }

        public int PopFront()
        {
            throw new NotImplementedException();
        }

        public void Resize(int count)
        {
            throw new NotImplementedException();
        }

        public void Swap(List other_list)
        {
            throw new NotImplementedException();
        }

        public void Remove(int value)
        {
            throw new NotImplementedException();
        }

        public void Unique()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public int this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}