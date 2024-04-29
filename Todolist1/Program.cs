
using System;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskList taskList = new TaskList(); 

            ToDoListManager todoManager = ToDoListManager.Instance;

            
            todoManager.AttachObserver(taskList);

            
            todoManager.AddTask(TaskFactory.CreateTask("Städa", 3));
            todoManager.AddTask(TaskFactory.CreateTask("Laga mat", 1));
            todoManager.AddTask(TaskFactory.CreateTask("Gör klart arbetet", 2));

            
            todoManager.SortTasksByPriority();

           
            Console.WriteLine("\nSorted tasks:");
            foreach (var task in todoManager.GetTasks())
            {
                Console.WriteLine(task);
            }
        }
    }
}
