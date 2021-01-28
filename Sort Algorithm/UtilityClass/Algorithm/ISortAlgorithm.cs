using Sort_Algorithm.Model;
using Sort_Algorithm.UtilityClass.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.Algorithm
{
    public interface ISortAlgorithm
    {
        void Sort(int[] array, SortFunc sortFunc);
    }
}
