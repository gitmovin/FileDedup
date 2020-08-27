using System;

namespace FileDedup.Core
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling Menu");
            Menu.MainMenu();
            Console.WriteLine("End Program.");
            return;
        }
    }
}



/*

Process
- Use thumbdrive as receiving end of the process - Build the master database on the thumbdrive

- Run a test to see how the thumb drive and W10 handle file names with special characters
    Confirmed - need to filter out special characters

- Add function to reverse order to string before writing to disk file - DONE

- new repository is building on C:\zz_TEMP_OUT

- fix the fact that existing folders in destination folder are not being seen and mkdir wants to create them



- Add "CleanFileName" method to the DeBup process - always check for ":" and "|" when files are read
- Add ability to enter Number of iterations with the menu - will mean creating new way to pass vars to objects
- Add ability to execute file after creating it, and capturing log of results










====================================================================

ThumbDrive SPeeds: 
Write from W10 to ThumbDrive - 6,737976 Bps - 1F file in 2:49 minutes
Read from Thumbdrive to Mac Mini - 1GB file in 1:01 minutes
Write from Mac Mini to Thumbdrive - 1GB file in 2:52 minutes
Read from Thumrbrivev to W10 - 1GB file in 1:01 minutes
 
*/
