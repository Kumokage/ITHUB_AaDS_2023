namespace DynamicArray
{
    public abstract class Array
    {
        protected int[]? _container;
        protected int _count;

        public abstract void Insert(int value);

        public abstract void Insert(int value, int position);

        public abstract void Remove(int index);

        public abstract void Remove();

        public abstract int this[int index]
        {
            get;
            set;
        }

        public abstract int Length
        {
            get;
        }

        public abstract void Sort();

        public abstract int BinarySearch(int value);

        public abstract int LinearSearch(int value);

    }
}