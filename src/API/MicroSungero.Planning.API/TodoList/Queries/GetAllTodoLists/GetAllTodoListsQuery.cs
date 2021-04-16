using System.Collections.Generic;
using MicroSungero.Kernel.API;
using MicroSungero.Planning.API.Models;

namespace MicroSungero.Planning.API.Queries
{
  /// <summary>
  /// Query to get all TodoLists.
  /// </summary>
  public class GetAllTodoListsQuery : IQuery<IEnumerable<TodoListDto>>
  {
  }
}
