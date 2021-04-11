using System.Threading;
using System.Threading.Tasks;
using MicroSungero.Kernel.Domain.DomainEvents;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities.DomainEvents
{
  /// <summary>
  /// Hhandler of event raised after TodoList was deleted.
  /// </summary>
  public class TodoListDeletedEventHandler : EntityDeletedEventHandler<ITodoList>, IDomainEventHandler<EntityDeletedEvent<ITodoList>>
  {
    /// <summary>
    /// Create handler of EntityDeletedEvent raised for TodoList.
    /// </summary>
    /// <param name="validator">Entity validator.</param>
    public TodoListDeletedEventHandler(IEntityValidationService<ITodoList> validator)
      : base(validator)
    {
    }

    /// <summary>
    /// Core logic of handling event raised after TodoList was deleted.
    /// </summary>
    /// <param name="domainEvent">Event raised after TodoList was deleted.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected override async Task HandleEventCore(EntityDeletedEvent<ITodoList> domainEvent, CancellationToken cancellationToken)
    {
      var todoList = domainEvent.Entity;
    }
  }
}
