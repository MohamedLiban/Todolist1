using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public interface IObserver
    {
        void Update();
    }

    public class TaskList : IObserver
    {
        private List<Task> tasks = new List<Task>();

        public void Update()
        {
            Console.WriteLine("Task list has been updated.");
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
    }
}
