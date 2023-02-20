using System;
using System.Diagnostics;
using System.IO;

namespace DynamicArray
{
    class Program
    {
        public delegate int SearchDel(int value);
        public delegate void SortDel();

        public static double TestSearchAlgo(SearchDel algo, int N, int searchNumber)
        {
            Stopwatch stopWatch = new Stopwatch();
            long[] deltas = new long[N];
            for (int i = 0; i < N; i++)
            {
                stopWatch.Start();
                algo(searchNumber);
                stopWatch.Stop();
                deltas[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            return deltas.Average();
        }

        public static double TestSortAlgo(SortDel algo, int N) 
        {
            Stopwatch stopWatch = new Stopwatch();
            long[] deltas = new long[N];
            for (int i = 0; i < N; i++)
            {
                stopWatch.Start();
                algo();
                stopWatch.Stop();
                deltas[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            return deltas.Average();
        }

        static void Main(string[] args)
        {
            int N = 1000; // repeats
            int min = 0;
            int max = 10000;

            double avgSort, avgSearchLinear, avgSearchBinary;
            int[] arr;


            string fileName = "AlgoTimeResults.csv";
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine("n,LinearSearch,BinarySearch,Sort");
            }

            for (int n = 500; n < 10000; n += 500)
            {
                arr = FillWithRandom(min, max, n);
                DArray testArrSort = new DArray(arr);
                avgSort = TestSortAlgo(testArrSort.Sort, N);

                arr = FillWithRandom(min, max, n);
                int searchNumber = arr[n/2]; // the number we are searching we take from middle of array
                DArray testArrSearch = new DArray(arr);
                testArrSearch.Sort();
                avgSearchLinear = TestSearchAlgo(testArrSearch.LinearSearch, N, searchNumber);
                avgSearchBinary = TestSearchAlgo(testArrSearch.BinarySearch, N, searchNumber);

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine($"{n},{avgSearchLinear},{avgSearchBinary},{avgSort}");
                }
            }


        }

        private static int[] FillWithRandom(int min, int max, int n)
        {
            int[] arr = new int[n];
            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(min, max);
            }

            return arr;
        }
    }
}

