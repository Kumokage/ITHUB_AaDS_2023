using System;
using System.Diagnostics;
using System.IO;

namespace SortingLib
{
    class Program
    {
        static int N = 400;
        static int[] n = new int[] { 100, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000 };

        static Random rand = new Random(1);

        delegate void Sort(ref string[] arr, Order order);

        private static string[] TestSortAlgo(Sort sort)
        {
            string[] results = new string[n.Length];
            for (int current_n = 0; current_n < n.Length; ++current_n)
            {
                string[] arr = CreateRandomArr(n[current_n]);

                long count = 0;
                for (int i = 0; i < N; ++i)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    sort(ref arr, Order.ASC);
                    stopWatch.Stop();
                    count += stopWatch.Elapsed.Ticks;
                }

                count /= N;
                results[current_n] = count.ToString();
            }
            return results;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        private static string[] CreateRandomArr(int length)
        {
            string[] arr = new string[length];
            for (int i = 0; i < N; ++i)
            {
                arr[i] = RandomString(length);
            }

            return arr;
        }

        static void Main(string[] args)
        {
            string[] resultsBuble = TestSortAlgo(Sortings.BubleSort);
            string[] resultsSelect = TestSortAlgo(Sortings.SelectSort);
            string[] resultsInsert = TestSortAlgo(Sortings.InsertSort);
            string[] resultsMerge = TestSortAlgo(Sortings.MergeSort);
            string[] resultsQuick = TestSortAlgo(Sortings.QuickSort);

            string buf = "n;BubleSort;SelectSort;InsertSort;MergeSort;QuickSort\n";
            for (int i = 0; i < n.Length; ++i)
            {
                buf += $"{n[i]};{resultsBuble[i]};{resultsSelect[i]};{resultsInsert[i]};{resultsMerge[i]};{resultsQuick[i]}\n";
            }

            File.WriteAllText("../AlgoTimeResults.csv", buf);
        }
    }
}