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

    public DevGrafanaUrlResponseBuilder WithListAllDashboards(string url)
    {
      // TODO: [TESTS] (DevGrafanaUrlResponseBuilder.WithListAllDashboards) Add tests
      _urls["ListAllDashboards"] = url;
      return this;
    }

    public Dictionary<string, string> Build()
    {
      return _urls;
    }
  }
}
