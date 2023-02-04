using ErrorOr;

namespace TaskList.ServiceErrors;

public static class Errors
{
    public static class Task
    {
        public static Error InvalidName => Error.Validation(
            code: "Task.InvalidName",
            description: $"Task name must be at least {Models.Task.MinNameLength}" +
                $" characters long and at most {Models.Task.MaxNameLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Task.InvalidDescription",
            description: $"Task description must be at least {Models.Task.MinDescriptionLength}" +
                $" characters long and at most {Models.Task.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found");
    }
}