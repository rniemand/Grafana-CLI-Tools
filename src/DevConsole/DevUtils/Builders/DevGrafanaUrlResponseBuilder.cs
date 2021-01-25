using System.Collections.Generic;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevGrafanaUrlResponseBuilder
  {
    private readonly Dictionary<string, string> _urls;

    public DevGrafanaUrlResponseBuilder()
    {
      _urls = new Dictionary<string, string>();
    }

    public DevGrafanaUrlResponseBuilder WithSearchDashboards(string url)
    {
      // TODO: [TESTS] (DevGrafanaUrlResponseBuilder.WithSearchDashboards) Add tests
      _urls["SearchDashboards"] = url;
      return this;
    }

    public Dictionary<string, string> Build()
    {
      return _urls;
    }
  }
}
