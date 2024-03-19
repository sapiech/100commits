namespace Fask.Core.ValueObjects;

public record TaskEffort
{
    public ushort Value { get; }

    public TaskEffort(ushort value)
    {
        if (value == 0)
        {
            throw new ArgumentException(value.ToString());
        }
        
        Value = value;
    }

    public static implicit operator ushort(TaskEffort effort) => effort.Value;
    public static implicit operator TaskEffort(ushort name) => new(name);
}