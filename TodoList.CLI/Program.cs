// See https://aka.ms/new-console-template for more information
using System.Text;
using TodoList.CLI;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.Unicode;

var openTasksRepository = new OpenTasksRepository();
{
    Console.WriteLine("Введите задачу");
    string? note = null;

    do
    {
        note = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(note));

    var openTask = new OpenTask();
    openTask.Note = note;
    openTask.CreatedDate = DateTimeOffset.UtcNow;
    
    openTasksRepository.Add(openTask);
}

{
    var openTasks = openTasksRepository.Get();

    var group = openTasks.GroupBy(x => new DateTime(x.CreatedDate.Year, x.CreatedDate.Month, x.CreatedDate.Day));
    foreach (var groupOfOpenTasks in group)
    {
        Console.WriteLine($"Текущие задачи на: {groupOfOpenTasks.Key: dd.MM.yyyy}");

        foreach (var openTask in groupOfOpenTasks.ToArray())
        {
            Console.WriteLine(openTask.Note);
        }
    }
}




