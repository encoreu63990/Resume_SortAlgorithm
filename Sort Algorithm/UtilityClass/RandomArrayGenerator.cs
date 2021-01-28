using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm.UtilityClass
{
    public class RandomArrayGenerator
    {
        public static int[] Generate(int arrayLength)
        {
            var random = new Random();
            var array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(0, 100000);
            }

            return array;
        }
    }
}
