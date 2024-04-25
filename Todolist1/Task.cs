namespace ToDoListApp
{
    public class Task
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string name, int priority)
        {
            Name = name;
            Priority = priority;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"Task: {Name}, Priority: {Priority}, Completed: {IsCompleted}";
        }
    }
}
