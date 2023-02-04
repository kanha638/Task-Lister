namespace TaskList.Contracts.Task;

public record CreateTask(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> tags);