using System;
using System.Collections.Generic;
using GrafanaCli.Core.Builders;
using GrafanaCli.Core.Config;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevGrafanaUrlBuilder : IGrafanaUrlBuilder
  {
    private readonly Dictionary<string, string> _returnUrls;

    public DevGrafanaUrlBuilder(GrafanaCliConfig config)
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.DevGrafanaUrlBuilder) Add tests
      _returnUrls = config.DevConfig.UrlBuilderConfig;
    }

    // Interface methods
    public string ListAllDashboards(string query, int limit, int page)
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.SearchDashboards) Add tests
      if (_returnUrls.ContainsKey(nameof(ListAllDashboards)))
        return _returnUrls[nameof(ListAllDashboards)];

      throw new Exception("No URL override configured");
    }

    public string GetDashboard(string uid)
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.GetDashboard) Add tests
      if (_returnUrls.ContainsKey(nameof(GetDashboard)))
        return _returnUrls[nameof(GetDashboard)];

      throw new Exception("No URL override configured");
    }
  }
}
