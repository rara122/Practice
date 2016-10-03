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

            BinarySearchTree tree = Algorithms.BuildTree(0);
            for (int i = 0; i < 15; i++) {
                Console.Write("Input a number, I will see if that sum exists: ");
                int expectedSum = 0;
                //string input = Console.ReadLine();
                if (int.TryParse(Console.ReadLine(), out expectedSum)) {
                    Console.WriteLine($"Closest node was: {Algorithms.HasSumInBST(tree.Root, expectedSum)}");
                }

            }
            Console.Beep();
            Console.Read();

        }
    }
}
