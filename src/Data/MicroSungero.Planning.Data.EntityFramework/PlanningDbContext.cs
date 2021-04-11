using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Kernel.Data;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Database context of Planning module.
  /// </summary>
  public class PlanningDbContext: BaseDbContext
  {
    #region DbContext

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create database context of Planning module.
    /// </summary>
    /// <param name="options">Options.</param>
    /// <param name="connectionSettings">Database connection settings.</param>
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options, IDatabaseConnectionSettings connectionSettings = null)
      : base(options, connectionSettings)
    {
    }

    #endregion
  }
}
