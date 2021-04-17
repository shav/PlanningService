using System.ComponentModel.DataAnnotations;
using MicroSungero.Kernel.API;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Command that deletes todo list.
  /// </summary>
  public class DeleteTodoListCommand : ICommand
  {
    /// <summary>
    /// TodoList Id.
    /// </summary>
    [Required]
    public int TodoListId { get; set; }
  }
}
