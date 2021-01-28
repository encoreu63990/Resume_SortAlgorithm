using Sort_Algorithm.UtilityClass.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.Algorithm
{
    public class MergeSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] array, SortFunc sortFunc)
        {
            MergeSort(array, 0, array.Length - 1, sortFunc);
        }

        private void MergeSort(int[] array, int start, int end, SortFunc sortFunc)
        {
            if (start < end)
            {
                // length = 3 
                // left         0 1
                // right        2
                // length = 4
                // left         0 1
                // right        2 3 
                MergeSort(array, start, (start + end) / 2, sortFunc);
                MergeSort(array, (start + end) / 2 + 1, end, sortFunc);
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
                if (sortFunc(array[right], array[left]))
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
    }
}
