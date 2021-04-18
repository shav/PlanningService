using MicroSungero.Kernel.Domain.Entities;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.System.Domain;

namespace MicroSungero.Planning.Domain
{
  /// <summary>
  /// User tag for Todo item.
  /// </summary>
  public interface ITodoTag: IChildEntity
  {
    /// <summary>
    /// User tag.
    /// </summary>
    IEntityTag Tag { get; set; }

    /// <summary>
    /// Reference to Todo item which has this tag.
    /// </summary>
    ITodo Todo { get; }
  }
}
