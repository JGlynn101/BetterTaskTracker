using System.Text.Json;
using System.IO;
using System.Runtime.InteropServices;
using TaskTracker.Repositories;
namespace TaskTracker
{
    public class TaskManager
    {
        private readonly TaskRepository _repo;
        public List<Task> Tasks { get; }
        public int NextId { get; private set; }
        public TaskManager(TaskRepository repo)
        {
            _repo = repo;
            Tasks = _repo.Load();
            NextId = Tasks.Count == 0 ? 1 : Tasks.Max(t => t.Id) + 1;
        }
        public void Add(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Task name cannot be empty");
            }
            Tasks.Add(new Task(NextId++, name, description));
            _repo.Save(Tasks);

        }
        public void Delete(int id)
        {
           var task = Tasks.FirstOrDefault(t => t.Id == id);
           if(task != null)
            {
                Tasks.Remove(task);
                _repo.Save(Tasks);
            }
        }
        public void Update(int id, int fieldInteger, string userTaskChange)
        {
            if(id >= 1){
                var task = Tasks.FirstOrDefault(t => t.Id == id);
                if(userTaskChange != ""){
                    if(fieldInteger == 1)
                    {
                        task.Name = userTaskChange;
                    }
                    if(fieldInteger == 2)
                    {
                        task.Status = userTaskChange;
                    }
                    if(fieldInteger == 3)
                    {
                        task.Description = userTaskChange;
                    }
                }
            }
        }
        public void List()
        {
            Console.WriteLine("Tasks\nId\tName\tDescription\tStatus");
            Console.WriteLine("-------------------------------");
            foreach(Task task in Tasks){
                if(!task.Deleted){
                    Console.WriteLine($"{task.Id}\t{task.Name}\t{task.Description}\t{task.Status}");
                }
            }
        }
        public void ListFinishedTasks()
        {
            Console.WriteLine("Completed Tasks\nId\tName\tDescription\tStatus");
            Console.WriteLine("-------------------------------");
            foreach (Task task in Tasks)
            {
                if(task.Finished && !task.Deleted)
                {
                    Console.WriteLine($"{task.Id}\t{task.Name}\t{task.Description}\t{task.Status}");  
                }
            }
        }
        public void ListUnfinishedTasks()
        {
            Console.WriteLine("Unfinished Tasks\nId\tName\tDescription\tStatus");
            Console.WriteLine("-------------------------------");
            foreach (Task task in Tasks)
            {
                if(!task.Finished && !task.Deleted)
                {
                    Console.WriteLine($"{task.Id}\t{task.Name}\t{task.Description}\t{task.Status}");  
                }
            }
        }
        public void ListInProgressTasks()
        {
            Console.WriteLine("In Progress Tasks\nId\tName\tDescription\tStatus");
            Console.WriteLine("-------------------------------");
            foreach (Task task in Tasks)
            {
                if(task.Status == "In Progress" && !task.Deleted)
                {
                    Console.WriteLine($"{task.Id}\t{task.Name}\t{task.Description}\t{task.Status}");  
                }
            }
        }
        public void SaveTasks()
        {
            _repo.Save(Tasks);
        }

    }
}