using System;

namespace ConsoleTODO.Models
{
    public class TaskModel 
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskDueDate { get; set; } // make it DateTime later perhaps?
    }    
}
