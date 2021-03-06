using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MicroSungero.Kernel.API;
using MicroSungero.Kernel.Data;
using MicroSungero.Planning.API.Models;
using MicroSungero.Planning.Domain.Entities;

namespace MicroSungero.Planning.API.Queries
{
  /// <summary>
  /// Query handler to get todo list.
  /// </summary>
  public class GetTodoListQueryHandler : IQueryHandler<GetTodoListQuery, TodoListDto>
  {
    #region Properties and fields

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
    /// Create query handler.
    /// </summary>
    /// <param name="repository">TodoList repository.</param>
    /// <param name="mapper">Objects to DTO mapper.</param>
    public GetTodoListQueryHandler(IEntityRepository<ITodoList> repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handling query core logic.
    /// </summary>
    /// <param name="query">GetTodoList query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Todo list.</returns>
    private async Task<ITodoList> HandleCore(GetTodoListQuery query, CancellationToken cancellationToken)
    {
      return this.repository.GetById(query.TodoListId);
    }

    #endregion

    #region IQueryHandler

    public async Task<TodoListDto> Handle(GetTodoListQuery query, CancellationToken cancellationToken)
    {
      var todoList = await this.HandleCore(query, cancellationToken);
      return this.mapper.Map<TodoListDto>(todoList);
    }

    #endregion
  }
}