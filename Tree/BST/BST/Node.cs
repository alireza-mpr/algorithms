using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Node
    {
        public Node Right { get; set; }
        public Node Left { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node Insert(int value)
        {
            Node current = this;

            while (current != null)
            {
                if (current.Value <= value)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(value);
                        break;
                    }
                    current = current.Right;
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(value);
                        break;
                    }
                    current = current.Left;
                }
            }

            return this;
        }

        public bool Contains(int value)
        {
            Node current = this;

            while (current != null)
            {
                if (current.Value == value)
                    return true;

                if (current.Value < value)
                    current = current.Right;
                else
                    current = current.Left;
            }

            return false;
        }

        public Node Remove(int value, Node parent = null)
        {
            var current = this;

            while (current != null)
            {
                if (current.Value < value)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (current.Value > value)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    if (current.Right != null && current.Left != null)
                    {
                        current.Value = current.Right.FindMin().Value;
                        current.Right.Remove(current.Value, current);
                    }
                    else if (parent == null)
                    {
                        if (current.Left != null)
                        {
                            current.Value = current.Left.Value;
                            current.Right = current.Left.Right;
                            current.Left = current.Left.Left;
                        }
                        else
                        {
                            current.Value = current.Right.Value;
                            current.Left = current.Right.Left;
                            current.Right = current.Right.Right;
                        }
                    }
                    else
                    {
                        if (parent.Right == current)
                            parent.Right = current.Right ?? current.Left;
                        else
                            parent.Left = current.Right ?? current.Left;
                    }
                    break;
                }
            }

            return this;
        }

        private Node FindMin()
        {
            var current = this;

            while (current != null && current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }
    }
}