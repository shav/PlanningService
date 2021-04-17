using System;
using System.ComponentModel.DataAnnotations;
using MicroSungero.Kernel.API;
using MicroSungero.Planning.API.Models;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Command that updates existing todo list.
  /// </summary>
  public class UpdateTodoListCommand : ICommand<TodoListDto>
  {
    /// <summary>
    /// TodoList Id.
    /// </summary>
    [Required]
    public int TodoListId { get; set; }

    /// <summary>
    /// Title (optional).
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description (optional).
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Deadline (optional).
    /// </summary>
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that updated todo list should be immediatly saved to database.
    /// </summary>
    public bool NeedSave { get; set; } = false;
  }
}
