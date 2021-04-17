using System.ComponentModel.DataAnnotations;
using MicroSungero.Kernel.API;
using MicroSungero.Planning.API.Models;

namespace MicroSungero.Planning.API.Queries
{
  /// <summary>
  /// Query to get todo list.
  /// </summary>
  public class GetTodoListQuery : IQuery<TodoListDto>
  {
    /// <summary>
    /// TodoList Id.
    /// </summary>
    [Required]
    public int TodoListId { get; set; }
  }
}
