using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;


namespace FileDedup.Core
{
    public class StackBasedIteration
    {
        public static void TraverseTest()
        {
            // Specify the starting folder on the command line, or in
            // Visual Studio in the Project > Properties > Debug pane.
            TraverseTree(@"C:\zz_TEMP");
        }

        public static void TraverseTree(string root)
        {
            // Counters
            int countDeleted = 0;
            int count1MM = 0;
            int count2MBook = 0;
            int count3MBPro = 0;
            bool createNewFolderAndFile;
            string sourceString, destinationString;
            // Stacks for containing processed strings representing directories
            Stack<string> myStack0 = new Stack<string>();
            Stack<string> myStack1 = new Stack<string>();
            Stack<string> myStack2 = new Stack<string>();
            Stack<string> myStack3 = new Stack<string>();
            Stack<string> myStack4 = new Stack<string>();
            Stack<string> myStack5 = new Stack<string>();


            // Set the variable "dirs" to contain a list of all directories under the "root" directory.
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(root, "*", SearchOption.AllDirectories));

 
            // Print the list of directories to a text file.
            for (int i=0; i < dirs.Count; i++)
            {
                createNewFolderAndFile = true;
                // Drop directories that need not be saved
                if (dirs[i].Contains("RECYCLE.BIN")
                    || dirs[i].Contains(@"\Desktop")
                    || dirs[i].Contains(@"\from 1MM\Users\margaret\Documents\_R")
                    || dirs[i].Contains(@"\from 3MBPro\Users\ronpearl\_M")
                    || dirs[i].Contains(@"untitled folder")
                    || dirs[i].Contains(@"\.")
                    || dirs[i].Contains(@"\from 2MBook\Users\apple\Library")
                    || dirs[i].Contains(@"\from 2MBook\Users\apple\src\ltcadm")
                    || dirs[i].Contains(@"\from 2MBook\Users\apple\src\ltcuat")
                    || dirs[i].Contains(@"\from 2MBook\Users\apple\tmp")
                    || dirs[i].Contains(@"\Address Book -")
                    || dirs[i].Contains(@"\ScanSnap\")
                    || dirs[i].Contains(@"z_backups\")
                    || dirs[i].Contains(@".DS_Store")
                    || dirs[i].Contains(@"\z_Archive")
                    || dirs[i].Contains(@"trash")
                    )
                {
//                    Console.Write("DELETE              : ");
                    myStack0.Push(dirs[i]);
                    createNewFolderAndFile = false;
                    countDeleted++;
                } else
                // put remaining directories in one of three lists
                if (dirs[i].Contains("from 1MM"))
                {
//                    Console.Write("write to 1MM list   : ");
                    myStack1.Push(dirs[i]);
                    count1MM++;
                } else
               if (dirs[i].Contains("from 2MBook"))
                {
 //                  Console.Write("write to 2MBook list: ");
                    myStack2.Push(dirs[i]);
                    count2MBook++;
                } else
               if (dirs[i].Contains("from 3MBPro"))
                {
 //                   Console.Write("write to 3MBPro list: ");
                    myStack3.Push(dirs[i]);
                    count3MBPro++;
                }
                // Write to files that create folders and files
 //               Console.Write(\" Line(dirs[i]);
                if (createNewFolderAndFile)
                {
                    sourceString= dirs[i];
                    destinationString = sourceString.Replace("TEMP", "TEMP_OUT");
                     string line1 = "mkdir " + "\"" + destinationString + "\"";
                    string line2 = "copy " + "\"" + sourceString + "\\" + "*.*" + "\"" + " " + "\"" + destinationString + "\"";
                    myStack4.Push(line1);
                    myStack5.Push(line2);
                }
            }

            // Print summary on console
            Console.WriteLine("countDeleted = {0}", countDeleted);
            Console.WriteLine("count1MM = {0}", count1MM);
            Console.WriteLine("count2MBook = {0}", count2MBook);
            Console.WriteLine("count3MBPro = {0}", count3MBPro);

            Console.WriteLine("Writing to text files started");
            
            // Sort arrays before writing to file
            string[] myStack0Sort = myStack0.ToArray();
            Array.Sort(myStack0Sort);
            string[] myStack1Sort = myStack1.ToArray();
            Array.Sort(myStack1Sort);
            string[] myStack2Sort = myStack2.ToArray();
            Array.Sort(myStack2Sort);
            string[] myStack3Sort = myStack3.ToArray();
            Array.Sort(myStack3Sort);
            string[] myStack4Sort = myStack4.ToArray();
            Array.Sort(myStack4Sort);
            string[] myStack5Sort = myStack5.ToArray();
            Array.Sort(myStack5Sort);

            // Create sorted text files
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\filesDeleted.txt", myStack0Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\files1MM.txt", myStack1Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\files2MBook.txt", myStack2Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\files3MBPro.txt", myStack3Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\makeDir.bat", myStack4Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\makeFile.bat", myStack5Sort);

            Console.WriteLine("Writing to text files complete");

        }
 /*       // Replace substring
        ReplaceSubstring(string masterString, string fromString, string toString)
        {
            // Convert string to character array
            string source = "The mountains are behind the clouds today.";

            // Replace one substring with another with String.Replace.
            // Only exact matches are supported.
            var replacement = source.Replace("mountains", "peaks");
            Console.WriteLine($"The source string is <{source}>");
            Console.WriteLine($"The updated string is <{replacement}>");
        }
*/
    }
}
