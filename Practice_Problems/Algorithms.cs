using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProblems.Models;

namespace PracticeProblems {
    public static class Algorithms {

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
            bool left = PostOrderTreeSequence(array, start, middleIndex-1);
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
