using System.Threading;
using System.Threading.Tasks;
using MicroSungero.Kernel.Domain.DomainEvents;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities.DomainEvents
{
  /// <summary>
  /// Hhandler of event raised after TodoList was saved.
  /// </summary>
  public class TodoListSavedEventHandler : EntitySavedEventHandler<ITodoList>, IDomainEventHandler<EntitySavedEvent<ITodoList>>
  {
    /// <summary>
    /// Create handler of EntitySavedEvent raised for TodoList.
    /// </summary>
    /// <param name="validator">Entity validator.</param>
    public TodoListSavedEventHandler(IEntityValidationService<ITodoList> validator)
      : base(validator)
    {
    }

    /// <summary>
    /// Core logic of handling event raised after TodoList was saved.
    /// </summary>
    /// <param name="domainEvent">Event raised after TodoList was saved.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected override async Task HandleEventCore(EntitySavedEvent<ITodoList> domainEvent, CancellationToken cancellationToken)
    {
      var todoList = domainEvent.Entity;
    }
  }
}
