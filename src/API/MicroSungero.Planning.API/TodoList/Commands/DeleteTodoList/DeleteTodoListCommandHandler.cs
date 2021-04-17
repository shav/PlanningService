using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroSungero.Kernel.API;
using MicroSungero.Kernel.Data;
using MicroSungero.Planning.Domain.Entities;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Command handler to delete TodoList.
  /// </summary>
  public class DeleteTodoListCommandHandler : ICommandHandler<DeleteTodoListCommand>
  {
    #region Properties and fields

    /// <summary>
    /// Unit-of-work.
    /// </summary>
    private readonly IUnitOfWorkScope unitOfWork;

    /// <summary>
    /// TodoList repository.
    /// </summary>
    private readonly IEntityRepository<ITodoList> repository;

    #endregion

    #region Constructors

    /// <summary>
    /// Create command handler.
    /// </summary>
    /// <param name="unitOfWork">Unit-of-work.</param>
    /// <param name="repository">TodoList repository.</param>
    public DeleteTodoListCommandHandler(IUnitOfWorkScope unitOfWork, IEntityRepository<ITodoList> repository)
    {
      this.repository = repository;
      this.unitOfWork = unitOfWork;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handling command core logic.
    /// </summary>
    /// <param name="query">DeleteTodoList command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task<Unit> HandleCore(DeleteTodoListCommand command, CancellationToken cancellationToken)
    {
      using (this.unitOfWork)
      {
        var todoList = this.repository.GetById(command.TodoListId);
        this.repository.Delete(todoList);
        
        await unitOfWork.SubmitChanges();
      }
      return await Unit.Task;
    }

    #endregion

    #region ICommandHandler

    public async Task<Unit> Handle(DeleteTodoListCommand command, CancellationToken cancellationToken)
    {
      return await this.HandleCore(command, cancellationToken);
    }

    #endregion
  }
}