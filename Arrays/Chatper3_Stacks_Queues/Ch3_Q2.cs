using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// How would you design a stack which, in addition to push and pop, also has a function min which returns the minimum element? Push, pop and min should all operate in O(1) time.
/// </summary>
namespace CrackingTheCodeInterview {
    public static class Ch3_Q2 {
        public static void Run() {
            Console.WriteLine("~~~~~~~~~~~~ Running Ch3_Q2 ~~~~~~~~~~~~\n");

            CustomStack<int> stack = new CustomStack<int>(new List<int> { 2, 4, 6, 8, 1 });
            
            Console.WriteLine("Given Stack: ");
            var data = stack.Pop();
            while (data != null) {

                data = stack.Pop();
            }
        }

        public class CustomStack<T> {
            private List<T> datasource;
            private T minValue;

            public CustomStack(List<T> data) {
                if (data != null) {
                    datasource = data;
                }
                else {
                    datasource = new List<T>();
                }
            }

            public void Push(T data) {
                datasource.Add(data);
                if (minValue == null) {
                    minValue = data;
                }
                else {
                    if (((IComparable)data).CompareTo(minValue) < 0) {
                        minValue = data;
                    }
                }
            }

            public T Pop() {
                if (datasource != null && datasource.Count > 0) {
                    return datasource.ElementAt<T>(datasource.Count - 1);
                }
                else {
                    return default(T);
                }
            }

            public T Min() { return minValue; }

        }
    }
}
