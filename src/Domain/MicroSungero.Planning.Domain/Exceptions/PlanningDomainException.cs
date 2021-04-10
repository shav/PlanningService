using System;
using MicroSungero.Kernel.Domain.Exceptions;

namespace MicroSungero.Planning.Domain.Exceptions
{
  /// <summary>
  /// Base domain exception for planning module.
  /// </summary>
  public class PlanningDomainException : DomainException
  {
    /// <summary>
    /// Create domain exception for planning module.
    /// </summary>
    public PlanningDomainException()
    {
    }

    /// <summary>
    /// Create domain exception for planning module.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public PlanningDomainException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Create domain exception for planning module.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Original exception.</param>
    public PlanningDomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
  }
}
