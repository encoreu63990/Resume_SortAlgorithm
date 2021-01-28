using System;
using System.Linq;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 999;
            int[] array = new int[length];
            int[] sorted = new int[length];
            GetArray(length, ref array, ref sorted);

            // 大 -> 小
            //MergeSort(ref array, 0, array.Length - 1, new CompareFunc(Decrease));
            //sorted = sorted.OrderByDescending(c => c).ToArray();
            // 小 -> 大
            MergeSort(ref array, 0, array.Length - 1, new CompareFunc(Increse));
            sorted = sorted.OrderBy(c => c).ToArray();
           
            Console.WriteLine("陣列是否相同: " + Compare(array, sorted));
            Console.ReadLine();
        }

        static int[] GetArray(int n, ref int[] array, ref int[] sorted)
        {
            for (int leftPoint = 0; leftPoint < n; leftPoint++)
            {
                array[leftPoint] = new Random().Next(-10000, 10000);
                sorted[leftPoint] = array[leftPoint];
            }
            return array;
        }

        static bool Compare(int[] array, int[] sorted)
        {
            if (array.Length != sorted.Length)
                return false;
            for (int leftPoint = 0; leftPoint < array.Length; leftPoint++)
            {
                if (array[leftPoint] != sorted[leftPoint]) return false;
            }
            return true;
        }

        static void MergeSort(ref int[] array, int start, int end, CompareFunc compare)
        {
            if (start < end)
            {
                // length = 3 
                // left         0 1
                // right        2
                // length = 4
                // left         0 1
                // right        2 3 
                MergeSort(ref array, start, (start + end) / 2, compare);
                MergeSort(ref array, (start + end) / 2 + 1, end, compare);
            }
            else return;
            // 符合 end > start 排序條件
            // 排序好的為 
            // start  to  (start + end) / 2
            // (start + end) / 2  to  end
            int left = start;
            int right = (start + end) / 2 + 1;

            int leftLast = (start + end) / 2;
            int rightLast = end;

            int offset = 0;
            int[] tmp = new int[end - start + 1];
            while (true)
            {
                if (left > leftLast && right > rightLast)
                {
                    break;
                }
                else if (left > leftLast)
                {
                    // 左邊出界
                    tmp[offset++] = array[right++];
                    continue;
                }
                else if (right > rightLast)
                {
                    // 右邊出界
                    tmp[offset++] = array[left++];
                    continue;
                }
                // 符合
                if (compare(array[right], array[left]))
                {
                    tmp[offset++] = array[right++];
                }
                else
                {
                    tmp[offset++] = array[left++];
                }
            }

            //Console.Write("排序前左邊: ");
            //for (int i = start; i <= leftLast; i++)
            //    Console.Write(array[i] + "  ");

            //Console.Write("\n排序前右邊: ");
            //for (int i = leftLast + 1; i <= end; i++)
            //    Console.Write(array[i] + "  ");

            //Console.Write("\n排序結果: ");
            //for (int i = 0; i < tmp.Count(); i++)
            //    Console.Write(tmp[i] + "  ");

            //Console.WriteLine("\n");

            for (int i = 0; i < tmp.Length; i++)
            {
                array[i + start] = tmp[i];
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
