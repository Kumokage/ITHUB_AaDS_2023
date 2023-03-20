using System;
using System.Diagnostics;

namespace DynamicArray
{
    class Program
    {
        static int N = 10;
        static int[] n = new int[]{1000, 10000, 50000};

        static Random rand = new Random(1);

        public static DArray FillArr(int count) {
            DArray arr = new DArray(count);
            
            for (int i = 0; i < count; ++i) {
                arr[i] = rand.Next(100);
            }

            return arr;
        }

        public static string[] TestLinearSearchAlgo()
        {
            string[] results = new string[n.Length];
            Stopwatch stopWatch = new Stopwatch();
            for(int current_n = 0; current_n < n.Length; ++current_n){
                DArray arr =  FillArr(n[current_n]);

                long count = 0;
                for( int i = 0; i < N; ++i) {
                    int index = rand.Next(n[current_n] + 1);
                    int value = arr[index];
                    stopWatch.Start();
                    arr.LinearSearch(value);
                    stopWatch.Stop();
                    count += stopWatch.Elapsed.Ticks;
                    stopWatch.Restart();
                    Console.WriteLine($"current_n = {current_n}, i = {i} " + stopWatch.Elapsed.Ticks);
                }

                count /= N;
                Console.WriteLine("count " + count);
                results[current_n] = count.ToString();
            }
            return results;
        }

        public static string[] TestBinarySearchAlgo()
        {
            string[] results = new string[n.Length];
            for(int current_n = 0; current_n < n.Length; ++current_n){
                DArray arr =  FillArr(n[current_n]);
                arr.Sort();

                long count = 0;
                for( int i = 0; i < N; ++i) {
                    int index = rand.Next(n[current_n] + 1);
                    int value = arr[index];
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    arr.BinarySearch(value);
                    stopWatch.Stop();
                    count += stopWatch.Elapsed.Ticks;
                }

                count /= N;
                results[current_n] = count.ToString();
            }
            return results;
        }

        public static string[] TestSortAlgo()
        {
            string[] results = new string[n.Length];
            for(int current_n = 0; current_n < n.Length; ++current_n){
                DArray arr =  FillArr(n[current_n]);

                long count = 0;
                for( int i = 0; i < N; ++i) {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    arr.Sort();
                    stopWatch.Stop();
                    count += stopWatch.Elapsed.Ticks;
                }

                count /= N;
                results[current_n] = count.ToString();
            }
            return results;
        }

        static void Main(string[] args)
        {
            string[] resultsLinear = TestLinearSearchAlgo();
            string[] resultsBinarySearch = TestBinarySearchAlgo();
            string[] resultsSort = TestSortAlgo();

            string buf = "n;LinearSearch;BinarySearch;Sort\n";
            for (int i = 0; i < n.Length; ++i) {
                buf += $"{n[i]};{resultsLinear[i]};{resultsBinarySearch[i]};{resultsSort[i]}\n";
            }

            File.WriteAllText("../AlgoTimeResults.csv", buf);
        }
    }
}
