using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MicroSungero.Kernel.Data;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Database context factory of Planning module.
  /// </summary>
  public class PlanningDbContextFactory : IDbContextFactory
  {
    #region Properties and fields

    /// <summary>
    /// Database context options.
    /// </summary>
    private DbContextOptions<PlanningDbContext> options;

    /// <summary>
    /// Database connection settings.
    /// </summary>
    private IDatabaseConnectionSettings connectionSettings;

    /// <summary>
    /// Logger factory.
    /// </summary>
    private readonly ILoggerFactory logFactory;

    #endregion

    #region IDbContextFactory

    public IDbContext Create()
    {
      return new PlanningDbContext(this.options, this.logFactory, this.connectionSettings);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create database context factory of Planning module.
    /// </summary>
    /// <param name="options">Options.</param>
    /// <param name="logFactory">Logger factory.</param>
    /// <param name="connectionSettings">Database connection settings.</param>
    public PlanningDbContextFactory(DbContextOptions<PlanningDbContext> options, ILoggerFactory logFactory, IDatabaseConnectionSettings connectionSettings = null)
    {
      this.options = options;
      this.connectionSettings = connectionSettings;
      this.logFactory = logFactory;
    }

    #endregion
  }
}
