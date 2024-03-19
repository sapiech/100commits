namespace Fask.Core.ValueObjects;

public sealed record TaskName
{
    public string Value { get; }

    public TaskName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(TaskName name) => name.Value;
    public static implicit operator TaskName(string name) => new(name);
}
