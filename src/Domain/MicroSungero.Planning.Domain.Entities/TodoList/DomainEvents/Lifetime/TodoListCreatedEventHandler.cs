using System.Threading;
using System.Threading.Tasks;
using MicroSungero.Kernel.Domain.DomainEvents;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities.DomainEvents
{
  /// <summary>
  /// Hhandler of event raised after new TodoList was created.
  /// </summary>
  public class TodoListCreatedEventHandler : EntityCreatedEventHandler<ITodoList>, IDomainEventHandler<EntityCreatedEvent<ITodoList>>
  {
    /// <summary>
    /// Create handler of EntityCreatedEvent raised for TodoList.
    /// </summary>
    /// <param name="validator">Entity validator.</param>
    public TodoListCreatedEventHandler(IEntityValidationService<ITodoList> validator)
      : base(validator)
    {
    }

    /// <summary>
    /// Core logic of handling event raised after new TodoList was created.
    /// </summary>
    /// <param name="domainEvent">Event raised after TodoList was created.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected override async Task HandleEventCore(EntityCreatedEvent<ITodoList> domainEvent, CancellationToken cancellationToken)
    {
      var todoList = domainEvent.Entity;
    }
  }
}
