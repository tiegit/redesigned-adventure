using System.Diagnostics;
using TodoList.CLI.Operations;

namespace TodoList.CLI;

public class Application
{
    // меню с операциями
    private readonly Dictionary<string, IOperation> _menu;
    public Application()
    {
        _menu = new Dictionary<string, IOperation>
        {
            { "create", new CreateTaskOperation()},
            { "get", new GetTasksOperation()},
        };
    }

    public void Run(CancellationToken token)
    {
        Console.Clear();

        while (!token.IsCancellationRequested)
        {
            PrintMenu();
            var operationName = Console.ReadLine() ?? string.Empty;            

            if (!_menu.TryGetValue(operationName, out var operation) || operation == null)
            {   
                Console.WriteLine($"Комманды '{operationName}' не существует");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                Console.ReadKey(true);
                Console.Clear();
                continue;
            }
            operation.Invoke();            
        }
    }
    private void PrintMenu()
    {
        Console.WriteLine("_________________________________________");
        Console.WriteLine("Список доступных операций над задачами: ");
        foreach (var item in _menu)
        {
            Console.WriteLine($"- {item.Key}");
        }        
        Console.WriteLine("Введите 'Ctrl + C' чтобы выйти из программы");
    }
}
