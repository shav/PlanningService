using System;
using AutoMapper;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.System.API.Models;

namespace MicroSungero.Planning.API.Models
{
  /// <summary>
  /// Todo item DTO.
  /// </summary>
  [AutoMap(sourceType: typeof(ITodo))]
  public class TodoDto
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
    /// Note (user comment for todo item).
    /// </summary>
    public string Note { get; set; }

    /// <summary>
    /// Priority.
    /// </summary>
    public string Priority { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// User tag.
    /// </summary>
    public EntityTagDto Tag { get; set; }

    /// <summary>
    /// Performer Id.
    /// </summary>
    public int? PerformerId { get; set; }

    /// <summary>
    /// Deadline.
    /// </summary>
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Indicates that todo item is completed.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Completion date.
    /// </summary>
    public DateTime? CompletedDate { get; set; }
  }
}
