using System.Threading;
using System.Threading.Tasks;
using MicroSungero.Kernel.Domain.DomainEvents;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities.DomainEvents
{
  /// <summary>
  /// Handler of event raised before deleting TodoList.
  /// </summary>
  public class TodoListBeforeDeleteEventHandler : EntityBeforeDeleteEventHandler<ITodoList>, IDomainEventHandler<EntityBeforeDeleteEvent<ITodoList>>
  {
    /// <summary>
    /// Create handler of EntityBeforeDeleteEvent raised for TodoList.
    /// </summary>
    /// <param name="validator">Entity validator.</param>
    public TodoListBeforeDeleteEventHandler(IEntityValidationService<ITodoList> validator)
      : base(validator)
    {
    }

    /// <summary>
    /// Core logic of handling event raised before deleting TodoList.
    /// </summary>
    /// <param name="domainEvent">Event raised before deleting TodoList.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected override async Task HandleEventCore(EntityBeforeDeleteEvent<ITodoList> domainEvent, CancellationToken cancellationToken)
    {
      var todoList = domainEvent.Entity;
    }
  }
}
