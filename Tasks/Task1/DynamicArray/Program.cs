//using System;
//using System.Diagnostics;

//namespace DynamicArray
//{
//    class Program
//    {
//        public delegate int SearchDel(int value);
//        public delegate void SortDel();

//        public static string[] TestSearchAlgo(SearchDel algo)
//        {
//            int[] n = { 1000, 10000, 50000 };
//            int N = 10;

//            string[] results = new string[n.Length + 1];
//            results[0] = "n\tLinearSearch\tBinarySearch";

//            for (int i = 0; i < n.Length; i++)
//            {
//                long totalTicksLinearSearch = 0;
//                long totalTicksBinarySearch = 0;

//                for (int j = 0; j < N; j++)
//                {
//                    DArray testArray = new DArray(n[i]);
//                    Stopwatch stopwatch = new Stopwatch();
//                    stopwatch.Start();
//                    algo.Invoke(42);
//                    stopwatch.Stop();

//                    if (algo == testArray.LinearSearch)
//                        totalTicksLinearSearch += stopwatch.ElapsedTicks;
//                    else if (algo == testArray.BinarySearch)
//                        totalTicksBinarySearch += stopwatch.ElapsedTicks;
//                }

//                double averageTicksLinearSearch = (double)totalTicksLinearSearch / N;
//                double averageTicksBinarySearch = (double)totalTicksBinarySearch / N;

//                results[i + 1] = $"{n[i]}\t{averageTicksLinearSearch}\t{averageTicksBinarySearch}";
//            }

//            return results;
//        }

//        public static string[] TestSortAlgo(SortDel algo)
//        {
//            int[] n = { 1000, 10000, 50000 };
//            int N = 10;

//            string[] results = new string[n.Length + 1];
//            results[0] = "n\tSort";

//            for (int i = 0; i < n.Length; i++)
//            {
//                long totalTicksSort = 0;

//                for (int j = 0; j < N; j++)
//                {
//                    DArray testArray = new DArray(n[i]);
//                    Stopwatch stopwatch = new Stopwatch();
//                    stopwatch.Start();
//                    algo.Invoke();
//                    stopwatch.Stop();
//                    totalTicksSort += stopwatch.ElapsedTicks;
//                }

//                double averageTicksSort = (double)totalTicksSort / N;

//                results[i + 1] = $"{n[i]}\t{averageTicksSort}";
//            }

//            return results;
//        }

//        static void Main(string[] args)
//        {
//            string[] searchResults = TestSearchAlgo((value) =>
//            {
//                DArray testArray = new DArray();
//                return testArray.LinearSearch(value);
//            });

//            string[] sortResults = TestSortAlgo(() =>
//            {
//                DArray testArray = new DArray();
//                testArray.Sort();
//            });

//            string[] finalResults = CombineResults(searchResults, sortResults);

//            WriteResultsToCSV(finalResults);
//        }

//        public static string[] CombineResults(string[] searchResults, string[] sortResults)
//        {
//            if (searchResults.Length != sortResults.Length)
//                throw new ArgumentException("The lengths of searchResults and sortResults do not match.");

//            string[] combinedResults = new string[searchResults.Length];

//            for (int i = 0; i < combinedResults.Length; i++)
//                combinedResults[i] = searchResults[i] + "\t" + sortResults[i];

//            return combinedResults;
//        }

//        public static void WriteResultsToCSV(string[] results)
//        {
//            string filename = "AlgoTimeResults.csv";
//            using (StreamWriter writer = new StreamWriter(filename))
//            {
//                foreach (string result in results)
//                {
//                    writer.WriteLine(result);
//                }
//            }

//            Console.WriteLine($"Results saved to {filename}");
//        }
//    }
//}

using System;
using System.Diagnostics;

namespace DynamicArray
{
    class Program
    {
        static int N = 10;
        static int[] n = new int[] { 1000, 10000, 50000 };

        static Random rand = new Random(1);

        public static DArray FillArr(int count)
        {
            DArray arr = new DArray(count);

            for (int i = 0; i < count; ++i)
            {
                arr[i] = rand.Next(100);
            }

            return arr;
        }

        public static string[] TestSearchAlgo(Func<DArray, int, long> searchFunc)
        {
            string[] results = new string[n.Length];

            for (int current_n = 0; current_n < n.Length; ++current_n)
            {
                DArray arr = FillArr(n[current_n]);

                long count = 0;
                for (int i = 0; i < N; ++i)
                {
                    int index = rand.Next(n[current_n] + 1);
                    int value = arr[index];

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    searchFunc(arr, value);
                    stopWatch.Stop();

                    count += stopWatch.Elapsed.Ticks;
                }

                count /= N;
                results[current_n] = count.ToString();
            }

            return results;
        }

        public static long LinearSearch(DArray arr, int value)
        {
            return arr.LinearSearch(value);
        }

        public static long BinarySearch(DArray arr, int value)
        {
            arr.Sort();
            return arr.BinarySearch(value);
        }

        public static string[] TestSortAlgo()
        {
            string[] results = new string[n.Length];

            for (int current_n = 0; current_n < n.Length; ++current_n)
            {
                DArray arr = FillArr(n[current_n]);

                long count = 0;
                for (int i = 0; i < N; ++i)
                {
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
            Console.WriteLine($"Start saving...");
            string[] resultsLinear = TestSearchAlgo(LinearSearch);
            string[] resultsBinarySearch = TestSearchAlgo(BinarySearch);
            string[] resultsSort = TestSortAlgo();

            string buf = "n;LinearSearch;BinarySearch;Sort\n";
            for (int i = 0; i < n.Length; ++i)
            {
                buf += $"{n[i]};{resultsLinear[i]};{resultsBinarySearch[i]};{resultsSort[i]}\n";
            }

            File.WriteAllText("../AlgoTimeResults.csv", buf);
            Console.WriteLine($"Results saved");
        }
    }
}
