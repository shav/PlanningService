using System;
using System.Collections.Generic;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// Todo list.
  /// </summary>
  public interface ITodoList : IEntity
  {
    /// <summary>
    /// Title.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Author Id.
    /// </summary>
    int AuthorId { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    DateTime CreatedDate { get; set; }

    /// <summary>
    /// Deadline (end date until that this TodoList should be completed).
    /// </summary>
    DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that all items of this TodoList are completed.
    /// </summary>
    bool IsCompleted { get; set; }

    /// <summary>
    /// Completion date.
    /// </summary>
    DateTime? CompletedDate { get; set; }

    /// <summary>
    /// Collection of todo items.
    /// </summary>
    ICollection<ITodo> TodoItems { get; }
  }
}
