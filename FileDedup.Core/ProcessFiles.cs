using System;
using System.Collections.Generic;
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
            int countDeleted = 0;
            int count1MM = 0;
            int count2MBook = 0;
            int count3MBPro = 0;

            // Set the variable "dirs" to contain a list of all directories under the "root" directory.
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(root, "*", SearchOption.AllDirectories));

            // Print the list of directories to a text file.
            for (int i=0; i < 1000; i++)
            {
 
                // Drop directories that need not be saved
                if (dirs[i].Contains("RECYCLE.BIN")
                    || dirs[i].Contains(@"\Desktop") 
                    )
                {
                    Console.Write("DELETE              : ");
                    countDeleted++;
                } else
                // put remaining directories in one of three lists
                if (dirs[i].Contains("from 1MM"))
                {
                    Console.Write("write to 1MM list   : ");
                    count1MM++;
                } else
               if (dirs[i].Contains("from 2MBook"))
                {
                    Console.Write("write to 2MBook list: ");
                    count2MBook++;
                } else
               if (dirs[i].Contains("from 3MBPro"))
                {
                    Console.Write("write to 3MBPro list: ");
                    count3MBPro++;
                }
                Console.WriteLine(dirs[i]);


            }
            Console.WriteLine("countDeleted = {0}", countDeleted);
            Console.WriteLine("count1MM = {0}", count1MM);
            Console.WriteLine("count2MBook = {0}", count2MBook);
            Console.WriteLine("count3MBPro = {0}", count3MBPro);

        }

    }
}


