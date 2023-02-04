using TaskList.Models;
using ErrorOr;

namespace TaskList.Services.Tasks;

public interface ITaskService
{
    ErrorOr<Created> CreateTask(Task task);
    ErrorOr<Task> GetTask(Guid id);
    ErrorOr<UpsertedTask> UpsertTask(Task task);
    ErrorOr<Deleted> DeleteTask(Guid id);
}