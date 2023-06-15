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
            string _buf;
            if (order == Order.ASC)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int k = 0; k < arr.Length - 1; k++)
                    {
                        if (string.Compare(arr[k], arr[k + 1]) < 0)
                        {
                            _buf = arr[k + 1];
                            arr[k + 1] = arr[k];
                            arr[k] = _buf;
                        }
                    }
                }
            }
            else if (order == Order.DESC)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int k = 0; k < arr.Length - 1; k++)
                    {
                        if (string.Compare(arr[k], arr[k + 1]) > 0)
                        {
                            _buf = arr[k + 1];
                            arr[k + 1] = arr[k];
                            arr[k] = _buf;
                        }
                    }
                }
            }
        }

        public static void SelectSort(ref string[] arr, Order order)
        {
            int _index = 0;
            string _buf;
            if (order == Order.ASC)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    _buf = arr[i];
                    _index = i;
                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        if (string.Compare(arr[k], arr[_index]) > 0)
                        {
                            _index = k;
                        }
                    }
                    if (_index != i)
                    {
                        arr[i] = arr[_index];
                        arr[_index] = _buf;
                    }
                }
            }
            else if (order == Order.DESC)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    _buf = arr[i];
                    _index = i;
                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        if (string.Compare(arr[k], arr[_index]) < 0)
                        {
                            _index = k;
                        }
                    }
                    if (_index != i)
                    {
                        arr[i] = arr[_index];
                        arr[_index] = _buf;
                    }
                }
            }
        }

        public static void InsertSort(ref string[] arr, Order order)
        {
             int j = 0;
            string x = "0";
            if (order == Order.ASC)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    x = arr[i];
                    j = i;
                    while (j > 0 && string.Compare(arr[j - 1], x) < 0)
                    {
                        arr[j] = arr[j - 1];
                        j = j - 1;
                    }
                    arr[j] = x;
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    x = arr[i];
                    j = i;
                    while (j > 0 && string.Compare(arr[j - 1], x) > 0)
                    {
                        arr[j] = arr[j - 1];
                        j = j - 1;
                    }
                    arr[j] = x;
                }
            }
        }

        public static void MergeSort(ref string[] arr, Order order)
        {
            if(order == Order.DESC)
            {
                if (arr.Length == 0)
                return;
                string[] buf = new string[arr.Length];
            MergeDESC(ref arr, ref buf, 0, arr.Length - 1);
            }
            else
            {
                if (arr.Length == 0)
                return;

            string[] buf = new string[arr.Length];
            MergeAESC(ref arr, ref buf, 0, arr.Length - 1);
            }
        }
         public static void MergeDESC(ref string[] arr, ref string[] buf, int l, int r) 
        {
                if (l >= r)
                    return;
                int m = (l + r) / 2;
                MergeDESC(ref arr, ref buf, l, m);
                MergeDESC(ref arr, ref buf, m + 1, r);
                int k = l;
                for (int i = l, j = m + 1; i <= m || j <= r; ) {
                    if (j > r ||  (i <= m && string.Compare(arr[i],arr[j]) < 0)) 
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
        public static void MergeAESC(ref string[] arr, ref string[] buf, int l, int r)
        {
                if (l >= r)
                    return;            
                int m = (l + r) / 2;
                MergeAESC(ref arr, ref buf, l, m);
                MergeAESC(ref arr, ref buf, m + 1, r);

                // Merge
                int k = l;
                for (int i = l, j = m + 1; i <= m || j <= r; ) {
                    if (j > r||  (i <= m && string.Compare(arr[i],arr[j]) > 0)) {
                        buf[k] = arr[i];
                        ++i;
                    }
                    else {
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
         public static void QuickSort(ref string[] arr, Order order)
        {
            if(order == Order.ASC)
            {
               
                QuickSortAEC(ref arr,0,arr.Length-1);
               // QuickSortAEC(ref arr, Order.ASC,0,0);
            }
            else{
                QuickSortDESC(ref arr,0,arr.Length-1);
            }
            
            
        }
        private static void QuickSortAEC(ref string[]arr, int l, int r)
        {
             if(l<r)
                {
                int q = r;
                string x = arr[l];
                for(int i = l +1; i <= q;)
                {
                    if(string.Compare(arr[i],x)<0)
                    {
                        string buf_1 = arr[i];
                        arr[i] = arr[q];
                        arr[q] = buf_1;
                        --q;
                    }
                    else
                    {
                        ++i;
                    }
                }
                string buf = arr[q];
                arr[q] = arr[l];
                arr[l] = buf;

                QuickSortAEC(ref arr, l, q - 1);
            QuickSortAEC(ref arr, q + 1, r);
        }
         
        }
        private static void QuickSortDESC(ref string[]arr, int l, int r)
        {
             if(l<r)
                {
                int q = r;
                string x = arr[l];
                for(int i = l +1; i <= q;)
                {
                    if(string.Compare(arr[i],x)>0)
                    {
                        string buf_1 = arr[i];
                        arr[i] = arr[q];
                        arr[q] = buf_1;
                        --q;
                    }
                    else
                    {
                        ++i;
                    }
                }
                string buf = arr[q];
                arr[q] = arr[l];
                arr[l] = buf;

                QuickSortDESC(ref arr, l, q - 1);
            QuickSortDESC(ref arr, q + 1, r);
        }
         
        }
    }
}