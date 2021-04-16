using MicroSungero.Kernel.Domain;

namespace MicroSungero.Planning.Domain
{
  /// <summary>
  /// Priority.
  /// </summary>
  public class Priority : Enumeration
  {
    #region Enumeration items

    public static readonly Priority Low = new Priority(nameof(Low));

    public static readonly Priority Normal = new Priority(nameof(Normal));

    public static readonly Priority High = new Priority(nameof(High));

    #endregion

    #region Constructors

    /// <summary>
    /// Create priority.
    /// </summary>
    /// <param name="value">Priority value.</param>
    public Priority(string value)
      : base(value)
    {
    }

    #endregion
  }
}
