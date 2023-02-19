using System.Reflection;
using System;
using DynamicArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicArrayTest
{
    [TestClass]
    public class UnitArrayTest
    {
        [TestMethod]
        public void TestIndexer()
        {
            int[] test_arr = new int[] { 1, 2, 4, 5 };
            DArray arr = new DArray(test_arr);

            Assert.AreEqual(arr[2], 4);
            Assert.AreEqual(arr[0], 1);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr[-1]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr[5]);
        }

        [TestMethod]
        public void TestLength()
        {
            int[] test_arr = new int[] { 1, 2, 4, 5 };
            DArray arr = new DArray(test_arr);
            Assert.AreEqual(arr.Length, 4);

            arr = new DArray();
            Assert.AreEqual(arr.Length, 0);

            arr = new DArray(6);
            Assert.AreEqual(arr.Length, 6);
        }

        [TestMethod]
        public void TestInsert()
        {
            int[] test_arr = new int[]{1, 2, 4, 5};
            DArray arr = new DArray(test_arr);
            arr.Insert(3, 2);
            
            Assert.AreEqual(arr[2], 3);
            
            arr.Insert(6);
            Assert.AreEqual(arr[5], 6);
            
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr.Insert(10, 9));
            Assert.ThrowsException<IndexOutOfRangeException>(() => arr.Insert(10, -2));
        }

        [TestMethod]
        public void TestRemove()
        {
            int[] test_arr = new int[] { 1, 2, 3, 4, 5 };
            DArray arr = new DArray(test_arr);
            arr.Remove(2);

            Assert.AreEqual(arr[1], 2);
            Assert.AreEqual(arr[2], 4);
            Assert.AreEqual(arr[3], 5);
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            int[] test_arr = new int[] { 1, 3, 8, 13, 19, 55, 108 };
            DArray arr = new DArray(test_arr);

            Assert.AreEqual(arr.BinarySearch(13), 3);
            Assert.AreEqual(arr.BinarySearch(108), 6);
            Assert.AreEqual(arr.BinarySearch(1), 0);

            Assert.ThrowsException<ArgumentException>(() => arr.BinarySearch(4));
            Assert.ThrowsException<ArgumentException>(() => arr.BinarySearch(-1));

            test_arr = new int[] { 108, 1, 8, 3, 13, 19, 55 };
            arr = new DArray(test_arr);
            Assert.ThrowsException<ArgumentException>(() => arr.BinarySearch(8));
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            int[] test_arr = new int[] { 108, 1, 8, 3, 13, 19, 55 };
            DArray arr = new DArray(test_arr);

            Assert.AreEqual(arr.LinearSearch(3), 3);
            Assert.AreEqual(arr.LinearSearch(108), 0);
            Assert.AreEqual(arr.LinearSearch(55), 6);

            Assert.ThrowsException<ArgumentException>(() => arr.LinearSearch(4));
            Assert.ThrowsException<ArgumentException>(() => arr.LinearSearch(-1));
        }

        [TestMethod]
        public void TestSort()
        {
            int[] test_arr = new int[] { 108, 3, 8, 13, 55, 19, 1 };
            int[] test_arr_sorted = new int[] { 1, 3, 8, 13, 19, 55, 108 };

            DArray arr = new DArray(test_arr);
            arr.Sort();

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], test_arr_sorted[i]);
            }
        }
    }
}