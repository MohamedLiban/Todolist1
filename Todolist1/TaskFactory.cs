namespace ToDoListApp
{
    public static class TaskFactory
    {
        public static Task CreateTask(string name, int priority)
        {
            return new Task(name, priority);
        }
    }
}
