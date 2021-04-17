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
  /// Command handler to update existing TodoList.
  /// </summary>
  public class UpdateTodoListCommandHandler : ICommandHandler<UpdateTodoListCommand, TodoListDto>
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
    public UpdateTodoListCommandHandler(IUnitOfWorkScope unitOfWork, IEntityRepository<ITodoList> repository, IMapper mapper)
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
    /// <param name="query">UpdateTodoList command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated todo list.</returns>
    private async Task<ITodoList> HandleCore(UpdateTodoListCommand command, CancellationToken cancellationToken)
    {
      using (this.unitOfWork)
      {
        var todoList = this.repository.GetById(command.TodoListId);
        this.Apply(todoList, command);
        this.repository.Update(todoList);

        if (command.NeedSave)
          await unitOfWork.SubmitChanges();

        return todoList;
      }
    }

    /// <summary>
    /// Apply changes from command to TodoList instance.
    /// </summary>
    /// <param name="todoList">Todo list for updating.</param>
    /// <param name="command">UpdateTodoList command.</param>
    private void Apply(ITodoList todoList, UpdateTodoListCommand command)
    {
      todoList.Title = command.Title;
      todoList.Description = command.Description;
      todoList.Deadline = command.Deadline;
    }

    #endregion

    #region ICommandHandler

    public async Task<TodoListDto> Handle(UpdateTodoListCommand command, CancellationToken cancellationToken)
    {
      var todoList = await this.HandleCore(command, cancellationToken);
      return this.mapper.Map<TodoListDto>(todoList);
    }

    #endregion
  }
}