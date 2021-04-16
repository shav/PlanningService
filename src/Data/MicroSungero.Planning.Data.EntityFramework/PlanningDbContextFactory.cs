using Microsoft.EntityFrameworkCore;
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

    #endregion

    #region IDbContextFactory

    public IDbContext Create()
    {
      return new PlanningDbContext(this.options, this.connectionSettings);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create database context factory of Planning module.
    /// </summary>
    /// <param name="options">Options.</param>
    /// <param name="connectionSettings">Database connection settings.</param>
    public PlanningDbContextFactory(DbContextOptions<PlanningDbContext> options, IDatabaseConnectionSettings connectionSettings = null)
    {
      this.options = options;
      this.connectionSettings = connectionSettings;
    }

    #endregion
  }
}
