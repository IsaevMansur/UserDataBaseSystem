namespace UserDBService.Sources.Utils;

public class Result<T>
{
    private Result(T? model, string error)
    {
        this.Model = model;
        this.Error = error;
    }

    public T? Model { get; }
    public string? Error { get; }
    public bool IsSuccess => !string.IsNullOrEmpty(Error);

    public static Result<T> Success(T value) => new(value, string.Empty);
    public static Result<T> Failure(string error) => new(default, error);


    public override string ToString()
    {
        return IsSuccess ? $"Success: {Model}" : $"Failure: {Error}";
    }
}