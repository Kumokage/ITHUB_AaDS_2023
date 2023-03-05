using System;
namespace SortingLib 
{

    public enum Order
    {
        ASC,
        DESC
    }

    public static class Sortings
    {
        public static void BubleSort(ref string[] arr, Order order) 
        {
            if(order == Order.ASC)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    for (int j = 0; j < arr.Length - i - 1; ++j)
                    {
                        if (String.Compare(arr[j + 1], arr[j]) == 1)
                        {
                            string buf = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = buf;
                        }
                    }
                }
            }
            else if(order == Order.DESC)
            {
                for (int i = arr.Length - 1; i > 0; --i)
                {
                    for (int j = arr.Length - 1; j > 0; --j)
                    {
                        if (String.Compare(arr[j], arr[j - 1]) == -1)
                        {
                            string buf = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = buf;
                        }
                    }
                }
            }

        }

        public static void SelectSort(ref string[] arr, Order order)
        {
            int orderInt = 3;
            if (order == Order.ASC)
            {
                orderInt = 1;
            }
            else if (order == Order.DESC)
            {
                orderInt = -1;
            }

            int minmax;
            for (int i = 0; i < arr.Length; ++i)
            {
                minmax = i;
                for (int j = i; j < arr.Length; ++j)
                {
                    if (String.Compare(arr[j], arr[minmax]) == orderInt)
                    {
                        minmax = j;
                    }
                }
                string buf = arr[i];
                arr[i] = arr[minmax];
                arr[minmax] = buf;
            }
        }

        public static void InsertSort(ref string[] arr, Order order)
        {
            int orderInt = 3;
            if (order == Order.ASC)
            {
                orderInt = 1;
            }
            else if (order == Order.DESC)
            {
                orderInt = -1;
            }

            for (int i = 1; i < arr.Length; ++i)
            {
                string buf = arr[i];
                int k = i;

                while (k > 0 && String.Compare(arr[k - 1], buf) != orderInt)
                {
                    arr[k] = arr[k - 1];
                    --k;
                }
                arr[k] = buf;
            }
        }

        public static void MergeSort(ref string[] arr, Order order)
        {
            int orderInt = 3;
            if (order == Order.ASC)
            {
                orderInt = 1;
            }
            else if (order == Order.DESC)
            {
                orderInt = -1;
            }

            string[] replic = new string[arr.Length];

            MergeSort(ref arr, ref replic, 0, arr.Length - 1, orderInt);
        }

        private static void MergeSort(ref string[] array, ref string[] replic, int start, int end, int orderInt)
        {
            if (start >= end)
                return;

            int mid = (start + end) / 2;
            MergeSort(ref array, ref replic, start, mid, orderInt);
            MergeSort(ref array, ref replic, mid + 1, end, orderInt);

            int index = start;
            for (int i = start, j = mid + 1; i <= mid || j <= end;)
            {
                if (j > end || (i <= mid && String.Compare(array[i], array[j]) == orderInt))
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


        public static void QuickSort(ref string[] arr, Order order)
        {
            int orderInt = 3;
            if (order == Order.ASC)
            {
                orderInt = 1;
            }
            else if (order == Order.DESC)
            {
                orderInt = -1;
            }

            QuickSort(ref arr, 0, arr.Length - 1, orderInt);
        }
        private static void QuickSort(ref string[] arr, int start, int end, int orderInt)
        {
            if (start < end)
            {
                int q = end;
                string x = arr[start];

                for (int i = start + 1; i <= q;)
                {
                    if (String.Compare(x, arr[i]) == orderInt)
                    {
                        string buf = arr[i];
                        arr[i] = arr[q];
                        arr[q] = buf;

                        --q;
                    }
                    else
                    {
                        ++i;
                    }
                }
                string buff = arr[start];
                arr[start] = arr[q];
                arr[q] = buff;

                QuickSort(ref arr, start, q - 1, orderInt);
                QuickSort(ref arr, q + 1, end, orderInt);
            }
        }
    }
}