using System.Linq;
using System.Reflection;
using System;
using SortingLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingLib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const int N = 10;
        private Random random = new Random();

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string[] CreateRandomArr()
        {
            string[] arr = new string[N];
            for (int i = 0; i < N; ++i)
            {
                arr[i] = RandomString(random.Next(1, 20));
            }

            return arr;
        }

        [TestMethod]
        public void TestBubleSortASC()
        {
            string[] arr = CreateRandomArr();
            Sortings.BubleSort(ref arr, Order.ASC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) >= 0);
            }
        }

        [TestMethod]
        public void TestBubleSortDESC()
        {
            string[] arr = CreateRandomArr();
            Sortings.BubleSort(ref arr, Order.DESC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void TestSelectSortASC()
        {
            string[] arr = CreateRandomArr();
            Sortings.SelectSort(ref arr, Order.ASC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) >= 0);
            }
        }

        [TestMethod]
        public void TestSelectSortDESC()
        {
            string[] arr = CreateRandomArr();
            Sortings.SelectSort(ref arr, Order.DESC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void TestInsertSortASC()
        {
            string[] arr = CreateRandomArr();
            Sortings.InsertSort(ref arr, Order.ASC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) >= 0);
            }
        }

        [TestMethod]
        public void TestInsertSortDESC()
        {
            string[] arr = CreateRandomArr();
            Sortings.InsertSort(ref arr, Order.DESC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void TestMergeSortASC()
        {
            string[] arr = CreateRandomArr();
            Sortings.MergeSort(ref arr, Order.ASC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) >= 0);
            }
        }

        [TestMethod]
        public void TestMergeSortDESC()
        {
            string[] arr = CreateRandomArr();
            Sortings.MergeSort(ref arr, Order.DESC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void TestQuickSortASC()
        {
            string[] arr = CreateRandomArr();
            Sortings.QuickSort(ref arr, Order.ASC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) >= 0);
            }
        }

        [TestMethod]
        public void TestQuickSortDESC()
        {
            string[] arr = CreateRandomArr();
            Sortings.QuickSort(ref arr, Order.DESC);

            for (int i = 0; i < N - 1; ++i)
            {
                Assert.IsTrue(arr[i].CompareTo(arr[i + 1]) <= 0);
            }
        }


    }
}