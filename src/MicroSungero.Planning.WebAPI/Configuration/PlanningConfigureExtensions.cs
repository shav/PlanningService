using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroSungero.Common.Utils;
using MicroSungero.Planning.Data;
using MicroSungero.Planning.Data.EntityFramework;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.WebAPI;
using MicroSungero.WebAPI.Configuration;

namespace MicroSungero.Planning.WebAPI
{
  /// <summary>
  /// Extension methods for Planning module configuration.
  /// </summary>
  public static class PlanningConfigureExtensions
  {
    /// <summary>
    /// Use Planning module at the application.
    /// </summary>
    /// <param name="services">Dependency container.</param>
    /// <param name="configuration">App configuration.</param>
    public static void UsePlanningModule(this IServiceCollection services, IConfiguration configuration)
    {
      services.ConfigureDatabase<PlanningDbContext, PlanningDbContextFactory>(configuration);
      services.ConfigureRepository<TodoList, TodoListRepository>();
      services.ConfigureRepository<ITodoList, TodoListRepository>();

      var domainModules = new[]
      {
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Domain),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Domain.Abstractions),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Domain.Entities),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Domain.Services)
      };
      var apiModules = new[]
      {
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.API),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.API.Services)
      };
      var dataModules = new[]
      {
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Data),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Data.Abstractions),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.Data.EntityFramework)
      };
      services.ConfigureModules(new[] { domainModules, apiModules, dataModules }.SelectMany(module => module).ToArray());
    }
  }
}
