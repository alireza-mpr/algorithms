using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class BubbleSort
    {
        public static void Sort(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    var left = array[i];
                    var right = array[i + 1];
                    if (left > right)
                    {
                        array[i] = right;
                        array[i + 1] = left;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public static void SortSlightlyOptimized(int[] array)
        {
            int wall = array.Length - 1; // https://youtu.be/9I2oOAr2okY?si=yEYpXAh372rISLct
            do
            {
                for (int i = 0; i < wall; i++)
                {
                    var left = array[i];
                    var right = array[i + 1];
                    if (left > right)
                    {
                        array[i] = right;
                        array[i + 1] = left;
                    }
                }
                wall--;
            } while (wall >= 0);
        }
    }
}
