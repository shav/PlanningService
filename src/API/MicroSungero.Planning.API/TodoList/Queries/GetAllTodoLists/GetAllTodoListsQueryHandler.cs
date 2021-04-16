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

    /// <summary>
    /// Create query handler.
    /// </summary>
    /// <param name="unitOfWork">Unit-of-work.</param>
    /// <param name="repository">TodoList repository.</param>
    /// <param name="mapper">Objects to DTO mapper.</param>
    public GetAllTodoListsQueryHandler(IUnitOfWorkScope unitOfWork, IEntityRepository<ITodoList> repository, IMapper mapper)
    {
      this.unitOfWork = unitOfWork;
      this.repository = repository;
      this.mapper = mapper;
    }

    #region IQueryHandler

    public async Task<IEnumerable<TodoListDto>> Handle(GetAllTodoListsQuery query, CancellationToken cancellationToken)
    {
      using (this.unitOfWork)
      {
        return this.repository.GetAll()
          .Select(todo => this.mapper.Map<TodoListDto>(todo))
          .ToList();
      }
      return Enumerable.Empty<TodoListDto>();
    }

    #endregion
  }
}
