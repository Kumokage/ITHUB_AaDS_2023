using System;
namespace DynamicArray;

public class DArray : Array
{
    // _count количество элементов в массиве

    private bool _isSorted = false;

    public DArray() {
        _container = new int[1];
        _count = 0;
    }

    public DArray(int count) {
        _container = new int[count];
        _count = 0;
    }

    public DArray(int[] container) {
        if (container.Length == 0) {
            _container = new int[1];
        }
        else{
            _container = new int[container.Length];
        }
        
        _count = container.Length;
        for(int i = 0; i < _count; ++i) {
            _container[i] = container[i];
        }
    }

    public override int this[int index]
    {
        get {
            if (index >= _count || index < 0) {
                throw new IndexOutOfRangeException();
            }

            return _container[index];
        }
        set {
            Insert(value, index);
        }
    }

    public override int Length
    {
        get {
            return _count;
        }
    }

    private void Resize() {
        int[] new_container = new int[_container.Length * 2];
        for (int i = 0; i < _count; ++i ) {
            new_container[i] =  _container[i];
        }

        _container = new_container;
    }

    public override void Insert(int value, int position)
    {
        if (position > _count || position < 0) {
            throw new IndexOutOfRangeException("Incorrect position value");
        }

        if (_count == _container.Length) {
            Resize();
        }

        for (int i = _count - 1; i >= position; --i) {
            _container[i + 1] = _container[i];
        }

        _container[position] = value;
        ++_count;
        _isSorted = false;
    }

    public override void Insert(int value)
    {
        Insert(value, _count);
    }

    public override void Remove(int index)
    {
        if(index >= _count || index < 0) {
            throw new IndexOutOfRangeException();
        } 

        for (int i = index; i < _count - 1; ++i ) {
            _container[i] = _container[i + 1];
        }

        --_count;
    }

    public override void Remove()
    {
        --_count;
    }

    public override int BinarySearch(int value)
    {
        int start = 0;
        int end = _count;
        int mid;

        if (!_isSorted)
        {
            Sort();
        }

        while (start <= end)
        {
            mid = (start + end) / 2;

            if (_container[mid] == value)
            {
                return mid;
            }

            if (value > _container[mid])
            {
                start = mid + 1;
            }

            if (value < _container[mid])
            {
                end = mid - 1;
            }
        }

        throw new ArgumentException("No such value");
    }

    public override int LinearSearch(int value)
    {
        for (int i = 0; i < _count; i++) 
        { 
            if (value == _container[i]) 
            { 
                return i; 
            } 
        } 
        
        throw new ArgumentException("Incorret value");
    }

    public override void Sort()
    {
        for (int k = _count; k > 0; --k)
        {
            for (int i = 0; i < k - 1; i++)
            {
                if (_container[i] > _container[i + 1])
                {
                    int temp = _container[i + 1];
                    _container[i + 1] = _container[i];
                    _container[i] = temp;
                }
            }
        }
        _isSorted = true;
    }
}