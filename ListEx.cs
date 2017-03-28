/*
    Collection data types are basically data structures that are DYNAMIC in nature
    
   ... meaning ...
    
    that during the run-time of a program, they can contain any number of data elements.
    This means that the collection can contain nothing or one or several data elements.

    This is unlike a standard array where you need to declare how big it must be 
    (how many values are to go in it) before you do anything with it in the program.
    The array data structure is fixed because of this.
    
    Collection data elements can consist of value types (e.g. bool, char, int, long, float, double)
    or reference types (e.g. any of the C# classes or user-defined classes).

    The following are examples of C# Collection data types:
    - Lists
    - Hash Tables
    - Dictionaries
    - Stacks
    - Queues

    This example demonstrates the List<T> data structure, where <T> is the generic data type.
    Lists are very flexible to work with - one can add, insert and remove elements anywhere in the structure,
    unlike the more restricted ones such as Stacks and Queues.

    A List is essentially a resizable array.

    List methods include (this listing is not inclusive):
    Add(T)              --- adds an element T at the end of the List
    BinarySearch(T)     --- searches the entire sorted list looking for element T
    Clear()             --- removes all elements from the List
    Contains(T)         --- determines whether element T exists in the List
    Insert(Int32, T)    --- inserts an element T at position Int32
    Remove(T)           --- removes the first occurrence of T
    RemoveAt(Int32)     --- removes the element at position Int32
    Reverse()           --- reverses the order of the elements in the entire List
    Sort()              --- sorts the order of the elements in the entire List using the default comparer
    ToArray()           --- copies the elements in the List to a fixed new array object

    MSDN documentation:
    https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx

    NOTE: The DisplayGenericList() method is used to display 3 List objects which contain string, DateTime and Dog objects
          Using a generic data type can provide a lot of flexibility of the programmer.

    This example is structured in a simple 4-step process:

    1. Declare data variables needed for this program
    2. Get/Set input for the data we need
    3. Process the data in some meaningful way
    4. Output what we want to see

    The understanding is based on the idea that every computer program runs this way despite its complexity

    Source code is error-free and was tested in MS Visual Studio 2015 as at March, 2017
    Hans Telford

    
*/

using System;
using System.Collections.Generic;   // need this to use List<T> data structure
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace List_Example
{
    // a Dog class
    public class Dog
    {
        // private instance data (can only be accessed by public methods in this class)
        private string name;
        private string type;
        private int age;

        // constructor method (intialises the private data by using input values)
        public Dog (string name, string type, int age)
        {
            this.name = name;
            this.type = type;
            this.age = age;
        }

        // override method ToString() used to override the Object class ToString() method
        // this is done to provide a customised string output of the class instance variables
        public override string ToString()
        {
            return "Dog object - Name: " + this.name + "\tType: " + this.type + "\tAge: " + this.age;
        }

    }

    // our test (containing Main())
    class ListEx
    {
        static void Main(string[] args)
        {
            // 1. Declare data variables needed for this program
            // Instantiate a List object called gameGenres that contains string values
            List<string> gameGenres = new List<string>();

            //  2. Get input for the data we need
            //     In this case, we are only adding data into each of the three data structures

            // Add elements to gameGenres
            gameGenres.Add("Action");
            gameGenres.Add("Puzzle");
            gameGenres.Add("Arcade");
            gameGenres.Add("Role-Playing Game or RPG");
            gameGenres.Add("First-Person Shooter or FPS");     

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******          List Example        *******");
            Console.WriteLine("********************************************");

            // 3.Process the data in some meaningful way
            // 4.Output what we want to see

            Console.WriteLine("The initialised list of game genres ...");
            DisplayGenericList(gameGenres);

            // demonstrate Remove() and RemoveAt() methods
            gameGenres.Remove("Arcade");
            gameGenres.RemoveAt(0);
            Console.WriteLine("The list after using Remove('Arcade') and then RemoveAt(0) ...");
            DisplayGenericList(gameGenres);

            // demonstrate Sort() method
            gameGenres.Sort();
            Console.WriteLine("The list after sorting ...");
            DisplayGenericList(gameGenres);

            // demonstrate Reverse() method
            gameGenres.Reverse();
            Console.WriteLine("The reversed list ...");
            DisplayGenericList(gameGenres);

            Console.WriteLine("********************************************");

            /*********************************************************/

            List<DateTime> timeList = new List<DateTime>();
            // arguments list is year, month, day, hour, minute, second
            timeList.Add(new DateTime(2015, 2, 1, 7, 0, 0));
            timeList.Add(DateTime.Now);
            timeList.Add(new DateTime(2000, 1, 1, 12, 0, 0));

            timeList.Sort();
            Console.WriteLine("Time list after sorting ...");
            DisplayGenericList(timeList);
            Console.WriteLine("********************************************");

            /*********************************************************/

            List<Dog> doggies = new List<Dog>();
            // Add doggies
            doggies.Add(new Dog("Bruce", "Chihuahua", 5));
            doggies.Add(new Dog("Lucy", "Jack Russell", 3));
            doggies.Add(new Dog("Ralph", "Labrador", 2));

            Console.WriteLine("List of Dog objects (doggies) ...");
            DisplayGenericList(doggies);
            Console.WriteLine("********************************************");

            /*********************************************************/
        }

        // Generic method that is able to display many types of list objects
        // more flexible than using a specific data type for the list object
        static void DisplayGenericList<T> (List<T> genericList)
        {
            Console.WriteLine("");
            int i = 1;
            foreach (var genericItem in genericList)
            {
                Console.WriteLine(i + ". " + genericItem.ToString());
                i++;
            }
            Console.WriteLine("");
        }

    }
}


/*
    OUTPUT:

        ********************************************
        *******          List Example        *******
        ********************************************
        The initialised list of game genres ...

        1. Action
        2. Puzzle
        3. Arcade
        4. Role-Playing Game or RPG
        5. First-Person Shooter or FPS

        The list after using Remove('Arcade') and then RemoveAt(0) ...

        1. Puzzle
        2. Role-Playing Game or RPG
        3. First-Person Shooter or FPS

        The list after sorting ...

        1. First-Person Shooter or FPS
        2. Puzzle
        3. Role-Playing Game or RPG

        The reversed list ...

        1. Role-Playing Game or RPG
        2. Puzzle
        3. First-Person Shooter or FPS

        ********************************************
        Time list after sorting ...

        1. 1/01/2000 12:00:00 PM
        2. 1/02/2015 7:00:00 AM
        3. 28/03/2017 1:08:06 PM

        ********************************************
        List of Dog objects (doggies) ...

        1. Dog object - Name: Bruce     Type: Chihuahua Age: 5
        2. Dog object - Name: Lucy      Type: Jack Russell      Age: 3
        3. Dog object - Name: Ralph     Type: Labrador  Age: 2

        ********************************************
        Press any key to continue . . .
*/
