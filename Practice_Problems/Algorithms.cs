using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProblems.Models;

namespace PracticeProblems {
    public static class Algorithms {

        /// <summary>
        /// Convert a BST to a DoublyLinkedList 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Node ConvertToDoublyLinkedList(Node root) {
            Node headNode = null;
            ConvertNode(root, ref headNode);

            while (headNode.Left != null) {
                headNode = headNode.Left;
            }

            return headNode;
        }
        private static void ConvertNode(Node current, ref Node lastUsedNode) {
            if (current == null) {
                return;
            }

            // Left
            ConvertNode(current.Left, ref lastUsedNode);

            // Process
            // 1. Set Current.Left with LastUsedNode
            current.Left = lastUsedNode;
            // 2. Link LastUsedNode.Right to Current
            if (lastUsedNode != null)
                lastUsedNode.Right = current;

            // 3. LastUsedNode = parent
            lastUsedNode = current;

            // Right
            ConvertNode(current.Right, ref lastUsedNode);
        }

        /// <summary>
        /// Builds a sample tree
        /// </summary>
        /// <returns></returns>
        public static BinarySearchTree BuildTree() {
            /*
             *           10
             *        /      \
             *      6         14
             *    /   \     /    \
             *   4     8   12    16
             * 
             */

            Node n1, n2, n3, n4, n5, n6, n7;
            n1 = new Node(4);
            n2 = new Node(6);
            n3 = new Node(8);
            n4 = new Node(10);
            n5 = new Node(12);
            n6 = new Node(14);
            n7 = new Node(16);

            n2.Left = n1; n2.Right = n3;
            n4.Left = n2; n4.Right = n6;
            n6.Left = n5; n6.Right = n7;

            BinarySearchTree tree = new BinarySearchTree() { Root = n4 };

            return tree;
        }

        /// <summary>
        /// QuickSort Person by Last Name ASC
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int QuickSort(List<Person> list, int left, int right) {
            int i = left;
            int j = right;
            int pivot = (left + right) / 2;

            Person temp;

            while (i <= j) {
                while (string.Compare(list[i].LastName, list[pivot].LastName) < 0) {
                    i++;
                }
                while (string.Compare(list[j].LastName, list[pivot].LastName) > 0) {
                    j--;
                }
                //Flip Logic
                if (i <= j) {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }
            }

            return i;
        }

        /// <summary>
        /// Get all Letter Combinations of a Phone Number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static List<string> GetPhoneWords(string phoneNumber) {
            List<string> results = new List<string>();
            //Add starting string
            results.Add("");

            foreach (var number in phoneNumber) {
                if (NumberPad.ContainsKey(number) && NumberPad[number] != null) {
                    int count = results.Count;
                    List<string> tempList = new List<string>();
                    for (int i = 0; i < count; i++) {
                        foreach (var letter in NumberPad[number]) {
                            tempList.Add(results[i] + letter);
                        }
                    }
                    results = tempList;
                }
                else {
                    for (int i = 0; i < results.Count; i++) {
                        results[i] = results[i] + number;
                    }
                }
            }
            return results;
        }
        public static Dictionary<int, char[]> NumberPad {
            get {
                if (_numPad == null) {
                    _numPad = new Dictionary<int, char[]>();

                    _numPad.Add('0', new char[] { '0', });
                    _numPad.Add('1', new char[] { '1', });
                    _numPad.Add('2', new char[] { 'A', 'B', 'C' });
                    _numPad.Add('3', new char[] { 'D', 'E', 'F' });
                    _numPad.Add('4', new char[] { 'G', 'H', 'I' });
                    _numPad.Add('5', new char[] { 'J', 'K', 'L' });
                    _numPad.Add('6', new char[] { 'M', 'N', 'O' });
                    _numPad.Add('7', new char[] { 'P', 'Q', 'R', 'S' });
                    _numPad.Add('8', new char[] { 'T', 'U', 'V' });
                    _numPad.Add('9', new char[] { 'W', 'X', 'Y', 'Z' });
                }

                return _numPad;
            }
        }
        private static Dictionary<int, char[]> _numPad;

        /// <summary>
        /// Find Permutataions of a word Recursively
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<string> Permutate(string word) {
            List<string> permutationList = new List<string>();

            if (word.Length == 0) {
                return permutationList;
            }

            if (word.Length == 1) {
                permutationList.Add(word);
            }
            else {
                string wordMinusLastCharacter = word.Substring(0, word.Length - 1);
                string lastCharacter = word[word.Length - 1].ToString();

                foreach (var innerPermutation in Permutate(wordMinusLastCharacter)) {
                    for (int i = 0; i <= innerPermutation.Length; i++) {
                        permutationList.Add(innerPermutation.Insert(i, lastCharacter));
                    }
                }
            }

            return permutationList;

        }
    }
}
