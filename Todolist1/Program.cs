using System;
using System.Collections.Generic;
using System.Linq;


public interface IObserver
{
    void Update();
}

public class TaskList
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

public class Task : IObserver
{
    private string name;
    private int priority;
    private bool isCompleted;

    public Task(string name, int priority)
    {
        this.name = name;
        this.priority = priority;
        this.isCompleted = false;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Priority
    {
        get { return priority; }
        set { priority = value; }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public void Update()
    {
        Console.WriteLine($"Task '{name}' has been updated.");
    }

    public override string ToString()
    {
        return $"Task: {name}, Priority: {priority}, Completed: {isCompleted}";
    }
}


public class ToDoListManager
{
    private static ToDoListManager instance;
    private List<Task> tasks = new List<Task>();

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
    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void EditTask(Task task, string newName, int newPriority)
    {
        task.Name = newName;
        task.Priority = newPriority;
    }

    public void MarkTaskAsCompleted(Task task)
    {
        task.IsCompleted = true;
    }

    public List<Task> GetTasksByPriorityRange(int minPriority, int maxPriority)
    {
        return tasks.Where(task => task.Priority >= minPriority && task.Priority <= maxPriority).ToList();
    }

    public void SortTasksByPriority()
    {
        tasks.Sort((x, y) => x.Priority.CompareTo(y.Priority));
    }

    public List<Task> GetTasks()
    {
        return tasks;
    }

    public void PrintTasks()
    {
        Console.WriteLine("Current tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}


public static class TaskFactory
{
    public static Task CreateTask(string name, int priority)
    {
        return new Task(name, priority);
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        Task task1 = TaskFactory.CreateTask("Städa", 3);
        Task task2 = TaskFactory.CreateTask("Laga mat", 1);
        Task task3 = TaskFactory.CreateTask("Gör klart arbetet", 2);
        Task task4 = TaskFactory.CreateTask("Hämta barnen", 4);
        Task task5 = TaskFactory.CreateTask("Träna", 5);
        Task task6 = TaskFactory.CreateTask("Ringa mamma", 6);
        Task task7 = TaskFactory.CreateTask("Köpa mat", 7);
        Task task8 = TaskFactory.CreateTask("Betala räkningar", 8);
        Task task9 = TaskFactory.CreateTask("Läsa bok", 9);
        Task task10 = TaskFactory.CreateTask("Planera semester", 10);

        
        ToDoListManager todoManager = ToDoListManager.Instance;

        
        todoManager.AddTask(task1);
        todoManager.AddTask(task2);
        todoManager.AddTask(task3);
        todoManager.AddTask(task4);
        todoManager.AddTask(task5);
        todoManager.AddTask(task6);
        todoManager.AddTask(task7);
        todoManager.AddTask(task8);
        todoManager.AddTask(task9);
        todoManager.AddTask(task10);

        
        todoManager.SortTasksByPriority();

        
        todoManager.PrintTasks();

        
        Console.WriteLine("\nEditing task 1...");
        todoManager.EditTask(task1, "Städa köket", 2);
        todoManager.PrintTasks();

       
        Console.WriteLine("\nMarking task 2 as completed...");
        todoManager.MarkTaskAsCompleted(task2);
        todoManager.PrintTasks();

        
        Console.WriteLine("\nTasks with priority between 3 and 7:");
        List<Task> tasksInRange = todoManager.GetTasksByPriorityRange(3, 7);
        foreach (var task in tasksInRange)
        {
            Console.WriteLine(task);
        }
    }
}
