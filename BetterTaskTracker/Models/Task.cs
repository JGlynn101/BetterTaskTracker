
using System.Runtime.InteropServices.Swift;

namespace TaskTracker
{
    
   public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "Todo";
    public bool Finished { get; set; }
    public bool Deleted { get; set; }

    public Task() {} 

    public Task(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
}