using System.Globalization;
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
            public Node(int value,Node?next,Node?prev)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;
            }
        }

        private Node? head;
        private Node? tail;
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

        public int? Front()
        {
            if(head is not null)
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
            if(tail is not null)
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
           if (head == null)
            {
                return true;
            }
            else
            {
                return false;
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
            Node newNode = new Node(value,null,null);
            if(head!=null&&tail!=null)
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
            else
            {
                throw new ArgumentException("list is empty");
            }
        }
        public void PushFront(int value)
        {
                Node newNode = new Node(value,null,null);
                if (head != null&&tail!=null)
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
                    if(head.next != null) 
                    {
                        head.next.prev = null;
                        head = head.next;
                    }
                    else
                    {
                        tail = null;
                        head = null;
                    }
                    --size;
                    return temp;
                }
                else
                {
                    throw new Exception("list is empty");
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
                List temp = new List();
                temp.head = other_list.head;
                temp.tail = other_list.tail;
                other_list.head = this.head;
                other_list.tail = this.tail;
                this.head = temp.head;
                this.tail = temp.tail;
        }

        public void Remove(int value)
        {
                if (head == null)
                {
                    throw new Exception("Empty list");
                }
                else
                {
                    Node buff = head;

                    while(buff.next!=null&&buff.value!=value)
                    {
                        buff = buff.next;
                    }
                        if(buff.value == value)
                        {
                            if(buff.prev!=null&&buff.next != null)
                            {
                                buff.prev.next = buff.next;
                                buff.next.prev = buff.prev;
                                --size;
                                return;
                            }
                            else if(buff.prev != null&&buff.next == null)
                            {
                                buff.prev.next = null;
                                tail = buff.prev;
                                --size;
                                return;
                            }
                            else if(buff.prev == null&& buff.next == null)
                            {
                                head = null;
                                tail = null;
                                --size;
                                return;
                            }
                        }
                }
                throw new ArgumentException("there's no such element in list");
            }

        public void Unique()
        {
            int change = 0;
            if(head==null || tail==null)
            {
                throw new ArgumentException("empty");
            }

            Node buff = head;
            while(buff.next != null)
            {
                if(buff.next.value == buff.value)
                {
                    Node buff2 = buff.next;
                    while(buff2.next !=null && buff2.next.value == buff.value)
                    {
                        buff2 = buff2.next;
                        ++change;
                    }

                    if(buff2.next!=null)
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
            
        }

        public int this[int index]
        {
            get
            {
               int steps = 0;
               if(index < 0 || index >= size)
               {
                   throw new ArgumentException("there's no such index");
               }
               else
               {
                   if(head!=null&&tail!=null)
                   {
                   if(index > size/2)
                   {
                       Node buff = tail;
                       while(buff.prev!=null&&steps != size - index-1)
                       {
                           buff = buff.prev;
                           ++steps;
                       }
                       return buff.value;
                   }
                   else
                   {
                       Node buff = head;
                       while(buff.next!=null&&steps!=index)
                       {
                           buff = buff.next;
                           ++steps;
                       }
                       return buff.value;
                   }
               }
               else
               {
                   throw new ArgumentException("list is empty");
               }
               }
            }
            set
            {
                int steps = 0;
               if(index < 0 || index >= size)
               {
                   throw new ArgumentException("there's no such index");
               }
               else
               {
                   if(head!=null&&tail!=null)
                   {
                   if(index > size/2)
                   {
                       Node buff = tail;
                       while(buff.prev!=null&&steps != size - index-1)
                       {
                           buff = buff.prev;
                           ++steps;
                       }
                        buff.value = value;
                   }
                   else
                   {
                       Node buff = head;
                       while(buff.next!=null&&steps!=index)
                       {
                           buff = buff.next;
                           ++steps;
                       }
                        buff.value = value;
                   }
               }
               else
               {
                   throw new ArgumentException("list is empty");
               }
               }
            }
        }
    }
}