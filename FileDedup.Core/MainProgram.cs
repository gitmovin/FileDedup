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
