using System;
using PracticeProblems.Models;

namespace PracticeProblems {
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree tree = Algorithms.BuildTree();
            //Node headNode = Algorithms.ConvertToDoublyLinkedList(tree.Root);
            //headNode.Output();

            BinarySearchTree tree = Algorithms.BuildTree(1);
            for (int i = 0; i < 5; i++) {
                Console.Write("Input an integer to FindPathForSum: ");
                int expectedSum = 0;
                //string input = Console.ReadLine();
                if (Int32.TryParse(Console.ReadLine(), out expectedSum)) {
                    Algorithms.FindPathForSum(tree.Root, expectedSum);
                }

                Console.Beep();
            }
            Console.ReadKey();
        }
    }
}
