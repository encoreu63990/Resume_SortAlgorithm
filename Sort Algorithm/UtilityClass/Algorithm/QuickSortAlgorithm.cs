using Sort_Algorithm.UtilityClass.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.Algorithm
{
    public class QuickSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] array, SortFunc sortFunc)
        {
            QuickSort(array, 0, array.Length - 1, sortFunc);
        }

        private void QuickSort(int[] array, int start, int end, SortFunc sortFunc)
        {
            if (start >= end) return;

            int left = start - 1;
            int right = 0;
            int pivot = array[end];
            int tmp;
            for (right = start; right < end; right++)
            {
                if (sortFunc(array[right], pivot))
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

            QuickSort(array, start, left, sortFunc);
            QuickSort(array, left + 1, end, sortFunc);
        }
    }
}
