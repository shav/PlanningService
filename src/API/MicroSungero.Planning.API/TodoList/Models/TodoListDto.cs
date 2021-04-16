using System;
using System.Collections.Generic;
using AutoMapper;
using MicroSungero.Planning.Domain.Entities;

namespace MicroSungero.Planning.API.Models
{
  /// <summary>
  /// Todo list DTO.
  /// </summary>
  [AutoMap(sourceType: typeof(ITodoList))]
  public class TodoListDto
  {
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Type unique identifier.
    /// </summary>
    public Guid TypeGuid { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Author Id.
    /// </summary>
    public int AuthorId { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Dealine.
    /// </summary>
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that all items of this TodoList are completed.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Completion date.
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// Collection of todo items.
    /// </summary>
    public IEnumerable<TodoDto> TodoItems { get; }
  }
}
