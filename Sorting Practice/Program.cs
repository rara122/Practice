using System.Linq;

namespace Sorting_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 4, 3, 7, 8, 1 };
            System.Console.WriteLine("Here is the loaded array.\n ==> {0}");

            CustomSort.Sort<int>(array.ToList());   
        }
    }
}
