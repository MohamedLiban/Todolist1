using System;
using System.Collections.Generic;
using ToDoListApp.ToDoListApp;

namespace ToDoListApp
{
    public class ToDoListManager
    {
        private static ToDoListManager instance;
        private List<Task> tasks = new List<Task>();
        private List<IObserver> observers = new List<IObserver>();

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
            NotifyObservers(); 
        }

        public IEnumerable<Task> GetTasks()
        {
            return tasks;
        }

        public void SortTasksByPriority()
        {
            tasks.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            NotifyObservers(); 
        }

        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
    namespace ToDoListApp
    {
        public interface IObserver
        {
            void Update();
            void Observer(); 
        }
    }
}
