using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProblems.Models;

namespace PracticeProblems {
    public static class Extensions {
        public static void Output(this Node n) {
            Console.Write("Forward Traversal: ");
            while (n.Right != null) {
                Console.Write($"-> [{n?.Value ?? -1}] ");
                n = n.Right;
            }
            Console.WriteLine($"-> [{n?.Value ?? -1}] ");
            Console.Write("Reversed Traversal: ");
            while (n != null) {
                Console.Write($"-> [{n?.Value ?? -1}] ");
                n = n.Left;
            }
        }
    }
}
