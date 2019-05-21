using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ConsoleTODO.Models;

namespace ConsoleTODO.Controllers
{
    public static class DataAccess
    {
        public static string FullFilePath(this string fileName)
        {
            return $"H:\\jpmDesk\\Desktop\\CODE\\DOTNET\\ConsoleTODO\\Data\\{ fileName }";
        }

        public static List<string> LoadDataFromFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<TaskModel> BuildTaskList(this List<string> lines)
        {
            List<TaskModel> tasks = new List<TaskModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split('|');

                TaskModel t = new TaskModel();
                t.Id = int.Parse(cols[0]);
                t.TaskName = cols[1];
                t.TaskDescription = cols[2];
                t.TaskDueDate = cols[3];

                tasks.Add(t);
            }

            return tasks;
        }

        public static void SaveDataToFile(this List<TaskModel> tasks, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TaskModel t in tasks)
            {
                lines.Add($"{ t.Id }|{ t.TaskName }|{ t.TaskDescription }|{ t.TaskDueDate }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines, Encoding.UTF8);
        }

        public static List<TaskModel> CreateNewTask(List<TaskModel> currentTasks, string fileName)
        {
            TaskModel task = new TaskModel();

            if (currentTasks.Count > 0) {
                task.Id = currentTasks.Max(x => x.Id) + 1;
            }
            else
            {
                task.Id = 1;
            }
            Console.WriteLine($"This task's ID will be { task.Id }."); // debug?
            Console.Write("Please specify the task's name: ");
            task.TaskName = Console.ReadLine();
            Console.Write("Please specify the task's description: ");
            task.TaskDescription = Console.ReadLine();
            Console.Write("When it should be done? (DD/MM/YYYY): ");
            task.TaskDueDate = Console.ReadLine();
            if (string.IsNullOrEmpty(task.TaskDueDate)) task.TaskDueDate = "No deadline";

            currentTasks.Add(task);

            currentTasks.SaveDataToFile(fileName);

            return currentTasks;
        }

        public static List<TaskModel> EditTask(List<TaskModel> currentTasks, string fileName)
        {
            string newName;
            string newDescription;
            string newDate;
            int idToEdit = 0;

            try
            {
                Console.Write("Enter the ID of the task you want to edit: ");
                idToEdit = Convert.ToInt32(Console.ReadLine());

                TaskModel selectedTask = currentTasks.Where(x => x.Id == idToEdit).First();

                Console.Write("Enter the new name for this task (or leave empty): ");
                newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) selectedTask.TaskName = newName;
                Console.Write("Enter the new description for this task (or leave empty): ");
                newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription)) selectedTask.TaskDescription = newDescription;
                Console.Write("Enter the new due date for this task (or leave empty): ");
                newDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDate)) selectedTask.TaskDueDate = newDate;

                currentTasks.SaveDataToFile(fileName);

                return currentTasks;
            }
            catch
            {
                return currentTasks;
            }
        }

        public static List<TaskModel> RemoveTask(List<TaskModel> currentTasks, string fileName)
        {
            int idToRemove = 0;

            try
            {
                Console.Write("Enter the ID of the task you want to remove: ");
                idToRemove = Convert.ToInt32(Console.ReadLine());

                TaskModel selectedTask = currentTasks.Where(x => x.Id == idToRemove).First();

                currentTasks.Remove(selectedTask);
                currentTasks.SaveDataToFile(fileName);

                Console.WriteLine("Task has been successfully removed.");

                return currentTasks;
            }
            catch
            {
                return currentTasks;
            }
        }
    }
}
