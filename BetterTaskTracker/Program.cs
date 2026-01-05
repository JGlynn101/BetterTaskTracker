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
            bool listUpdated = false;
            TaskManager taskManager = new TaskManager(taskRepository);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1 to Add Task\n2 to View Tasks\n3 to update a Task\n4 to Delete Tasks\n5 to exit program");
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
                    int taskChangeInteger = 0;
                    string taskChangeString = "";
                    Console.WriteLine("Insert ID of Task to Update");
                    int.TryParse(Console.ReadLine(), out taskId);
                    Console.WriteLine("1 to Change Name 2 to Change Status 3 to Change Description");
                    int.TryParse(Console.ReadLine(), out userResponse);
                    if(userResponse == 1)
                    {
                        taskChangeInteger = 1;
                        Console.WriteLine("Insert new Name");
                        taskChangeString = Console.ReadLine();
                        
                    }
                    if(userResponse == 2)
                    {
                        taskChangeInteger = 2;
                        Console.WriteLine("Insert 'ToDo' or 'In Progress'");
                        taskChangeString = Console.ReadLine();
                        if(taskChangeString != "ToDo" || taskChangeString != "In Progress")
                        {
                            while (taskChangeString != "ToDo" || taskChangeString != "In Progress")
                            {
                                Console.WriteLine("Incorrect Format. Please Try again.");
                                Console.WriteLine("Insert 'ToDo' or 'In Progress'");
                                taskChangeString = Console.ReadLine();
                            }
                        }
                    }
                    if(userResponse == 3)
                    {
                        taskChangeInteger = 3;
                        Console.WriteLine("Insert new Description");
                        taskChangeString = Console.ReadLine();
                    }
                    taskManager.Update(taskId, taskChangeInteger, taskChangeString);
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
            if (listUpdated)
            {
                taskManager.SaveTasks();
            }
       
            return;
        }
    }
}
