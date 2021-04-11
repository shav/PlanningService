using MicroSungero.Kernel.Data;
using MicroSungero.Planning.Domain.Entities;

namespace MicroSungero.Planning.Data
{
  /// <summary>
  /// TodoList repository.
  /// </summary>
  public class TodoListRepository
    : BaseEntityInterfaceRepository<TodoList, ITodoList>, IEntityRepository<ITodoList>
  {
    #region Constructors

    /// <summary>
    /// Create TodoList repository.
    /// </summary>
    /// <param name="unitOfWorkContext">Unit-of-work context.</param>
    public TodoListRepository(IUnitOfWorkContext unitOfWorkContext)
      : base(unitOfWorkContext)
    {
    }

    #endregion
  }
}
