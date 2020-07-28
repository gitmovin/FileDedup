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
            // Set a variable to the My Documents path.

//            List<string> dirs = new List<string>(root);
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(root));












            /*
                        string docPath1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                                   // Data structure to hold names of subfolders to be
                                   // examined for files.
                                   Stack<string> dirs = new Stack<string>(20);

                                   if (!System.IO.Directory.Exists(root))
                                   {
                                       throw new ArgumentException();
                                   }
                                   dirs.Push(root);
                        */
        }
    }
}


