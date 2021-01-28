using Sort_Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.Algorithm
{
    public class SortAlogrithmFactory
    {
        public static ISortAlgorithm Generate(AlgorithmName algorithmName)
        {
            ISortAlgorithm sortAlgorithm = null;

            switch (algorithmName)
            {
                case AlgorithmName.MergeSort:
                    sortAlgorithm = new MergeSortAlgorithm();
                    break;
                case AlgorithmName.QuickSort:
                    sortAlgorithm = new QuickSortAlgorithm();
                    break;
                case AlgorithmName.SelectionSort:
                    sortAlgorithm = new SelectionSortAlgorithm();
                    break;
            }

            return sortAlgorithm;
        }
    }
}
