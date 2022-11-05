namespace TodoList.CLI.Operations;

public class GetTasksOperation : IOperation
{
    public void Invoke()
    {
        var openTasks = OpenTasksRepository.Get();

        var groups = openTasks
            .GroupBy(x => new DateTime(x.CreatedDate.Year, x.CreatedDate.Month, x.CreatedDate.Day));
            
        foreach (var groupOfOpenTasks in groups)
        {
            Console.WriteLine($"Текущие задачи на: {groupOfOpenTasks.Key: dd.MM.yyyy}");

            foreach (var openTask in groupOfOpenTasks.ToArray())
            {
                Console.WriteLine(openTask.Note);
            }
        }
    }
}
