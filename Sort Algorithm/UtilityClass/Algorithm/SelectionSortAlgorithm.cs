using Sort_Algorithm.UtilityClass.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.Algorithm
{
    public class SelectionSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] array, SortFunc sortFunc)
        {
            SelectionSort(array, sortFunc);
        }

        private void SelectionSort(int[] array, SortFunc sortFunc)
        {
            int i, j, index;
            for (i = 0; i < array.Length; i++)
            {
                index = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (sortFunc(array[j], array[index])) index = j;
                }
                if (index != i)
                {
                    int tmp = array[i];
                    array[i] = array[index];
                    array[index] = tmp;
                }
            }
        }
    }
}
