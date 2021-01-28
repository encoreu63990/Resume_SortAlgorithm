using System;
using System.Linq;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 999;
            int[] array = new int[length];
            int[] sorted = new int[length];
            GetArray(length, ref array, ref sorted);

            SelectionSort(ref array, new CompareFunc(Increse));
            sorted = sorted.OrderBy(c => c).ToArray();

            //SelectionSort(ref array, new CompareFunc(Decrease));
            //sorted = sorted.OrderByDescending(c => c).ToArray();

            Console.WriteLine("陣列是否相同: " + Compare(array, sorted));
            Console.ReadLine();
        }

        static int[] GetArray(int n, ref int[] array, ref int[] sorted)
        {
            for (int i = 0; i < n; i++)
            {
                array[i] = new Random().Next(-10000, 10000);
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
                if (array[i] != sorted[i]) return false;
            }
            return true;
        }

        static void SelectionSort(ref int[] array, CompareFunc compare)
        {
            int i, j, index;
            for (i = 0; i < array.Length; i++)
            {
                index = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[j],array[index])) index = j;
                }
                if (index != i)
                {
                    int tmp = array[i];
                    array[i] = array[index];
                    array[index] = tmp;
                }
            }
        }

        //  排大 or 小
        delegate bool CompareFunc(int after, int before);
        // 小 -> 大  
        static bool Increse(int after, int before)
        {
            // 前 > 後，則 True
            return before > after;
        }
        // 大 -> 小  
        static bool Decrease(int after, int before)
        {
            // 後 > 前，則 True  
            return after > before;
        }
    }
}
