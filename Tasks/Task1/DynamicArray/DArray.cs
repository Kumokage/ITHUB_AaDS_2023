using System;
using System.Data;

namespace DynamicArray;

public class DArray : Array
{
    private bool _is_sorted = false;

    public DArray() 
    {
        _container = new int[1];
        _count = 0;
    }

    public DArray(int count) 
    {
        _container = new int[count];
        _count = count;
    }

    public DArray(int[] container) 
    {
        _container = container;
        _count = container.Length;

        int[] sortedArray = new int[container.Length];
        System.Array.Copy(container, sortedArray, container.Length);
        DoSort(ref sortedArray);
        if (sortedArray.SequenceEqual(container))
        {
            _is_sorted = true;
        }
    }

    public override int this[int index]
    {
        get
        {
            if ((index >= _count) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            return _container![index];
        }

        set
        {
            if ((index >= _count) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            _container![index] = value;
            _is_sorted = false;
        }
    }

    public override int Length
    {
        get => _count;
    }

    private void GrowContainer()
    {
        int[]? newContainer = new int[_count + 1];
        System.Array.Copy(_container!, newContainer, _count);
        _container = newContainer;
        _count++;
    }

    public override void Insert(int value, int index)
    {
        if ((index > _count) || (index < 0))
        {
            throw new IndexOutOfRangeException();
        }
        
        if(index == _count)
        {
            Insert(value);
            return;
        }

        GrowContainer();
        int len = _count - index - 1;
        System.Array.Copy(_container!, index, _container!, index + 1, len);
        _container![index] = value;
        _is_sorted = false;
    }

    public override void Insert(int value)
    {
        GrowContainer();
        _container![_count - 1] = value;
        _is_sorted = false;
    }

    public override void Remove(int index)
    {
        if ((index >= _count) || (index < 0))
        {
            throw new IndexOutOfRangeException();
        }

        int len = _count - index - 1;
        System.Array.Copy(_container!, index + 1, _container!, index, len);
        _count--;
        _is_sorted = false;
    }

    public override void Remove()
    {
        _count--;
        _is_sorted = false;
    }

    public override int BinarySearch(int value)
    {
        if (!_is_sorted)
        {
            //throw new NotSortedException();
            throw new ArgumentException("Not sorted");
        }

        return BinarySearch(value, 0, _count);
    }

    private int BinarySearch(int value, int start, int end)
    {
        int mid = (start + end) / 2;

        if (start > end)
        {
            throw new ArgumentException("No such value");
        }
            
        if (_container![mid] == value)
        {
            return mid;
        }

        if (_container[mid] > value)
        {
            return BinarySearch(value, start, mid - 1);
        }
        else
        {
            return BinarySearch(value, mid + 1, end);
        }
            
    }

    public override int LinearSearch(int value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (value == _container![i])
            {
                return i;
            }
        }

        throw new ArgumentException("No such value");
    }

    private void DoSort(ref int[] arr)
    {
        int minIndex = 0;

        for (int j = 0; j < _count; j++)
        {
            int min = int.MaxValue;

            for (int i = j; i < _count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            int s = arr[j];
            arr[j] = arr[minIndex];
            arr[minIndex] = s;
        }
    }

    public override void Sort()
    {
        DoSort(ref _container!);
        _is_sorted = true;
    }
}