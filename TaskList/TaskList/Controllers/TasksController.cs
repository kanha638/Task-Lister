using TaskList.Contracts.Task;
using TaskList.Models;
using TaskList.ServiceErrors;
using TaskList.Services.Tasks;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace TaskList.Controllers;

public class TasksController : ApiController
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
        ErrorOr<Task> requestToTaskResult = Task.From(request);

        if (requestToTaskResult.IsError)
        {
            return Problem(requestToTaskResult.Errors);
        }

        var task = requestToTaskResult.Value;
        ErrorOr<Created> createTaskResult = _taskService.CreateTask(task);

        return createTaskResult.Match(
            created => CreatedAtGetTask(task),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTask(Guid id)
    {
        ErrorOr<Task> getTaskResult = _taskService.GetTask(id);

        return getTaskResult.Match(
            task => Ok(MapTaskResponse(task)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTask(Guid id, UpsertTaskRequest request)
    {
        ErrorOr<task> requestToTaskResult = task.From(id, request);

        if (requestToTaskResult.IsError)
        {
            return Problem(requestToTaskResult.Errors);
        }

        var task = requestToTaskResult.Value;
        ErrorOr<UpsertedTask> upsertTaskResult = _taskService.UpsertTask(task);

        return upsertTaskResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetTask(task) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTask(Guid id)
    {
        ErrorOr<Deleted> deleteTaskResult = _taskService.DeleteTask(id);

        return deleteTaskResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static TaskResponse MapTaskResponse(Task task)
    {
        return new TaskResponse(
            task.Id,
            task.Name,
            task.Description,
            task.StartDateTime,
            task.EndDateTime,
            task.LastModifiedDateTime,
            task.Savory,
            task.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetTask(Task task)
    {
        return CreatedAtAction(
            actionName: nameof(GetTask),
            routeValues: new { id = task.Id },
            value: MapTaskResponse(task));
    }
}