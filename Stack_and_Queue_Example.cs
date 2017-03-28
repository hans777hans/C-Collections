/*
    A Stack<T> class is a dynamic data structure that uses a FILO (First-In Last-Out) method of data
    input and retrieval.
    Think of a stack of cleaned dishes --- the first dish that is washed goes at the bottom of the pile
    The last dish that is stacked to the top will be the first to be used.

    Methods:
    - Push()    puts new data on the top of the stack
    - Pop()     removes data from the top of the stack
    - Peek()    gets a copy of the data from the top of the stack

    Very useful for a stack of cards in a game

    MSDN Documentaton:
    https://msdn.microsoft.com/en-us/library/system.collections.stack(v=vs.110).aspx

    ******************************************************************************************************
    A Queue<T> class is a similar data structure that uses a FIFO (First-In First-Out) method of data
    input of retrievel.
    Think of a queue of people at the ticket office --- first in to get the ticket and the first to get out.

    Methods:
    - Enqueue() puts new data at the end of the queue
    - Dequeue() removes data from the beginning of the queue
    - Peek()    gets a copy of the data from the beginning of the queue

    Very useful to enforece fairness like in players waiting their turn to play a round in a game

    MSDN Documentation:
    https://msdn.microsoft.com/en-us/library/system.collections.queue(v=vs.110).aspx

    ******************************************************************************************************
    Stack - 
    Pros:
    1. Helps manage the data in particular way (LIFO) which is not possible with Linked list and array.
    2. When function is called the local varriables are stored in stack and destroyed once returned. 
       Stack is used when varriable is not used outside the function.
       So, it gives control over how memory is allocated and deallocated
    3. Stack frees you from the burden of remembering to cleanup(read delete) the object
    4. Not easily corrupted (No one can easily inset data in middle)

    Cons:
    1. Stack memory is limited.
    2. Creating too many objects on the stack will increase the chances of stack overflow
    3. Random access not possible

    ******************************************************************************************************
    
    Queue - 
    Pros:
    1. Helps manage the data in particular way (FIFO). which is not possible with Linked list and array.
    2. Not easily corrupted (No one can easily inset data in middle)

    Cons:
    1. Random access not possible
    ******************************************************************************************************
    

    This example includes an example of using File IO to read an external plaintext file (.csv format)
    which consists of a list of 118 elements (with atomic number, element name and element symbol)
    This external file (named "elements.csv" needs to be in the same directory as the executable)

    This example is structured in a simple 4-step process:

    1. Declare data variables needed for this program
    2. Get/Set input for the data we need
    3. Process the data in some meaningful way
    4. Output what we want to see

    The understanding is based on the idea that every computer program runs this way despite its complexity

    Source code is error-free and was tested in MS Visual Studio 2015 as at March, 2017
    Hans Telford

    OUTPUT:
    ********************************************
    *******    Stack and Queue Example   *******
    ********************************************
    List display ...
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
    Stack display ...
    10, 9, 8, 7, 6, 5, 4, 3, 2, 1,
    Queue display ...
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
    Numbers in myList that are divisible by 2 ...
    2, 4, 6, 8, 10,
    ***********************************************************
    Enter string to test for palindrome --> mum

    mum is  a palindrome
    ***********************************************************
    Press any key to continue . . .

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class Stack_and_Queue_Example
    {
        static void Main(string[] args)
        {
            // 1. Declare data variables needed for this program
            // myList is a simple List data structure containing integers only
            // Lists allow you to add and remove data at any point of the List
            List<int> myList = new List<int>();
            // myStack is a simple Stack data structure containing integers only
            // Stacks allow you to add and remove data to only the top of the Stack 
            // Last-in First-out (LIFO data structure)
            Stack<int> myStack = new Stack<int>();
            // myQueue is a simple Queue data structure containing integers only
            // Queues allow you to add data to the end of the Queue and to remove data from the beginning
            // of the Queue 
            // First-in First out (FIFO data structure)
            Queue<int> myQueue = new Queue<int>();

            //  2. Get input for the data we need
            //     In this case, we are only adding data into each of the three data structures
            // for loop that loops 10 times
            // add the integer values of 1 to 10 in each object - myList, myStack, myQueue
            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i);
                myStack.Push(i);
                myQueue.Enqueue(i);
            }

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******    Stack and Queue Example   *******");
            Console.WriteLine("********************************************");

            // display each collection
            DisplayList (myList);
            DisplayStack (myStack);
            DisplayQueue (myQueue);

           // 3.Process the data in some meaningful way
           // 4.Output what we want to see
           // LINQ Query example
           // Need 3 parts
           // a. Data source --- use myList as the data source for this example
           // b. Query creation
           // this example is looking for a number where when multiplied by 2 results in 14
           // this means the number we are looking for is 7
           // numQuery is an IEnumerable<int>
           var numQuery = myList.Where (num => num % 2 == 0).OrderBy(n => n);
           // c. Query execution

            Console.WriteLine("Numbers in myList that are divisible by 2 ... ");
            foreach (int num in numQuery)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("***********************************************************");

            // Palindrome test using Stack and Queue
            string strToTest = "";
            Console.Write("Enter string to test for palindrome --> ");
            strToTest = Console.ReadLine().ToLower();
            Console.WriteLine("");

            Console.Write(strToTest + " is ");

            if (IsPalindrome(strToTest))
            {
                Console.Write(" a palindrome");
            }
            else
            {
                Console.Write(" not a palindrome");
            }
            Console.WriteLine("");
            Console.WriteLine("***********************************************************");

        }

        static void DisplayList (List<int> intList)
        {
            Console.WriteLine("List display ...");
            foreach (var intItem in intList)
            {
                Console.Write(intItem + ", ");
            }
            Console.WriteLine("");
        }

        static void DisplayStack (Stack<int> intStack)
        {
            Console.WriteLine("Stack display ...");
            while (intStack.Count > 0)
            {
                Console.Write(intStack.Pop() + ", ");
            }
            Console.WriteLine("");
        }

        static void DisplayQueue (Queue<int> intQueue)
        {
            Console.WriteLine("Queue display ...");
            while (intQueue.Count > 0)
            {
                Console.Write(intQueue.Dequeue() + ", ");
            }
            Console.WriteLine("");
        }

        // check whether a word or phrase is a palindrome
        // can be spelt the same way either forward or in reverse
        static bool IsPalindrome (string strToTest)
        {
            Stack<char> charStack = new Stack<char>();
            Queue<char> charQueue = new Queue<char>();
            bool palindromeStatus = true;

            // add characters to charStack and charQueue
            for (int i = 0; i < strToTest.Length; i++)
            {
                charStack.Push(strToTest[i]);
                charQueue.Enqueue(strToTest[i]);
            }

            // loop while the stack is not empty
            while (charStack.Count > 0)
            {
                // get character from stack (FILO --- last character added is on top)
                char stackChar = charStack.Pop();
                // get character from queue (FIFO --- first character added is on top)
                char queueChar = charQueue.Dequeue();
                // compare the two characters
                // if they are the same for each loop, then the string is a palindrome
                // if any of the characters are not the same, then the string is NOT a palindrome
                if (stackChar != queueChar)
                {
                    palindromeStatus = false;
                    break;
                }
            }

            return palindromeStatus;
        }
    }
}
