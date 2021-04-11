using System;
using MicroSungero.Kernel.Domain.Entities;
using MicroSungero.System.Domain;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// Todo list item.
  /// </summary>
  public class Todo : Entity, ITodo, IChildEntity, IInternalChildEntity
  {
    #region Constants

    /// <summary>
    /// Type unique identifier.
    /// </summary>
    public static new readonly Guid ClassTypeGuid = Guid.Parse("24AECA98-A713-4F61-A4C9-91FE129DE006");

    #endregion

    #region IEntity

    public override Guid TypeGuid => ClassTypeGuid;

    public override string DisplayValue => this.Title;

    #endregion

    #region ITodo

    public string Title { get; set; }

    public string Description { get; set; }

    public string Note { get; set; }

    public ITodoPriority Priority { get; set; }

    public IEntityTag Tag { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? PerformerId { get; set; }

    public DateTime? Deadline { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedDate { get; set; }

    public ITodoList TodoList { get; private set; }

    #endregion

    #region Properties and fields

    /// <summary>
    /// Id of TodoList which contains this todo item.
    /// </summary>
    public int TodoListId { get; private set; }

    #endregion

    #region IChildEntity

    public IEntity RootEntity
    {
      get { return this.TodoList; }
      set { this.TodoList = (ITodoList)value; }
    }

    #endregion
  }
}
