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
        int compare = 0;
            if (order == Order.ASC)
            {
                compare = 1;
            }
            else if (order == Order.DESC)
            {
                compare = -1;
            }

                for (int i = 0; i < arr.Length; ++i)
                {
                    for (int j = 0; j < arr.Length - i - 1; ++j)
                    {
                        if (String.Compare(arr[j + 1], arr[j]) == compare)
                        {
                            string buf = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = buf;
                        }
                    }
                }
    }

    public static void SelectSort(ref string[] arr, Order order)
    {
        int compare = 0;
            if (order == Order.ASC)
            {
                compare = 1;
            }
            else if (order == Order.DESC)
            {
                compare = -1;
            }

            int minmax;
            for (int i = 0; i < arr.Length; ++i)
            {
                minmax = i;
                for (int j = i; j < arr.Length; ++j)
                {
                    if (String.Compare(arr[j], arr[minmax]) == compare)
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
       int compare = 0;
            if (order == Order.ASC)
            {
                compare = 1;
            }
            else if (order == Order.DESC)
            {
                compare = -1;
            }

            for (int i = 1; i < arr.Length; ++i)
            {
                string buff = arr[i];
                int k = i;

                while (k > 0 && String.Compare(arr[k - 1], buff) != compare)
                {
                    arr[k] = arr[k - 1];
                    --k;
                }
                arr[k] = buff;
            }
    }
    private static void MergeSort(ref string[] array, ref string[] replic, int l, int r, int compare)
        {
            if (l >= r)
                return;

            int mid = (l + r) / 2;
            MergeSort(ref array, ref replic, l, mid, compare);
            MergeSort(ref array, ref replic, mid + 1, r, compare);

            int index = l;
            for (int i = l, j = mid + 1; i <= mid || j <= r;)
            {
                if (j > r || (i <= mid && String.Compare(array[i], array[j]) == compare))
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
            for (int i = l; i <= r; ++i)
            {
                array[i] = replic[i];
            }
        }
    public static void MergeSort(ref string[] arr, Order order)
    {
       int compare = 0;
            if (order == Order.ASC)
            {
                compare = 1;
            }
            else if (order == Order.DESC)
            {
                compare = -1;
            }

            string[] replic = new string[arr.Length];

            MergeSort(ref arr, ref replic, 0, arr.Length - 1, compare);
    }

    public static void QuickSort(ref string[] arr,Order order)
    {
       int compare = 0;
            if (order == Order.ASC)
            {
                compare = 1;
            }
            else if (order == Order.DESC)
            {
                compare = -1;
            }

            QuickSort(ref arr, 0, arr.Length - 1, compare);
    }
    private static void QuickSort(ref string[] arr, int l, int r, int compare)
        {
            if (l < r)
            {
                int q = r;
                string x = arr[l];

                for (int i = l + 1; i <= q;)
                {
                    if (String.Compare(x, arr[i]) == compare)
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
                string buff = arr[l];
                arr[l] = arr[q];
                arr[q] = buff;

                QuickSort(ref arr, l, q - 1, compare);
                QuickSort(ref arr, q + 1, r, compare);
            }
        }
    
    }
   
}
