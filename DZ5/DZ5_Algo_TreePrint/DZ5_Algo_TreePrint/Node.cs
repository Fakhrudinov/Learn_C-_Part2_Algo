﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Algo_TreePrint
{
    public class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var node = obj as Node;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }
}
