using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Write code to remove duplicates from an unsorted linked list.
/// FOLLOW UP
/// How would you solve this problem if a temporary buffer is not allowed?
/// </summary>
namespace CrackingTheCodeInterview {

    public static class Ch2_Q1 {

        public static void Run() {
            Console.WriteLine("~~~~~~~~~~~~ Running Ch2_Q1 ~~~~~~~~~~~~\n");
            LinkedList<int> sample = new LinkedListWithInit<int> { 1, 1, 2, 2, 3, 3, 4, 5, 6, 77, 345, 3456, 234, 12, 33, 2345, 456, 457, 235, 4235, 45, 45 };
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            CustomLinkedList<int> customLinkedList1 = new CustomLinkedList<int>();
            foreach (var value in sample) {
                customLinkedList.Push(new Node<int>(value));
                customLinkedList1.Push(new Node<int>(value));
            }


            Console.WriteLine("Source List   ::::  --> {0}.\n", string.Join<int>(", ", sample));
            Algo1(sample);
            Console.WriteLine("Algo1 Results ::::  --> {0}.\n", string.Join<int>(", ", sample));

            Algo2(customLinkedList);
            List<int> customList = new List<int>();
            var startNode = customLinkedList.First;
            while (startNode.Next != null) {
                customList.Add(startNode.Value);
                startNode = startNode.Next;
            }
            customList.Add(startNode.Value);
            Console.WriteLine("Algo2 Results ::::  --> {0}.\n", string.Join<int>(", ", customList));

            deleteDups2(customLinkedList1.First);
            customList = new List<int>();
            startNode = customLinkedList1.First;
            while (startNode.Next != null) {
                customList.Add(startNode.Value);
                startNode = startNode.Next;
            }
            customList.Add(startNode.Value);
            Console.WriteLine("Algo3 Results ::::  --> {0}.\n", string.Join<int>(", ", customList));
        }

        /// <summary>
        /// C# Generic.LinkedList + HashSet
        /// </summary>
        /// <param name="sourceList"></param>
        private static void Algo1(LinkedList<int> sourceList) {
            if (sourceList?.First != null) {
                LinkedListNode<int> current = sourceList.First;
                HashSet<int> hashset = new HashSet<int>();

                while (current != null) {
                    LinkedListNode<int> nextNode = current.Next;

                    if (hashset.Contains(current.Value)) {
                        //Node's Next is automatically reset to the next item in the list with C#
                        sourceList.Remove(current);
                    }
                    else {
                        hashset.Add(current.Value);
                    }

                    current = nextNode;
                }
            }
        }

        /// <summary>
        /// CustomLinkedList + HashSet
        /// </summary>
        /// <param name="sourceList"></param>
        private static void Algo2(CustomLinkedList<int> sourceList) {
            HashSet<int> hashset = new HashSet<int>();
            if (sourceList?.First != null) {
                Node<int> current = sourceList.First;
                hashset.Add(current.Value);

                while (current.Next != null) {
                    Node<int> nextNode = current.Next;
                    if (hashset.Contains(nextNode.Value)) {
                        current.Next = nextNode.Next;
                    }
                    else {
                        hashset.Add(nextNode.Value);
                    }
                    current = nextNode;
                }
            }
        }

        /// <summary>
        /// CustomLinkedList + No temp buffers
        /// </summary>
        /// <param name="sourceList"></param>
        private static void Algo3(CustomLinkedList<int> sourceList) {
            if (sourceList?.First != null) {
                Node<int> sourceNode = sourceList.First;
                while (sourceNode != null) {
                    Node<int> prevNode = sourceNode;
                    Node<int> currNode = sourceNode.Next;
                    while (currNode != null) {
                        if (currNode.Value == sourceNode.Value) {
                            prevNode.Next = currNode.Next;
                        }
                        else {
                            prevNode = currNode;
                        }
                        currNode = currNode.Next;
                    }

                    sourceNode = sourceNode.Next;
                }
            }
        }

        /// <summary>
        /// From Book: CustomNode + No temp buffers
        /// </summary>
        /// <param name="head"></param>
        private static void deleteDups2(Node<int> head) {
            if (head == null) {
                return;
            }
            Node<int> previous = head;
            Node<int> current = previous.Next;
            while (current != null) {
                Node<int> runner = head;
                while (runner != current) { // Check for earlier dups
                    if (runner.Value == current.Value) {
                        Node<int> tmp = current.Next; // remove current
                        previous.Next = tmp;
                        current = tmp; // update current to Next node
                        break; // all other dups have already been removed
                    }
                    runner = runner.Next;
                }
                if (runner == current) { // current not updated - update now
                    previous = current;
                    current = current.Next;
                }
            }
        }

        public class Node<T> {
            public Node<T> Next;
            //public Node<T> previous;
            public T Value;

            public Node(T data) {
                Value = data;
            }
        }

        public class CustomLinkedList<T> {
            public Node<T> First;
            public Node<T> Last;

            public void Push(Node<T> node) {
                if (First == null) {
                    First = node;
                    Last = First;
                    First.Next = null;
                }
                else {
                    Last.Next = node;
                    Last = node;
                }
            }
        }

        // Allows you to init LinkedLists with { ##, ##, ... }
        public class LinkedListWithInit<T> : LinkedList<T> {
            public void Add(T obj) {
                ((ICollection<T>)this).Add(obj);
            }
        }
    }
}
