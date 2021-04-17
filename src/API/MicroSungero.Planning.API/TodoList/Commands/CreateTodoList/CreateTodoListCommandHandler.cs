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
  public class CreateTodoListCommandHandler : ICommandHandler<CreateTodoListCommand, TodoListDto>
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
    public CreateTodoListCommandHandler(IUnitOfWorkScope unitOfWork, IEntityRepository<ITodoList> repository, IMapper mapper)
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
    /// <param name="query">CreateTodoList command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>New todo list.</returns>
    private async Task<ITodoList> HandleCore(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
      using (this.unitOfWork)
      {
        var todoList = this.repository.Create();
        this.Apply(todoList, command);

        if (command.NeedSave)
          await unitOfWork.SubmitChanges();

        return todoList;
      }
    }

    /// <summary>
    /// Apply TodoList properties from command to new instance of TodoList.
    /// </summary>
    /// <param name="todoList">New todo list.</param>
    /// <param name="command">CreateTodoList command.</param>
    private void Apply(ITodoList todoList, CreateTodoListCommand command)
    {
      todoList.Title = command.Title;
      todoList.Description = command.Description;
      todoList.AuthorId = command.AuthorId;
      todoList.Deadline = command.Deadline;
    }

    #endregion

    #region ICommandHandler

    public async Task<TodoListDto> Handle(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
      var todoList = await this.HandleCore(command, cancellationToken);
      return this.mapper.Map<TodoListDto>(todoList);
    }

    #endregion
  }
}