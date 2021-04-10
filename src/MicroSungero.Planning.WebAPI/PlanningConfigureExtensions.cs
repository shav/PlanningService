using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MicroSungero.Common.Utils;
using MicroSungero.WebAPI;

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
    public static void UsePlanningModule(this IServiceCollection services)
    {
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
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.API.Services),
        AppDomain.CurrentDomain.GetAssemblyByName(Planning.Module.AssemblyNames.API.Behaviors)
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
