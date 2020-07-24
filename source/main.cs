/////////////////////////////////////////
// 
// Uses "Console App(.NET Core)" template
// C:\Users\ron\OneDrive\Desktop\My first git>dotnet --list-sdks
// 3.1.302 [C:\Program Files\dotnet\sdk]
//
/////////////////////////////////////////

using System;
//using System.Linq.Expressions;

namespace ConsoleApp3_Switch_Driven
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            while (true)
            {

                Console.WriteLine("Enter command");
                command = Console.ReadLine();
                switch (command)
                {
                    case "test":
                        Console.WriteLine("This is a test command");
                        break;
                    case "scan":
                        bluetooth.scan();
                        break;
                    case "quit":
                        Console.WriteLine("Ending program");
                        return;
                    default:
                        Console.WriteLine("BAD COMMAND. Type \"quit\" or try again");
                        break;
                }
            }
        }
        
    }
    