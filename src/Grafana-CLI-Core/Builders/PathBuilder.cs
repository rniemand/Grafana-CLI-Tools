using GrafanaCli.Core.Config;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.Logging;

namespace GrafanaCli.Core.Builders
{
  public interface IPathBuilder
  {
    string BuildPath(string mask);
  }

  public class PathBuilder : IPathBuilder
  {
    private readonly ILoggerAdapter<PathBuilder> _logger;
    private readonly string _rootDirectory;

    public PathBuilder(
      ILoggerAdapter<PathBuilder> logger,
      IEnvironmentAbstraction environment,
      GrafanaCliConfig config)
    {
      // TODO: [TESTS] (PathBuilder.PathBuilder) Add tests
      _logger = logger;

      _rootDirectory = config.DataDirectory
        .Replace("./", environment.CurrentDirectory.AppendIfMissing("\\"))
        .AppendIfMissing("\\");
    }

    public string BuildPath(string mask)
    {
      // TODO: [TESTS] (PathBuilder.BuildPath) Add tests
      return mask
        .Replace("{root}", _rootDirectory)
        .Replace("./", _rootDirectory)
        .AppendIfMissing("\\");
    }
  }
}
