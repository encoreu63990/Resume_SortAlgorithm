using System;
using System.Linq;
namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 99999;
            int[] array = new int[length];
            int[] sorted = new int[length];
            GetArray(length, ref array, ref sorted);

            //QuickSort(ref array, 0, array.Length - 1, new CompareFunc(Increse));
            //sorted = sorted.OrderBy(c => c).ToArray();

            QuickSort(ref array, 0, array.Length - 1, new CompareFunc(Decrease));
            sorted = sorted.OrderByDescending(c => c).ToArray();

            //DisplayArray(array, sorted);

            Console.WriteLine("陣列是否相同: " + Compare(array, sorted));
            Console.ReadLine();
        }

        static int[] GetArray(int n, ref int[] array, ref int[] sorted)
        {
            for (int i = 0; i < n; i++)
            {
                array[i] = new Random().Next(0, 100000);
                sorted[i] = array[i];
            }
            return array;
        }

        static bool Compare(int[] array, int[] sorted)
        {
            if (array.Length != sorted.Length)
                return false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != sorted[i])
                {
                    Console.WriteLine("陣列位置: " + i + "  不相同");
                    return false;
                }
            }
            return true;
        }

        static void QuickSort(ref int[] array, int start, int end, CompareFunc compare)
        {
            if (start >= end) return;

            int left = start - 1;
            int right = 0;
            int pivot = array[end];
            int tmp;
            for (right = start; right < end; right++)
            {
                if (compare(array[right], pivot))
                {
                    left++;
                    tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;
                }
            }

            tmp = array[left + 1];
            array[left + 1] = array[end];
            array[end] = tmp;

            QuickSort(ref array, start, left, compare);
            QuickSort(ref array, left + 1, end, compare);
        }

        //  排大 or 小
        delegate bool CompareFunc(int after, int before);
        // 小 -> 大  
        static bool Increse(int after, int before)
        {
            // 前 > 後，則 True
            return before >= after;
        }
        // 大 -> 小  
        static bool Decrease(int after, int before)
        {
            // 後 > 前，則 True  
            return after >= before;
        }

        static void DisplayArray(int[] array, int[] sorted)
        {
            //return;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(sorted[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
