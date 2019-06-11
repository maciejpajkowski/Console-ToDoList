using System;
using System.Collections.Generic;
using ConsoleTODO.Models;
using ConsoleTODO.Views;
using ConsoleTODO.Controllers;

namespace ConsoleTODO
{
    class Program
    {
        private const string dataFile = "TasksData.csv";
        private const string testDataFile = "TestingData.csv";
        
        static void Main(string[] args)
        {
            int currentOption = 0; 

            Console.Clear();
            Console.WriteLine("Welcome!");

            // STATE
            List<TaskModel> tasks = dataFile.FullFilePath().LoadDataFromFile().BuildTaskList();
            TaskList.Display(tasks);

            while (true) {
                Menu.Display();
                Console.Write("What would you like to do? (enter option number): ");

                try 
                {
                    currentOption = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Returning to main menu...");
                    TaskList.Display(tasks);
                    continue;
                }

                if (currentOption > 4 || currentOption < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Returning to main menu...");
                    TaskList.Display(tasks);
                    continue;
                }

                switch (currentOption)
                {
                    case 1:
                        DataAccess.CreateNewTask(tasks, dataFile);
                        TaskList.Display(tasks);
                        break;
                    case 2:
                        DataAccess.EditTask(tasks, dataFile);
                        TaskList.Display(tasks);
                        break;
                    case 3:
                        DataAccess.RemoveTask(tasks, dataFile);
                        TaskList.Display(tasks);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
