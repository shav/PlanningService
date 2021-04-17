using System;
using System.ComponentModel.DataAnnotations;
using MicroSungero.Kernel.API;
using MicroSungero.Planning.API.Models;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Command that creates new todo list.
  /// </summary>
  public class CreateTodoListCommand : ICommand<TodoListDto>
  {
    /// <summary>
    /// Title (optional).
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description (optional).
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Author Id.
    /// </summary>
    [Required]
    public int AuthorId { get; set; }

    /// <summary>
    /// Deadline (optional).
    /// </summary>
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that created todo list should be immediatly saved to database.
    /// </summary>
    public bool NeedSave { get; set; } = false;
  }
}
