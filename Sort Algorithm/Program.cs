using Sort_Algorithm.Model;
using Sort_Algorithm.UtilityClass;
using Sort_Algorithm.UtilityClass.Algorithm;
using Sort_Algorithm.UtilityClass.SortFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm
{
    static class Program
    {
        static void Main(string[] args)
        {
            // 定義陣列大小
            const int arrayLength = 999;
            // 定義排序演算法、排序方式
            const AlgorithmName algorithmName = AlgorithmName.QuickSort;
            const SortType sortType = SortType.Increase;

            // 取得亂數陣列陣列
            var array = RandomArrayGenerator.Generate(arrayLength);

            // 複製陣列，後續用來預設判斷排序是否正確
            var arrayCopy = new int[arrayLength];
            array.CopyTo(arrayCopy, 0);

            // 執行排序
            array.Sort(algorithmName, sortType);

            // 取得正確的排序結果
            arrayCopy =
                sortType == SortType.Increase ?
                arrayCopy.OrderBy(c => c).ToArray() : arrayCopy.OrderByDescending(c => c).ToArray();

            // 驗證成功 or 失敗
            Console.WriteLine("排序是否正確? " + (array.SequenceEqual(arrayCopy) ? "正確" : "錯誤"));

            Console.ReadKey();
        }

        public static void Sort(this int[] array, AlgorithmName algorithmName, SortType sortType)
        {
            var sortAlogrithm = SortAlogrithmFactory.Generate(algorithmName);
            var sortFunc = SortFuncFactory.Generate(sortType);

            sortAlogrithm.Sort(array, sortFunc);
        }
    }
}
