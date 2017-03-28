/*
    A Hashtable is a dynamic data structure which represents a collection of key/value pairs 
    that are organized based on the hash code of the key.

    Hashtable is basically a data structure to retain values of key-value pair 
    where your key can not be duplicated.

    Hashtable optimises lookups. It computes a hash of each key you add. 
    It then uses this hash code to look up the element very quickly.

    The Dictionary data structure is similar and also uses key/value pairs, however it is a generic data
    type; whereas the Hashtable is not. This means the Dictionary provides type safety because you can't
    insert any random object into it and you don't have to cast values that are taken out.

    MSDN documentation source:
    https://msdn.microsoft.com/en-us/library/system.collections.hashtable(v=vs.110).aspx

    This example is structured in a simple 4-step process:

    1. Declare data variables needed for this program
    2. Get input for the data we need
    3. Process the data in some meaningful way
    4. Output what we want to see

    The understanding is based on the idea that every computer program runs this way despite its complexity.

    The example stores keys for a file extension (e.g. "txt", "rtf", "doc") and values for the executable
    program that opens the extensions. If the file extension is "txt", then the program launches "notepad.exe".

    Source code is error-free and was tested in MS Visual Studio 2015 as at March, 2017
    Hans Telford

    OUTPUT:

    ********************************************
    *******       Hash Table Example     *******
    ********************************************
    Key = rtf, Value = wordpad.exe
    Key = ppt, Value = powerpnt.exe
    Key = txt, Value = notepad.exe
    Key = csv, Value = excel.exe
    Key = doc, Value = winword.exe
    ********************************************
    What type of file do you wish to open? (txt, rtf, ppt, csv or doc) --> txt
    Press any key to continue . . .


*/

using System;
using System.Collections;   // needed for Hashtable class
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashtableEx
    {
        static void Main(string[] args)
        {
            // 1.Declare data variables needed for this program
            // Hashtable object
            Hashtable appLauncher = new Hashtable();
            // string variable used to capture (from the user) what file type to open
            string fileTypeToOpen = "";

            // 2. Get input for the data we need
            //    In this case, add what we need for the appLauncher object
            appLauncher.Add("txt", "notepad.exe");
            appLauncher.Add("rtf", "wordpad.exe");
            appLauncher.Add("ppt", "powerpnt.exe");
            appLauncher.Add("csv", "excel.exe");
            appLauncher.Add("doc", "winword.exe");

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******       Hash Table Example     *******");
            Console.WriteLine("********************************************");

            // Display all of the key/value pairs in appLauncher Hashtable
            foreach (DictionaryEntry de in appLauncher)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            Console.WriteLine("********************************************");

            // 3. Process the data in some meaningful way
            // Practical use example
            Console.Write("What type of file do you wish to open? (txt, rtf, ppt, csv or doc) --> ");
            fileTypeToOpen = Console.ReadLine().ToLower();

            // 4. Output what we want to see
            // Run this in a try/catch block in case there are any issues in launching windows apps
            try
            {
                // check if the appLauncher Hashtable contains the key
                if (appLauncher.ContainsKey(fileTypeToOpen))
                {
                    // if it does, launch the exe program associated with it
                    System.Diagnostics.Process.Start(appLauncher[fileTypeToOpen].ToString());
                }
                else
                {
                    // otherwise, display an error message
                    Console.WriteLine("ERROR: " + fileTypeToOpen + " is not listed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION CAUGHT: " + e.ToString());
            }
            
            // NOTE: This is a lot simpler than writing a whole bunch of if/else-if statements
        }
    }
}
