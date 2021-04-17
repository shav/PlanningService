using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroSungero.Kernel.API;
using MicroSungero.Planning.API.Commands;
using MicroSungero.Planning.API.Models;
using MicroSungero.Planning.API.Queries;

namespace MicroSungero.Planning.WebAPI.Controllers
{
  /// <summary>
  /// Controller for managing todo lists.
  /// </summary>
  [Produces("application/json")]
  [ApiController]
  [Route("[controller]")]
  public class TodoListController : ControllerBase
  {
    #region Properties and fields

    /// <summary>
    /// Service that executes queries.
    /// </summary>
    private readonly IQueryService queryService;

    /// <summary>
    /// Service that executes commands.
    /// </summary>
    private readonly ICommandService commandService;

    #endregion

    #region WebAPI methods

    /// <summary>
    /// Get all TodoLists.
    /// </summary>
    [HttpGet]
    [Route("All")]
    public async Task<IEnumerable<TodoListDto>> GetAll()
    {
      return await this.queryService.Execute(new GetAllTodoListsQuery());
    }

    /// <summary>
    /// Get TodoList by Id.
    /// </summary>
    /// <param name="id">Id of TodoList.</param>
    [HttpGet]
    [Route("{id}")]
    public async Task<TodoListDto> Get(int id)
    {
      var getTodoListQuery = new GetTodoListQuery() { TodoListId = id };
      return await this.queryService.Execute(getTodoListQuery);
    }

    /// <summary>
    /// Create new TodoList.
    /// </summary>
    [HttpPost]
    [Route("Create")]
    public async Task<TodoListDto> Create(CreateNewTodoListCommand command)
    {
      return await this.commandService.Execute(command);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create controller for managing todo lists.
    /// </summary>
    /// <param name="queryService">Service that executes queries.</param>
    /// <param name="commandService">Service that executes commands.</param>
    public TodoListController(IQueryService queryService, ICommandService commandService)
    {
      this.queryService = queryService;
      this.commandService = commandService;
    }

    #endregion
  }
}
