using System;
using ConsoleTODO.Controllers;

namespace ConsoleTODO.Views
{
    public static class Menu
    {
        public static void Display()
        {
            Console.WriteLine("--------------- MENU ---------------");
            Console.WriteLine("1. Create a new task.");
            Console.WriteLine("2. Edit an existing task.");
            Console.WriteLine("3. Delete an existing task.");
            Console.WriteLine("4. Quit the application.");
        }
    }
}
