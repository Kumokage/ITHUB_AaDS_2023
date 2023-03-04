using System;

namespace DynamicArray
{
    public class DArray : Array
    {
        private bool _isSorted = false;

        public DArray()
        {
            _container = new int[1];
            _count = 0;
            _isSorted = false;
        }

        public DArray(int count)
        {
            _container = new int[count];
            _count = 0;
            _isSorted = false;

            for (int i = 0; i < count; i++)
            {
                _container[i] = 0;
            }
        }

        public DArray(int[] container)
        {
            if (container.Length == 0)
            {
                _container = new int[0];
            }
            else
            {
                _container = new int[container.Length];
            }

            _container = container;
            _count = container.Length;

            _isSorted = true;
            for (int i = 1; i < _count; i++)
            {
                if (_container[i - 1] > _container[i])
                {
                    _isSorted = false;
                    break;
                }
            }
        }

        public override int this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _container[index];
            }
            set
            {
                Insert(value, index);
            }
        }

        public override int Length
        {
            get => _count;
        }

        public override void Insert(int value, int position)
        {
            if (_count + 1 >= _container.Length)
            {
                Resize();
            }

            if (position < 0 || position > _count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = _count; i >= position; --i)
            {
                _container[i + 1] = _container[i];
            }

            _container[position] = value;
            ++_count;
        }

        public override void Insert(int value)
        {
            Insert(value, _count);
        }

        public override void Remove(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count - 1; ++i)
            {
                _container[i] = _container[i + 1];
            }

            --_count;
        }

        public override void Remove()
        {
            if (_count == 0)
            {
                throw new Exception("Array is empty");
            }

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

            throw new ArgumentException();
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

            throw new ArgumentException();
        }

        public override void Sort()
        {
            if (_container.Length == 0)
                return;

            int[] replic = new int[_count];

            MergeSort(ref _container, ref replic, 0, _count - 1);
            _isSorted = true;
        }

        private void MergeSort(ref int[] array, ref int[] replic, int start, int end)
        {
            if (start >= end)
                return;

            int mid = (start + end) / 2;
            MergeSort(ref array, ref replic, start, mid);
            MergeSort(ref array, ref replic, mid + 1, end);

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
            for (int i = start; i <= end; ++i)
            {
                array[i] = replic[i];
            }
        }

        private void Resize()
        {
            int[] newContainer = new int[_container.Length * 2];
            for (int i = 0; i < _count; ++i)
            {
                newContainer[i] = _container[i];
            }

            _container = newContainer;
        }
    }
}
