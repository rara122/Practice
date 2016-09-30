using System;
using PracticeProblems.Models;

namespace PracticeProblems {
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = Algorithms.BuildTree();
            Node headNode = Algorithms.ConvertToDoublyLinkedList(tree.Root);
            headNode.Output();
            Console.Beep();
        }
    }
}
