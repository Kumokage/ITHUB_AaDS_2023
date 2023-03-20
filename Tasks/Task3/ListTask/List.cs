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
            head = null;
            tail = null;
            size = 0;
        }

        public List(IEnumerable<int> collection) 
        {
            foreach (int temp in collection)
            {
                PushBack(temp);
            }
        }

        public int Front()
        {
           return head.value;
        }

        public int Back()
        {
            return tail.value;
        }

        public bool Empty()
        {
           if (head == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            Node newNode = new Node();
            newNode.value = value;
            if(head!=null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
            ++size;
        }

        public int PopBack()
        {
            if (tail != null)
            {
                int temp = tail.value;
                if (tail.prev != null)
                {
                    tail.prev.next = null;
                    tail = tail.prev;
                }
                else
                {
                    tail = null;
                    head = null;
                }
                --size;

                return temp;
            }

        public void PushFront(int value)
        {
                Node newNode = new Node();
                newNode.value = value;
                if (head != null)
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
                ++size;
            }

        public int PopFront()
        {
            if(head!=null)
                {
                    int temp = head.value;
                    if(head.prev != null) 
                    {
                        head.prev.next = null;
                        head = head.next;
                    }
                    else
                    {
                        tail = null;
                        head = null;
                    }
                    --size;
                }
                else
                {
                    throw new Exception("Empty");
                }
        }

        public void Resize(int count)
        {
                if (count > size)
                {
                    int add = count - size;
                    for (int i = 0; i < add; ++i)
                    {
                        PushBack(0);
                    }
                }
                else if (count < size)
                {
                    int remove = size - count;
                    for (int i = 0; i < remove; ++i)
                    {
                        PopBack();
                    }
                }
            }

        public void Swap(List other_list)
        {
                List temp = new List(other_list);
                other_list.Clear();
                for(int i = 0; i< size; i++)
                {
                    other_list.PushBack(i);
                }
                Clear();
                for (int i = 0; i < temp.Size(); i++)
                {
                    PushBack(temp[i]);
                }
            }

        public void Remove(int value)
        {
                if (Empty()==true)
                {
                    throw new Exception("Empty");
                }
                else
                {

                }
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