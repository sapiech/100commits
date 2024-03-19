using Fask.Core.ValueObjects;
using Fask.Shared.Abstraction.Core;

namespace Fask.Core.Entities;

public sealed class TaskItem : AggregateRoot<Guid>
{
    private TaskName _name;
    private string _description;
    private TaskEffort _effort;
    
    private readonly IList<>
}