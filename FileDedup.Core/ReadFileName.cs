using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDedup.Core
{
      class File
    {
        string PathAndFile, Name, Path;
        DateTimeOffset DateTime;
        int size;
        internal File First, Next, Last, Prev;

    }

    class ReadFiles
    {
        public static void ReadFileNames()
        {
            // Set up program to use Unix-style End Of Line (EOL) character
 //           System.Console.Out.NewLine.


            // Set up input file
            string inputFilename = "C:\\Users\\ron\\temp\\findResults3.txt";
           StreamReader inputFilePointer = new StreamReader(inputFilename);
 

            // Set up output file
            string outputFilename = "C:\\Users\\ron\\temp\\renamingCommand.txt";
            using (System.IO.StreamWriter outputFilePointer = new System.IO.StreamWriter(outputFilename))
            {

                ProcessRgpFile(inputFilePointer, outputFilePointer, ":");
                ProcessRgpFile(inputFilePointer, outputFilePointer, "|");
                outputFilePointer.Close();
            }
            // if we need to keep window open
            System.Console.WriteLine("Press ENTER twice to end program");
            System.Console.ReadLine();
            inputFilePointer.Close();
        }


        static void ProcessRgpFile(System.IO.StreamReader inputFilePointer, System.IO.StreamWriter outputFilePointer, string stringToReplace)
        {
            int i, j;
            int lines = 0;
            int index = 0, count = 0, addressBook = 0;
            string pathAndFileName1, pathAndFileName2, outputCommand0, outputCommand1, outputCommand2, outputCommand3;
 //           StreamReader sr = new StreamReader(inputFilename);
 //           using (System.IO.StreamWriter outputFilename = new System.IO.StreamWriter(outputFilename))

                try
                {
                for (i = 1; i <= 1000000; i++)
                {
                    // For each line
                    pathAndFileName1 = pathAndFileName2 = inputFilePointer.ReadLine();
                    if (pathAndFileName1 == null)
                    {
                        break;
                    }
                    lines++;
                    for (j = 0;j<10;j++)
                    {
                        index = pathAndFileName2.IndexOf(stringToReplace);
                        if (index < 0)
                        {
                            // No more special characters in this line
                            break;
                        }
                        count++;


                        // Write command to show file before name change
                        outputCommand0 = "ls -l \"" + pathAndFileName1 + "\"";
                        outputFilePointer.WriteLine(outputCommand0);

                        // Write command to give write permission to user
                        outputCommand1 = "chmod g+w \"" + pathAndFileName1 + "\"";
                        outputFilePointer.WriteLine(outputCommand1);

                        // Write commmand to rename file
                        StringBuilder sb = new StringBuilder(pathAndFileName1);
                        sb[index] = ' ';
                        pathAndFileName2 = sb.ToString();
                        outputCommand2 = "mv \"" + pathAndFileName1 + "\" \"" + pathAndFileName2 + "\"";
                        outputFilePointer.WriteLine(outputCommand2);

                        // Write command to show file after name change
                        outputCommand3 = "ls -l \"" + pathAndFileName2 + "\"";
                        outputFilePointer.WriteLine(outputCommand3);
                        outputFilePointer.WriteLine("");
 /*                     index = pathAndFileName1.IndexOf("AddressBook");
                        if (index >= 0)
                        {
                            addressBook++;
                        }
*/
                    }
                }
            }
            catch
            {
                Console.WriteLine("ERROR opening the output file ");

            }
            Console.WriteLine("Count = " + count);
            Console.WriteLine("AddressBook = " + addressBook);
            Console.WriteLine("total lines = " + lines);
        }
    }
}

/*
 * Found 174 "|" characters.
 * Found 21,084 ":" characters..
 * */
