using Sort_Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass.SortFunction
{
    public class SortFuncFactory
    {
        public static SortFunc Generate(SortType sortType)
        {
            SortFunc sortFunc = null;

            switch (sortType)
            {
                case SortType.Increase:
                    sortFunc = Increse;
                    break;
                case SortType.Decrease:
                    sortFunc = Decrease;
                    break;
            }

            return sortFunc;
        }

        // 小 -> 大  
        private static bool Increse(int after, int before)
        {
            // 前 > 後，則 True
            return before > after;
        }
        // 大 -> 小  
        private static bool Decrease(int after, int before)
        {
            // 後 > 前，則 True  
            return after > before;
        }
    }
}
