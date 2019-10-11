using System;

namespace Epam.Training_2
{
    public static class ExceptionTests
    {
        private static readonly int _recursion_arr_size = 10000;
        private static readonly int _index_arr_size = 10;

        public static void StackOverflow()
        {
            double[] arr = new double[_recursion_arr_size];
            StackOverflow();
        }

        public static void IndexOutOfRange()
        {
            int[] arr = new int[_index_arr_size];
            arr[_index_arr_size] = 0;
        }

        public static int DoSomeMath(int a, int b)
        {
            if(a < 0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }
            if(b > 0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }
            return a + b;
        }
    }
}
