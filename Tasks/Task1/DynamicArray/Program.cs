using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace DynamicArray
{
    class Program
    {
        public delegate int SearchDel(int value);
        public delegate void SortDel();

        public static string TestSearchAlgo(SearchDel algo, int size)
        {
            double _tickAverage = 0;
            for (int j = 0; j <= 1000; j++)
            {
                Stopwatch stopWatch = new Stopwatch();
                int a = new Random().Next(size);
                stopWatch.Start();
                algo(a);
                stopWatch.Stop();
                _tickAverage += stopWatch.Elapsed.Ticks;
            }

            _tickAverage /= 1000;

            return Convert.ToString(_tickAverage);
        }

        public static string TestSortAlgo(SortDel algo)
        {
            double _tickAverage = 0;
            for (int j = 0; j <= 100; j++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                algo();
                stopWatch.Stop();
                _tickAverage += stopWatch.Elapsed.Ticks;
            }
            _tickAverage /= 1000;

            return Convert.ToString(_tickAverage);
        }

        static void Main(string[] args)
        {

            DArray test_arr = new DArray();
            string[] _linearSearhResult = new string[50];
            string[] _binarySearhResult = new string[50];
            string[] _sortResult = new string[50];

            int index = 0;
            for (int i = 100; i <= 5000; i += 100)
            {

                for (int j = 0; j < i; j++)
                {
                    test_arr.Insert(j);
                }

                test_arr.Sort();

                _linearSearhResult[index] = TestSearchAlgo(test_arr.LinearSearch, i);
                _binarySearhResult[index] = TestSearchAlgo(test_arr.BinarySearch, i);
                ++index;

            }

            index = 0;
            for (int i = 100; i <= 5000; i += 100)
            {

                for (int j = 0; j < i; j++)
                {
                    test_arr.Insert(new Random().Next(i), j);
                }

                _sortResult[index] = TestSortAlgo(test_arr.Sort);
                ++index;
            }

            var sw = new StreamWriter("AlgoTimeResults.csv");
            sw.WriteLine("n;LinearSearh;BinarySearh;MergeSort");
            for (int i = 0; i < _linearSearhResult.Length; i++)
            {
                sw.WriteLine(100 * (i + 1) + ";" + _linearSearhResult[i] + ";" + _binarySearhResult[i] + ";" + _sortResult[i]);
            }
            sw.Close();
        }
    }
}
