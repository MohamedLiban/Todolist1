using System;
using System.Linq;

namespace ToDoListApp
{
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

            
            foreach (var task in todoManager.GetTasks())
            {
                Console.WriteLine(task);
            }

            
            todoManager.SortTasksByPriority();
            Console.WriteLine("\nSorted tasks:");
            foreach (var task in todoManager.GetTasks())
            {
                Console.WriteLine(task);
            }
        }
    }
}
