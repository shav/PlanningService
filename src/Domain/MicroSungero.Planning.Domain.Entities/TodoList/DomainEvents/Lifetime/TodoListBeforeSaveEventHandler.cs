using System.Threading;
using System.Threading.Tasks;
using MicroSungero.Kernel.Domain.DomainEvents;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities.DomainEvents
{
  /// <summary>
  /// Hhandler of event raised before saving TodoList.
  /// </summary>
  public class TodoListBeforeSaveEventHandler : EntityBeforeSaveEventHandler<ITodoList>, IDomainEventHandler<EntityBeforeSaveEvent<ITodoList>>
  {
    /// <summary>
    /// Create handler of EntityBeforeSaveEvent raised for TodoList.
    /// </summary>
    /// <param name="validator">Entity validator.</param>
    public TodoListBeforeSaveEventHandler(IEntityValidationService<ITodoList> validator)
      : base(validator)
    {
    }

    /// <summary>
    /// Core logic of handling event raised before saving TodoList.
    /// </summary>
    /// <param name="domainEvent">Event raised before saving TodoList.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    protected override async Task HandleEventCore(EntityBeforeSaveEvent<ITodoList> domainEvent, CancellationToken cancellationToken)
    {
      var todoList = domainEvent.Entity;
    }
  }
}
