// See https://aka.ms/new-console-template for more information
using System.IO;
using Lesson3;

int[] test = { 17, 15, 1, 76, 13, 14, 9, 48, 2, 21 };

Sorting.MergeSort(ref test);

for (int i = 0; i < test.Length; i++)
{
    Console.WriteLine(test[i]);
}