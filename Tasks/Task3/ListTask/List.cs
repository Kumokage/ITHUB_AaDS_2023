using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ListTask
{
    public class List
    {
        class Node
        {
            public int value;
            public Node? next;
            public Node? prev;
        }

        private Node? head;
        private Node? tail;
        private int size;

        public List()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public List(IEnumerable<int> collection)
        {
            foreach (int buf in collection)
            {
                PushBack(buf);
            }
        }

        public List(List list)
        {
            for (int i = 0; i < list.Size(); i++)
            {
                PushBack(list[i]);
            }
        }

        public int? Front()
        {

            if (head is Node node)
            {
                return node.value;
            }
            else
            {
                return null;
            }
        }

        public int? Back()
        {
            if (tail is Node node)
            {
                return node.value;
            }
            else
            {
                return null;
            }
        }

        public bool Empty()
        {
            if (head is Node)
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
            Node new_node = new Node();
            new_node.value = value;

            if (tail is Node && head is Node)
            {
                new_node.prev = tail;
                tail.next = new_node;
                tail = new_node;
            }
            else
            {
                head = new_node;
                tail = new_node;
            }

            ++size;
        }

        public int PopBack()
        {
            if (tail is Node)
            {
                int buf = tail.value;

                if (tail.prev is not null)
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

                return buf;
            }
            else
            {
                throw new Exception("Empty list");
            }
        }

        public void PushFront(int value)
        {
            Node new_node = new Node();
            new_node.value = value;

            if (tail is Node && head is Node)
            {
                new_node.next = head;
                head.prev = new_node;
                head = new_node;
            }
            else
            {
                head = new_node;
                tail = new_node;
            }

            ++size;
        }

        public int PopFront()
        {
            if (head is Node)
            {
                int buf = head.value;

                if (head.next is not null)
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

                return buf;
            }
            else
            {
                throw new Exception("Empty list");
            }
        }

        public void Resize(int count)
        {
            if (count > size)
            {
                int push_count = count - size;
                for (int i = 0; i < push_count; ++i)
                {
                    PushBack(0);
                }
            }
            else if (count < size)
            {
                int pop_count = size - count;
                for (int i = 0; i < pop_count; ++i)
                {
                    PopBack();
                }
            }
        }

        public void Swap(List other_list)
        {
            List buf = new List(other_list);

            other_list.Clear();
            for (int i = 0; i < size; i++)
            {
                other_list.PushBack(this[i]);
            }

            Clear();
            for (int i = 0; i < buf.Size(); i++)
            {
                PushBack(buf[i]);
            }

        }

        public void Remove(int value)
        {
            if (Empty())
            {
                throw new Exception("Empty list");
            }

            Node? node = head;

            for (int i = 0; i < size; ++i)
            {
                if(node.value == value)
                {
                    if (node.next is Node)
                    {
                        node.next.prev = node.prev;
                    }
                    else
                    {
                        node.prev.next = null;
                        tail = node;
                    }

                    if (node.prev is Node)
                    {
                        node.prev.next = node.next;
                    }
                    else
                    {
                        node.next.prev = null;
                        head = node;
                    }

                    tail = tail.prev;

                    --size;
                    return;
                }

                node = node.next;
            }
        }

        public void Unique()
        {
            Node? node = head;

            for (int i = 0; i < size-1; ++i)
            {
                if(node.value == node.next.value)
                {
                    Node? node2 = node.next;

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
            if (size == 0)
                return;

            Node node = head;
            int[] array = new int[size];
            int[] replic = new int[size];

            for (int i = 0; i < size; ++i)
            {
                replic[i] = node.value;
                node = node.next;
            }

            MergeSort(ref array,ref replic, 0, size - 1);
        }

        private void MergeSort(ref int[] array, ref int[] replic, int start, int end)
        {
            if (start >= end)
                return;

            int mid = (start + end) / 2;
            MergeSort(ref array,ref replic, start, mid);
            MergeSort(ref array,ref replic, mid + 1, end);

            int index = start;
            for (int i = start, j = mid + 1; i <= mid || j <= end;)
            {
                if (j > end || (i <= mid && array[i] < array[j]))
                {
                    replic[index] = array[i];
                    ++i;
                }
                else
                {
                    replic[index] = array[j];
                    ++j;
                }
                ++index;
            }

            Node node = head;
            for (int i = start; i <= end; ++i)
            {
                node.value = replic[i];
                node = node.next;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= size || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node? node = head;

                for (int i = 0; i < index; ++i)
                {
                    node = node.next;
                }

                return node.value;
            }
            set
            {
                Node? node = head;

                for (int i = 0; i < index; ++i)
                {
                    node = node.next;
                }

                node.value = value;
            }
        }
    }
}
