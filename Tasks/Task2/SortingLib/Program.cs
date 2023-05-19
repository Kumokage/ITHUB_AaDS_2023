using System;

namespace SortingLib
{
    class Program 
    {
        public static void Main(string[] args)
        {
            string[] arr = { "Misha", "Alena", "Sasha" };
            Sortings.InsertSort(ref arr, Order.ASC);
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
