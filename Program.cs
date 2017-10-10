using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class Program
    {
        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int arrayMiddle = array.Length / 2;
            return Merge(MergeSort(array.Take(arrayMiddle).ToArray()), MergeSort(array.Skip(arrayMiddle).ToArray()));
        }
        static int[] InsertionSort(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && result[j - 1] > array[i])
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = array[i];
            }
            return result;
        }
        static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                  if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

        static void printArr(int[] arr)
        {
            foreach (int x in arr)
                Console.Write(x + " ");
        }

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("Enter array length: ");
            string length = Console.ReadLine();
            int a = Convert.ToInt32(length);
            int[] arr = new int[a];

            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, a + 1);
            }
            if (a > 10)
            {
                Console.WriteLine("Merge sorting {0} elements", a);
                timer.Start(); // start timer
                arr = MergeSort(arr);
                timer.Stop(); // stop timer
                //printArr(arr);
            }
            else
            {
                Console.WriteLine("Insertion sorting {0} elements",a);
                timer.Start(); // start timer
                arr = InsertionSort(arr);
                timer.Stop(); // stop timer
                printArr(arr);
            }
            Console.WriteLine("\n\nSorting time of {1} elements: {0}", (timer.ElapsedMilliseconds / 100.0).ToString(), a);
            Console.ReadLine();
        }
    }
}
