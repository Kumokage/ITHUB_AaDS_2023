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
            for (int k = arr.Length - 1 ; k >= 0; --k)
            {
                for (int i = 0; i < k; i++)
                {

                    if (order == Order.ASC)
                    {
                        if (arr[i].CompareTo(arr[i + 1]) < 0)
                        {
                            string temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = temp;
                        }
                        
                        
                    }
                    else if (order == Order.DESC)
                    {
                        if (arr[i].CompareTo(arr[i + 1]) > 0)
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
                        if (arr[i].CompareTo(arr[min]) < 0)
                        {
                            min = i;

                        }
                        
                    }
                    else if (order == Order.DESC)
                    {
                        if (arr[i].CompareTo(arr[min]) > 0)
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
                        while (minI >= 0 && arr[minI].CompareTo(min) < 0)
                        {
                            arr[minI + 1] = arr[minI];
                            minI--;


                        }

                        arr[minI + 1] = min;
                    }
                    else if (order == Order.DESC)
                        {
                            while (minI >= 0 && arr[minI].CompareTo(min) > 0)
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
            

            string[] buf = new string[arr.Length];
            Merge(ref arr, ref buf, 0, arr.Length - 1, order);
        }
        static void Merge(ref string[] arr, ref string[] buf, int l, int r, Order order)
        {
            if (l >= r)
                return;

        
            int m = (l + r) / 2;
            Merge(ref arr, ref buf, l, m, order);
            Merge(ref arr, ref buf, m + 1, r, order);

            
            int k = l;
            for (int i = l, j = m + 1; i <= m || j <= r;)
            {
                if (order == Order.ASC)
                {



                    if (j > r || (i <= m && string.Compare(arr[i], arr[j]) > 0))
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
                else
                {
                    if (j > r || (i <= m && string.Compare(arr[i], arr[j]) < 0))
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
            }

            for (int i = l; i <= r; ++i) {
                arr[i] = buf[i];
            }
        }
        

        public static void QuickSort(ref string[] arr, Order order)
        {
            
           QuickSort(ref arr, 0, arr.Length -1, order);
         
        }

        public static string[] QuickSort(ref string[] arr,  int l, int r, Order order)
        {

            int i = l;
            int j = r;
            string pivot = arr[l];

            while (i <= j)
            {
                if (order == Order.DESC)
                {


                    while (string.Compare(arr[i], pivot) < 0)
                    {
                        i++;
                    }
                    while (string.Compare(arr[j], pivot) > 0)
                    {
                        j--;
                    }
                }
                else
                {
                    while (string.Compare(arr[i], pivot) > 0)
                    {
                        i++;
                    }
                    while (string.Compare(arr[j], pivot) < 0)
                    {
                        j--;
                    }


                }

                if (i <= j)
                {
                    string temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                QuickSort(ref arr, l, j, order);
                
            }

            if (i < r)
                QuickSort(ref arr, i, r, order);
            return arr;
        }

         
    }
}