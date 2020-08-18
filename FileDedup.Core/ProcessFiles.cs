﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;


namespace FileDedup.Core
{
    public class StackBasedIteration
    {

        public static void TraverseTest2()
        {
            Stack<string> outputStack = new Stack<string>();

            // Specify the starting folder on the command line, or in
            // Visual Studio in the Project > Properties > Debug pane.
            TraverseTree2(@"C:\zz_TEMP", @"C:\zz_TEMP_OUT", outputStack);
            var test = 0;
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\MasterFileUpdates.txt", outputStack);
        }

        public static void TraverseTree2(string sourceFolder, string destinationFolder, Stack<string> outputStack)
        {
            Stack<string> stackOfSourceFiles = new Stack<string>();
            Stack<string> stackOfSourceFolders = new Stack<string>();
            int miscCounter = 0;
            int maxLoops = 50;
            //establish starting point for the process
            stackOfSourceFolders.Push(sourceFolder);

            // Loop through each folder gathered during the process
            while (stackOfSourceFolders.Count > 0 && maxLoops-- > 0)
            {
                // Get next folder to process
                sourceFolder = stackOfSourceFolders.Pop();

                // Get list of file names in source folder
                var sourceFileNames = Directory.GetFiles(sourceFolder);

                // Get list of file names in destination folder
                var destinationFileList = Directory.GetFiles(destinationFolder);

                // iterate through file names in source folder
                foreach (var sourceFileName in sourceFileNames)
                {
                    ProcessFile(sourceFileName, destinationFileList, outputStack);
                    miscCounter++;
                }

                // Process subfolders in this folder
                var folderNames = Directory.GetDirectories(sourceFolder);
                foreach (var folderName in folderNames)
                {
                    miscCounter++;
                }

            }
        } // end of TraverseTree2 method


        public static void ProcessFile(string sourceFileName, string[] destinationFileList, Stack<string> outputStack)
        {
            int miscCounter = 0;
            // see source file should be dumped
            if (DumpElement(sourceFileName))
            {
                // Source file sould be dumped, see if destination file exists
                if (ElementInList(sourceFileName, destinationFileList))
                {
                    miscCounter++;
                    // Remove destination file name
                    return;
                }
            }
            miscCounter++;
            // Create destination file name
            var destinationFileName = sourceFileName.Replace("TEMP", "TEMP_OUT");

            // Copy source file to destination folder
//          string line2 = "copy " + "\"" + sourceString   + "\\" + "*.*" + "\"" + " " + "\"" + destinationString   + "\"";

             // Original - keep for reference
//           string line1 = "copy " + "\"" + sourceFileName + "\\" + "*.*" + "\"" + " " + "\"" + destinationFileName + "\"";

             string line1 = "copy " + "\"" + sourceFileName + "\"" + " " +"\"" + destinationFileName + "\"";

            outputStack.Push(line1);







            
        }


        public static bool ElementInList(string value, string[] stringArray)
        {
            int pos = Array.IndexOf(stringArray, value);
            if(pos > -1)
            {
                // value IS NOT in stringArray
                return false;
            }
            // value IS in stringArray
            return true;
        }

        public static bool DumpElement(string entity)
        {
           if (entity.Contains("RECYCLE.BIN")
            || entity.Contains(@"\Desktop")
            || entity.Contains(@"\from 1MM\Users\margaret\Documents\_R")
            || entity.Contains(@"\from 3MBPro\Users\ronpearl\_M")
            || entity.Contains(@"untitled folder")
            || entity.Contains(@"\.")
            || entity.Contains(@"\from 2MBook\Users\apple\Library")
            || entity.Contains(@"\from 2MBook\Users\apple\src\ltcadm")
            || entity.Contains(@"\from 2MBook\Users\apple\src\ltcuat")
            || entity.Contains(@"\from 2MBook\Users\apple\tmp")
            || entity.Contains(@"\Address Book -")
            || entity.Contains(@"\ScanSnap\")
            || entity.Contains(@"z_backups\")
            || entity.Contains(@".DS_Store")
            || entity.Contains(@"\z_Archive")
            || entity.Contains(@"trash")
            )
            {
                return true;
            }
            return false;

        }


// ===================================================================================================================================


    /*
       Overview
                --------
                This version of the program reads ONE soure repository and updates one destination repository
                It is meant to be used repeatedly with different source repositories to continuously update the destination repository.
                It could even be used to keep a running destination repository to eliminate the need for constantly adding new data to
                existing archive repositories.In this scenario, the active repository would be backed up only to protect against
                short-term data loss.

                Data categories
                ---------------
                Data Consolidation Map
                - Needed files that do not have special characters or permissions
                - Needed Files that have special characters

                    cannot be uploaded to SP6
                    are already on MBPro
                - Needed Files that have special permissions

                    are already on SP6

                    cannot be opened on MBPro
                - UnNeeded Files

                    that are on one or both systems


                PseudoCode - ProcessRepo
                ------------------------
                Open source repository and destination reposotiry
                Navigate to first folder in repo
                For each folder in the source repo
                    Call ProcessFile with


                PseudoCode - Processfile
                ------------------------

                   generate fully qualified file name
                if (file not needed) 
                    if (file exists on destination repo)
                        delete file
                if (file needed)
                    if (file does not exist on destination repo)
                        Copy file into destination repo


    */





    // ==================== Original TraverseTree method ================
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
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\makeDir.txt", myStack4Sort);
            System.IO.File.WriteAllLines(@"c:\zz_TEMP\working folder\makeFile.txt", myStack5Sort);

            Console.WriteLine("Writing to text files complete");

        }
    }
}



