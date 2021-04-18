using System;
using System.Collections.Generic;
using MicroSungero.Kernel.Domain.Entities;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// Todo items list.
  /// </summary>
  public class TodoList : Entity, ITodoList, IAggregateRoot
  {
    #region Constants

    /// <summary>
    /// Type unique identifier.
    /// </summary>
    public static new readonly Guid ClassTypeGuid = Guid.Parse("1617D55F-BE3B-4BE8-998E-C762582B91F5");

    #endregion

    #region IEntity

    public override Guid TypeGuid => ClassTypeGuid;

    public override string DisplayValue => this.Title;

    #endregion

    #region ITodoList

    public string Title { get; set; }

    public string Description { get; set; }

    public int AuthorId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? Deadline { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedDate { get; set; }

    public ICollection<ITodo> TodoItems => todoItems;

    #endregion

    #region Properties and fields

    /// <summary>
    /// Todo items collection.
    /// </summary>
    private List<ITodo> todoItems = new List<ITodo>();

    #endregion
  }
}
