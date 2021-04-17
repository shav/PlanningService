using System.Collections.Generic;
using System.Linq;
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
  /// Query handler to get all TodoLists.
  /// </summary>
  public class GetAllTodoListsQueryHandler : IQueryHandler<GetAllTodoListsQuery, IEnumerable<TodoListDto>>
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
    public GetAllTodoListsQueryHandler(IEntityRepository<ITodoList> repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handling query core logic.
    /// </summary>
    /// <param name="query">GetAllTodoLists query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>All TodoLists collection.</returns>
    public async Task<IEnumerable<ITodoList>> HandleCore(GetAllTodoListsQuery query, CancellationToken cancellationToken)
    {
      return this.repository.GetAll().ToList();
    }

    #endregion

    #region IQueryHandler

    public async Task<IEnumerable<TodoListDto>> Handle(GetAllTodoListsQuery query, CancellationToken cancellationToken)
    {
      var todoLists = await this.HandleCore(query, cancellationToken);
      return todoLists
        .Select(todoList => this.mapper.Map<TodoListDto>(todoList))
        .ToList();
    }

    #endregion
  }
}