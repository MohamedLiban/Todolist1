using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class ToDoListManager
    {
        private static ToDoListManager instance;
        private List<Task> tasks = new List<Task>();
        private TaskList taskList = new TaskList();

        private ToDoListManager() { }

        public static ToDoListManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ToDoListManager();
                }
                return instance;
            }
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
            taskList.Update();
        }

        public IEnumerable<Task> GetTasks()
        {
            return tasks;
        }

        public void SortTasksByPriority()
        {
            int n = tasks.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (tasks[j].Priority > tasks[j + 1].Priority)
                    {
                        Task temp = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = temp;
                    }
                }
            }
        }
    }
}
