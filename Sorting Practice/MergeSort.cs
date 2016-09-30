using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Practice
{
    public static class CustomSort
    {
        public static void MergeSort<T>(ref T[] unsortedArray)
        {
            //MergeSortRecursive(ref unsortedArray);
        }

        private static void MergeSortRecursive<T>(ref T[] array, int start, int end)
        {
            if (array == null || array.Length < 2)
            {
                return;
            }

            //T[] left = new T[array.Length / 2];
            //T[] right = new T[array.Length - array.Length / 2];

            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (i < array.Length / 2)
            //    {
            //        left[i] = array[i];
            //    }
            //    else
            //    {
            //        right[i] = array[i];
            //    }
            //}

            //MergeSortRecursive<T>(ref right);

            array = Merge(ref array, start, (end - start / 2), end);
        }
        private static T[] Merge<T>(ref T[] array, int start, int middle, int end)
        {
            if (Comparer<T>.Default.Compare(array[middle - 1], array[middle]) > 0)
            {
                //put tail end into temp 
                T[] temp = new T[end - middle];
                for (int i = 0; i < end - middle; i++)
                {
                    temp[i] = array[end - middle + i];
                }
            }
            return new T[0];
        }
    }
}
