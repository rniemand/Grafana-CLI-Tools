using System;
using System.Collections.Generic;
using GrafanaCli.Core.Builders;

namespace GrafanaCli.DevConsole.DevUtils.Builders
{
  public class DevGrafanaUrlBuilder : IGrafanaUrlBuilder
  {
    private readonly Dictionary<string, string> _returnUrls;

    public DevGrafanaUrlBuilder()
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.DevGrafanaUrlBuilder) Add tests

      _returnUrls = new Dictionary<string, string>();
    }

    // Interface methods
    public string ListAllDashboards()
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.ListAllDashboards) Add tests

      if (_returnUrls.ContainsKey(nameof(ListAllDashboards)))
        return _returnUrls[nameof(ListAllDashboards)];

      throw new Exception("No URL override configured");
    }

    // Configuration methods
    public void SetReturnUrl(string methodName, string url)
    {
      // TODO: [TESTS] (DevGrafanaUrlBuilder.SetReturnUrl) Add tests
      _returnUrls[methodName] = url;
    }
  }
}
