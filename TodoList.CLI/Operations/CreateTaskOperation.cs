namespace TodoList.CLI.Operations;

public class CreateTaskOperation : IOperation
{
    public void Invoke()
    {
        Console.WriteLine("Введите задачу для добавления в список дел");
        string? note;

        do
        {
            note = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(note));

        var openTask = new OpenTask();
        openTask.Note = note;
        openTask.CreatedDate = DateTimeOffset.UtcNow;

        OpenTasksRepository.Add(openTask);
    }
}
