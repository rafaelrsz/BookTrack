using System.Reflection;

namespace BookTrack.Infra;
public static class AssemblyReference
{
  public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

}
