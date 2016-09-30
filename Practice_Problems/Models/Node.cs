using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Models {
    public class Node {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node() {

        }

        public Node(int val) {
            Value = val;
        }
    }
}
