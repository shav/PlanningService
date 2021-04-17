using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroSungero.Kernel.API;
using MicroSungero.Kernel.Data;
using MicroSungero.Planning.API.Models;
using MicroSungero.Planning.Domain.Entities;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Command handler to create new TodoList.
  /// </summary>
  public class CreateNewTodoListCommandHandler : ICommandHandler<CreateNewTodoListCommand, TodoListDto>
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

    /// <summary>
    /// Objects to DTO mapper.
    /// </summary>
    private readonly IMapper mapper;

    #endregion

    #region Constructors

    /// <summary>
    /// Create command handler.
    /// </summary>
    /// <param name="unitOfWork">Unit-of-work.</param>
    /// <param name="repository">TodoList repository.</param>
    /// <param name="mapper">Objects to DTO mapper.</param>
    public CreateNewTodoListCommandHandler(IUnitOfWorkScope unitOfWork, IEntityRepository<ITodoList> repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handling command core logic.
    /// </summary>
    /// <param name="query">CreateNewTodoList command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>New todo list.</returns>
    public async Task<ITodoList> HandleCore(CreateNewTodoListCommand command, CancellationToken cancellationToken)
    {
      using (this.unitOfWork)
      {
        var todoList = this.repository.Create();
        todoList.Title = command.Title;
        todoList.Description = command.Description;
        todoList.AuthorId = command.AuthorId;
        todoList.Deadline = command.Deadline;

        if (command.NeedSave)
          await unitOfWork.SubmitChanges();

        return todoList;
      }
    }

    #endregion

    #region ICommandHandler

    public async Task<TodoListDto> Handle(CreateNewTodoListCommand command, CancellationToken cancellationToken)
    {
      var todoList = await this.HandleCore(command, cancellationToken);
      return this.mapper.Map<TodoListDto>(todoList);
    }

    #endregion
  }
}