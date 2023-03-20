using System;
namespace SortingLib
{

    public enum Order
    {
        ASC,
        DESC
    }

public static void BubleSort(ref string[] arr, Order order)
    {
        int compare = 1000;
        
        if (order == Order.ASC)
        {
            compare = 1;
        }
        else if (order == Order.DESC)
        {
            compare = -1;
        }
        for (int i = arr.Length - 1; i > 0; --i)
        {
            for (int j = arr.Length - 1; j > 0; --j)
            {
                if (String.Compare(arr[j], arr[j - 1]) == compare)
                {
                    string temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

    public static void SelectSort(ref string[] arr, Order order)
    {
        int compare=10000;
        if (order == Order.ASC)
        {
            compare = 1;
        }
        else if (order == Order.DESC)
        {
            compare = -1;
        }

        int max;
        for (int k = 0; k < arr.Length; k++)
        {

            max = 0;
            for (int i = 1; i < arr.Length - k; i++)
            {
                if (string.Compare( arr[i] , arr[max])==compare)
                    max = i;
            }


            string temp = arr[arr.Length - k - 1];
            arr[arr.Length - k - 1] = arr[max];
            arr[max] = temp;
        }
    }

    public static void InsertSort(ref string[] arr, Order order)
    {
        int compare = 100;
        if (order == Order.ASC)
        {
            compare = 1;
        }
        else if (order == Order.DESC)
        {
            compare = -1;
        }
        string x;
        int j;

        for (int i = 1; i < arr.Length; i++)
        {
            x = arr[i];
            j = i;
            while (j > 0 && (string.Compare(arr[j - 1], x)) == compare)
            {
                string temp = arr[j];
                arr[j] = arr[j - 1];
                arr[j - 1] = temp;
                j -= 1;

            }
            arr[j] = x;
        }
    }


    public static void MergeSort(ref string[] arr, Order order)
    {
        if (arr.Length == 0)
            return;

        int compare = 1000 ;
        if (order == Order.ASC)
        {
            compare = -1;
        }
        else if (order ==Order.DESC)
        {
            compare = 1;
        }
        string[] buf = new string[arr.Length];
        MergeSort(ref arr, ref buf, 0, arr.Length - 1, compare);
        
    }
    private static void MergeSort(ref string[] arr, ref string[] buf, int l, int r, int compare)
    {
        if (l >= r)
            return;



        int m = (l + r) / 2;
        
        MergeSort(ref arr, ref buf, l, m);
        MergeSort(ref arr, ref buf, m + 1, r);
       

        int k = l;
        for (int i = l, j = m + 1; i <= m || j <= r;)
        {
            if ((i <= m && string.Compare(arr[i], arr[j]) == compare))
            {
                buf[k] = arr[i];
                ++i;
            }
            else
            {
                buf[k] = arr[j];
                ++j;
            }
            ++k;
        }
        for (int i = l; i <= r; ++i)
        {
            arr[i] = buf[i];
        }

    }

    

    private static void QuickSort(ref string[] arr, int start, int end, int compare)
    {
        if (start < end)
        {
            int q = end;
            string x = arr[start];

            for (int i = start + 1; i <= q;)
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
            string buff = arr[start];
            arr[start] = arr[q];
            arr[q] = buff;
            
            QuickSort(ref arr, start, q - 1, compare);
            QuickSort(ref arr, q + 1, end, compare);
        }
    }

    public static void QuickSort(ref string[] arr,Order compare)
    {
        int compareInt=100;
        if (compare == Order.ASC)
        {
            compareInt = 1;
        }
        else if (compare == Order.DESC)
        {
            compareInt = -1;
        }

        QuickSort(ref arr, 0, arr.Length - 1, compareInt);
    }
    
}
