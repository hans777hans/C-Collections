﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    // Binary Tree class --- generic type <T> which uses IComparable interface
    // this is needed to use the CompareTo() method

    class BinaryTree<T> where T : IComparable
    {
        // properties
        private Node<T> root;
        private int count;

        // constructor - initialise the Binary Tree structure 
        //               and set up the root node with a null memory address
        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        // Get the root node
        public Node<T> GetRoot()
        {
            return root;
        }

        // Add a node to the Binary Tree structure
        public void Add (T data)
        {
            // Create the node
            Node<T> newNode = new Node<T>(data);
            // check if the root is null
            // if so, assign the root to newNode
            if (root == null)
            {
                root = newNode;
                count++;
                Console.WriteLine(data + " entered - this is the root");
            }
            else
            {
                Node<T> current = root;
                Node<T> parent;

                while (true)
                {
                    parent = current;
                    // check if data is the same as the parent data
                    // and if so, ignore
                    if (data.CompareTo(current.data) == 0)
                    {
                        // duplicate - ignore the node
                        Console.WriteLine(data + " entered - duplicate value ignored");
                        return;
                    }
                    // check if data is less than the parent data
                    // and if so, assign current to the left node
                    if (data.CompareTo(current.data) == -1)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            count++;
                            Console.WriteLine(data + " entered");
                            return;
                        }
                    }
                    // data is now greater than the parent data
                    // in this case, assign current to the right node
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            count++;
                            Console.WriteLine(data + " entered");
                            return;
                        }
                    }

                } // end while loop

            } // end if-else

        } // end Add() method

        // Contains() method --- looks for a specific value and returns boolean
        // true if found and false if not found
        public bool Contains (T value)
        {
            return (this.Find(value) != null);
        }

        // Find() method called from Contains() method
        public Node<T> Find (T value)
        {
            Node<T> nodeToFind = GetRoot();

            while (nodeToFind != null)
            {
                if (value.CompareTo(nodeToFind.data) == 0)
                {
                    // found
                    return nodeToFind;
                }
                else
                {
                    // search left if the value to find is smaller than the current node
                    if (value.CompareTo(nodeToFind.data) == -1)
                    {
                        nodeToFind = nodeToFind.leftChild;

                    }
                    // search right if the value to find is greater than the current node
                    else if (value.CompareTo(nodeToFind.data) == 1)
                    {
                        nodeToFind = nodeToFind.rightChild;
                    }
                }
            }

            // not found
            return null;
        }
        
        // Get the node count of the Binary Tree structure
        public int GetCount()
        {
            return count;
        }

        // Traverse through the Binary Tree structure using Preorder method of Root-L-R
        public void Preorder(Node<T> root)
        {
            // Order of method: (Root-L-R)
            if (root != null)
            {
                Console.Write(root.data + " ");
                Preorder(root.leftChild);
                Preorder(root.rightChild);
            }
        }

        // Traverse through the Binary Tree structure using Inorder method of L-Root-R
        // This method produces an ordered display of the values
        public void Inorder(Node<T> root)
        {
            // Order of method: (L-Root-R)
            if (root != null)
            {
                Inorder(root.leftChild);
                Console.Write(root.data + " ");
                Inorder(root.rightChild);
            }
        }

        // Traverse through the Binary Tree structure using Postorder method of L-R-Root
        public void Postorder(Node<T> root)
        {
            // Order of method: (L-R-Root)
            if (root != null)
            {
                Postorder(root.leftChild);
                Postorder(root.rightChild);
                Console.Write(root.data + " ");
            }
        }

    }
}
