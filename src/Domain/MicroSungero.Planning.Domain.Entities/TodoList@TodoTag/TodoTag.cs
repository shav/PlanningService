using System;
using MicroSungero.Kernel.Domain.Entities;
using MicroSungero.System.Domain;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// User tag for Todo item.
  /// </summary>
  public class TodoTag : ChildEntity, ITodoTag, IChildEntity, IInternalChildEntity
  {
    #region Constants

    /// <summary>
    /// Type unique identifier.
    /// </summary>
    public static new readonly Guid ClassTypeGuid = Guid.Parse("093756A6-AE51-4B0E-8ED8-CD0E625927CD");

    #endregion

    #region IEntity

    public override Guid TypeGuid => ClassTypeGuid;

    public override string DisplayValue => this.Tag?.ToString() ?? base.DisplayValue;

    #endregion

    #region ITodoTag

    public IEntityTag Tag { get; set; }

    public ITodo Todo { get; private set; }

    #endregion

    #region Properties and fields

    /// <summary>
    /// Id of Todo item which has this tag.
    /// </summary>
    public int TodoId { get; private set; }

    #endregion

    #region IChildEntity

    public IEntity RootEntity
    {
      get { return this.Todo; }
      set { this.Todo = (ITodo)value; }
    }

    #endregion
  }
}
