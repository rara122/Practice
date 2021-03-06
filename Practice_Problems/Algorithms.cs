﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProblems.Models;

namespace PracticeProblems {
    public static class Algorithms {

        /// <summary>
        /// Check whether or not a given Value can be summed up from two nodes of a given BST
        /// ref: http://codercareer.blogspot.com/2013/03/no-46-nodes-with-sum-in-binary-search.html
        /// </summary>
        /// <returns></returns>
        public static bool HasSumInBST(Node root, int expectedValue) {
            Stack<Node> minStack = BuildMinStack(root);
            Stack<Node> maxStack = BuildMaxStack(root);

            if (root == null || minStack == null || maxStack == null) {
                return false;
            }

            int? left = GetMin(ref minStack);
            int? right = GetMax(ref maxStack);

            while (left != right && left != null && right != null) {
                if (left + right == expectedValue) {
                    return true;
                }

                if (left + right > expectedValue) {
                    right = GetMax(ref maxStack);
                }
                else {
                    left = GetMin(ref minStack);
                }
            }

            return false;
        }
        private static Stack<Node> BuildMinStack(Node root) {
            Stack<Node> minStack = new Stack<Node>();
            while (root != null) {
                minStack.Push(root);
                root = root.Left;
            }
            return minStack;
        }
        private static Stack<Node> BuildMaxStack(Node root) {
            Stack<Node> maxStack = new Stack<Node>();
            while (root != null) {
                maxStack.Push(root);
                root = root.Right;
            }
            return maxStack;
        }
        private static int? GetMin(ref Stack<Node> minStack) {
            if (minStack.Count < 1) {
                return null;
            }

            int result = minStack.Peek().Value;

            Node n = minStack.Pop();
            n = n.Right;
            while (n != null) {
                minStack.Push(n);
                n = n.Left;
            }

            return result;
        }
        private static int? GetMax(ref Stack<Node> maxStack) {
            if (maxStack.Count < 1) {
                return null;
            }

            int result = maxStack.Peek().Value;

            Node n = maxStack.Pop();
            n = n.Left;
            while (n != null) {
                maxStack.Push(n);
                n = n.Right;
            }

            return result;
        }
        /*
         * Standard Binary Search Tree
         * 
         *           10
         *        /      \
         *      8         14
         *    /   \     /    \
         *   4     9   12    16
         *    \
         *     6
         *    /\
         *   5  7
         */
        /// <summary>
        /// Find the closest Node to the a given value within a BST
        /// ref: 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static int? FindClosestValueInBST(Node root, int expectedValue) {
            int min = int.MinValue;
            return FindClosestValueInBST(root, expectedValue, ref min);
        }
        private static int? FindClosestValueInBST(Node root, int expectedValue, ref int possibleResult) {
            if (root == null) {
                return null;
            }

            if (root.Value == expectedValue) {
                possibleResult = root.Value;
            }
            else {
                if (Math.Abs(root.Value - possibleResult) < Math.Abs(expectedValue - possibleResult)) {
                    possibleResult = root.Value;
                }
                FindClosestValueInBST(root.Left, expectedValue, ref possibleResult);
                FindClosestValueInBST(root.Right, expectedValue, ref possibleResult);
            }
            return possibleResult;
        }

        /// <summary>
        /// Check to see if a tree is a Binary Search Tree (Using PostOrder Traversal)
        /// ref: http://codercareer.blogspot.com/2012/01/no-31-binary-search-tree-verification.html
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBinarySearchTree2(Node root, int min = int.MinValue, int max = int.MaxValue) {
            //Base Case
            if (root == null) {
                return true;
            }

            bool left = IsBinarySearchTree(root.Left, min, root.Value);
            bool right = IsBinarySearchTree(root.Right, root.Value, max);

            //PreOrder check of Values
            if (root.Value < min || root.Value > max) {
                return false;
            }


            return (left && right);
        }
        /// <summary>
        /// Check to see if a tree is a Binary Search Tree (Using InOrder Traversal)
        /// ref: http://codercareer.blogspot.com/2012/01/no-31-binary-search-tree-verification.html
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBinarySearchTree1(Node root, int min = int.MinValue) {
            if (root == null) {
                return true;
            }

            //Traverse the tree using INORDER traversal 
            //If there is a value that is not ASC then it is not a BST
            bool left = IsBinarySearchTree(root.Left, min);
            if (root.Value < min) {
                return false;
            }
            bool right = IsBinarySearchTree(root.Right, root.Value);

            return (left && right);
        }
        /// <summary>
        /// Check to see if a tree is a Binary Search Tree (Using PreOrder Traversal)
        /// ref: http://codercareer.blogspot.com/2012/01/no-31-binary-search-tree-verification.html
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBinarySearchTree(Node root, int min = int.MinValue, int max = int.MaxValue) {
            //Base Case
            if (root == null) {
                return true;
            }

            //PreOrder check of Values
            if (root.Value < min || root.Value > max) {
                return false;
            }

            bool left = IsBinarySearchTree(root.Left, min, root.Value);
            bool right = IsBinarySearchTree(root.Right, root.Value, max);

            return (left && right);
        }

        /// <summary>
        /// Check to see if an array of input is the result of a Post Order tree traversal
        /// ref: http://codercareer.blogspot.com/2011/09/no-06-post-order-traversal-sequences-of.html
        /// Post Order: Left, Right, Curr
        /// Pre Order : Curr, Left, Right
        /// In Order  : Left, Curr, Right
        /// 
        /// Standard Binary Search Tree
        /// 
        ///           10
        ///        /      \
        ///      6         14
        ///    /   \     /    \
        ///   4     8   12    16
        /// 
        /// Traversed Post Order: 4, 8, 6, 12, 16, 14, 10
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool PostOrderTreeSequence(int[] array, int start, int end) {

            //Base Case: 1 or 0 Elements
            if (((end - start + 1) <= 1) || (array == null) || array.Count() <= 1) {
                return true;
            }

            //Set root = A[end]
            int rootValue = array[end];

            //Get left/right subtree indices
            int middleIndex = ((end - start - 1) / 2) + start + 1;

            //Check Left subtree nodes < rootValue
            for (int i = start; i < middleIndex; i++) {
                if (array[i] > rootValue) {
                    return false;
                }
            }
            //Check Right subtree nodes > rootValue
            for (int i = middleIndex; i < end; i++) {
                if (array[i] < rootValue) {
                    return false;
                }
            }

            //Recurse
            bool left = PostOrderTreeSequence(array, start, middleIndex - 1);
            bool right = PostOrderTreeSequence(array, middleIndex, (end - 1));

            return (left && right);
        }

        /// <summary>
        /// Output any path of a given Binary Tree that sums up to the specified value.
        /// ref: http://codercareer.blogspot.com/2011/09/no-04-paths-with-specified-sum-in.html
        /// Make sure to traverse all the nodes: BFS OR DFS both work 
        /// Keep in mind this is Binary Tree not BST
        /// </summary>
        public static void FindPathForSum(Node root, int expectedSum) {
            List<int> path = new List<int>();
            FindPathForSum(root, expectedSum, ref path);
        }
        private static void FindPathForSum(Node currentNode, int expectedSum, ref List<int> path, int currentSum = 0) {
            //Recurse Base Case
            if (currentNode == null || path == null) {
                return;
            }

            //Load this into the path
            path.Add(currentNode.Value);
            //Add value to currentSum
            currentSum += currentNode.Value;

            //Is it a Leaf?
            if (currentNode.Left == null && currentNode.Right == null) {
                //Did we find the expectedSum?
                if (currentSum == expectedSum) {
                    //Output Results
                    Console.WriteLine($"A path found: {string.Join(" + ", path)}");
                }
            }

            //Recurse Left
            FindPathForSum(currentNode.Left, expectedSum, ref path, currentSum);
            //Recure Right
            FindPathForSum(currentNode.Right, expectedSum, ref path, currentSum);

            //Finished the traversal, Remove this path
            path.RemoveAt(path.Count - 1);
        }

        /// <summary>
        /// Convert a Binary Search Tree to a DoublyLinkedList 
        /// ref: http://codercareer.blogspot.com/2011/09/interview-question-no-1-binary-search.html
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
        /// Builds a sample tree (Binary Search Tree)
        /// </summary>
        /// <returns></returns>
        public static BinarySearchTree BuildTree(int type = 0) {
            List<Node> nodeList = new List<Node>();
            BinarySearchTree tree = new BinarySearchTree();


            switch (type) {
                case 1:
                    /*
                     * Standard Binary Tree
                     * 
                     *             10
                     *          /      \
                     *        6         5
                     *      /   \     /    \
                     *     4     8   3     16
                     *    /
                     *   11
                     *   
                     */


                    nodeList.Add(new Node(4));
                    nodeList.Add(new Node(6));
                    nodeList.Add(new Node(8));
                    nodeList.Add(new Node(10));
                    nodeList.Add(new Node(3));
                    nodeList.Add(new Node(5));
                    nodeList.Add(new Node(16));
                    nodeList.Add(new Node(11));

                    //[Node 6]
                    nodeList[1].Left = nodeList[0]; nodeList[1].Right = nodeList[2];
                    //[Node 10]
                    nodeList[3].Left = nodeList[1]; nodeList[3].Right = nodeList[5];
                    //[Node 5]
                    nodeList[5].Left = nodeList[4]; nodeList[5].Right = nodeList[6];
                    //[Node 11]
                    nodeList[0].Left = nodeList[7];

                    tree.Root = nodeList[3];
                    break;
                case 0:
                default:
                    /*
                     * Standard Binary Search Tree
                     * 
                     *           10
                     *        /      \
                     *      6         14
                     *    /   \     /    \
                     *   4     8   12    16
                     * 
                     */


                    nodeList.Add(new Node(4));
                    nodeList.Add(new Node(6));
                    nodeList.Add(new Node(8));
                    nodeList.Add(new Node(10));
                    nodeList.Add(new Node(12));
                    nodeList.Add(new Node(14));
                    nodeList.Add(new Node(16));

                    nodeList[1].Left = nodeList[0]; nodeList[1].Right = nodeList[2];
                    nodeList[3].Left = nodeList[1]; nodeList[3].Right = nodeList[5];
                    nodeList[5].Left = nodeList[4]; nodeList[5].Right = nodeList[6];

                    tree.Root = nodeList[3];
                    break;
            }

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
