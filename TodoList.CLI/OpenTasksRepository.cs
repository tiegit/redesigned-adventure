using System.Text.Json;

namespace TodoList.CLI;
public static class OpenTasksRepository
{
    private static string DirectoryName = "\\openTasks";
    public static bool Add(OpenTask newOpenTask)
    {
        Directory.CreateDirectory(DirectoryName);

        var json = JsonSerializer.Serialize(newOpenTask, new JsonSerializerOptions { WriteIndented = true });

        var fileName = $"{Guid.NewGuid()}.json";
        var filePath = Path.Combine(DirectoryName, fileName);
        File.WriteAllText(filePath, json);

        return true;
    }

    public static OpenTask[] Get()
    {
        var files = Directory.GetFiles(DirectoryName);

        var openTasks = new List<OpenTask>();

        foreach (var file in files)
        {
            var json = File.ReadAllText(file);
            var openTask = JsonSerializer.Deserialize<OpenTask>(json);

            if (openTask == null)
            {
                throw new Exception("OpenTask cannon be deserialized !!!");
            }
            openTasks.Add(openTask);
        }

        return openTasks.ToArray();
    }
}