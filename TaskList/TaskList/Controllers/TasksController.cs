using Microsoft.AspNetCore.Mvc;
namespace TaskList.Controllers;

[ApiController]
public class TasksController : ControllerBase
{
    [HttpPost("/task")]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
        return ok(request);
    }
    [HttpGet("/task/{id:guid}")]
    public IActionResult GetTask(Guid id)
    {
        return ok(id);
    }
    [HttpPut("/task/{id:guid}")]
    public IActionResult UpsertTask(Guid id, UpsertTaskRequest request)
    {
        return ok(request);
    }

    [HttpDelete("/task/{id:guid}")]
    public IActionResult DeleteTask(Guid id)
    {
        return ok(id);
    }
}