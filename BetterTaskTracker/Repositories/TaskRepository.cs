using System.Text.Json;

namespace TaskTracker.Repositories
{
    public class TaskRepository
    {
        private readonly string _path = "./tasks.json";
        private readonly JsonSerializerOptions _options =
            new() { WriteIndented = true };

        public List<Task> Load()
        {
            if (!File.Exists(_path))
                return new List<Task>();

            var json = File.ReadAllText(_path);
            return string.IsNullOrWhiteSpace(json)
                ? new List<Task>()
                : JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
        }

        public void Save(List<Task> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, _options);
            File.WriteAllText(_path, json);
        }
    }
}
