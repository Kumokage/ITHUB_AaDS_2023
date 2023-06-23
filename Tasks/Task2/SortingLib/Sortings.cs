using System.IO.Enumeration;
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
           int n = arr.Length;
           do
           {
            swapped = false;
            for(int i = 0; i < n -1; i++)
           }
        }

        public static void SelectSort(ref string[] arr, Order order)
        {
            throw new NotImplementedException();
        }

        public static void InsertSort(ref string[] arr, Order order)
        {
            throw new NotImplementedException();
        }

        public static void MergeSort(ref string[] arr, Order order)
        {
            throw new NotImplementedException();
        }

        public static void QuickSort(ref string[] arr, Order order)
        {
            Console.WriteLine("0");
        }
    }
}