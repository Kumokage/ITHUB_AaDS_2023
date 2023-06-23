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
            for (int k = arr.Length - 1; k >= 0; --k)
            {
                for (int i = 0; i < k; i++)
                {
                    if (order == Order.ASC)
                    {
                        if (arr[i].CompareTo(arr[i + 1]) > 0)
                        {
                            string temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = temp;
                        }
                    }
                    else if (order == Order.DESC)
                    {
                        if (arr[i].CompareTo(arr[i + 1]) < 0)
                        {
                            string temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = temp;
                        }
                    }
                }
            }
        }

        public static void SelectSort(ref string[] arr, Order order)
        {
            int min;

            for (int k = 0; k < arr.Length; k++)
            {
                min = 0;
                for (int i = 1; i < arr.Length - k; i++)
                {
                    if (order == Order.ASC)
                    {
                        if (arr[i].CompareTo(arr[min]) > 0)
                        {
                            min = i;
                        }
                    }
                    else if (order == Order.DESC)
                    {
                        if (arr[i].CompareTo(arr[min]) < 0)
                        {
                            min = i;
                        }
                    }
                }
                string temp = arr[arr.Length - k - 1];
                arr[arr.Length - k - 1] = arr[min];
                arr[min] = temp;
            }
        }

        public static void InsertSort(ref string[] arr, Order order)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                string min = arr[i];
                int minI = i - 1;
                if (order == Order.ASC)
                {
                    while (minI >= 0 && arr[minI].CompareTo(min) > 0)
                    {
                        arr[minI + 1] = arr[minI];
                        minI--;
                    }
                    arr[minI + 1] = min;
                }
                else if (order == Order.DESC)
                {
                    while (minI >= 0 && arr[minI].CompareTo(min) < 0)
                    {
                        arr[minI + 1] = arr[minI];
                        minI--;
                    }
                    arr[minI + 1] = min;
                }
            }
        }

        public static void MergeSort(ref string[] arr, Order order)
        {
            throw new NotImplementedException();
        }
        static void Merge(int[] a, int l, int m, int r)
        {
            int i, j, k;

            int n1 = m - l + 1;
            int n2 = r - m;

            int[] left = new int[n1 + 1];
            int[] right = new int[n2 + 1];

            for (i = 0; i < n1; i++)
            {
                left[i] = a[l + i];
            }

            for (j = 1; j <= n2; j++)
            {
                right[j - 1] = a[m + j];
            }

            left[n1] = int.MaxValue;
            right[n2] = int.MaxValue;

            i = 0;
            j = 0;

            for (k = l; k <= r; k++)
            {
                if (left[i] < right[j])
                {
                    a[k] = left[i];
                    i = i + 1;
                }
                else
                {
                    a[k] = right[j];
                    j = j + 1;
                }
            }
        }
    }
}