/////////////////////////////////////////
// 
// Uses "Console App(.NET Core)" template
// C:\Users\ron\OneDrive\Desktop\My first git>dotnet --list-sdks
// 3.1.302 [C:\Program Files\dotnet\sdk]
//
/////////////////////////////////////////

using System;

namespace FileDedup.Core

{
    class Menu
    {
        public static void MainMenu()
        {
            string command;
            while (true)
            {

                Console.WriteLine("Enter command");
                command = Console.ReadLine();
                switch (command)
                {
                    case "read":
                        ReadFiles.ReadFileNames();
                        break;
                    case "test":
                        Console.WriteLine("This is a test command");
                        break;
                    case "scan":
                        // bluetooth.scan();
                        break;
                    case "quit":
                    case "exit":
                        Console.WriteLine("Ending program");
                        return;
                    default:
                        Console.WriteLine("BAD COMMAND. Type \"quit\" or try again");
                        break;
                }
            }
        }

    }
}
    