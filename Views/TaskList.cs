using System;
using System.Text;
using System.Collections.Generic;
using ConsoleTODO.Models;

namespace ConsoleTODO.Views
{
    public static class TaskList
    {
        public static void Display(List<TaskModel> tasks)
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine("Here are your current tasks:");
            } 
            else 
            {
                Console.WriteLine("Nothing to do! :D");
            } 

            foreach (TaskModel task in tasks)
            {
                Console.WriteLine("");
                Console.WriteLine($"  ID: { task.Id }  |  { task.TaskName }                            ");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"  { task.TaskDescription }                                 ");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"                                Due: { task.TaskDueDate }  ");
                Console.WriteLine("");
            }
        }
    }
}

//
//   ID: Id   |  TaskName
// --------------------------------------------------
//   TaskDescription
//
// --------------------------------------------------
//                                 Due: TaskDueDate
