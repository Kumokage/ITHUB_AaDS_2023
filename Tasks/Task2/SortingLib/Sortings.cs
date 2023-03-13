using System;
namespace SortingLib
{

    public enum Order
    {
        ASC,
        DESC
    }

    Matvey Filchagin, [13.03.2023 7:18]
public static void BubleSort(ref string[] arr, Order order)
    {
        int compare;
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
        int compare;
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
                if (arr[i] > arr[max])
                    max = i;
            }


            int temp = arr[arr.Length - k - 1];
            arr[arr.Length - k - 1] = arr[max];
            arr[max] = temp;
        }
    }

    public static void InsertSort(ref string[] arr, Order order)
    {
        int compare;
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

        for (int i = 1; i < inArray.Length; i++)
        {
            x = inArray[i];
            j = i;
            while (j > 0 && (string.Compare(inArray[j - 1], x)) == compare)
            {
                string temp = arr[j];
                arr[j] = arr[j - 1];
                arr[j - 1] = temp;
                j -= 1;

            }
            inArray[j] = x;
        }
    }



    private static void MergeSort(ref string[] arr, ref string[] buf, int l, int r, int compare)
    {
        if (l >= r)
            return;



        int m = (l + r) / 2;
        MergeSort(ref arr, ref buf, l, m);
        MergeSort(ref arr, ref buf, m + 1, r);


        int k = l;
        for (int i = l, j = m + 1; i <= m  j <= r;)
        {
            if (j > r(i <= m && string.Compare(arr[i], arr[j]) == compare))
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

    public static void MergeSort(ref string[] arr, Order order)
    {
        if (arr.Length == 0)
            return;

        int compare;
        if (order == Order.ASC)
        {
            compare = -1;
        }
        else if (order = Order.DESC)
        {
            compare = 1;
        }
        string[] buf = new string[arr.Length];
        MergeSort(ref arr, ref buf, 0, arr.Length - 1, compare);
    }



    public static void QuickSort(ref string[] arr)
    {
        int compare;

        if (compare == Order.ASC)
        {
            compare = 1;
        }
        else if (compare == Order.DESC)
        {
            compare = -1;
        }

        QuickSort(ref arr, 0, arr.Length - 1, compare);
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
}
}