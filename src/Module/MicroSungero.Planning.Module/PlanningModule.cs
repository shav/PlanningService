using MicroSungero.ModuleInfo;

namespace MicroSungero.Planning
{
  /// <summary>
  /// Planning module info.
  /// </summary>
  public class Module : ModuleBase
  {
    /// <summary>
    /// Module name.
    /// </summary>
    public const string Name = "Planning";

    /// <summary>
    /// Module assemblies names.
    /// </summary>
    public static readonly ModuleAssemblyNames AssemblyNames = new ModuleAssemblyNames(Name);
  }
}
