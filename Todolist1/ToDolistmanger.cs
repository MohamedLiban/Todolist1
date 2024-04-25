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
            tasks.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }



    }
}
