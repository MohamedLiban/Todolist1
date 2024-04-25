using System;
using System.Collections.Generic;

namespace ToDoListApp
{
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

        public void update()
        {
            throw new NotImplementedException();
        }

        
    }

    public interface IObserver
    {
        void update();
    }
}
