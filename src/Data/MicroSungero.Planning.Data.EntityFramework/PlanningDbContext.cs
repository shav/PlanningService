using Microsoft.EntityFrameworkCore;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Kernel.Data;
using Microsoft.Extensions.Logging;

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
      
      modelBuilder.ApplyConfiguration(new TodoListTableMapping(this.ConnectionSettings));
      modelBuilder.ApplyConfiguration(new TodoTableMapping(this.ConnectionSettings));
      modelBuilder.ApplyConfiguration(new TodoTagTableMapping(this.ConnectionSettings));
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create database context of Planning module.
    /// </summary>
    /// <param name="options">Options.</param>
    /// <param name="logFactory">Logger factory.</param>
    /// <param name="connectionSettings">Database connection settings.</param>
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options, ILoggerFactory logFactory, IDatabaseConnectionSettings connectionSettings = null)
      : base(options, logFactory, connectionSettings)
    {
    }

    #endregion
  }
}
