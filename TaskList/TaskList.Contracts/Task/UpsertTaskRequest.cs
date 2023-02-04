namespace TaskList.Contracts.Task;

public record UpsertTaskRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);