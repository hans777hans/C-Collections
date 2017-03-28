/*
    A tree is a data structure designed to represent data as a hierarchical tree-like structure containing nodes.
    A node itself contains data and a memory address (reference value) to its parent node.
    The root node is the first node set up in memory - it contains data, but a null memory address because it has no parent.
    Subsequent nodes are set up as subtrees or children of the parent node. 
    These children can act as parent nodes in their own right. A parent node can have any number of child nodes.
    In computer science, a tree is considered an abstract data type.

    A binary tree is a tree structure in which all data nodes must have at most two children (i.e. can have 0, 1 or 2).
    These nodes are known as left child and right child.
    The one node located above the left and right child nodes is the parent.
    When nodes are created, the value of the new node is first compared with the root node value.
    If the new node value is less than the root node value, the new node is then moved to the left child node position
    of the root node. If there isn't any, then a new left child node is created under the root node.
    If there is an existing left child for the root, then the new node value is compared with the left child node value.
    If the new node value is less than the left child node value, then a new node is created in this position.
    If the new node value is greater than the node value, then a new node is created in the right child position.
    So, in all, the node values on the left side are less than the root node value and the node values on the right side
    are greater than the root node value --- look at the example below.

    This type of Binary Tree is known as the Binary Search Tree in C# because it is very useful and fast for searching data.

    There can only be one root node (the original parent).
    All nodes except the root, have only one parent

                                               Root Node
                                              -----------
                                                   |
                                    ---------------------------------
                                    |                               |
                                Left Child                     Right Child
                                ----------                     -----------
                                    |                               |         
                       --------------------------            ---------------
                       |                        |            |              |
                   Left Child              Right Child   Left Child    Right Child
    

    Binary Tree example: 
    Order of insertion: 16, 24, 15, 13, 18, 56, 13, 19, 17 (NOTE: The second value of 13 is rejected as it is a duplicate)

                                               [16]
                                                 |
                                         -----------------
                                     [15]                  [24]
                                       |                    |
                                 --------------        -------------
                             [13]                    [18]           [56]
                                                       |
                                                ---------------
                                               [17]             [19]
 
    
    To search through a Binary Tree structure, some traversal methods are used:

    1. Breadth-first search method is a technique which visits all the nodes at the same depth or level
    before visiting the nodes at the next level (left to right).
    e.g. 16 (Level 0), 15, 24  (Level 1), 13, 18, 56 (Level 2), 17, 19 (Level 3)

    2. Depth-first search method is a technique which generally visits the left sub-tree first, then the right sub-tree
    and then finally, the root node (refer Postorder traversal example below).
    
    There are 3 traversal strategies in the depth-first method:

   2.1 Inorder traversal
       Always produces an ascending sorted output
       - must visit the left subtree node, then the root node and then the right subtree node (L-Root-R)
       - when visiting the subtrees, you take the same steps
       e.g. 13, 15, 16, 17, 18, 19, 24, 56

   2.2 Preorder traversal (order that might be used by a functional calculator)
       - must visit the root node first, then the left subtree and then the right subtree (Root-L-R)
       e.g. 16, 15, 13, 24, 18, 17, 19, 56

   2.3 Postorder traversal (used in "reverse Polish" notation calculators that use a stack for their calculations)
       - must visit the left subtree, then the right subtree and finally the root node (L-R-Root)
       - the root value is always last
       e.g. 13, 15, 17, 19, 18, 56, 24, 16

   The implementation for these traversal types uses recursion.

   MSDN documentation on Binary Trees:
   Creating Binary Trees
   https://msdn.microsoft.com/en-us/library/aa227489(v=vs.60).aspx
   An Extensive Examination of Data Structures using C# 2.0
   Part 3 Binary Trees and BSTs
   https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx

   This example is structured in a simple 4-step process:

    1. Declare data variables needed for this program
    2. Get input for the data we need
    3. Process the data in some meaningful way
    4. Output what we want to see

    The understanding is based on the idea that every computer program runs this way despite its complexity.

    The example uses 3 files - "TreesEx.cs", "Node.cs" and "BinaryTree.cs".
    The Node class contains a data component and two memory addresses to each of its child nodes and is the
    basis of a single node in a binary tree data structure.

    The Binary Tree class contains null, one or several nodes. They are added into the binary tree according
    to the rule that all data values less than its parent node will be placed to the left of the parent node,
    and all data values greater than its parent node will be placed to the right of the parent node.

    This example is structured in a simple 4-step process:

    1. Declare data variables needed for this program
    2. Get input for the data we need
    3. Process the data in some meaningful way
    4. Output what we want to see

    Source code is error-free and was tested in MS Visual Studio 2015 as at March, 2017
    Hans Telford

    OUTPUT:
    ********************************************
    *******      Binary Tree Example     *******
    ********************************************
    16 entered - this is the root
    24 entered
    15 entered
    13 entered
    18 entered
    56 entered
    13 entered - duplicate value ignored
    19 entered
    17 entered
    Binary tree node insertion complete!
    There are 8 nodes in total.
    **************************************************
    Preorder traversal of elements ...
    16 15 13 24 18 17 19 56
    **************************************************
    Inorder traversal of elements ...
    13 15 16 17 18 19 24 56
    **************************************************
    Postorder traversal of elements ...
    13 15 17 19 18 56 24 16
    **************************************************
    Enter a value to search ==> 24

    24 found!
    **************************************************
    Press any key to continue . . .


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    class TreesEx
    {
        static void Main(string[] args)
        {
            // 1. Declare data variables needed for this program
            // Create a binary tree and insert 10 elements (one is a duplicate and will be ignored)
            BinaryTree<int> bt = new BinaryTree<int>();

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******      Binary Tree Example     *******");
            Console.WriteLine("********************************************");

            // 2. Get input for the data we need
            //    In this case, add what we need for the bt binary tree object
            // Order of insertion: 16, 24, 15, 13, 18, 56, 13, 19, 17
            bt.Add (16);
            bt.Add (24);
            bt.Add (15);
            bt.Add (13);
            bt.Add (18);
            bt.Add (56);
            bt.Add (13);
            bt.Add (19);
            bt.Add (17);

            // 3. Process the data in some meaningful way
            // and ...
            // 4. Output what we want to see
            Console.WriteLine("Binary tree node insertion complete!");
            Console.WriteLine("There are " + bt.GetCount() + " nodes in total.");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Preorder traversal of elements ...");
            bt.Preorder(bt.GetRoot());
            Console.WriteLine("");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Inorder traversal of elements ...");
            bt.Inorder(bt.GetRoot());
            Console.WriteLine("");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Postorder traversal of elements ...");
            bt.Postorder(bt.GetRoot());
            Console.WriteLine("");
            Console.WriteLine("**************************************************");
            Console.Write("Enter a value to search ==> ");
            int valueToSearch = Int32.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (bt.Contains(valueToSearch))
            {
                Console.WriteLine(valueToSearch + " found!");
            }
            else
            {
                Console.WriteLine(valueToSearch + " not found");
            }

            Console.WriteLine("**************************************************");

        }
    }
}
