using System;
using System.Collections.Generic;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// Todo (TodoList item).
  /// </summary>
  public interface ITodo : IChildEntity
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
    /// Note (user comment for todo item).
    /// </summary>
    string Note { get; set; }

    /// <summary>
    /// Priority.
    /// </summary>
    Priority Priority { get; set; }

    /// <summary>
    /// Collection of user tags.
    /// </summary>
    ICollection<ITodoTag> Tags { get; }

    /// <summary>
    /// Creation date.
    /// </summary>
    DateTime CreatedDate { get; set; }

    /// <summary>
    /// Person that should perform this todo item. 
    /// By default it is author of TodoList.
    /// </summary>
    int? PerformerId { get; set; }

    /// <summary>
    /// Deadline (end date until that this todo item should be completed).
    /// </summary>
    DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that todo item is completed.
    /// </summary>
    bool IsCompleted { get; set; }

    /// <summary>
    /// Completion date.
    /// </summary>
    DateTime? CompletedDate { get; set; }

    /// <summary>
    /// Reference to TodoList which contains this todo item.
    /// </summary>
    ITodoList TodoList { get; }
  }
}
