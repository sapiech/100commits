namespace Fask.Shared.Abstraction.Core;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private bool _versionIncremented;
    private readonly List<IDomainEvent> _domainEvents = [];

    protected void AddEvent(IDomainEvent @event)
    {
        if (_domainEvents.Count != 0 && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
        }

        _domainEvents.Add(@event);
    }

    protected void ClearEvents()
    {
        _domainEvents.Clear();
    }

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}