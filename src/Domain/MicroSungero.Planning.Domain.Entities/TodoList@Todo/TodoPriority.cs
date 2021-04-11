using MicroSungero.Kernel.Domain;

namespace MicroSungero.Planning.Domain.Entities
{
  /// <summary>
  /// Todo item priority.
  /// </summary>
  public class TodoPriority : Enumeration, ITodoPriority
  {
    #region Enumeration items

    public static readonly TodoPriority Low = new TodoPriority(nameof(Low));

    public static readonly TodoPriority Normal = new TodoPriority(nameof(Normal));

    public static readonly TodoPriority High = new TodoPriority(nameof(High));

    #endregion

    #region Constructors

    /// <summary>
    /// Create todo item priority.
    /// </summary>
    /// <param name="value">Priority value.</param>
    public TodoPriority(string value)
      : base(value)
    {
    }

    #endregion
  }
}
