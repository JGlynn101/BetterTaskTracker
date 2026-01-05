using System.IO;
using TaskTracker;
using System.Text.Json;
using System.Security.Authentication.ExtendedProtection;
using TaskTracker.Repositories;

namespace TaskTracker
{
    class Program()
    {
        static void Main()
        {
            TaskRepository taskRepository = new TaskRepository{};
            int taskId;
            int userResponse;
            bool listUpdated;
            TaskManager taskManager = new TaskManager(taskRepository);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Insert 1 to Add Task\n2 to View Tasks\n3 to update a Task\n4 to Delete Tasks\n5 to exit program");
                int.TryParse(Console.ReadLine(), out userResponse);
                if (userResponse == 1) // Add task
                {
                    Console.WriteLine("Insert Name of Task");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Insert Description of Task");
                    string? description = Console.ReadLine();
                    taskManager.Add(name, description);
                    listUpdated = true;
                }
                else if (userResponse == 2) //View Tasks
                {
                    Console.WriteLine("1 to View All tasks\n2 to View Finished tasks\n3 to view Unfinished tasks\n 4 for Tasks in progress");
                    int.TryParse(Console.ReadLine(), out userResponse);
                    if(userResponse == 1)
                    {
                        taskManager.List();
                    }
                    if(userResponse == 2)
                    {
                        taskManager.ListFinishedTasks();
                    }
                    if(userResponse == 3)
                    {
                        taskManager.ListUnfinishedTasks();
                    }
                    if(userResponse == 4)
                    {
                        taskManager.ListInProgressTasks();
                    }
                }
                else if (userResponse == 3) //Update Task
                {
                    Console.WriteLine("Insert ID of Task to Update");
                    int.TryParse(Console.ReadLine(), out taskId);
                    Console.WriteLine("Insert new Description");
                    string descriptionString = Console.ReadLine();
                    taskManager.Update(taskId, descriptionString);
                    listUpdated = true;
                }
                else if (userResponse == 4) //Delete Task
                {
                    Console.WriteLine("Insert ID of Task to Delete");
                    int.TryParse(Console.ReadLine(), out taskId);
                    taskManager.Delete(taskId);
                    listUpdated = true;
                }
                else if(userResponse == 5)
                {
                    flag = false;
                }
            }
            taskManager.SaveTasks();
            return;
        }
    }
}
