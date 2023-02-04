using TaskList.Models;
using TaskList.ServiceErrors;
using ErrorOr;

namespace TaskList.Services.Tasks;

public class TaskService : ITaskService
{
    private static readonly Dictionary<Guid, Task> _tasks = new();

    public ErrorOr<Created> CreateBreakfast(Task task)
    {
        _tasks.Add(breakfast.Id, task);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _tasks.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<Task> GetBreakfast(Guid id)
    {
        if (_tasks.TryGetValue(id, out var task))
        {
            return task;
        }

        return Errors.Task.NotFound;
    }

    public ErrorOr<UpsertedTask> UpsertBreakfast(Task task)
    {
        var isNewlyCreated = !_tasks.ContainsKey(task.Id);
        _tasks[task.Id] = task;

        return new UpsertedTask(isNewlyCreated);
    }
}