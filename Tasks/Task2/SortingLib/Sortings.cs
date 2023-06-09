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
        int compare = 0;
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
                if (String.Compare(arr[i], arr[max]) == compare)               
                    max = i;
            }
            string temp = arr[arr.Length - k - 1];
            arr[arr.Length - k - 1] = arr[max];
            arr[max] = temp;
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



    private static void MergeSort(ref string[] arr, ref string[] buf, int l, int r, int compare)
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
    }

    public static void MergeSort(ref string[] arr, Order order)
    {
        
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
    }
    private static void QuickSort(ref string[] arr, int start, int end, int compare)
    {

    }
    
    }
   
}
