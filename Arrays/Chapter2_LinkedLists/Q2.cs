using System;
using System.Collections.Generic;
using static CrackingTheCodeInterview.Ch2_Q1;

/// <summary>
/// Implement an algorithm to find the nth to last element of a singly linked list.
/// </summary>
namespace CrackingTheCodeInterview {
    public static class Ch2_Q2 {
        public static void Run() {
            Console.WriteLine("~~~~~~~~~~~~ Running Ch2_Q2 ~~~~~~~~~~~~\n");
            LinkedList<int> sample = new LinkedListWithInit<int> { 1, 1, 2, 2, 3, 3, 4, 5, 6, 77, 345, 3456, 234, 12, 33, 2345, 456, 457, 235, 4235, 45, 45 };
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            //CustomLinkedList<int> customLinkedList1 = new CustomLinkedList<int>();
            foreach (var value in sample) {
                customLinkedList.Push(new Node<int>(value));
                //customLinkedList1.Push(new Node<int>(value));
            }
            Console.WriteLine("Source List   ::::  --> {0}.\n", string.Join<int>(", ", sample));
            string arg = "";
            int offset = 0;
            while (!Int32.TryParse(arg, out offset)) {
                Console.WriteLine("\nEnter the index to search the list in descending order?");
                arg = Console.ReadLine();
            }

            Node<int> resultNode = Algo1(customLinkedList.First, offset);
            Console.WriteLine("Looked for the {0}th element from the back and found: {1}.\n", offset, resultNode?.Value != null ? resultNode.Value.ToString() : "N/A");
        }

        private static Node<int> Algo1(Node<int> sourceNode, int offset) {
            if (sourceNode == null) {
                return null;
            }
            Node<int> returnNode, lastNode;

            returnNode = lastNode = sourceNode;

            //Push lastNode to the offset
            for (int i = 0; i < offset; i++) {
                if (lastNode != null) {
                    lastNode = lastNode.Next;
                }
                //Not enough elements to backtrack that far.
                else {
                    return null;
                }
            }

            while (lastNode != null) {
                lastNode = lastNode.Next;
                returnNode = returnNode.Next;
            }

            return returnNode;
        }

    }
}
