using System.Collections.Generic;
using GrafanaCli.Core.Models;

namespace GrafanaCli.Core.Config
{
  public class DeveloperConfig
  {
    public bool Enabled { get; set; }
    public bool UseDevHttpClient { get; set; }
    public bool UseDevGrafanaUrlBuilder { get; set; }
    public List<DevHttpResponse> HttpClientResponses { get; set; }
    public Dictionary<string, string> UrlBuilderConfig { get; set; }

    public DeveloperConfig()
    {
      // TODO: [TESTS] (DeveloperConfig.DeveloperConfig) Add tests
      Enabled = false;
      UseDevHttpClient = false;
      UseDevGrafanaUrlBuilder = false;
      HttpClientResponses = new List<DevHttpResponse>();
      UrlBuilderConfig = new Dictionary<string, string>();
    }
  }
}
